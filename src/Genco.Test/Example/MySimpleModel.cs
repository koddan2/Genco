// <auto-generated>
//     This file is generated by a tool.
// </auto-generated>
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data;
using System.ComponentModel.DataAnnotations;
using RangeAttribute = System.ComponentModel.DataAnnotations.RangeAttribute;
#nullable enable
namespace Genco.Test.Example
{
    public static class SomeExtraStuff
    {
        // MySimpleModel
        public static readonly int Value = 1;
    }
    /// <summary>
    /// This is a generated class.
    /// The tool used to generate this file is called Genco.
    /// </summary>
    public partial record MySimpleModel
    {
        public MySimpleModel()
        {
            Console.WriteLine("MySimpleModel");
            System.Diagnostics.Debug.Assert(GetHashCode() != 0, "OOPS");
        }
        // Id
        [Range(0x1000, 0xffff)]
        public long Id { get; set; }
        // Name
        [MaxLength(0xff)]
        public string? Name { get; set; }
        // CreatedAt
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        // Status
        public Status Status { get; set; } = Status.Ok;
        // ExternalReference
        public Guid? ExternalReference { get; set; }
        // Description
        public string? Description { get; set; }
        public static MySimpleModel FromDictionary(IDictionary<string, object?> dictionary)
        {
            // var result = new MySimpleModel();
            var result = (MySimpleModel)RuntimeHelpers.GetUninitializedObject(
                typeof(MySimpleModel));
            // var constructor = typeof(MySimpleModel).GetConstructor(Type.EmptyTypes);
            // constructor.Invoke(result);
            result.PopulateFromDictionary(dictionary);
            return result;
        }
        public static async IAsyncEnumerable<MySimpleModel> LoadRecordsAsync(DbDataReader reader)
        {
            while (await reader.ReadAsync())
            {
                yield return LoadRecord(reader);
            }
        }
        public static IEnumerable<MySimpleModel> LoadRecords(DbDataReader reader)
        {
            while (reader.Read())
            {
                yield return LoadRecord(reader);
            }
        }
        public static MySimpleModel LoadRecord(DbDataReader reader)
        {
            Dictionary<string, int> columnIndexes = new();
            for (int i = 0; i < reader.FieldCount; ++i)
            {
                columnIndexes.Add(reader.GetName(i), i);
            }
            var result = new MySimpleModel()
            {
            };
            // Id
            if (columnIndexes
                .TryGetValue("id", out int ordinal_Id))
            {
                result.Id = reader.GetFieldValue<long>(ordinal_Id);
            }
            // Name
            if (columnIndexes
                .TryGetValue("name", out int ordinal_Name))
            {
                result.Name = reader.GetFieldValue<string?>(ordinal_Name);
            }
            // CreatedAt
            if (columnIndexes
                .TryGetValue("createdat", out int ordinal_CreatedAt))
            {
                result.CreatedAt = reader.GetFieldValue<DateTime>(ordinal_CreatedAt);
            }
            // Status
            if (columnIndexes
                .TryGetValue("status", out int ordinal_Status))
            {
                result.Status = reader.GetFieldValue<Status>(ordinal_Status);
            }
            // ExternalReference
            if (columnIndexes
                .TryGetValue("externalreference", out int ordinal_ExternalReference))
            {
                result.ExternalReference = reader.GetFieldValue<Guid?>(ordinal_ExternalReference);
            }
            // Description
            if (columnIndexes
                .TryGetValue("description", out int ordinal_Description))
            {
                result.Description = reader.GetFieldValue<string?>(ordinal_Description);
            }
            return result;
        }
        public static class Sql
        {
            public enum IdentifierCasing
            {
                Verbatim = 0,
                Invariant = 1,
                Lower = 2,
                Upper = 3,
            }
            static IEnumerable<string> TransformCasing(IEnumerable<string> names, IdentifierCasing casing) => names.Select(x => TransformCasing(x, casing));
            static string TransformCasing(string name, IdentifierCasing casing) => casing switch
            {
                IdentifierCasing.Lower => name.ToLowerInvariant(),
                IdentifierCasing.Upper => name.ToUpperInvariant(),
                IdentifierCasing.Invariant => name.ToUpperInvariant(),
                _ => name,
            };
            public static string GetInsertCommandText (string tableName = "MySimpleModel", IdentifierCasing casing = default, params string[] skipProperties)
            {
                var relevantProperties = new []
                {
                    "Id",
                    "Name",
                    "CreatedAt",
                    "Status",
                    "ExternalReference",
                    "Description",
                }.Except(skipProperties ?? Array.Empty<string>());
                var relevantPropertiesWithCasing = TransformCasing(relevantProperties, casing);
                var template = @"INSERT INTO {0}
({1})
VALUES ({2});";
                var columnsList = string.Join(", ", relevantPropertiesWithCasing);
                var valuesList = string.Join(", ", relevantProperties.Select(prop => $"@{prop}"));
                var result = string.Format(template, tableName, columnsList, valuesList);
                return result;
            }
        }
    }
    public enum MySimpleModelProperty
    {
        Id,
        Name,
        CreatedAt,
        Status,
        ExternalReference,
        Description,
    }
    internal static class MySimpleModelMeta
    {
        private static System.Reflection.PropertyInfo? _Property_Id = null;
        private static System.Reflection.PropertyInfo? _Property_Name = null;
        private static System.Reflection.PropertyInfo? _Property_CreatedAt = null;
        private static System.Reflection.PropertyInfo? _Property_Status = null;
        private static System.Reflection.PropertyInfo? _Property_ExternalReference = null;
        private static System.Reflection.PropertyInfo? _Property_Description = null;
        internal static readonly Type ModelType = typeof(MySimpleModel);
        internal static System.Reflection.PropertyInfo? GetProperty(MySimpleModelProperty property)
        {
            if (property == MySimpleModelProperty.Id)
            {
                return Property_Id;
            }
            if (property == MySimpleModelProperty.Name)
            {
                return Property_Name;
            }
            if (property == MySimpleModelProperty.CreatedAt)
            {
                return Property_CreatedAt;
            }
            if (property == MySimpleModelProperty.Status)
            {
                return Property_Status;
            }
            if (property == MySimpleModelProperty.ExternalReference)
            {
                return Property_ExternalReference;
            }
            if (property == MySimpleModelProperty.Description)
            {
                return Property_Description;
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
                            ?? throw new InvalidOperationException("Could not find property 'Id' on MySimpleModel");
                }
                return _Property_Id;
            }
        }
        internal static System.Reflection.PropertyInfo Property_Name
        {
            get
            {
                if (_Property_Name == null)
                {
                    _Property_Name =
                        ModelType.GetProperty("Name")
                            ?? throw new InvalidOperationException("Could not find property 'Name' on MySimpleModel");
                }
                return _Property_Name;
            }
        }
        internal static System.Reflection.PropertyInfo Property_CreatedAt
        {
            get
            {
                if (_Property_CreatedAt == null)
                {
                    _Property_CreatedAt =
                        ModelType.GetProperty("CreatedAt")
                            ?? throw new InvalidOperationException("Could not find property 'CreatedAt' on MySimpleModel");
                }
                return _Property_CreatedAt;
            }
        }
        internal static System.Reflection.PropertyInfo Property_Status
        {
            get
            {
                if (_Property_Status == null)
                {
                    _Property_Status =
                        ModelType.GetProperty("Status")
                            ?? throw new InvalidOperationException("Could not find property 'Status' on MySimpleModel");
                }
                return _Property_Status;
            }
        }
        internal static System.Reflection.PropertyInfo Property_ExternalReference
        {
            get
            {
                if (_Property_ExternalReference == null)
                {
                    _Property_ExternalReference =
                        ModelType.GetProperty("ExternalReference")
                            ?? throw new InvalidOperationException("Could not find property 'ExternalReference' on MySimpleModel");
                }
                return _Property_ExternalReference;
            }
        }
        internal static System.Reflection.PropertyInfo Property_Description
        {
            get
            {
                if (_Property_Description == null)
                {
                    _Property_Description =
                        ModelType.GetProperty("Description")
                            ?? throw new InvalidOperationException("Could not find property 'Description' on MySimpleModel");
                }
                return _Property_Description;
            }
        }
        /// <summary>Property <code>Id</code> is <see cref="long"/>.</summary>
        internal static Type Type_Id { get; } = typeof(long);
        internal static bool Type_Id_IsNullable { get; } = false;
        /// <summary>Property <code>Name</code> is <see cref="string"/>.</summary>
        internal static Type Type_Name { get; } = typeof(string);
        internal static bool Type_Name_IsNullable { get; } = true;
        /// <summary>Property <code>CreatedAt</code> is <see cref="DateTime"/>.</summary>
        internal static Type Type_CreatedAt { get; } = typeof(DateTime);
        internal static bool Type_CreatedAt_IsNullable { get; } = false;
        /// <summary>Property <code>Status</code> is <see cref="Status"/>.</summary>
        internal static Type Type_Status { get; } = typeof(Status);
        internal static bool Type_Status_IsNullable { get; } = false;
        /// <summary>Property <code>ExternalReference</code> is <see cref="Guid"/>.</summary>
        internal static Type Type_ExternalReference { get; } = typeof(Guid);
        internal static bool Type_ExternalReference_IsNullable { get; } = true;
        /// <summary>Property <code>Description</code> is <see cref="string"/>.</summary>
        internal static Type Type_Description { get; } = typeof(string);
        internal static bool Type_Description_IsNullable { get; } = true;
    }
    // CSharpCodeDictionaryMappingMethods
    public static class MySimpleModelDictionaryMappingExtensions
    {
        public static void PopulateFromDictionary(this MySimpleModel instance, IDictionary<string, object?> dictionary)
        {
            // Id
            if (dictionary.TryGetValue("Id", out var Id_AsObj))
            {
#if DEBUG
                if (Id_AsObj is not null)
                {
                    var type = Id_AsObj.GetType();
                    var value = Id_AsObj;
                    System.Diagnostics.Debug.Assert(
                        MySimpleModelMeta.Property_Id.PropertyType.IsAssignableFrom(type),
                        $"dictionary['Id'] of type '{type.FullName}' (Value: {value}) is not assignable to MySimpleModel.Id");
                }
#endif
                if (Id_AsObj is not null)
                {
                    // instance.Id = (long)Id_AsObj;
                    MySimpleModelMeta.Property_Id.SetValue(instance, (long)Id_AsObj);
                }
                else throw new ArgumentException("The value for the key 'Id' in the supplied dictionary is null", nameof(dictionary));
            }
            else throw new KeyNotFoundException("The key 'Id' was not present in the supplied dictionary");
            // Name
            if (dictionary.TryGetValue("Name", out var Name_AsObj))
            {
#if DEBUG
                if (Name_AsObj is not null)
                {
                    var type = Name_AsObj.GetType();
                    var value = Name_AsObj;
                    System.Diagnostics.Debug.Assert(
                        MySimpleModelMeta.Property_Name.PropertyType.IsAssignableFrom(type),
                        $"dictionary['Name'] of type '{type.FullName}' (Value: {value}) is not assignable to MySimpleModel.Name");
                }
#endif
                // instance.Name = (string?)Name_AsObj;
                MySimpleModelMeta.Property_Name.SetValue(instance, (string?)Name_AsObj);
            }
            else instance.Name = default;
            // CreatedAt
            if (dictionary.TryGetValue("CreatedAt", out var CreatedAt_AsObj))
            {
#if DEBUG
                if (CreatedAt_AsObj is not null)
                {
                    var type = CreatedAt_AsObj.GetType();
                    var value = CreatedAt_AsObj;
                    System.Diagnostics.Debug.Assert(
                        MySimpleModelMeta.Property_CreatedAt.PropertyType.IsAssignableFrom(type),
                        $"dictionary['CreatedAt'] of type '{type.FullName}' (Value: {value}) is not assignable to MySimpleModel.CreatedAt");
                }
#endif
                if (CreatedAt_AsObj is not null)
                {
                    // instance.CreatedAt = (DateTime)CreatedAt_AsObj;
                    MySimpleModelMeta.Property_CreatedAt.SetValue(instance, (DateTime)CreatedAt_AsObj);
                }
                else throw new ArgumentException("The value for the key 'CreatedAt' in the supplied dictionary is null", nameof(dictionary));
            }
            else throw new KeyNotFoundException("The key 'CreatedAt' was not present in the supplied dictionary");
            // Status
            if (dictionary.TryGetValue("Status", out var Status_AsObj))
            {
#if DEBUG
                if (Status_AsObj is not null)
                {
                    var type = Status_AsObj.GetType();
                    var value = Status_AsObj;
                    System.Diagnostics.Debug.Assert(
                        MySimpleModelMeta.Property_Status.PropertyType.IsAssignableFrom(type),
                        $"dictionary['Status'] of type '{type.FullName}' (Value: {value}) is not assignable to MySimpleModel.Status");
                }
#endif
                if (Status_AsObj is not null)
                {
                    // instance.Status = (Status)Status_AsObj;
                    MySimpleModelMeta.Property_Status.SetValue(instance, (Status)Status_AsObj);
                }
                else throw new ArgumentException("The value for the key 'Status' in the supplied dictionary is null", nameof(dictionary));
            }
            else throw new KeyNotFoundException("The key 'Status' was not present in the supplied dictionary");
            // ExternalReference
            if (dictionary.TryGetValue("ExternalReference", out var ExternalReference_AsObj))
            {
#if DEBUG
                if (ExternalReference_AsObj is not null)
                {
                    var type = ExternalReference_AsObj.GetType();
                    var value = ExternalReference_AsObj;
                    System.Diagnostics.Debug.Assert(
                        MySimpleModelMeta.Property_ExternalReference.PropertyType.IsAssignableFrom(type),
                        $"dictionary['ExternalReference'] of type '{type.FullName}' (Value: {value}) is not assignable to MySimpleModel.ExternalReference");
                }
#endif
                // instance.ExternalReference = (Guid?)ExternalReference_AsObj;
                MySimpleModelMeta.Property_ExternalReference.SetValue(instance, (Guid?)ExternalReference_AsObj);
            }
            else instance.ExternalReference = default;
            // Description
            if (dictionary.TryGetValue("Description", out var Description_AsObj))
            {
#if DEBUG
                if (Description_AsObj is not null)
                {
                    var type = Description_AsObj.GetType();
                    var value = Description_AsObj;
                    System.Diagnostics.Debug.Assert(
                        MySimpleModelMeta.Property_Description.PropertyType.IsAssignableFrom(type),
                        $"dictionary['Description'] of type '{type.FullName}' (Value: {value}) is not assignable to MySimpleModel.Description");
                }
#endif
                // instance.Description = (string?)Description_AsObj;
                MySimpleModelMeta.Property_Description.SetValue(instance, (string?)Description_AsObj);
            }
            else instance.Description = default;
        }
        public static Dictionary<string, object?> ToDictionary(this MySimpleModel instance)
        {
            var dictionary = new Dictionary<string, object?>
            {
                ["Id"] = instance.Id,
                ["Name"] = instance.Name,
                ["CreatedAt"] = instance.CreatedAt,
                ["Status"] = instance.Status,
                ["ExternalReference"] = instance.ExternalReference,
                ["Description"] = instance.Description,
            };
            return dictionary;
        }
    }
    // CSharpCodeAdoNetMappingMethods
    public static class MySimpleModelAdoNetMappingExtensions
    {
        /// <summary>
        /// Adds all properties (that should not be skipped) using the following template:
        /// <code>"@" + nameof(PropertyName)</code>
        /// E.g. <example>
        /// <code>"@MyCamelCasePropName"</code>
        /// </example>
        /// Some database providers are case-sensitive, so make sure you define them such
        /// that they are compatible with this scheme.
        /// </summary>
        public static void AddAllParameters(this MySimpleModel model, IDbCommand command, params string[] skipProperties)
        {
            void AddParameter<T>(string parameterName, T value, string name)
            {
                if (skipProperties?.Contains(name) is true)
                {
                    return;
                }
                var newParameter = command.CreateParameter();
                newParameter.ParameterName = parameterName;
                newParameter.Value = value;
                command.Parameters.Add(newParameter);
            }
            AddParameter("@Id", model.Id, "Id");
            AddParameter("@Name", model.Name, "Name");
            AddParameter("@CreatedAt", model.CreatedAt, "CreatedAt");
            AddParameter("@Status", model.Status, "Status");
            AddParameter("@ExternalReference", model.ExternalReference, "ExternalReference");
            AddParameter("@Description", model.Description, "Description");
        }
    }
    // CSharpCodeDtoTypeAndExtensions
    public partial record MySimpleModelDto
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Status? Status { get; set; }
        public Guid? ExternalReference { get; set; }
        public string? Description { get; set; }
    }
    public static class MySimpleModelDtoMappingExtensions
    {
        public static MySimpleModelDto ToDto(this MySimpleModel instance)
        {
            var result = new MySimpleModelDto();
            result.Id = instance.Id;
            result.Name = instance.Name;
            result.CreatedAt = instance.CreatedAt;
            result.Status = instance.Status;
            result.ExternalReference = instance.ExternalReference;
            result.Description = instance.Description;
            return result;
        }
        public static MySimpleModel ToModel(this MySimpleModelDto dto)
        {
            var obj = RuntimeHelpers.GetUninitializedObject(
                MySimpleModelMeta.ModelType);
            var result = (MySimpleModel)obj;
            // result.Id = dto.Id;
            MySimpleModelMeta.Property_Id.SetValue(result, dto.Id);
            // result.Name = dto.Name;
            MySimpleModelMeta.Property_Name.SetValue(result, dto.Name);
            // result.CreatedAt = dto.CreatedAt;
            MySimpleModelMeta.Property_CreatedAt.SetValue(result, dto.CreatedAt);
            // result.Status = dto.Status;
            MySimpleModelMeta.Property_Status.SetValue(result, dto.Status);
            // result.ExternalReference = dto.ExternalReference;
            MySimpleModelMeta.Property_ExternalReference.SetValue(result, dto.ExternalReference);
            // result.Description = dto.Description;
            MySimpleModelMeta.Property_Description.SetValue(result, dto.Description);
            return result;
        }
    }
    public static class MySimpleModelExtensions
    {
        public static IEnumerable<(MySimpleModelProperty Property, object? Value)> Enumerate(this MySimpleModel model)
        {
            yield return (MySimpleModelProperty.Id, model.Id);
            yield return (MySimpleModelProperty.Name, model.Name);
            yield return (MySimpleModelProperty.CreatedAt, model.CreatedAt);
            yield return (MySimpleModelProperty.Status, model.Status);
            yield return (MySimpleModelProperty.ExternalReference, model.ExternalReference);
            yield return (MySimpleModelProperty.Description, model.Description);
        }
    }
    /*
    From Common.toml
    */
    public enum PropertiesOfMySimpleModel
    {
        /// <summary>
        /// Signifies the Id property.
        /// Attributes: [Range(0x1000, 0xffff)]
        /// </summary>
        Id,
        /// <summary>
        /// Signifies the Name property.
        /// Attributes: [MaxLength(0xff)]
        /// </summary>
        Name,
        /// <summary>
        /// Signifies the CreatedAt property.
        /// Attributes:
        /// </summary>
        CreatedAt,
        /// <summary>
        /// Signifies the Status property.
        /// Attributes:
        /// </summary>
        Status,
        /// <summary>
        /// Signifies the ExternalReference property.
        /// Attributes:
        /// </summary>
        ExternalReference,
        /// <summary>
        /// Signifies the Description property.
        /// Attributes:
        /// </summary>
        Description,
    }
    public class MyCustomCodeForMySimpleModel
    {
        public const int Value = 1;
        public static readonly Type MyType = typeof(MySimpleModel);
        /*
        */
    }
    /*
    Template in Common.toml
    From Common.toml :: 1
    */
}

