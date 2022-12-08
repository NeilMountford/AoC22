﻿using AoC22.Solutions.Day2;
using AoC22.Solutions.Day3;
using AoC22.Solutions.Day4;
using AoC22.Solutions.Day8;

await Day8();

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

async Task Day8()
{
    var input = await LoadInputData(8);
    var treeHousePlanner = new TreeHouseLocationPlanner(input);
    var visibleTrees = treeHousePlanner.CountTreesVisibleFromOutside();
    var bestScenicScore = treeHousePlanner.GetHighestScenicScore();

    Console.WriteLine($"Visible trees: {visibleTrees}");
    Console.WriteLine($"Most scenic: {bestScenicScore}");
}