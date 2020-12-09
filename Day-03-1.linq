<Query Kind="Statements" />

string file = @"C:\Users\heebinho\source\repos\adventofcode\input3.txt";
var lines = File.ReadAllLines(file);

lines.Select( (l, i) => new { Line=l, i, C=l.Count(), Index=i*3, IndexM=i*3% (l.Count()) }  )
	.Select( r=> new {Record=r, Character=r.Line[r.IndexM]})
	.Where(cr=>cr.Character=='#')

.Dump();
