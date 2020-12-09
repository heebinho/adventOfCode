<Query Kind="Statements" />

string file = @"C:\Users\heebinho\source\repos\adventofcode\input2.txt";
var lines = File.ReadAllLines(file);

//How many passwords are valid?

lines.Select(l => l.Split(':', '-', ' '))
	 .Select(l => new { PosAno = int.Parse(l[0]), PosBno = int.Parse(l[1]), Character = l[2].ToCharArray()[0], Pwd = l.Last() })
	 .Select(r => new { Record = r, PosA = r.Pwd[r.PosAno - 1], PosB = r.Pwd[r.PosBno - 1] })
	 .Select(rp => new { RecPos = rp , A=rp.PosA==rp.Record.Character, B=rp.PosB==rp.Record.Character})
	 .Where(c=> c.A != c.B) 
	 //.Count()
	 .Dump();

lines.Dump();