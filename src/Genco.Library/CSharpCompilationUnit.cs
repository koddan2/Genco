namespace Genco.Library;

public static class CSharpCompilationUnit
{
    public record InvocationParameterViewModel(InvicationParameterDefinition Definition)
    {
        public string? ParameterName => Definition.Name;
        public string? ParameterTypeSyntax => Definition.Type;
    }

    public static InvocationParameterViewModel ToViewModel(
        this InvicationParameterDefinition recordParameterDefinition
    ) => new(recordParameterDefinition);

    public record RecordViewModel(GencoConfigurationRecordElement Element)
    {
        public string ParameterListSyntax => FormatParameterList(Element.ParameterList);
        public IEnumerable<InvocationParameterViewModel> Parameters =>
            Element.ParameterList.Select(x => x.ToViewModel());
    }

    public static RecordViewModel ToViewModel(this GencoConfigurationRecordElement element) =>
        new(element);

    public record PropertyViewModel(PropertyDefinition PropertyDefinition)
    {
        public string? PropertyName => PropertyDefinition.Name;
        public string? PropertyAttributeSyntax =>
            PropertyDefinition.Attributes is not null ? $"[{PropertyDefinition.Attributes}]" : null;
        public string? PropertyTypeSyntax => PropertyDefinition.Type;
        public string? PropertySetterSyntax =>
            PropertyDefinition.Setter is null ? "" : $" {PropertyDefinition.Setter};";
        public string? PropertyDefaultValueSyntax =>
            PropertyDefinition.DefaultValue is null ? "" : $" = {PropertyDefinition.DefaultValue};";
        public bool PropertyIsAssignable => PropertyDefinition.Setter == "set";
        public bool PropertyIsNullable =>
            PropertyDefinition.Type?.StartsWith("Nullable<") is true
            || PropertyDefinition.Type?.EndsWith("?") is true;
        public bool PropertyIsNotNull => !PropertyIsNullable;
    }

    public static PropertyViewModel ToViewModel(this PropertyDefinition propertyDefinition) =>
        new(propertyDefinition);

    public record ConstructorViewModel(GencoConfigurationConstructorElement Element)
    {
        public IEnumerable<InvocationParameterViewModel> Parameters
            => Element.ParameterList.Select(x => x.ToViewModel());
        public string? ParameterListSyntax => FormatParameterList(Element.ParameterList);
        public string? CustomCodeSyntax => Element.CustomCode;
    }

    public static ConstructorViewModel ToViewModel(
        this GencoConfigurationConstructorElement element
    ) => new(element);

    public record UsingsViewModel(HashSet<string> Usings)
    {
        public IEnumerable<string> Syntaxes => Usings.Select(u => $"using {u};");
    }

    public record CodeFileViewModel(
        GencoConfiguration Configuration,
        UsingsViewModel Usings,
        string Namespace,
        string ModelTypeName,
        string ModelTypeSyntax,
        RecordViewModel? Record,
        IEnumerable<PropertyViewModel> Properties,
        IEnumerable<ConstructorViewModel> Constructors
    )
    {
        public bool NullableEnable { get; set; } = true;
        public string? FileHeader { get; set; }

        private bool HasRecord => Record is not null;
        public bool HasDefaultConstructor =>
            (!HasRecord || Record?.Parameters.Any() is false)
            && (!Constructors.Any() || Constructors.Any(ctor => !ctor.Parameters.Any()));
    }

    public static CodeFileViewModel FromConfiguration(GencoConfiguration cfg)
    {
        var viewModel = new CodeFileViewModel(
            Configuration: cfg,
            Usings: new UsingsViewModel(cfg.Usings.ToHashSet()),
            Namespace: cfg.Namespace.Default(FileResolver.ResolveNamespace(cfg)),
            ModelTypeName: cfg.Name.Default(FileResolver.ResolveFilename(cfg)),
            ModelTypeSyntax: cfg.Type.Default("record"),
            Record: cfg.Record?.ToViewModel(),
            Properties: cfg.Properties.Select(x => x.ToViewModel()),
            Constructors: cfg.Constructors.Select(x => x.ToViewModel())
        );

        if (cfg.FileHeader is not null)
        {
            viewModel.FileHeader = cfg.FileHeader;
        }
        else
        {
            viewModel.FileHeader = "";
        }

        if (cfg.FileHeaderInclude is not null)
        {
            var includeFile = FileResolver.ResolveRelativeTo(
                cfg.PathToConfigurationFile,
                cfg.FileHeaderInclude
            );
            cfg.FileHeader += Environment.NewLine;
            viewModel.FileHeader += File.ReadAllText(includeFile);
        }

        ////if (cfg.Constructor is not null)
        ////{
        ////    viewModel.Constructor
        ////}

        return viewModel;
    }

    private static string FormatParameterList(
        IEnumerable<InvicationParameterDefinition> recordParameterList
    )
    {
        static string RenderParameter(InvicationParameterDefinition p)
        {
            var result = "";
            if (p.Attributes.Any())
            {
                result = $"[property: {string.Join(", ", p.Attributes)}] {p.Type} {p.Name}";
            }
            else
            {
                result = $"{p.Type} {p.Name}";
            }

            if (p.DefaultValue is not null)
            {
                result += $" = {p.DefaultValue}";
            }

            return result;
        }

        var elements = recordParameterList.Select(RenderParameter);
        var listContents = string.Join(", ", elements);
        var result = $"({listContents})";
        return result;
    }
}
