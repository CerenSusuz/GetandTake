using Microsoft.AspNetCore.Mvc.Filters;

namespace GetandTake.Filters;

public class CustomPageFilter : IAsyncPageFilter
{

    public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
    {
        return Task.CompletedTask;
    }

    public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
    {
        await next.Invoke();
    }
}
