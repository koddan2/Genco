namespace Genco.Library;

public record GencoConfiguration
{
    public string? PathToConfigurationFile { get; set; }
    public string? FileHeader { get; set; }
    public string? Namespace { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public List<string> Usings { get; set; } = new List<string>();
    public GencoConfigurationGenerateElement Generate { get; set; } = new GencoConfigurationGenerateElement();

    public List<string> RecordParameterList { get; set; } = new List<string>();
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
