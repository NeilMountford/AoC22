namespace AoC22.Solutions.Day6;

public class SignalDecoder
{
    private readonly string _signal;
    
    public SignalDecoder(string input)
    {
        _signal = input.Trim();
    }

    public int FindFirstPacket()
    {
        return FindUniqueCharacterSequence(4);
    }

    public int FindMessage()
    {
        return FindUniqueCharacterSequence(14);
    }

    private int FindUniqueCharacterSequence(int numberOfUniqueCharacters)
    {
        var indexOffset = numberOfUniqueCharacters - 1;
        for (var i = indexOffset; i < _signal.Length; i++)
        {
            var inclusiveStart = i - indexOffset;
            var exclusiveEnd = i + 1;
            var last4 = _signal[inclusiveStart..exclusiveEnd];
            if (last4.Distinct().Count() == numberOfUniqueCharacters)
            {
                return exclusiveEnd;
            }
        }

        return 0;
    }
}