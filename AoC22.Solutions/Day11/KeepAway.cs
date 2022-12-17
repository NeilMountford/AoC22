using System.Numerics;

namespace AoC22.Solutions.Day11;

public class KeepAway
{
    private readonly Monkey[] _monkeys;
    
    public KeepAway(string input, bool applyReliefAfterInspection)
    {
        var divisors = new List<uint>();
        uint GetDivisor() => divisors.Aggregate(1u, (acc, val) => acc * val);
        
        _monkeys = input
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(
                m =>
                {
                    var lines = m.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                    var startingItemWorryLevels = lines[1]
                        .Replace("Starting items: ", "")
                        .Split(",", StringSplitOptions.TrimEntries)
                        .Select(long.Parse);
                    
                    var operation = lines[2]
                        .Replace("Operation: new = ", "")
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    long CalculateNewWorry(long old)
                    {
                        checked
                        {
                            var l = long.TryParse(operation[0], out var leftOperand) ? leftOperand : old;
                            var r = long.TryParse(operation[2], out var rightOperand) ? rightOperand : old;
                            return operation[1] switch
                            {
                                "+" => l + r,
                                "*" => l * r,
                                _ => throw new ArgumentOutOfRangeException("operator")
                            };
                        }
                    }

                    var divisor = uint.Parse(lines[3].Split(" ").Last());
                    divisors.Add(divisor);
                    
                    var testTrueTargetMonkey = int.Parse(lines[4].Split(" ").Last());
                    var testFalseTargetMonkey = int.Parse(lines[5].Split(" ").Last());

                    return new Monkey(
                        startingItemWorryLevels,
                        CalculateNewWorry,
                        divisor,
                        () => _monkeys![testTrueTargetMonkey],
                        () => _monkeys![testFalseTargetMonkey],
                        applyReliefAfterInspection,
                        GetDivisor);
                })
            .ToArray();
    }

    public long GetMonkeyBusinessAfterRounds(int roundsToPlay)
    {
        for (var round = 0; round < roundsToPlay; round++)
        {
            foreach (var monkey in _monkeys)
            {
                monkey.TakeTurn();
            }
        }

        var top2 = _monkeys.Select(m => m.InspectionCount).OrderByDescending(i => i).Take(2);
        return top2.First() * top2.Last();
    }
}