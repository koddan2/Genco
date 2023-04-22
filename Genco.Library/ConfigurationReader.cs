namespace Genco.Library;

public static class FileResolver
{
    internal static string ResolveFilename(GencoConfiguration cfg)
    {
        var withoutExt = Path.GetFileNameWithoutExtension(cfg.PathToConfigurationFile);
        return withoutExt
            ?? throw new ArgumentException("Could not resolve filename without extension", nameof(cfg));
    }

    internal static string ResolveNamespace(GencoConfiguration cfg)
    {
        var csproj = ResolveCsproj(cfg);
        var csprojDir = Path.GetDirectoryName(csproj).Require();
        var csprojName = Path.GetFileNameWithoutExtension(csproj);
        var relativePath = Path.GetRelativePath(csprojDir, cfg.PathToConfigurationFile.Require());
        string relativePathWithDots = "";
        if (relativePath.Replace(Path.DirectorySeparatorChar, '.') is string withDots && withDots != ".")
        {
            relativePathWithDots = withDots;
        }
        return $"{csprojName}{relativePathWithDots}";
    }
    internal static string ResolveCsproj(GencoConfiguration cfg)
    {
        var dirPath = Path.GetDirectoryName(cfg.PathToConfigurationFile).Require();
        return ResolveCsproj(dirPath);
    }
    internal static string ResolveCsproj(string dirPath, int limit = 10)
    {
        var dirInfo = new DirectoryInfo(dirPath);

        if (dirInfo.Exists
            && dirInfo.EnumerateFiles().FirstOrDefault(fi => fi.Extension == ".csproj") is FileInfo csproj)
        {
            return csproj.FullName;
        }
        else if (limit > 0)
        {
            return ResolveCsproj(dirInfo.Parent.Require().FullName, limit - 1);
        }
        throw new ArgumentException("Unable to resolve project base directory");
    }
}
public static class CSharpCompilationUnit
{
    public record ViewModel(string Namespace, string TypeName, string TypeSyntax)
    {
        public string? FileHeader { get; set; }
    }

    public static ViewModel FromConfiguration(GencoConfiguration cfg)
    {
        var viewModel = new ViewModel(
            Namespace: cfg.Namespace.Default(FileResolver.ResolveCsproj(cfg)),
            TypeName: cfg.Name.Default(FileResolver.ResolveFilename(cfg)),
            TypeSyntax: cfg.Type.Default("record"));

        if (cfg.FileHeader is not null)
        {
            viewModel.FileHeader = cfg.FileHeader;
        }

        return viewModel;
    }
}
