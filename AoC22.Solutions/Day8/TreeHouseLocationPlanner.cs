namespace AoC22.Solutions.Day8;

public class TreeHouseLocationPlanner
{
    private readonly Tree[][] _trees;

    public TreeHouseLocationPlanner(string input)
    {
        _trees = input
            .Split("\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(r => r.ToCharArray().Select(h => new Tree(int.Parse(h.ToString()))).ToArray())
            .ToArray();
        var numRows = _trees.Length;
        var numCols = _trees[0].Length;

        for (var r = 0; r < numRows; r++)
        {
            for (var c = 0; c < numCols; c++)
            {
                var tree = _trees[r][c];
                var northTree = r == 0 ? null : _trees[r - 1][c];
                var southTree = r == numRows - 1 ? null : _trees[r + 1][c];
                var eastTree = c == numCols - 1 ? null : _trees[r][c + 1];
                var westTree = c == 0 ? null : _trees[r][c - 1];
                tree.North = northTree;
                tree.South = southTree;
                tree.East = eastTree;
                tree.West = westTree;
            }
        }
    }

    public int CountTreesVisibleFromOutside()
    {
        return _trees.Sum(r => r.Count(t => t.IsVisible()));
    }

    public int GetHighestScenicScore()
    {
        return _trees.Max(r => r.Max(t => t.CalculateScenicScore()));
    }
}