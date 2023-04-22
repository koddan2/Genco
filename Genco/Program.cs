namespace Genco;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World! - {0}", args.Length);
        var tomlPath = Path.Combine(ProjectSourcePath.Lazy.Value, "Example", "MyModel.toml");
        Genco.Library.GencoProcessor.ProcessFile(tomlPath);
    }
}