using Tomlyn;

namespace Genco.Library;

public static class GencoProcessor
{
    public static void ProcessFile(string pathToTomlFile)
    {
        var tomlText = File.ReadAllText(pathToTomlFile);
        TomlModelOptions tomlModelOptions = new()
        {
            ConvertPropertyName = s => s,
        };
        var cfg = Toml.ToModel<GencoConfiguration>(tomlText, options: tomlModelOptions);
        cfg.PathToConfigurationFile = pathToTomlFile;
        var viewModel = CSharpCompilationUnit.FromConfiguration(cfg);

        var outputDir = Path.GetDirectoryName(pathToTomlFile);
        var filename = FileResolver.ResolveFilename(cfg);
        var fullPathToFile = Path.Combine(outputDir.Require(), $"{filename}.cs");
        var result = Renderer.RenderCSharp(fullPathToFile, viewModel);
        File.WriteAllText(fullPathToFile, result.Code);
    }
}