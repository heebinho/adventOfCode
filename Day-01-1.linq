<Query Kind="Statements">
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

//IEnumerable<int> items = new List<int>() { 1721,979,366,299,675,1456 };

string file = @"C:\Users\heebinho\source\repos\adventofcode\input1.txt";
var items = File.ReadAllLines(file).Select(l=>int.Parse(l));

var result = items.SelectMany(i => items, (l, r) => new { l, r, sum = l+r, prod=l*r } )
				  .First(i=>i.sum == 2020).prod;

result.Dump();