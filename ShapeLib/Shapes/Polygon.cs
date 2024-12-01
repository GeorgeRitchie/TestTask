namespace ShapeLib.Shapes;

public sealed class Polygon : IShape
{
	public const int MaxPoints = 10000;

	private Point[] _vertices = [];

	public IReadOnlyCollection<Point> Vertices => _vertices;

	public Polygon(Point[] vertices)
	{
		_vertices = vertices ?? throw new ArgumentNullException(nameof(vertices));

		if (_vertices.Length > MaxPoints)
			throw new ArgumentException($"Too many points: {_vertices.Length}. Max allowed — {MaxPoints}.");
	}

	public double CalculateArea()
		=> IsClosedPolygon() ? CalculateClosedPolygonArea() : CalculateOpenPolylineArea();

	private bool IsClosedPolygon()
	{
		if (_vertices.Length < 3)
			return false;

		return _vertices[0].Equals(_vertices[^1]);
	}

	private double CalculateClosedPolygonArea()
	{
		if (!IsClosedPolygon())
			throw new InvalidOperationException("Polygon is not closed.");

		double area = 0;

		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			var current = _vertices[i];
			var next = _vertices[i + 1];

			area += current.X * next.Y - current.Y * next.X;
		}

		return Math.Abs(area) / 2.0;
	}

	private double CalculateOpenPolylineArea()
	{
		if (_vertices.Length < 3)
			return 0;

		double area = 0;

		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			var current = _vertices[i];
			var next = _vertices[i + 1];

			area += (next.X - current.X) * (current.Y + next.Y) / 2.0;
		}

		return Math.Abs(area);
	}
}
