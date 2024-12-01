using ShapeLib.Shapes;

namespace xUnitTests;

public class PolygonTests
{
	[Fact]
	public void Polygon_ShouldThrowArgumentNullException_WhenVerticesAreNull()
	{
		// Arrange

		// Act
		var action = () => new Polygon(null);

		// Assert
		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void Polygon_ShouldThrowArgumentException_WhenPolygonHasTooManyPoints()
	{
		// Arrange
		var vertices = new Point[Polygon.MaxPoints + 1];

		// Act
		var action = () => new Polygon(vertices);

		// Act and Assert
		action.ShouldThrow<ArgumentException>();
	}

	[Fact]
	public void CalculateArea_ShouldReturnZero_WhenVerticesAreEmpty()
	{
		// Arrange
		var polygon = new Polygon([]);

		// Act
		double area = polygon.CalculateArea();

		// Assert
		area.ShouldBe(0, tolerance: 0.01);
	}

	[Fact]
	public void CalculateArea_ShouldReturnZero_WhenPolygonHasLessThanThreePoints()
	{
		// Arrange
		var vertices = new[]
		{
			new Point(0, 0),
			new Point(1, 1)
		};
		var polygon = new Polygon(vertices);

		// Act
		double area = polygon.CalculateArea();

		// Assert
		area.ShouldBe(0, tolerance: 0.01);
	}

	[Fact]
	public void CalculateArea_ShouldReturnCorrectArea_ForClosedPolygon()
	{
		// Arrange
		var vertices = new[]
		{
			new Point(0, 0),
			new Point(4, 0),
			new Point(4, 3),
			new Point(0, 0)
		};
		var polygon = new Polygon(vertices);

		// Act
		double area = polygon.CalculateArea();

		// Assert
		area.ShouldBe(6.0, tolerance: 0.01);
	}

	[Fact]
	public void CalculateArea_ShouldCalculateAreaForOpenPolyline()
	{
		// Arrange
		var vertices = new[]
		{
			new Point(0, 0),
			new Point(2, 2),
			new Point(4, 0)
		};
		var polygon = new Polygon(vertices);

		// Act
		double area = polygon.CalculateArea();

		// Assert
		area.ShouldBe(4.0, tolerance: 0.01);
	}
}
