<Query Kind="Statements" />

string file = @"C:\Users\heebinho\source\repos\adventofcode\input6.txt";
string input = File.ReadAllText(file);
var groups = input.Split("\r\n\r\n");

groups
 .Select(g => g.Split("\n"))
 .Select(g => new { Group = g, Chars = g.Aggregate((a, b) => (a.Trim() + b.Trim())).OrderBy(o => o) })
 .Select(g => new { Group = g, CharGroups= g.Chars.GroupBy(g=>g) })
 .Select(g => g.CharGroups.Where(cg=>cg.Count() == g.Group.Group.Count()) )
 .Sum(g => g.Count())
.Dump();