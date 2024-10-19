using System;
using System.Text.Json.Serialization;

namespace PersonalFinanceApp.Models;

public record Color
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonPropertyName("color")]
    public string ColorCode { get; set; }
}
