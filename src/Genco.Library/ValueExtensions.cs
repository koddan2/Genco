using System.Diagnostics.CodeAnalysis;

namespace Genco.Library;

internal static class ValueExtensions
{
    internal static T Default<T>(this T? maybe, T fallback)
    {
        return maybe ?? fallback;
    }

    [return: NotNull]
    internal static T Require<T>(this T? maybe)
    {
        ArgumentNullException.ThrowIfNull(maybe, nameof(maybe));
        return maybe;
    }
}
