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
                var notNormalizedPath = inputFileVirtualPath.Replace("$[ProjectSourceRoot]", ProjectSourceRoot.Lazy.Value);
                var inputFileFullPath = Path.GetFullPath(notNormalizedPath);
                if (_verbosity > 0)
                {
                    Console.WriteLine("Processing: {0}", inputFileFullPath);
                }

                GencoProcessor.ProcessFile(inputFileFullPath);
            }
            return 0;
        }
        catch (Exception exn)
        {
            Console.Error.WriteLine(exn);
            return 1;
        }
    }
}