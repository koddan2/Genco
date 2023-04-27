using Stubble.Core.Builders;
using Stubble.Core.Loaders;

namespace Genco.Library;

public record CSharpCodeFile(string FullPathToFile, string Code);

public static class Renderer
{
    public static CSharpCodeFile RenderCSharp<T>(
        string fullPathToFile,
        T data,
        GencoConfiguration cfg
    )
    {
        var dynPartials = "";
        var stubble = new StubbleBuilder()
            .Configure(settings =>
            {
                var dict = new Dictionary<string, string>();
                void HelperLoadTemplate(string name) => dict.Add(name, LoadTemplate(name));
                HelperLoadTemplate("CSharpCodeDictionaryMappingMethods");
                HelperLoadTemplate("CSharpCodeAdoNetMappingMethods");
                HelperLoadTemplate("CSharpCodeDtoTypeAndExtensions");
                foreach (var extraTemplate in cfg.Extra.Templates)
                {
                    if (extraTemplate.Value.Contains(Environment.NewLine))
                    {
                        dynPartials += Indent.Spaces(extraTemplate.Value, 4);
                    }
                    else
                    {
                        dict.Add(extraTemplate.Key, File.ReadAllText(extraTemplate.Value));
                        dynPartials +=
                            $@"
{{{{>{extraTemplate.Key}}}}}
";
                    }
                }
                settings.SetPartialTemplateLoader(new DictionaryLoader(dict));
            })
            .Build();

        string templateText = LoadTemplate("CSharpCodeFile");
        templateText = templateText.Replace("###REPLACE###", dynPartials);
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
