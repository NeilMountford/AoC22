using AoC22.Solutions.Day2;
using AoC22.Solutions.Day3;
using AoC22.Solutions.Day4;
using AoC22.Solutions.Day5;
using AoC22.Solutions.Day6;
using AoC22.Solutions.Day7;
using AoC22.Solutions.Day8;
using AoC22.Solutions.Day9;

await Day9();

async Task<string> LoadInputData(int day)
{
    return await File.ReadAllTextAsync(Path.Combine("../../../../inputs", $"day{day}.txt"));
}

async Task Day2()
{
    var input = await LoadInputData(2);
    var handShapeCalculator = new BothInputsHandShapeStrategyCalculator(input);
    var handShapeResult = handShapeCalculator.CalculateScore();

    var outcomeCalculator = new HandShapeOutcomeStrategyCalculator(input);
    var outcomeResult = outcomeCalculator.CalculateScore();

    Console.WriteLine($"Suggested strategy score for hand shape: {handShapeResult}");
    Console.WriteLine($"Suggested strategy score for desired outcome: {outcomeResult}");
}

async Task Day3()
{
    var input = await LoadInputData(3);
    var rucksack = new RucksackLayout(input);
    var sumOfIncorrectlyPackedItemPriorities = rucksack.GetSumOfIncorrectlyPackedItemPriorities();
    var sumOfBadgeItems = rucksack.GetSumOfBadgeItemPriorities();

    Console.WriteLine($"Sum of incorrectly packed item priorities: {sumOfIncorrectlyPackedItemPriorities}");
    Console.WriteLine($"Sum of badge item priorities: {sumOfBadgeItems}");
}

async Task Day4()
{
    var input = await LoadInputData(4);
    var cleanupCrossover = new CleanupCrossover(input);
    var fullCrossover = cleanupCrossover.GetPairsWithFullOverlap();
    var partialCrossover = cleanupCrossover.GetPairsWithPartialOverlap();

    Console.WriteLine($"Full crossover count: {fullCrossover}");
    Console.WriteLine($"Partial crossover count: {partialCrossover}");
}

async Task Day5()
{
    var input = await LoadInputData(5);
    var createUnloader9000 = new CrateUnloader9000(input);
    var createUnloader9001 = new CrateUnloader9001(input);
    var stackTops9000 = createUnloader9000.GetFinalTopOfStacks();
    var stackTops9001 = createUnloader9001.GetFinalTopOfStacks();

    Console.WriteLine($"StackTops (model 9000): {stackTops9000}");
    Console.WriteLine($"StackTops (model 9001): {stackTops9001}");
}

async Task Day6()
{
    var input = await LoadInputData(6);
    var signalDecoder = new SignalDecoder(input);
    var firstPacket = signalDecoder.FindFirstPacket();
    var firstMessage = signalDecoder.FindMessage();

    Console.WriteLine($"First packet: {firstPacket}");
    Console.WriteLine($"Message: {firstMessage}");
}

async Task Day7()
{
    var input = await LoadInputData(7);
    var deviceCleanup = new DeviceCleanup(input);
    var sumOfSizesForDirectoriesWithSizeAtMost100000 = deviceCleanup.GetSumOfSizesForDirectoriesWithSizeAtMost100000();
    var smallestRemovableSize = deviceCleanup.GetSizeOfSmallestDeletableDirectory();

    Console.WriteLine($"Sum for part 1: {sumOfSizesForDirectoriesWithSizeAtMost100000}");
    Console.WriteLine($"Smallest removable: {smallestRemovableSize}");
}

async Task Day8()
{
    var input = await LoadInputData(8);
    var treeHousePlanner = new TreeHouseLocationPlanner(input);
    var visibleTrees = treeHousePlanner.CountTreesVisibleFromOutside();
    var bestScenicScore = treeHousePlanner.GetHighestScenicScore();

    Console.WriteLine($"Visible trees: {visibleTrees}");
    Console.WriteLine($"Most scenic: {bestScenicScore}");
}

async Task Day9()
{
    var input = await LoadInputData(9);
    var ropePuller = new RopePuller(input);
    var tailVisitedLocationCount = ropePuller.CountTailLocationsVisited(1);
    var longRopeTailVisitedLocationCount = ropePuller.CountTailLocationsVisited(9);

    Console.WriteLine($"Tail locations visited: {tailVisitedLocationCount}");
    Console.WriteLine($"Long tail locations visited: {longRopeTailVisitedLocationCount}");
}