using AoC22.Solutions.Day9;

namespace AoC22.Tests.Day9;

public class RopePullerTests
{
    [Fact]
    public void TailVisitsShouldBeCorrect()
    {
        var input = "R 4\nU 4\nL 3\nD 1\nR 4\nD 1\nL 5\nR 2";
        var ropePuller = new RopePuller(input);
        var result = ropePuller.CountTailLocationsVisited(1);

        result.Should().Be(13);
    }
    
    [Fact]
    public void TailVisitsShouldBeCorrectForLongerRope()
    {
        var input = "R 5\nU 8\nL 8\nD 3\nR 17\nD 10\nL 25\nU 20";
        var ropePuller = new RopePuller(input);
        var result = ropePuller.CountTailLocationsVisited(9);

        result.Should().Be(36);
    }
}