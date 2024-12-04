<Query Kind="Statements" />

string file = @"C:\Users\heebinho\source\repos\adventofcode\input7.txt";
var lines = File.ReadAllLines(file);

Func<Dictionary<string, Dictionary<string,string>>, KeyValuePair<string, Dictionary<string, string>>, string, bool> y = null;
y = (bags, bag, key) => {
	if(bag.Value.Keys.Count==1 && bag.Value.Keys.Single() == "other bag") return false;
	return bag.Value.Keys.Contains(key)  || bag.Value.Keys.Any(k=> y(bags, bags.Single(b=>b.Key==k), key) );
};

var bags = lines
.Select(l => l.Split(new string[] {",", "contain", "."}, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
.ToDictionary(k => k.First().Replace("bags", "bag"), v => v.Skip(1).ToDictionary(k => k.Split(" ", 2)[1].Replace("bags", "bag"), v => v.Split(" ", 2)[0]));

bags.Select(bag => new { Bag=bag, y=y(bags, bag, "shiny gold bag")} )
.Where(o=>o.y == true)
.Dump();