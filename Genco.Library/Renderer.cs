using Stubble.Core.Builders;

namespace Genco.Library;

public record CSharpCodeFile(string FullPathToFile, string Code);

public class Renderer
{
    public static CSharpCodeFile RenderCSharp<T>(string fullPathToFile, T data)
    {
        var stubble = new StubbleBuilder().Build();

        var baseDir = AppContext.BaseDirectory;
        var templateFullPath = Path.Combine(baseDir, "Templates", "CSharpCodeFile.mustache");
        var templateText = File.ReadAllText(templateFullPath);
        // Sync
        var renderedText = stubble.Render(templateText, data);

        return new CSharpCodeFile(fullPathToFile, renderedText);
    }
}
