using System.Runtime.CompilerServices;
#nullable enable
namespace Genco.Test.Example
{
    /// <summary>
    /// This is a generated class.
    /// The tool used to generate this file is called Genco.
    /// </summary>
    public record MySimplestModel
    {
        // Id
        public long Id { get; set; }
    }
    public enum MySimplestModelProperty
    {
        Id,
    }
    internal static class MySimplestModelMeta
    {
        private static System.Reflection.PropertyInfo? _Property_Id = null;
        internal static readonly Type ModelType = typeof(MySimplestModel);
        internal static System.Reflection.PropertyInfo? GetProperty(
            MySimplestModelProperty property
        )
        {
            if (property == MySimplestModelProperty.Id)
            {
                return Property_Id;
            }
            return null;
        }
        internal static System.Reflection.PropertyInfo Property_Id
        {
            get
            {
                if (_Property_Id == null)
                {
                    _Property_Id =
                        ModelType.GetProperty("Id")
                        ?? throw new InvalidOperationException(
                            "Could not find property 'Id' on MySimplestModel"
                        );
                }
                return _Property_Id;
            }
        }
        /// <summary>Property <code>Id</code> is <see cref="long"/>.</summary>
        internal static Type Type_Id { get; } = typeof(long);
        internal static bool Type_Id_IsNullable { get; } = false;
    }
    public static class MySimplestModelExtensions
    {
        public static IEnumerable<(MySimplestModelProperty Property, object? Value)> Enumerate(
            this MySimplestModel model
        )
        {
            yield return (MySimplestModelProperty.Id, model.Id);
        }
    }
}

