using System.Net;
using System.Text.Json;
using LibSevSUBackend.AppServices.Exceptions;
using LibSevSUBackend.Contracts.Errors;
using Microsoft.AspNetCore.Http.Extensions;

namespace LibSevSUBackend.Api.Middlewares;

/// <summary>
/// Промежуточное ПО для обработки ошибок.
/// </summary>
public class ExceptionHandlingMiddleware
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All),
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    private readonly RequestDelegate _next;

    /// <summary>
    /// Инициализирует экземпляр <see cref="ExceptionHandlingMiddleware"/>.
    /// </summary>
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    /// <summary>
    /// Выполняет операцию промежуточного ПО и передаёт управление
    /// </summary>
    public async Task Invoke(
        HttpContext context
        , IHostEnvironment environment
        , IServiceProvider serviceProvider)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            var statusCode = GetStatusCode(e);
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var apiError = CreateApiError(e, context, environment);
            await context.Response.WriteAsync(JsonSerializer.Serialize(apiError, JsonSerializerOptions));
        }
    }

    private object CreateApiError(Exception exception, HttpContext context, IHostEnvironment environment)
    {
        return exception switch
        {
            EntityNotFoundException => new ApiError
            {
                Code = ((int)HttpStatusCode.NotFound).ToString(),
                Message = "Сущность не была найдена.",
                TraceId = context.TraceIdentifier,
            },
            LoginAlreadyExistsException => new ApiError
            {
                Code = ((int)HttpStatusCode.Conflict).ToString(),
                Message = "Этот логин уже зарегистрирован.",
                TraceId = context.TraceIdentifier,
            },
            InvalidLoginDataException invalidLoginDataException => new ApiError
            {
                Code = ((int)HttpStatusCode.Unauthorized).ToString(),
                Message = invalidLoginDataException.Message,
                TraceId = context.TraceIdentifier,
            },
            ForbiddenException => new ApiError
            {
                Code = ((int)HttpStatusCode.Forbidden).ToString(),
                Message = "Нет доступа.",
                TraceId = context.TraceIdentifier,
            },
            ConflictException => new ApiError()
            {
                Code = ((int)HttpStatusCode.Conflict).ToString(),
                Message = "Конфликт.",
                TraceId = context.TraceIdentifier,
            },
            _ => new ApiError
            {
                Code = ((int)HttpStatusCode.InternalServerError).ToString(),
                Message = "Произошла непредвиденная ошибка.",
                TraceId = context.TraceIdentifier,
            }
        };
    }

    private HttpStatusCode GetStatusCode(Exception exception)
    {
        return exception switch
        {
            EntityNotFoundException => HttpStatusCode.NotFound,
            InvalidLoginDataException => HttpStatusCode.Unauthorized,
            ForbiddenException => HttpStatusCode.Forbidden,
            ConflictException => HttpStatusCode.Conflict,
            _ => HttpStatusCode.InternalServerError,
        };
    }
}