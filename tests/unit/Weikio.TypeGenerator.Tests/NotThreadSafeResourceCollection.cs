using Xunit;

namespace RThomasHyde.TypeGenerator.Tests
{
    [CollectionDefinition(nameof(NotThreadSafeResourceCollection), DisableParallelization = true)]
    public class NotThreadSafeResourceCollection { }
}
