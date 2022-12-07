namespace AoC22.Solutions.Day4;

public class CleanupCrossover
{
    private readonly List<ElfPairSections> _sectionsCovered;

    public CleanupCrossover(string input)
    {
        _sectionsCovered = input
            .Split("\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(pair =>
            {
                var elfSections = pair.Split(",");
                var elf1Sections = GetElfSections(elfSections[0]);
                var elf2Sections = GetElfSections(elfSections[1]);
                return new ElfPairSections(elf1Sections, elf2Sections);
            })
            .ToList();
    }

    private int[] GetElfSections(string elfSection)
    {
        var rangeSplit = elfSection.Split("-");
        var start = int.Parse(rangeSplit[0]);
        var end = int.Parse(rangeSplit[1]);
        var sectionCount = end - start + 1;
        return Enumerable.Range(start, sectionCount).ToArray();
    }

    public int GetPairsWithFullOverlap()
    {
        return _sectionsCovered.Count(s => s.ElfWithMostSections.Intersect(s.OtherElfSections).Count() == s.OtherElfSections.Length);
    }

    public int GetPairsWithPartialOverlap()
    {
        return _sectionsCovered.Count(s => s.ElfWithMostSections.Intersect(s.OtherElfSections).Any());
    }
}