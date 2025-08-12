using System;
//FIRST PROJECT
class Point3D : IComparable<Point3D>, ICloneable
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    
    public Point3D() : this(0, 0, 0) { }

    
    public Point3D(int x, int y) : this(x, y, 0) { }

    
    public Point3D(int x, int y, int z)
    {
        X = x; Y = y; Z = z;
    }

    public override string ToString()
    {
        return $"Point Coordinates: ({X}, {Y}, {Z})";
    }

    
    public static bool operator ==(Point3D p1, Point3D p2)
    {
        if (ReferenceEquals(p1, p2)) return true;
        if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null)) return false;
        return p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z;
    }

    public static bool operator !=(Point3D p1, Point3D p2)
    {
        return !(p1 == p2);
    }

    public override bool Equals(object obj)
    {
        return this == (obj as Point3D);
    }

    public override int GetHashCode()
    {
        return (X, Y, Z).GetHashCode();
    }

    
    public int CompareTo(Point3D other)
    {
        int compareX = X.CompareTo(other.X);
        if (compareX != 0) return compareX;
        return Y.CompareTo(other.Y);
    }

    
    public object Clone()
    {
        return new Point3D(X, Y, Z);
    }
}

class Program
{
    static void Main()
    {
      
        Point3D P1 = ReadPoint("P1");
        Point3D P2 = ReadPoint("P2");

        Console.WriteLine(P1 == P2 ? "Points are equal" : "Points are different");

      
        Point3D[] points =
        {
            P1,
            P2,
            new Point3D(5, 8, 2),
            new Point3D(3, 1, 4)
        };

        Array.Sort(points);
        Console.WriteLine("\nSorted Points:");
        foreach (var p in points)
            Console.WriteLine(p);

       
        var cloned = (Point3D)P1.Clone();
        Console.WriteLine($"\nCloned point: {cloned}");
    }

    static Point3D ReadPoint(string name)
    {
        int x, y, z; 

        Console.WriteLine($"Enter coordinates for {name}:");

        Console.Write("X: ");
        while (!int.TryParse(Console.ReadLine(), out x))
            Console.Write("Invalid input, enter X again: ");

        Console.Write("Y: ");
        y = Convert.ToInt32(Console.ReadLine()); 

        Console.Write("Z: ");
        z = int.Parse(Console.ReadLine());

        return new Point3D(x, y, z);
    }
}
//Second Project

