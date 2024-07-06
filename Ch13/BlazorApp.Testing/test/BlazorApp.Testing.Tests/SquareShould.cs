using BlazorApp.Testing.Shared;

namespace BlazorApp.Testing.Tests;
public class SquareShould
{
  [Fact]
  public void Return9For3()
  {
    // Arrange
    Utils sut = new();
    // Act
    int result = sut.Square(3);
    // Assert
    Assert.Equal(expected: 9, actual: result);
  }

  [Theory]
  [InlineData(1, 1)]
  [InlineData(2, 4)]
  [InlineData(-1, 1)]
  public void ReturnSquareOfNumber(int number, int square)
  {
    // Arrange
    Utils sut = new();
    // Act
    int result = sut.Square(number);
    // Assert
    Assert.Equal(expected: square, actual: result);
  }

  [Fact]
  public void ThrowOverflowForBigNumbers()
  {
    // Arrange
    Utils sut = new();
    // Act & Assert
    Assert.Throws<OverflowException>(() =>
    {
      int result = sut.Square(int.MaxValue);
    });
  }
}
