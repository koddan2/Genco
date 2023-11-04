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
    public enum MySimplestModelProperties
    {
        Id,
    }
#if DEBUG
    internal static class MySimplestModelMeta
    {
        private static System.Reflection.PropertyInfo? _Property_Id = null;
        internal static readonly Type ModelType = typeof(MySimpleModel);
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
        internal static Type Type_Id = typeof(long);
        internal static bool Type_Id_IsNullable = false;
    }
#endif
}

