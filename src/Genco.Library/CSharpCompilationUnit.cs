namespace Genco.Library;

public static class CSharpCompilationUnit
{
    public record RecordParameterViewModel(RecordParameterDefinition Definition)
    {
        public string? ParameterName => Definition.Name;
        public string? ParameterTypeSyntax => Definition.Type;
    }
    public static RecordParameterViewModel ToViewModel(this RecordParameterDefinition recordParameterDefinition)
        => new(recordParameterDefinition);
    public record RecordViewModel(GencoConfigurationRecordElement Element)
    {
        public string ParameterListSyntax => FormatParameterList(Element.ParameterList);
        public IEnumerable<RecordParameterViewModel> Parameters => Element.ParameterList.Select(x => x.ToViewModel());
    }
    public static RecordViewModel ToViewModel(this GencoConfigurationRecordElement element)
        => new(element);

    public record PropertyViewModel(PropertyDefinition PropertyDefinition)
    {
        public string? PropertyName => PropertyDefinition.Name;
        public string? PropertyAttributeSyntax => PropertyDefinition.Attributes is not null
            ? $"[{PropertyDefinition.Attributes}]" : null;
        public string? PropertyTypeSyntax => PropertyDefinition.Type;
        public string? PropertySetterSyntax => PropertyDefinition.Setter is null ? "" : $" {PropertyDefinition.Setter};";
        public string? PropertyDefaultValueSyntax => PropertyDefinition.DefaultValue is null ? "" : $" = {PropertyDefinition.DefaultValue};";
        public bool PropertyIsAssignable => PropertyDefinition.Setter == "set";
        public bool PropertyIsNullable => PropertyDefinition.Type?.StartsWith("Nullable<") is true || PropertyDefinition.Type?.EndsWith("?") is true;
        public bool PropertyIsNotNull => !PropertyIsNullable;
    }
    public static PropertyViewModel ToViewModel(this PropertyDefinition propertyDefinition)
        => new(propertyDefinition);

    public record UsingsViewModel(HashSet<string> Usings)
    {
        public IEnumerable<string> Syntaxes => Usings.Select(u => $"using {u};");
    }

    public record ViewModel(
        GencoConfiguration Configuration,
        UsingsViewModel Usings,
        string Namespace,
        string ModelTypeName,
        string ModelTypeSyntax,
        RecordViewModel Record,
        IEnumerable<PropertyViewModel> Properties)
    {
        public bool NullableEnable { get; set; } = true;
        public string? FileHeader { get; set; }

        public bool HasDefaultConstructor => Record.Element.ParameterList.Count == 0 && Configuration.Constructor is null;
    }

    public static ViewModel FromConfiguration(GencoConfiguration cfg)
    {
        var viewModel = new ViewModel(
            Configuration: cfg,
            Usings: new UsingsViewModel(cfg.Usings.ToHashSet()),
            Namespace: cfg.Namespace.Default(FileResolver.ResolveNamespace(cfg)),
            ModelTypeName: cfg.Name.Default(FileResolver.ResolveFilename(cfg)),
            ModelTypeSyntax: cfg.Type.Default("record"),
            Record: cfg.Record.ToViewModel(),
            Properties: cfg.Properties.Select(x => x.ToViewModel()));

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
            var includeFile = FileResolver.ResolveRelativeTo(cfg.PathToConfigurationFile, cfg.FileHeaderInclude);
            cfg.FileHeader += Environment.NewLine;
            viewModel.FileHeader += File.ReadAllText(includeFile);
        }

        ////if (cfg.Constructor is not null)
        ////{
        ////    viewModel.Constructor
        ////}

        return viewModel;
    }

    private static string FormatParameterList(IEnumerable<RecordParameterDefinition> recordParameterList)
    {
        static string RenderParameter(RecordParameterDefinition p)
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
