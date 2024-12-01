namespace ShapeLib.Shapes;

public interface ITriangle : IShape
{
	double SideA { get; }
	double SideB { get; }
	double SideC { get; }

	bool IsRightTriangle();
}

public sealed class Triangle : ITriangle
{
	public double SideA { get; }
	public double SideB { get; }
	public double SideC { get; }

	public Triangle(double sideA, double sideB, double sideC)
	{
		if (sideA <= 0 || sideB <= 0 || sideC <= 0)
			throw new ArgumentException("All sides must be greater than zero.");

		if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
			throw new ArgumentException("The provided sides do not form a valid triangle.");

		SideA = sideA;
		SideB = sideB;
		SideC = sideC;
	}

	public double CalculateArea()
	{
		var semiPerimeter = (SideA + SideB + SideC) / 2;
		return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
	}

	public bool IsRightTriangle()
	{
		var sides = new[] { SideA, SideB, SideC }.OrderBy(s => s).ToArray();
		return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) < 1e-10;
	}
}
