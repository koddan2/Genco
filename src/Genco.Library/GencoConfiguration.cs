﻿namespace Genco.Library;

public record GencoConfiguration
{
    public string? CustomCode { get; set; }
    public string? PathToConfigurationFile { get; set; }
    public string? FileHeader { get; set; }
    public string? FileHeaderInclude { get; set; }
    public string? Namespace { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public List<string> Usings { get; set; } = new List<string>();
    public GencoConfigurationGenerateElement Generate { get; set; } = new GencoConfigurationGenerateElement();
    public GencoConfigurationRecordElement Record { get; set; } = new GencoConfigurationRecordElement();
    public Dictionary<string, PropertyDefinition> Properties { get; set; } = new Dictionary<string, PropertyDefinition>();

    public object? Constructor { get; set; }

    public bool HasDefaultConstructor => Record.ParameterList.Count == 0 && Constructor is null;
}

public class GencoConfigurationRecordElement
{
    public List<RecordParameterDefinition> ParameterList { get; set; } = new List<RecordParameterDefinition>();
}

public record PropertyDefinition
{
    public string? Type { get; set; }
    public string? Setter { get; set; }
    public string? Attributes { get; set; }
    public string? DefaultValue { get; set; }

    // -- not necessarily set by configuration
    public string? Name { get; set; }

    public string? TypeSyntax => Type;
    public string? SetterSyntax => Setter is null ? "" : $" {Setter};";
    public string? DefaultValueSyntax => DefaultValue is null ? "" : $" = {DefaultValue};";
    public bool IsAssignable => Setter == "set";
    public bool IsNullable => Type?.StartsWith("Nullable<") is true || Type?.EndsWith("?") is true;
    public bool IsNotNull => !IsNullable;
}
public record RecordParameterDefinition
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? DefaultValue { get; set; }
    public List<string> Attributes { get; set; } = new List<string>();
}
public record GencoConfigurationGenerateMappersElement
{
    public bool? Dictionary { get; set; }
    public bool? AdoNet { get; set; }
}
public record GencoConfigurationGenerateElement
{
    public GencoConfigurationGenerateMappersElement Mappers { get; set; } = new GencoConfigurationGenerateMappersElement();
}