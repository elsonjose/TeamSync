namespace TeamSync.Application.Common.Dto;

/// <summary>
/// Defines the response of type <seealso cref="T"/>
/// </summary>
/// <typeparam name="T"></typeparam>
public class ResponseDto<T> where T : class
{   

    /// <summary>
    /// Specifies the data for the response.
    /// </summary>
    public T Data { get; set; } = null!;
}