namespace AoC22.Solutions.Day7;

public class DeviceDirectory
{
    public DeviceDirectory? Parent { get; }
    public Dictionary<string, DeviceDirectory> Directories { get; }
    public List<DeviceFile> Files { get; }
    public string Name { get; }

    public DeviceDirectory(string name, DeviceDirectory? parent)
    {
        Name = name;
        Parent = parent;
        Directories = new Dictionary<string, DeviceDirectory>();
        Files = new List<DeviceFile>();
    }

    public int GetDirectorySize()
    {
        return
            Files.Select(f => f.Size).Sum() +
            Directories.Values.Select(d => d.GetDirectorySize()).Sum();
    }
}