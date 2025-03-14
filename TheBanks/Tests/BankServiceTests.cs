using Microsoft.JSInterop;

namespace TheBanks.Tests
{
    public class TestJSRuntime : IJSRuntime
    {
        private readonly IJSRuntime _ijsRuntimeImplementation;

        public TestJSRuntime(IJSRuntime jsRuntimeImplementation)
        {
            _ijsRuntimeImplementation = jsRuntimeImplementation ??
                                        throw new ArgumentNullException(nameof(jsRuntimeImplementation));
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
        {
            return _ijsRuntimeImplementation.InvokeAsync<TValue>(identifier, args);
        }


        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken,
            object?[]? args)
        {
            return _ijsRuntimeImplementation.InvokeAsync<TValue>(identifier, cancellationToken, args);
        }

        public ValueTask InvokeVoidAsync(string identifier, object?[]? args)
        {
            return new ValueTask();
        }
    }
}