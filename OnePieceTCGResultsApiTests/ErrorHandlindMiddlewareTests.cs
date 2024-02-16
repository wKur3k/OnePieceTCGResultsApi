using System.Net;
using Microsoft.AspNetCore.Http;
using Moq;
using OnePieceTCGResultsApi.Exceptions;
using OnePieceTCGResultsApi.Middleware;

namespace OnePieceTCGResultsApiTests;

public class ErrorHandlindMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_CatchBadRequestException_ReturnsBadRequest()
    {
        // Arrange
        var middleware = new ErrorHandlingMiddleware();
        var context = new DefaultHttpContext();
        var nextDelegateMock = new Mock<RequestDelegate>();
        nextDelegateMock.Setup(x => x.Invoke(It.IsAny<HttpContext>())).Throws(new BadRequestException("Bad request"));

        // Act
        await middleware.InvokeAsync(context, nextDelegateMock.Object);

        // Assert
        Assert.Equal((int)HttpStatusCode.BadRequest, context.Response.StatusCode);
        Assert.Equal("application/json", context.Response.ContentType);
    }

    [Fact]
    public async Task InvokeAsync_CatchGeneralException_ReturnsInternalServerError()
    {
        // Arrange
        var middleware = new ErrorHandlingMiddleware();
        var context = new DefaultHttpContext();
        var nextDelegateMock = new Mock<RequestDelegate>();
        nextDelegateMock.Setup(x => x.Invoke(It.IsAny<HttpContext>())).Throws(new Exception("Internal server error"));

        // Act
        await middleware.InvokeAsync(context, nextDelegateMock.Object);

        // Assert
        Assert.Equal((int)HttpStatusCode.InternalServerError, context.Response.StatusCode);
        Assert.Equal("application/json", context.Response.ContentType);
    }
}