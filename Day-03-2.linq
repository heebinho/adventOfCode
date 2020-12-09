<Query Kind="Statements" />

string file = @"C:\Users\heebinho\source\repos\adventofcode\input3.txt";
var lines = File.ReadAllLines(file);

Func<string, int, int, int> f = (l, i, r) => i * r % l.Count();

var recs = lines
	.Select( (l, i) => new { Line = l, i, 
					I1 = f(l, i, 1), 
					I3 = f(l, i, 3), 
					I5 = f(l, i, 5), 
					I7 = f(l, i, 7) })
	.Select((r, i) => new { Record=r, i, 
					S1=r.Line[r.I1], 
					S3=r.Line[r.I3], 
					S5=r.Line[r.I5], 
					S7=r.Line[r.I7] });

var a = recs.Where(r=>r.S1=='#').Count().Dump();
var b = recs.Where(r=>r.S3=='#').Count().Dump();
var c = recs.Where(r=>r.S5=='#').Count().Dump();
var d = recs.Where(r=>r.S7=='#').Count().Dump();

var recsV = lines
	.Where((l, i) => i % 2 == 0)
	.Select((l, i) => new { Line = l, i, I1 = f(l, i, 1) })
	.Select((r, i) => new { Record = r, i, S1 = r.Line[r.I1]});

var e = recsV.Where(r=>r.S1=='#').Count().Dump();

var result = a*b*c*d*e;
result.Dump();


