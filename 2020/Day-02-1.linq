<Query Kind="Statements">
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

string file = @"C:\Users\heebinho\source\repos\adventofcode\input2.txt";
var lines = File.ReadAllLines(file);

//How many passwords are valid?

lines.Select(l=>l.Split(':','-',' '))
	 .Select(l => new { Min = int.Parse(l[0]), Max = int.Parse(l[1]), Character = l[2].ToCharArray()[0], Pwd = l.Last() })
	 .Select(r => new { Record = r, No= r.Pwd.ToCharArray().Where(c=>c==r.Character).Count() })
	 .Where(i=> i.No >= i.Record.Min && i.No <= i.Record.Max)
	 .Count()
	 .Dump();