<Query Kind="Statements" />

string file = @"C:\Users\heebinho\source\repos\adventofcode\input7.txt";
var lines = File.ReadAllLines(file);

Func<Dictionary<string, Dictionary<string, string>>, KeyValuePair<string, Dictionary<string, string>>, int> countBags = null;
countBags = (bags, bag) => {
	if (bag.Value.Keys.Count == 1 && bag.Value.Keys.Single() == "other bag") return 0;
	return bag.Value.Select(v => int.Parse(v.Value) + int.Parse(v.Value) * countBags(bags, bags.Single(b => b.Key == v.Key))).Sum();
};

var bags = lines
.Select(l => l.Split(new string[] { ",", "contain", "." }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
.ToDictionary(k => k.First().Replace("bags", "bag"), v => v.Skip(1).ToDictionary(k => k.Split(" ", 2)[1].Replace("bags", "bag"), v => v.Split(" ", 2)[0]));

countBags(bags, bags.Single(b => b.Key== "shiny gold bag")).Dump();