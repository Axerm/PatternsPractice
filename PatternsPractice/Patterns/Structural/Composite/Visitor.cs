using System.Text;

namespace PatternsPractice.Patterns.Structural.Composite;

public interface IBuildingVisitor
{
    void VisitBuilding(Building building);
    void VisitFloor(Floor floor);
    void VisitRoom(Room room);
}

public class InfoBuildingVisitor : IBuildingVisitor
{
    private readonly StringBuilder infoBuilder = new();

    public void VisitBuilding(Building building)
        => infoBuilder.AppendLine($"{building.GetInfo()}: {building.Name}");

    public void VisitFloor(Floor floor)
        => infoBuilder.AppendLine($"+--{floor.GetInfo()}: {floor.Number}");

    public void VisitRoom(Room room)
        => infoBuilder.AppendLine($"|  |--{room.GetInfo()}: {room.Number}");

    public string GetInfo() => infoBuilder.ToString();
}