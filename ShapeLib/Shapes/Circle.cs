namespace ShapeLib.Shapes;

public interface ICircle : IShape
{
	double Radius { get; }
}

public sealed class Circle : ICircle
{
	public double Radius { get; }

	public Circle(double radius)
	{
		if (radius <= 0)
			throw new ArgumentException("Radius must be greater than zero.", nameof(radius));

		Radius = radius;
	}

	public double CalculateArea()
	{
		return Math.PI * Math.Pow(Radius, 2);
	}
}

