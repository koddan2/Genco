﻿#if DEBUG
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Genco;

internal static class ProjectSourceRoot
{
    private const string _SelfFilename = nameof(ProjectSourceRoot) + ".cs";
    internal static Lazy<string> Lazy = new(CalculatePath);

    private static string CalculatePath()
    {
        var pathName = GetSourceFilePathName();
        var filename = Path.GetFileName(pathName);
        Debug.Assert(filename.Equals(_SelfFilename, StringComparison.Ordinal), "Invalid path");
        var directoryPath = Path.GetDirectoryName(pathName);
        return directoryPath ?? throw new ApplicationException("Null valued path");
    }

    public static string GetSourceFilePathName(
        [CallerFilePath] string? callerFilePath = null
    ) //
        => callerFilePath ?? throw new InvalidOperationException(nameof(callerFilePath));
}
#endif
