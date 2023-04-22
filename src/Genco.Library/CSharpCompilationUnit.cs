namespace Genco.Library;

public static class CSharpCompilationUnit
{
    public record ViewModel(
        GencoConfiguration Configuration,
        string Namespace,
        string TypeName,
        string TypeSyntax,
        HashSet<string> Usings,
        string RecordParameterList,
        IEnumerable<PropertyDefinition> Properties)
    {
        public bool NullableEnable { get; set; } = true;
        public string? FileHeader { get; set; }
        public bool HasDefaultConstructor => Configuration.HasDefaultConstructor;
    }

    public static ViewModel FromConfiguration(GencoConfiguration cfg)
    {
        var viewModel = new ViewModel(
            Configuration: cfg,
            Namespace: cfg.Namespace.Default(FileResolver.ResolveNamespace(cfg)),
            TypeName: cfg.Name.Default(FileResolver.ResolveFilename(cfg)),
            TypeSyntax: cfg.Type.Default("record"),
            Usings: cfg.Usings.ToHashSet(),
            RecordParameterList: FormatParameterList(cfg.Record.ParameterList),
            Properties: cfg.Properties.Select(kvp => kvp.Value with { Name = kvp.Key }));

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

    private static string FormatParameterList(List<RecordParameterDefinition> recordParameterList)
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
