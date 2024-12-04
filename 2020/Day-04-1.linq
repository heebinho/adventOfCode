<Query Kind="Statements" />

string file = @"C:\Users\heebinho\source\repos\adventofcode\input4.txt";
string input = File.ReadAllText(file);

var passports = input.Split("\r\n\r\n");

passports
	.Select( p => p.Split(' ','\n'))
	.Select( p => p.ToDictionary( k=>k.Split(":")[0], v=>v.Split(":")[1]))
	.Where( p => p.Count == 8 || (p.Count==7 && !p.ContainsKey("cid") ) )



.Dump();