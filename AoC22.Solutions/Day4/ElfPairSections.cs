namespace AoC22.Solutions.Day4;

public record ElfPairSections
{
    public int[] ElfWithMostSections { get; }
    public int[] OtherElfSections { get; }

    public ElfPairSections(int[] elf1Sections, int[] elf2Sections)
    {
        ElfWithMostSections = elf1Sections.Length >= elf2Sections.Length
            ? elf1Sections
            : elf2Sections;
        OtherElfSections = elf1Sections.Length < elf2Sections.Length
            ? elf1Sections
            : elf2Sections;
    }
}