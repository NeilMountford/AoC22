using System.Numerics;

namespace AoC22.Solutions.Day11;

public class Monkey
{
    private const int ReliefDivisor = 3;
    
    private readonly Func<long, long> _worryFunction;
    private readonly uint _divisor;
    private readonly Func<Monkey> _trueMonkeySelector;
    private readonly Func<Monkey> _falseMonkeySelector;
    private readonly Func<uint> _getDivisorProduct;
    private readonly bool _applyReliefAfterInspection;
    private readonly Queue<long> _itemWorryLevels;
    public long InspectionCount { get; private set; }

    public Monkey(
        IEnumerable<long> startingItemWorryLevels,
        Func<long, long> worryFunction,
        uint divisor,
        Func<Monkey> trueMonkeySelector,
        Func<Monkey> falseMonkeySelector,
        bool applyReliefAfterInspection,
        Func<uint> getDivisorProduct)
    {
        InspectionCount = 0;
        _worryFunction = worryFunction;
        _divisor = divisor;
        _trueMonkeySelector = trueMonkeySelector;
        _falseMonkeySelector = falseMonkeySelector;
        _applyReliefAfterInspection = applyReliefAfterInspection;
        _getDivisorProduct = getDivisorProduct;
        _itemWorryLevels = new Queue<long>(startingItemWorryLevels);
    }

    public void TakeTurn()
    {
        while (_itemWorryLevels.Count > 0)
        {
            InspectItem(_itemWorryLevels.Dequeue());
        }
    }

    private void InspectItem(long itemWorryLevel)
    {
        checked
        {
            var newWorryLevel = _worryFunction(itemWorryLevel);
            var newWorryLevelAfterRelief = _applyReliefAfterInspection 
                ? newWorryLevel / ReliefDivisor 
                : newWorryLevel % _getDivisorProduct();
            if (newWorryLevelAfterRelief % _divisor == 0)
            {
                _trueMonkeySelector().ThrowItem(newWorryLevelAfterRelief);
            }
            else
            {
                _falseMonkeySelector().ThrowItem(newWorryLevelAfterRelief);
            }
            InspectionCount++;
        }
    }

    private void ThrowItem(long itemWorryLevel)
    {
        _itemWorryLevels.Enqueue(itemWorryLevel);
    }
}