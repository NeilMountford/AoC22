namespace AoC22.Day2;

public class RockPaperScissorsStrategyCalculator
{
    private const int WinScore = 6;
    private const int DrawScore = 3;
    private const int LoseScore = 0;

    private const int RockScore = 1;
    private const int PaperScore = 2;
    private const int ScissorScore = 3;
    
    private readonly List<Strategy> _movesWithStrategies;

    public RockPaperScissorsStrategyCalculator(string input)
    {
        _movesWithStrategies = input
            .Split("\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(
                moves =>
                {
                    var handShapes = moves.Split(" ");
                    var opponentHandShape = ParseOpponentHandShape(handShapes[0]);
                    var suggestedMoveHandShape = ParseSuggestedMoveHandShape(handShapes[1]);
                    return new Strategy(opponentHandShape, suggestedMoveHandShape);
                })
            .ToList();
    }

    public int CalculateScore()
    {
        return _movesWithStrategies
            .Select(GetPlayerScore)
            .Sum();
    }

    private HandShape ParseOpponentHandShape(string input)
    {
        return input switch
        {
            "A" => HandShape.Rock,
            "B" => HandShape.Paper,
            "C" => HandShape.Scissors,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private HandShape ParseSuggestedMoveHandShape(string input)
    {
        return input switch
        {
            "X" => HandShape.Rock,
            "Y" => HandShape.Paper,
            "Z" => HandShape.Scissors,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private int GetPlayerScore(Strategy strategy)
    {
        return (strategy.SuggestedHandShape, strategy.OpponentHandShape) switch
        {
            (HandShape.Rock, HandShape.Rock) => RockScore + DrawScore,
            (HandShape.Rock, HandShape.Paper) => RockScore + LoseScore,
            (HandShape.Rock, HandShape.Scissors) => RockScore + WinScore,
            (HandShape.Paper, HandShape.Rock) => PaperScore + WinScore,
            (HandShape.Paper, HandShape.Paper) => PaperScore + DrawScore,
            (HandShape.Paper, HandShape.Scissors) => PaperScore + LoseScore,
            (HandShape.Scissors, HandShape.Rock) => ScissorScore + LoseScore,
            (HandShape.Scissors, HandShape.Paper) => ScissorScore + WinScore,
            (HandShape.Scissors, HandShape.Scissors) => ScissorScore + DrawScore,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}