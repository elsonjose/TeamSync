## Global Error Handling

### 1. Custom Middleware (Simple but extension to several errors is not easy)
1. Create a new middle class.
2. Initialize the requestDelegate using contructor.
3. Use try catch inside the invoke method and handle the exception inside the catch method.
4. Add middleware in program.cs

### 2. Filter Attrbute
1. Create a new FilterAttrbute class extending ExceptionFilterAttribute.
2. Provide implementation for onException(ExceptionContext context). Set exceptionHandled as true.
3. Add it to all controllers using [FilterAttributeClassName] in all controller classes or in the program.cs file using the below code.
    ```
    builder.Services.AddControllers(options => options.Filters.Add<FilterAttributeClassName>());
    ```
### 3. Problem Details
The RFC specification mentions 5 values. They are 
- Type : A URI reference that identifies the problem.
- Title : A short summary of the problem. Same for all occurences.
- Status : The status code.
- Details: The description of the problem.
- Instance : The resource (url) that cause the issue.

It can be implemented using one of the above 2 methods. Create a problem details object with the above properties and send it as response.

### 4. Middleware with error endpoint
1. Add UseMiddleware("/endpoint");
2. Create a new error controller
3. Get errors = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error.
4. return Problem(title = errors?.Message, statusCode = 400)
The type will be populated automatically. 

If you want to add additional properties, then you can either
1. Create a new class inheriting the ProblemDetailsFactory.
2. Copy all methods from DefaultProblemDetailsFactory to the new class.
3. Append required properties inside the ApplyProblemDetailsDefault().
4. Override the ProblemDetailsFactory dependency injection with new class.

or

1. Use minimal API to create the error endpoint.
2. Return Results.Problem() that accepts a dictionary for extensions.

## [Flow of control](https://www.youtube.com/watch?v=tZ8gGqiq_IU&list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k&index=5)
- OneOf
- FluentResults
- ErrorOr

