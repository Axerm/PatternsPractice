namespace PatternsPractice.Patterns.Structural.Composite;

public class Building : Composite
{
    protected List<Component> Components { get; set; }
    public string Name { get; init; }

    public Building(string name) => (Components, Name) = (new(), name);

    public override string GetInfo() => "Здание";
    public override void Add(Component component) => Components.Add(component);
    public override void Remove(Component component) => Components.Remove(component);
    public override Component GetChild(int index) => Components[index];

    public override void Visit(IBuildingVisitor visiter)
    {
        visiter.VisitBuilding(this);
        foreach (var component in Components)
            component.Visit(visiter);
    }
}

public class Floor : Composite
{
    protected List<Component> Components { get; set; }
    public int Number { get; init; }

    public Floor(int number) => (Components, Number) = (new(), number);

    public override string GetInfo() => "Этаж";
    public override void Add(Component component) => Components.Add(component);
    public override void Remove(Component component) => Components.Remove(component);
    public override Component GetChild(int index) => Components[index];

    public override void Visit(IBuildingVisitor visiter)
    {
        visiter.VisitFloor(this);
        foreach (var component in Components)
            component.Visit(visiter);
    }
}

public class Room : Component
{
    public string Number { get; init; }

    public Room(string number) => Number = number;

    public override string GetInfo() => "Помещение";

    public override void Visit(IBuildingVisitor visiter) => visiter.VisitRoom(this);
}