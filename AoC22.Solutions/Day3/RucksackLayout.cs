namespace AoC22.Solutions.Day3;

public class RucksackLayout
{
    private readonly List<Rucksack> _rucksacks;
    private readonly Dictionary<char, int> _characterPriorities;

    public RucksackLayout(string input)
    {
        _rucksacks = input
            .Split("\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(items =>
            {
                var itemsPerCompartment = items.Length / 2;
                var compartment1 = items[..itemsPerCompartment].ToCharArray();
                var compartment2 = items[itemsPerCompartment..].ToCharArray();
                return new Rucksack(compartment1, compartment2);
            })
            .ToList();

        _characterPriorities = Enumerable.Range('a', 'z').Zip(Enumerable.Range(1, 26))
            .Concat(Enumerable.Range('A', 'Z').Zip(Enumerable.Range(27, 26)))
            .ToDictionary(zipped => (char)zipped.First, zipped => zipped.Second);
    }

    public int GetSumOfIncorrectlyPackedItemPriorities()
    {
        return _rucksacks
            .Select(r => r.Compartment1.Intersect(r.Compartment2).Sum(i => _characterPriorities[i]))
            .Sum();
    }
}