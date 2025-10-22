namespace Sandbox;

public class SampleTests
{
    [Fact]
    public void SampleTest_ShouldPass()
    {
        // Arrange
        var expected = 42;
        
        // Act
        var actual = 42;
        
        // Assert
        Assert.Equal(expected, actual);
    }
}
