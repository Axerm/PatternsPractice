namespace PatternsPractice;

public static class Program
{
    private static void Main(string[] _)
        => RunStructuralPatterns();

    private static void RunStructuralPatterns()
    {
        //Patterns.Structural.Facade.Runner.Run();
        //Patterns.Structural.Decorator.Runner.Run();
        Patterns.Structural.Composite.Runner.Run();
    }
}