using AoC2021;

Day? day = Day.Create( args.FirstOrDefault(), typeof(Day20) ); 

Util.WriteLine( @"[  cyan]         .--._.--.--.__.--.--.__.--.--.__.--.--._.--.     "); 
Util.WriteLine( @"[  cyan]       _(_      _Y_      _Y_      _Y_      _Y_      _)_   "); 
Util.WriteLine( @"[yellow]      [___]    [___]    [___]    [___]    [___]    [___]  "); 
Util.WriteLine( @"[+white]      /:' \    /:' \    /:' \    /:' \    /:' \    /:' \  "); 
Util.WriteLine( @"[+white]     |::   |  |::   |  |::   |  |::   |  |::   |  |::   | "); 
Util.WriteLine( @"[+white]     \::.  /  \::.  /  \::.  /  \::.  /  \::.  /  \::.  / "); 
Util.WriteLine( @"[+white]      \::./    \::./    \::./    \::./    \::./    \::./  "); 
Util.WriteLine( @"[+white]       '='      '='      '='      '='      '='      '='   "); 
Util.WriteLine( @"[   red]                ------------------------------            "); 
Util.WriteLine( @"[ green]                        AoC.2021." + day.GetType().Name    ); 
Util.WriteLine(  "[   red]                ------------------------------         \n" ); 

string answerA; 
string answerB; 

// Warmup Run
{
    using var t = new ScopeTimer("Parsing Input"); 
    day.ParseInput(); 
}

// Run Part A
{
    using var t = new ScopeTimer(" Part A"); 
    answerA = day.RunA(); 
}
Util.WriteLine($" > Answer A: [+white]{answerA}\n");

// Run Part B
{
    using var t = new ScopeTimer(" Part B"); 
    answerB = day.RunB(); 
}
Util.WriteLine($" > Answer B: [+white]{answerB}\n"); 

// Copy answer to clipboard out of laziness;
if (!string.IsNullOrEmpty(answerB))
{
    Clipboard.SetText(answerB); 
}
else if (!string.IsNullOrEmpty(answerA))
{
    Clipboard.SetText(answerA); 
}


