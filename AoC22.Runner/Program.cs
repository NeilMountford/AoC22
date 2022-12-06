using AoC22.Day1;
using AoC22.Day2;

var input = await LoadInputData(2);
var handShapeCalculator = new BothInputsHandShapeStrategyCalculator(input);
var handShapeResult = handShapeCalculator.CalculateScore();

var outcomeCalculator = new HandShapeOutcomeStrategyCalculator(input);
var outcomeResult = outcomeCalculator.CalculateScore();

Console.WriteLine($"Suggested strategy score for hand shape: {handShapeResult}");
Console.WriteLine($"Suggested strategy score for desired outcome: {outcomeResult}");

async Task<string> LoadInputData(int day)
{
    return await File.ReadAllTextAsync(Path.Combine("E:\\dev\\aoc22\\inputs", $"day{day}.txt"));
}