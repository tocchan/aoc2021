using AoC2021; 

var day = new Day11(); 
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


