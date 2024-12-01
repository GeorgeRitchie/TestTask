using ShapeLib.Shapes;

namespace xUnitTests;

public class TriangleTests
{
	[Fact]
	public void TriangleArea_ShouldBeCorrect()
	{
		// Arrange
		var triangle = new Triangle(3, 4, 5);

		// Act
		var area = triangle.CalculateArea();

		// Assert
		area.ShouldBe(6);
	}

	[Fact]
	public void Triangle_IsRightTriangle_ShouldBeTrue()
	{
		// Arrange
		var triangle = new Triangle(3, 4, 5);

		// Act
		var result = triangle.IsRightTriangle();

		// Assert
		result.ShouldBeTrue();
	}

	[Fact]
	public void InvalidTriangle_ShouldThrowException()
	{
		// Arrange

		// Act
		var action = () => new Triangle(1, 2, 10);

		// Assert
		action.ShouldThrow<ArgumentException>();
	}
}
