using System.Text.Json.Serialization;
using InventoryManagementBO.Utilities;

namespace InventoryManagementGUI.Model;

public class PostResult
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Result Result { get; set; }

    public string Data { get; set; }
}