using System;
using AoC22.Solutions.Day11;

namespace AoC22.Tests.Day11;

public class KeepAwayTests
{
    [Fact]
    public void MonkeyBusinessLevelIsCorrect()
    {
        var input =
            "Monkey 0:\n  Starting items: 79, 98\n  Operation: new = old * 19\n  Test: divisible by 23\n    If true: throw to monkey 2\n    If false: throw to monkey 3\n\nMonkey 1:\n  Starting items: 54, 65, 75, 74\n  Operation: new = old + 6\n  Test: divisible by 19\n    If true: throw to monkey 2\n    If false: throw to monkey 0\n\nMonkey 2:\n  Starting items: 79, 60, 97\n  Operation: new = old * old\n  Test: divisible by 13\n    If true: throw to monkey 1\n    If false: throw to monkey 3\n\nMonkey 3:\n  Starting items: 74\n  Operation: new = old + 3\n  Test: divisible by 17\n    If true: throw to monkey 0\n    If false: throw to monkey 1";

        var keepAway = new KeepAway(input, true);
        var result = keepAway.GetMonkeyBusinessAfterRounds(20);

        result.Should().Be(10605);
    }
    
    [Fact]
    public void MonkeyBusinessLevelIsCorrectWithNoReliefAfterManyRounds()
    {
        var input =
            "Monkey 0:\n  Starting items: 79, 98\n  Operation: new = old * 19\n  Test: divisible by 23\n    If true: throw to monkey 2\n    If false: throw to monkey 3\n\nMonkey 1:\n  Starting items: 54, 65, 75, 74\n  Operation: new = old + 6\n  Test: divisible by 19\n    If true: throw to monkey 2\n    If false: throw to monkey 0\n\nMonkey 2:\n  Starting items: 79, 60, 97\n  Operation: new = old * old\n  Test: divisible by 13\n    If true: throw to monkey 1\n    If false: throw to monkey 3\n\nMonkey 3:\n  Starting items: 74\n  Operation: new = old + 3\n  Test: divisible by 17\n    If true: throw to monkey 0\n    If false: throw to monkey 1";

        var keepAway = new KeepAway(input, false);
        var result = keepAway.GetMonkeyBusinessAfterRounds(10000);

        result.Should().Be(2713310158);
    }
}