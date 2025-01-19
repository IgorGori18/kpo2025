namespace ConsoleApp;

public class Car
{
    public int SerialNumber { get; }
    public Engine Engine { get; }

    public Car(int serialNumber, int pedalSize)
    {
        SerialNumber = serialNumber;
        Engine = new Engine(pedalSize);
    }

    public override string ToString()
    {
        return $"Car #{SerialNumber} with pedal size {Engine.PedalSize}";
    }
}