using ConsoleApp.Abstractions.Abstractions;

namespace ConsoleApp.Abstractions;

public record EmptyEngineParams : EngineParamsBase
{
        
        public static readonly EmptyEngineParams DEFAULT = new();
        
}