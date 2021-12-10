using AoC2021;

Day day = args.FirstOrDefault() switch
{
    "1" => new Day01(),
    "2" => new Day02(),
    "3" => new Day03(),
    "4" => new Day04(),
    "5" => new Day05(),
    "6" => new Day06(),
    "7" => new Day07(),
    "8" => new Day08(),
    "9" => new Day09(),
    "10" => new Day10(),
    _ => new Day11(),
};

string answerA; 
string answerB; 

// Run Part A
{
    using var t = new ScopeTimer("Part A"); 
    answerA = day.RunA(); 
}
Console.WriteLine($"Answer A: {answerA}");

// Run Part B
{
    using var t = new ScopeTimer("Part B"); 
    answerB = day.RunB(); 
}
Console.WriteLine($"Answer B: {answerB}"); 

// Copy answer to clipboard out of laziness;
if (!string.IsNullOrEmpty(answerB))
{
    Clipboard.SetText(answerB); 
}
else if (!string.IsNullOrEmpty(answerA))
{
    Clipboard.SetText(answerA); 
}


