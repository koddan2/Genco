using CSharpier;
using System.Text;
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
        var formattedResult = CodeFormatter.Format(result.Code);
        if (formattedResult.CompilationErrors.Any())
        {
            throw new InvalidOperationException(formattedResult.CompilationErrors.First().GetMessage());
        }
        var cleanResult = CleanWhitespace(formattedResult.Code);
        File.WriteAllText(fullPathToFile, cleanResult);
    }

    private static string CleanWhitespace(string code)
    {
        var sb = new StringBuilder();
        var reader = new StringReader(code);
        for (string? line = ""; line is not null; line = reader.ReadLine())
        {
            var trimmed = line.Trim();
            if (trimmed.Length > 0)
            {
                sb.AppendLine(line.TrimEnd());
            }
        }
        sb.AppendLine();
        return sb.ToString();
    }
}