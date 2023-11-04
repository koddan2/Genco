#nullable enable
namespace Genco.Test.Example
{
    /// <summary>
    /// This is a generated class.
    /// The tool used to generate this file is called Genco.
    /// </summary>
    public record MySimplestWithDtoModel
    {
        // Id
        public long Id { get; set; }
    }
    public enum MySimplestWithDtoModelProperties
    {
        Id,
    }
#if DEBUG
    internal static class MySimplestWithDtoModelMeta
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
                            "Could not find property 'Id' on MySimplestWithDtoModel"
                        );
                }
                return _Property_Id;
            }
        }
        internal static Type Type_Id = typeof(long);
        internal static bool Type_Id_IsNullable = false;
    }
#endif
    public record MySimplestWithDtoModelDto
    {
        public long Id { get; set; }
    }
    public static class MySimplestWithDtoModelDtoMappingExtensions
    {
        public static MySimplestWithDtoModelDto ToDto(this MySimplestWithDtoModel instance)
        {
            var result = new MySimplestWithDtoModelDto();
            result.Id = instance.Id;
            return result;
        }
        public static MySimplestWithDtoModel ToModel(this MySimplestWithDtoModelDto dto)
        {
            var obj = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(
                MySimplestWithDtoModelMeta.ModelType
            );
            var result = (MySimplestWithDtoModel)obj;
            // result.Id = dto.Id;
            MySimplestWithDtoModelMeta.Property_Id.SetValue(result, dto.Id);
            return result;
        }
    }
}

