using System;
using System.Runtime.ExceptionServices;
using Frends.Instagram.Request.Definitions;

namespace Frends.Instagram.Request.Helpers;

internal static class ErrorHandler
{
    /// <summary>
    /// Converts an exception into a failed Result object or rethrows based on task options.
    /// </summary>
    /// <param name="exception">The exception to handle.</param>
    /// <param name="options"> Task options that control whether failures are returned as a Result object or thrown. </param>
    /// <param name="throwCanceled">
    /// When true, an OperationCanceledException is rethrown immediately.
    /// When false, cancellation is handled like any other failure.
    /// </param>
    /// <param name="statusCode">HTTP status code of the response, if one was received.</param>
    /// <param name="body">HTTP response body, if one was received.</param>
    /// <returns> A failed Result object when the exception is handled instead of rethrown. </returns>
    internal static Result Handle(
        this Exception exception,
        Options options,
        bool throwCanceled = true,
        int statusCode = 0,
        string body = null)
    {
        ArgumentNullException.ThrowIfNull(exception);
        ArgumentNullException.ThrowIfNull(options);

        ThrowIfCanceled(exception, throwCanceled);
        if (options.ThrowErrorOnFailure) ThrowBaseException(exception, options.ErrorMessageOnFailure);

        var result = ReturnResult(exception, options.ErrorMessageOnFailure);
        result.Statuscode = statusCode;
        result.Message = body;
        return result;
    }

    private static void ThrowIfCanceled(Exception exception, bool throwCanceled = true)
    {
        if (throwCanceled && exception is OperationCanceledException) ThrowBaseException(exception);
    }

    private static void ThrowBaseException(Exception exception, string customMessage = null)
    {
        if (string.IsNullOrEmpty(customMessage))
            ExceptionDispatchInfo.Capture(exception).Throw();

        throw new Exception(customMessage, exception);
    }

    private static Result ReturnResult(Exception exception, string customMessage = null)
    {
        var errorMessage = string.IsNullOrEmpty(customMessage)
            ? exception.Message
            : $"{customMessage}: {exception.Message}";

        return new Result
        {
            Success = false,
            Error = new Error
            {
                Message = errorMessage,
                AdditionalInfo = exception,
            },
        };
    }
}
