<Query Kind="Statements" />

var lines = File.ReadAllLines(@"C:\workarea\aoc\input1.txt").Select(l=>int.Parse(l));
var windows = lines.SkipLast(2).Select((l,i)=>l+lines.Skip(i+1).Take(2).Sum());
windows.Zip(windows.Skip(1)).Where(w=>w.Second>w.First).Count().Dump();