using System.Text.Json;
using System.Text.Json.Serialization;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;
public static class JsonOptionsProvider
{
    public static JsonSerializerOptions GetDefaultOptions()
    {
        return new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull 
        };
    }
}