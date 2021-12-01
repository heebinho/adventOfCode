<Query Kind="Statements" />

var lines = File.ReadAllLines(@"C:\workarea\aoc\input1.txt").Select(l=>int.Parse(l));
lines.Zip(lines.Skip(1)).Where((t)=>t.Second>t.First).Count().Dump();