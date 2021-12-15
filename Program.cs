﻿using AoC2021;

Day? day = Day.Create( args.FirstOrDefault(), typeof(Day15) ); 

Console.WriteLine( "         .--._.--.--.__.--.--.__.--.--.__.--.--._.--."); 
Console.WriteLine( "       _(_      _Y_      _Y_      _Y_      _Y_      _)_"); 
Console.WriteLine( "      [___]    [___]    [___]    [___]    [___]    [___]"); 
Console.WriteLine( "      /:' \\    /:' \\    /:' \\    /:' \\    /:' \\    /:' \\"); 
Console.WriteLine( "     |::   |  |::   |  |::   |  |::   |  |::   |  |::   |"); 
Console.WriteLine( "     \\::.  /  \\::.  /  \\::.  /  \\::.  /  \\::.  /  \\::.  /"); 
Console.WriteLine( "      \\::./    \\::./    \\::./    \\::./    \\::./    \\::./"); 
Console.WriteLine( "       '='      '='      '='      '='      '='      '='"); 
Console.WriteLine( "                ------------------------------" ); 
Console.WriteLine( "                        AoC.2021." + day.GetType().Name ); 
Console.WriteLine( "                ------------------------------" ); 

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


