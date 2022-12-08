namespace AoC22.Solutions.Day8;

public class Tree
{
    public int Height { get; }

    public Tree? North { get; set; }
    public Tree? East { get; set; }
    public Tree? South { get; set; }
    public Tree? West { get; set; }

    public Tree(int height)
    {
        Height = height;
    }

    public bool IsVisible()
    {
        return
            IsOnEdge() ||
            IsVisibleToNorth() ||
            IsVisibleToEast() ||
            IsVisibleToSouth() ||
            IsVisibleToWest();
    }

    public int CalculateScenicScore()
    {
        return
            CalculateNorthScenicScore() *
            CalculateEastScenicScore() *
            CalculateSouthScenicScore() *
            CalculateWestScenicScore();
    }

    private int CalculateNorthScenicScore()
    {
        var score = 0;
        var nextVisibleTree = North;

        while (nextVisibleTree != null)
        {
            score++;
            nextVisibleTree = nextVisibleTree.Height < Height ? nextVisibleTree.North : null;
        }

        return score;
        // if (North != null)
        // {
        //     return North.Height < Height ? North.CalculateNorthScenicScore(scenicScoreSum + 1) : scenicScoreSum + 1;
        // }
        //
        // return scenicScoreSum;
    }

    private int CalculateEastScenicScore()
    {
        var score = 0;
        var nextVisibleTree = East;

        while (nextVisibleTree != null)
        {
            score++;
            nextVisibleTree = nextVisibleTree.Height < Height ? nextVisibleTree.East : null;
        }

        return score;
        // if (East != null)
        // {
        //     return East.Height < Height ? East.CalculateEastScenicScore(scenicScoreSum + 1) : scenicScoreSum + 1;
        // }
        //
        // return scenicScoreSum;
    }

    private int CalculateSouthScenicScore()
    {
        var score = 0;
        var nextVisibleTree = South;

        while (nextVisibleTree != null)
        {
            score++;
            nextVisibleTree = nextVisibleTree.Height < Height ? nextVisibleTree.South : null;
        }

        return score;
        // if (South != null)
        // {
        //     return South.Height < Height ? South.CalculateSouthScenicScore(scenicScoreSum + 1) : scenicScoreSum + 1;
        // }
        //
        // return scenicScoreSum;
    }

    private int CalculateWestScenicScore()
    {
        var score = 0;
        var nextVisibleTree = West;

        while (nextVisibleTree != null)
        {
            score++;
            nextVisibleTree = nextVisibleTree.Height < Height ? nextVisibleTree.West : null;
        }

        return score;
        // if (West != null)
        // {
        //     return West.Height < Height ? West.CalculateWestScenicScore(scenicScoreSum + 1) : scenicScoreSum + 1;
        // }
        //
        // return scenicScoreSum;
    }

    private bool IsOnEdge()
    {
        return
            North == null ||
            East == null ||
            South == null ||
            West == null;
    }

    private bool IsVisibleToNorth()
    {
        var nextTree = North;

        while (nextTree != null)
        {
            if (nextTree.Height >= Height)
            {
                return false;
            }

            nextTree = nextTree.North;
        }

        return true;
    }

    private bool IsVisibleToEast()
    {
        var nextTree = East;

        while (nextTree != null)
        {
            if (nextTree.Height >= Height)
            {
                return false;
            }

            nextTree = nextTree.East;
        }

        return true;
    }

    private bool IsVisibleToSouth()
    {
        var nextTree = South;

        while (nextTree != null)
        {
            if (nextTree.Height >= Height)
            {
                return false;
            }

            nextTree = nextTree.South;
        }

        return true;
    }

    private bool IsVisibleToWest()
    {
        var nextTree = West;

        while (nextTree != null)
        {
            if (nextTree.Height >= Height)
            {
                return false;
            }

            nextTree = nextTree.West;
        }

        return true;
    }
}