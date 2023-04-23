namespace Genco.Library;

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
    public GencoConfigurationGenerateElement Generate { get; set; } = new();
    public GencoConfigurationRecordElement? Record { get; set; }
    public List<GencoConfigurationConstructorElement> Constructors { get; set; } = new();
    public List<PropertyDefinition> Properties { get; set; } = new();
}

public class GencoConfigurationConstructorElement
{
    public List<InvicationParameterDefinition> ParameterList { get; set; } =
        new List<InvicationParameterDefinition>();
    public string? CustomCode { get; set; }
}

public class GencoConfigurationRecordElement
{
    public List<InvicationParameterDefinition> ParameterList { get; set; } =
        new List<InvicationParameterDefinition>();
}

public record PropertyDefinition
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Setter { get; set; }
    public string? Attributes { get; set; }
    public string? DefaultValue { get; set; }
}

public record InvicationParameterDefinition
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
    public GencoConfigurationGenerateMappersElement Mappers { get; set; } =
        new GencoConfigurationGenerateMappersElement();
}
