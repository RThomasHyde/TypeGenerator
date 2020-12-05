namespace RThomasHyde.TypeGenerator.Tests.TestClasses
{
    public class TestClassWithConstructor
    {
        private string _test;

        public TestClassWithConstructor(string test)
        {
            _test = test;
        }

        public string Get()
        {
            return _test;
        }
    }
}
