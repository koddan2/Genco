using Genco.Library;

namespace Genco;

internal class Program
{
    private int _verbosity = 1;

    static int Main(string[] args)
    {
        return new Program().Run(args);
    }

    private int Run(string[] args)
    {
        try
        {
            if (int.TryParse(Environment.GetEnvironmentVariable("GENCO_VERBOSITY"), out int v))
            {
                _verbosity = v;
            }

            foreach (var arg in args)
            {
                var inputFileVirtualPath = arg;
                var notNormalizedPath =
#if DEBUG
                    inputFileVirtualPath.Replace(
                        "$[ProjectSourceRoot]",
                        ProjectSourceRoot.Lazy.Value
                    );
#else
                inputFileVirtualPath;
#endif
                var fullPath = Path.GetFullPath(notNormalizedPath);

                if (Path.Exists(fullPath))
                {
                    if (Directory.Exists(fullPath))
                    {
                        var tomlFiles = Directory.EnumerateFiles(fullPath, "*.toml", SearchOption.TopDirectoryOnly);
                        foreach (var tomlFile in tomlFiles)
                        {
                            ProcessFile(tomlFile);
                        }
                    }
                    else if (File.Exists(fullPath))
                    {
                        ProcessFile(fullPath);
                    }
                    else
                    {
                        throw new ApplicationException($"Invalid path (path is neither a file nor a directory): {fullPath}");
                    }
                }
                else
                {
                    throw new ApplicationException($"Invalid path (path does not exist): {fullPath}");
                }
            }
            return 0;
        }
        catch (Exception exn)
        {
            Console.Error.WriteLine(exn);
            return 1;
        }
    }

    private void ProcessFile(string inputFileFullPath)
    {
        if (_verbosity > 0)
        {
            Console.WriteLine("Processing: {0}", inputFileFullPath);
        }

        GencoProcessor.ProcessFile(inputFileFullPath);
    }
}
