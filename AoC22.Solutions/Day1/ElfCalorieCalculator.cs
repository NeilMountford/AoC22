namespace AoC22.Solutions.Day1;

public class ElfCalorieCalculator
{
    private readonly IOrderedEnumerable<int> _orderedCalories;

    public ElfCalorieCalculator(string input, string newlineCharacter)
    {
        var elfDelimiter = $"{newlineCharacter}{newlineCharacter}";
        
        var splitByElf = input
            .Split(elfDelimiter, StringSplitOptions.RemoveEmptyEntries);

        _orderedCalories = splitByElf.Select(
                e => e
                    .Split(newlineCharacter, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Sum())
            .OrderByDescending(i => i);
    }

    public int GetCaloriesForElfWithHighest()
    {
        return _orderedCalories.First();
    }

    public int GetSumOfCaloriesForThreeElvesWithHighest()
    {
        return _orderedCalories.Take(3).Sum();
    }
}