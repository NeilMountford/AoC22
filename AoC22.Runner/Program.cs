using AoC22.Day1;
using AoC22.Day2;

var input = await LoadInputData(2);
var calculator = new RockPaperScissorsStrategyCalculator(input);
var result = calculator.CalculateScore();

Console.WriteLine($"Suggested strategy score: {result}");

async Task<string> LoadInputData(int day)
{
    return await File.ReadAllTextAsync(Path.Combine("E:\\dev\\aoc22\\inputs", $"day{day}.txt"));
}