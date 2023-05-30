using Newtonsoft.Json;

namespace potg.Data;

public record FailResponse
{
    public FailResponse(string message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }

    [JsonProperty("message")]
    public string Message { get; }

    [JsonProperty("statusCode")]
    public int StatusCode { get; }
}