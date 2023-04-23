using Stubble.Core.Builders;
using Stubble.Core.Loaders;

namespace Genco.Library;

public record CSharpCodeFile(string FullPathToFile, string Code);

public static class Renderer
{
    public static CSharpCodeFile RenderCSharp<T>(string fullPathToFile, T data)
    {
        var stubble = new StubbleBuilder()
            .Configure(settings =>
            {
                var dict = new Dictionary<string, string>
                {
                    ["CSharpCodeDictionaryMappingMethods"] = LoadTemplate(
                        "CSharpCodeDictionaryMappingMethods"
                    ),
                    ["CSharpCodeAdoNetMappingMethods"] = LoadTemplate(
                        "CSharpCodeAdoNetMappingMethods"
                    ),
                };
                settings.SetPartialTemplateLoader(new DictionaryLoader(dict));
            })
            .Build();

        string templateText = LoadTemplate("CSharpCodeFile");
        // Sync
        var renderedText = stubble.Render(templateText, data);

        return new CSharpCodeFile(fullPathToFile, renderedText);
    }

    private static string LoadTemplate(string templateName)
    {
        var baseDir = AppContext.BaseDirectory;
        var templateFullPath = Path.Combine(baseDir, "Templates", $"{templateName}.mustache");
        var templateText = File.ReadAllText(templateFullPath);
        return templateText;
    }
}
