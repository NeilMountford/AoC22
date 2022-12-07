namespace AoC22.Solutions.Day2;

public class HandShapeOutcomeStrategyCalculator
{
    private const int WinScore = 6;
    private const int DrawScore = 3;
    private const int LoseScore = 0;

    private const int RockScore = 1;
    private const int PaperScore = 2;
    private const int ScissorScore = 3;
    
    private readonly List<HandShapeOutcomeStrategy> _movesWithDesiredOutcomes;

    public HandShapeOutcomeStrategyCalculator(string input)
    {
        _movesWithDesiredOutcomes = input
            .Split("\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(
                moves =>
                {
                    var handShapeWithDesiredOutcome = moves.Split(" ");
                    var opponentHandShape = ParseOpponentHandShape(handShapeWithDesiredOutcome[0]);
                    var desiredOutcome = ParseDesiredOutcomeHandShape(handShapeWithDesiredOutcome[1]);
                    return new HandShapeOutcomeStrategy(opponentHandShape, desiredOutcome);
                })
            .ToList();
    }

    public int CalculateScore()
    {
        return _movesWithDesiredOutcomes
            .Select(GetHandShapeStrategy)
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

    private DesiredOutcome ParseDesiredOutcomeHandShape(string input)
    {
        return input switch
        {
            "X" => DesiredOutcome.Lose,
            "Y" => DesiredOutcome.Draw,
            "Z" => DesiredOutcome.Win,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private HandShapeStrategy GetHandShapeStrategy(HandShapeOutcomeStrategy outcomeStrategy)
    {
        var suggestedHandShape = (outcomeStrategy.OpponentHandShape, outcomeStrategy.DesiredOutcome) switch
        {
            (HandShape.Rock, DesiredOutcome.Lose) => HandShape.Scissors,
            (HandShape.Rock, DesiredOutcome.Win) => HandShape.Paper,
            (HandShape.Paper, DesiredOutcome.Win) => HandShape.Scissors,
            (HandShape.Paper, DesiredOutcome.Lose) => HandShape.Rock,
            (HandShape.Scissors, DesiredOutcome.Lose) => HandShape.Paper,
            (HandShape.Scissors, DesiredOutcome.Win) => HandShape.Rock,
            (_, DesiredOutcome.Draw) => outcomeStrategy.OpponentHandShape,
            _ => throw new ArgumentOutOfRangeException()
        };
        return new HandShapeStrategy(outcomeStrategy.OpponentHandShape, suggestedHandShape);
    }

    private int GetPlayerScore(HandShapeStrategy handShapeStrategy)
    {
        return (handShapeStrategy.SuggestedHandShape, handShapeStrategy.OpponentHandShape) switch
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