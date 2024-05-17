using System.Runtime.CompilerServices;
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
    public enum MySimplestWithDtoModelProperty
    {
        Id,
    }
    internal static class MySimplestWithDtoModelMeta
    {
        private static System.Reflection.PropertyInfo? _Property_Id = null;
        internal static readonly Type ModelType = typeof(MySimplestWithDtoModel);
        internal static System.Reflection.PropertyInfo? GetProperty(
            MySimplestWithDtoModelProperty property
        )
        {
            if (property == MySimplestWithDtoModelProperty.Id)
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
                            "Could not find property 'Id' on MySimplestWithDtoModel"
                        );
                }
                return _Property_Id;
            }
        }
        /// <summary>Property <code>Id</code> is <see cref="long"/>.</summary>
        internal static Type Type_Id { get; } = typeof(long);
        internal static bool Type_Id_IsNullable { get; } = false;
    }
    // CSharpCodeDtoTypeAndExtensions
    public record MySimplestWithDtoModelDto
    {
        public long? Id { get; set; }
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
            var obj = RuntimeHelpers.GetUninitializedObject(MySimplestWithDtoModelMeta.ModelType);
            var result = (MySimplestWithDtoModel)obj;
            // result.Id = dto.Id;
            MySimplestWithDtoModelMeta.Property_Id.SetValue(result, dto.Id);
            return result;
        }
    }
    public static class MySimplestWithDtoModelExtensions
    {
        public static IEnumerable<(
            MySimplestWithDtoModelProperty Property,
            object? Value
        )> Enumerate(this MySimplestWithDtoModel model)
        {
            yield return (MySimplestWithDtoModelProperty.Id, model.Id);
        }
    }
}

