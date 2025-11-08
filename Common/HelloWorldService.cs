namespace Common;

public interface IHelloWorldService
{
    public string GetHelloWorld();
}

internal class HelloWorldService : IHelloWorldService
{
    private const string HelloWorld = "Hello World";

    public string GetHelloWorld() => HelloWorld;
}
