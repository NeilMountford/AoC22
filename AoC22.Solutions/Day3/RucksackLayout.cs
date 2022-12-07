namespace AoC22.Solutions.Day3;

public class RucksackLayout
{
    private readonly List<ElfGroup> _groupedRucksacks;
    private readonly Dictionary<char, int> _characterPriorities;

    public RucksackLayout(string input)
    {
        _groupedRucksacks = input
            .Split("\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(items =>
            {
                var itemsPerCompartment = items.Length / 2;
                var compartment1 = items[..itemsPerCompartment].ToCharArray();
                var compartment2 = items[itemsPerCompartment..].ToCharArray();
                return new Rucksack(compartment1, compartment2);
            })
            .Select((rucksack, index) => (rucksack, index))
            .GroupBy(rucksackWithIndex => rucksackWithIndex.index / 3, rucksackWithIndex => rucksackWithIndex.rucksack)
            .Select(group => new ElfGroup(group.ToArray()))
            .ToList();

        _characterPriorities = Enumerable.Range('a', 'z').Zip(Enumerable.Range(1, 26))
            .Concat(Enumerable.Range('A', 'Z').Zip(Enumerable.Range(27, 26)))
            .ToDictionary(zipped => (char)zipped.First, zipped => zipped.Second);
    }

    public int GetSumOfIncorrectlyPackedItemPriorities()
    {
        return _groupedRucksacks
            .SelectMany(group => group.Rucksacks)
            .Select(r => r.Compartment1.Intersect(r.Compartment2).Sum(i => _characterPriorities[i]))
            .Sum();
    }

    public int GetSumOfBadgeItemPriorities()
    {
        return _groupedRucksacks
            .Select(group => group.Rucksacks.Select(r => r.Compartment1.Concat(r.Compartment2)))
            .Select(groupRucksackCompartments => groupRucksackCompartments.Aggregate((l1, l2) => l1.Intersect(l2)).Single())
            .Select(badge => _characterPriorities[badge])
            .Sum();
    }
}