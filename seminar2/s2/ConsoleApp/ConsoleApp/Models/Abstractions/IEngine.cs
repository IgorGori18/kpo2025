namespace ConsoleApp.Abstractions.Abstractions;

public interface IEngine
{
    public bool IsCompatible(Customer customer);
    public string ToString();
}