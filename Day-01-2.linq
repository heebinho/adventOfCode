<Query Kind="Statements" />

string file = @"C:\Users\heebinho\source\repos\adventofcode\input1.txt";
var lines = File.ReadAllLines(file).Select(l => int.Parse(l));

//40000

var result = lines.SelectMany(l => lines, (l, r) => new { l, r, sum = l + r, prod = l * r })
				  .SelectMany(i => lines, (l, r) => new { l, r, sum = l.l + l.r + r, prod=l.l*l.r*r})
				  .First(s=>s.sum==2020).prod;
				  //.First().prod;

result.Dump();