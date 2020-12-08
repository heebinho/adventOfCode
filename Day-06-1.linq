<Query Kind="Statements" />

string file = @"C:\Users\heebinho\source\repos\adventofcode\input6.txt";
string input = File.ReadAllText(file);
var groups = input.Split("\r\n\r\n");

groups
 .Select(g => g.Split("\n"))
 .Select(g => new { Group = g, Chars = g.Aggregate((a, b) => (a.Trim() + b.Trim())).OrderBy(o => o) })
 .Select(g => g.Chars.Distinct())
 .Sum(g=>g.Count())
.Dump();