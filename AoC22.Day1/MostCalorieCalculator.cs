namespace AoC22.Day1;

public class MostCalorieCalculator
{
    private readonly IOrderedEnumerable<int> _calories;

    public MostCalorieCalculator(string input, string newlineCharacter)
    {
        var elfDelimiter = $"{newlineCharacter}{newlineCharacter}";
        
        var splitByElf = input
            .Split(elfDelimiter, StringSplitOptions.RemoveEmptyEntries);

        _calories = splitByElf.Select(
                e => e
                    .Split(newlineCharacter, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Sum())
            .OrderByDescending(i => i);
    }

    public int GetHighestCalories()
    {
        return _calories.First();
    }
}