using System.ComponentModel.DataAnnotations;

namespace HomeworkAi.OpenAi;

public class BasicResponse
{
    public BasicResponse()
    {
        NotifyUser = false;
    }
    public string? Status { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public bool NotifyUser { get; set; }
}
public class Response<T> : BasicResponse
{
    public T? ResponseData { get; set; }
}

public class ListResponse<T> : BasicResponse
{
    public List<T>? ListResponseData { get; set; }
}

public class ChatCompletionRequest
{
    [Required(ErrorMessage = "No text given")]

    public string Content { get; set; }
    public List<string> ChatHistory { get; set; }
    public int Role { get; set; }
}