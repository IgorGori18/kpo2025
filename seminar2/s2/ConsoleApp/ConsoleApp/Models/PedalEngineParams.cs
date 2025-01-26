using ConsoleApp.Abstractions.Abstractions;

namespace ConsoleApp.Abstractions;

public record PedalEngineParams : EngineParamsBase
{
    public uint PedalSize { get; }

    public PedalEngineParams(uint pedalSize) => PedalSize = pedalSize;
    
}