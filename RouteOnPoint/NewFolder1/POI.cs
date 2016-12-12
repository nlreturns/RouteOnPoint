using System;
using Windows.Devices.Geolocation;

public class PointOfInterest
{
    public string Name { get; set; }
    public string Information { get; set; }
    public string Path { get; set; }
    public bool Visited { get; set; }
    public Geocoordinate Coordinate { get; set; }

    public PointOfInterest(string name, string information, Geocoordinate coordinate, string path, bool visited)
	{
        this.Name = name;
        this.Information = information;
        this.Coordinate = coordinate;
        this.Path = path;
        this.Visited = visited;

	}
}
