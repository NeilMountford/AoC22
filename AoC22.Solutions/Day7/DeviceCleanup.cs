namespace AoC22.Solutions.Day7;

public class DeviceCleanup
{
    private readonly DeviceDirectory _root;
    private readonly List<DeviceDirectory> _allDirectories;
    
    public DeviceCleanup(string input)
    {
        _root = new DeviceDirectory("/", null);
        _allDirectories = new List<DeviceDirectory>();
        
        var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        var currentDirectory = _root;

        foreach (var line in lines)
        {
            var segments = line.Split(" ");
            if (line.StartsWith("$"))
            {
                var command = segments[1];

                if (command == "cd")
                {
                    var target = segments[2];

                    if (target == "/")
                    {
                        currentDirectory = _root;
                    }
                    else if (target == "..")
                    {
                        currentDirectory = currentDirectory.Parent ?? _root;
                    }
                    else
                    {
                        currentDirectory = currentDirectory.Directories[target];
                    }
                }
            }
            else
            {
                if (segments[0] == "dir")
                {
                    var deviceDirectory = new DeviceDirectory(segments[1], currentDirectory);
                    currentDirectory.Directories.Add(segments[1], deviceDirectory);
                    _allDirectories.Add(deviceDirectory);
                }
                else
                {
                    currentDirectory.Files.Add(new DeviceFile(segments[1], int.Parse(segments[0])));
                }
            }
        }
    }

    public int GetSumOfSizesForDirectoriesWithSizeAtMost100000()
    {
        return _allDirectories
            .Where(d => d.GetDirectorySize() <= 100000)
            .Sum(d => d.GetDirectorySize());
    }

    public int GetSizeOfSmallestDeletableDirectory()
    {
        var totalSpace = 70000000;
        var spaceRequiredForUpdate = 30000000;
        var usedSpace = _root.GetDirectorySize();
        var remainingSpace = totalSpace - usedSpace;
        var requiredSpace = spaceRequiredForUpdate - remainingSpace;

        return _allDirectories
            .Where(d => d.GetDirectorySize() >= requiredSpace)
            .OrderBy(d => d.GetDirectorySize())
            .First()
            .GetDirectorySize();
    }
}