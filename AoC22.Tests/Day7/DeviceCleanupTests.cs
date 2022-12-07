using AoC22.Solutions.Day7;

namespace AoC22.Tests.Day7;

public class DeviceCleanupTests
{
    [Fact]
    public void DirectorySumIsCorrect()
    {
        var input =
            "$ cd /\n$ ls\ndir a\n14848514 b.txt\n8504156 c.dat\ndir d\n$ cd a\n$ ls\ndir e\n29116 f\n2557 g\n62596 h.lst\n$ cd e\n$ ls\n584 i\n$ cd ..\n$ cd ..\n$ cd d\n$ ls\n4060174 j\n8033020 d.log\n5626152 d.ext\n7214296 k";

        var cleanup = new DeviceCleanup(input);
        var result = cleanup.GetSumOfSizesForDirectoriesWithSizeAtMost100000();

        result.Should().Be(95437);
    }
    
    [Fact]
    public void DirectoryToDeleteSizeIsCorrect()
    {
        var input =
            "$ cd /\n$ ls\ndir a\n14848514 b.txt\n8504156 c.dat\ndir d\n$ cd a\n$ ls\ndir e\n29116 f\n2557 g\n62596 h.lst\n$ cd e\n$ ls\n584 i\n$ cd ..\n$ cd ..\n$ cd d\n$ ls\n4060174 j\n8033020 d.log\n5626152 d.ext\n7214296 k";

        var cleanup = new DeviceCleanup(input);
        var result = cleanup.GetSizeOfSmallestDeletableDirectory();

        result.Should().Be(24933642);
    }
}