using System;

namespace DatingApp.API.Errors;

public record ApiException(int StatusCode, string Message, string? Details);
