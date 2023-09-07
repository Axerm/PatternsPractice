namespace PatternsPractice.Patterns.Structural.Composite;

public class RandomBuildingBuilder
{
    private readonly Building _building;
    private int _floorRooms;
    private int _floorCounter;

    public RandomBuildingBuilder(string buildingName)
        => (_building, _floorRooms, _floorCounter) = (new(buildingName), 5, 0);

    public RandomBuildingBuilder Rooms(int florrRooms)
    {
        _floorRooms = florrRooms;
        return this;
    }

    public RandomBuildingBuilder AddFloors(int floors)
    {
        for (int i = 0; i < floors; i++, _floorCounter++)
        {
            Floor floor = new(_floorCounter);

            for (int j = 1; j <= _floorRooms; j++)
                floor.Add(new Room($"{_floorCounter}-{j}"));

            _building.Add(floor);
        }

        return this;
    }

    public Building Build() => _building;
}
