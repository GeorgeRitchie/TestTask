using ShapeLib.Shapes;

namespace xUnitTests;

public class CircleTests
{
	[Fact]
	public void CircleArea_ShouldBeCorrect()
	{
		// Arrange
		var circle = new Circle(10);

		// Act
		var area = circle.CalculateArea();

		// Assert
		area.ShouldBe(Math.PI * 10 * 10);
	}
}
