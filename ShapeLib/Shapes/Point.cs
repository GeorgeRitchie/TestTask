namespace ShapeLib.Shapes;

public readonly struct Point : IEquatable<Point>, IComparable<Point>
{
	public double X { get; }
	public double Y { get; }

	public Point(double x, double y)
	{
		X = x;
		Y = y;
	}

	public bool Equals(Point other, double epsilon = 1e-10)
	{
		return Math.Abs(X - other.X) < epsilon && Math.Abs(Y - other.Y) < epsilon;
	}

	public bool Equals(Point other)
	{
		return Equals(other, 1e-10);
	}

	public override bool Equals(object? obj)
	{
		return obj is Point other && Equals(other);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y);
	}

	public int CompareTo(Point other)
	{
		int xComparison = X.CompareTo(other.X);
		return xComparison != 0 ? xComparison : Y.CompareTo(other.Y);
	}

	public override string ToString() => $"({X}, {Y})";

	public static bool operator ==(Point left, Point right) => left.Equals(right);
	public static bool operator !=(Point left, Point right) => !left.Equals(right);
}
