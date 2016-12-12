using System;

public class PointOfInterest
{
    public string Name { get; set; }
    public string Information { get; set; }
    public string Path { get; set; }
    public bool Visited { get; set; }
    public GeoCoordinate Coordinate { get; set; }

    public PointOfInterest(string name, string information, GeoCoordinate coordinate, string path, bool visited)
	{
        this.Name = name;
        this.Information = information;
        this.Coordinate = coordinate;
        this.Path = path;
        this.Visited = visited;

	}
}
