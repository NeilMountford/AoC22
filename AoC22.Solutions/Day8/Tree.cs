namespace AoC22.Solutions.Day8;

public class Tree
{
    private int Height { get; }

    public Tree? North
    {
        set => _treesInOtherDirections[Direction.North] = value;
    }

    public Tree? East
    {
        set => _treesInOtherDirections[Direction.East] = value;
    }
    public Tree? South
    {
        set => _treesInOtherDirections[Direction.South] = value;
    }
    public Tree? West
    {
        set => _treesInOtherDirections[Direction.West] = value;
    }

    private readonly Dictionary<Direction, Tree?> _treesInOtherDirections;

    public Tree(int height)
    {
        Height = height;
        _treesInOtherDirections = new Dictionary<Direction, Tree?>();
    }

    public bool IsVisible()
    {
        return
            IsOnEdge() ||
            IsVisibleInDirection(Direction.North) ||
            IsVisibleInDirection(Direction.East) ||
            IsVisibleInDirection(Direction.South) ||
            IsVisibleInDirection(Direction.West);
    }

    public int CalculateScenicScore()
    {
        return
            CalculateScenicScoreInDirection(Direction.North) *
            CalculateScenicScoreInDirection(Direction.East) *
            CalculateScenicScoreInDirection(Direction.South) *
            CalculateScenicScoreInDirection(Direction.West);
    }

    private int CalculateScenicScoreInDirection(Direction direction)
    {
        var score = 0;
        var nextVisibleTree = _treesInOtherDirections[direction];

        while (nextVisibleTree != null)
        {
            score++;
            nextVisibleTree = nextVisibleTree.Height < Height ? nextVisibleTree._treesInOtherDirections[direction] : null;
        }

        return score;
    }

    private bool IsOnEdge()
    {
        return
            _treesInOtherDirections[Direction.North] == null ||
            _treesInOtherDirections[Direction.East] == null ||
            _treesInOtherDirections[Direction.South] == null ||
            _treesInOtherDirections[Direction.West] == null;
    }

    private bool IsVisibleInDirection(Direction direction)
    {
        var nextTree = _treesInOtherDirections[direction];
        
        while (nextTree != null)
        {
            if (nextTree.Height >= Height)
            {
                return false;
            }

            nextTree = nextTree._treesInOtherDirections[direction];
        }

        return true;
    }
}