// <auto-generated>
//     This file is generated by a tool.
// </auto-generated>
/*
Copyright (c) 2023 Björn Roberg
Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:
The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.ComponentModel.DataAnnotations;
using RangeAttribute = System.ComponentModel.DataAnnotations.RangeAttribute;
#nullable enable
namespace Genco.Test.Example
{
    public enum Status
    {
        Unknown,
        Ok,
        Intermediate,
        Problematic,
    }
    /// <summary>
    /// This is a generated class.
    /// The tool used to generate this file is called Genco.
    /// </summary>
    public partial record MyMoreComplexModel([property: Required, Range(0, 100)] int Id, bool Important = true)
    {
        // Name
        [MaxLength(0xff)]
        public string? Name { get; init; }
        // CreatedAt
        public DateTime CreatedAt { get; } = DateTime.Now;
        // Status
        public Status Status { get; set; } = Status.Ok;
        // ExternalReference
        public Guid? ExternalReference { get; set; }
    }
    public enum MyMoreComplexModelProperties
    {
        Id,
        Important,
        Name,
        CreatedAt,
        Status,
        ExternalReference,
    }
#if DEBUG
    internal static class MyMoreComplexModelMeta
    {
        private static System.Reflection.PropertyInfo? _Property_Id = null;
        private static System.Reflection.PropertyInfo? _Property_Important = null;
        private static System.Reflection.PropertyInfo? _Property_Name = null;
        private static System.Reflection.PropertyInfo? _Property_CreatedAt = null;
        private static System.Reflection.PropertyInfo? _Property_Status = null;
        private static System.Reflection.PropertyInfo? _Property_ExternalReference = null;
        internal static readonly Type ModelType = typeof(MySimpleModel);
        internal static System.Reflection.PropertyInfo Property_Id
        {
            get
            {
                if (_Property_Id == null)
                {
                    _Property_Id =
                        ModelType.GetProperty("Id")
                            ?? throw new InvalidOperationException("Could not find property 'Id' on MyMoreComplexModel");
                }
                return _Property_Id;
            }
        }
        internal static System.Reflection.PropertyInfo Property_Important
        {
            get
            {
                if (_Property_Important == null)
                {
                    _Property_Important =
                        ModelType.GetProperty("Important")
                            ?? throw new InvalidOperationException("Could not find property 'Important' on MyMoreComplexModel");
                }
                return _Property_Important;
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
                            ?? throw new InvalidOperationException("Could not find property 'Name' on MyMoreComplexModel");
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
                            ?? throw new InvalidOperationException("Could not find property 'CreatedAt' on MyMoreComplexModel");
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
                            ?? throw new InvalidOperationException("Could not find property 'Status' on MyMoreComplexModel");
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
                            ?? throw new InvalidOperationException("Could not find property 'ExternalReference' on MyMoreComplexModel");
                }
                return _Property_ExternalReference;
            }
        }
        internal static Type Type_Id = typeof(int);
        internal static bool Type_Id_IsNullable = false;
        internal static Type Type_Important = typeof(bool);
        internal static bool Type_Important_IsNullable = false;
        internal static Type Type_Name = typeof(string);
        internal static bool Type_Name_IsNullable = true;
        internal static Type Type_CreatedAt = typeof(DateTime);
        internal static bool Type_CreatedAt_IsNullable = false;
        internal static Type Type_Status = typeof(Status);
        internal static bool Type_Status_IsNullable = false;
        internal static Type Type_ExternalReference = typeof(Guid);
        internal static bool Type_ExternalReference_IsNullable = true;
    }
#endif
    public static class MyMoreComplexModelDictionaryMappingExtensions
    {
        public static void PopulateFromDictionary(this MyMoreComplexModel instance, IDictionary<string, object?> dictionary)
        {
            // Name
            // CreatedAt
            // Status
            if (dictionary.TryGetValue("Status", out var Status_AsObj))
            {
#if DEBUG
                if (Status_AsObj is not null)
                {
                    var type = Status_AsObj.GetType();
                    var value = Status_AsObj;
                    System.Diagnostics.Debug.Assert(
                        MyMoreComplexModelMeta.Property_Status.PropertyType.IsAssignableFrom(type),
                        $"dictionary['Status'] of type '{type.FullName}' (Value: {value}) is not assignable to MyMoreComplexModel.Status");
                }
#endif
                if (Status_AsObj is not null) instance.Status = (Status)Status_AsObj;
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
                        MyMoreComplexModelMeta.Property_ExternalReference.PropertyType.IsAssignableFrom(type),
                        $"dictionary['ExternalReference'] of type '{type.FullName}' (Value: {value}) is not assignable to MyMoreComplexModel.ExternalReference");
                }
#endif
                instance.ExternalReference = (Guid?)ExternalReference_AsObj;
            }
            else instance.ExternalReference = default;
        }
        public static IDictionary<string, object?> ToDictionary(this MyMoreComplexModel instance)
        {
            var dictionary = new Dictionary<string, object?>
            {
                ["Id"] = instance.Id,
                ["Important"] = instance.Important,
                ["Name"] = instance.Name,
                ["CreatedAt"] = instance.CreatedAt,
                ["Status"] = instance.Status,
                ["ExternalReference"] = instance.ExternalReference,
            };
            return dictionary;
        }
    }
    public static class MyMoreComplexModelAdoNetMappingExtensions
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
        public static void AddAllParameters(this MyMoreComplexModel model, IDbCommand command, params string[] skipProperties)
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
            AddParameter("@Important", model.Important, "Important");
            AddParameter("@Name", model.Name, "Name");
            AddParameter("@CreatedAt", model.CreatedAt, "CreatedAt");
            AddParameter("@Status", model.Status, "Status");
            AddParameter("@ExternalReference", model.ExternalReference, "ExternalReference");
        }
    }
    public partial record MyMoreComplexModelDto
    {
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }
        public Guid? ExternalReference { get; set; }
    }
    public static class MyMoreComplexModelDtoMappingExtensions
    {
        public static MyMoreComplexModelDto ToDto(this MyMoreComplexModel instance)
        {
            var result = new MyMoreComplexModelDto();
            result.Name = instance.Name;
            result.CreatedAt = instance.CreatedAt;
            result.Status = instance.Status;
            result.ExternalReference = instance.ExternalReference;
            return result;
        }
        public static MyMoreComplexModel ToModel(this MyMoreComplexModelDto dto)
        {
            var obj = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(
                MyMoreComplexModelMeta.ModelType);
            var result = (MyMoreComplexModel)obj;
            // result.Name = dto.Name;
            MyMoreComplexModelMeta.Property_Name.SetValue(result, dto.Name);
            // result.CreatedAt = dto.CreatedAt;
            MyMoreComplexModelMeta.Property_CreatedAt.SetValue(result, dto.CreatedAt);
            // result.Status = dto.Status;
            MyMoreComplexModelMeta.Property_Status.SetValue(result, dto.Status);
            // result.ExternalReference = dto.ExternalReference;
            MyMoreComplexModelMeta.Property_ExternalReference.SetValue(result, dto.ExternalReference);
            return result;
        }
    }
}

