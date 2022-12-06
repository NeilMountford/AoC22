using AoC22.Day1;

const string inputFolder = "E:\\dev\\aoc22\\inputs";
var input = await File.ReadAllTextAsync(Path.Combine(inputFolder, "day1-1.txt"));
var day1 = new MostCalorieCalculator(input, "\n");

Console.WriteLine($"Elf with most calories: {day1.GetHighestCalories()}");