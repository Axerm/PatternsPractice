namespace PatternsPractice.Patterns.Structural.Composite;

public static class Runner
{
    public static void Run()
    {
        var builder = new RandomBuildingBuilder("Офисный центр")
            .Rooms(7).AddFloors(1)
            .Rooms(5).AddFloors(1)
            .Rooms(3).AddFloors(1)
            .Build();

        InfoBuildingVisitor visitor = new();
        builder.Visit(visitor);

        Console.WriteLine(visitor.GetInfo());
    }
}
