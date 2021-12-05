<Query Kind="Statements" />

// 1544000595
var commands = File.ReadAllLines(@"C:\Users\renato\code\adventOfCode\input2.txt").Select(l => new { action = l.Split()[0], no = int.Parse(l.Split()[1]) })
.Select((c,i) => {
	var t = c.action switch {
		"forward" => (c.no,0,0),
		"up" => (0,c.no,0),
		"down" => (0,0,c.no),
		_=>(0,0,0)
	};
	return new {i=i, f=t.Item1, up=t.Item2, down=t.Item3};
});

var nav = commands.Select(c => new {c.f, aim=commands.Take(c.i).Sum(pcs=>pcs.down - pcs.up) } )
				  .Select(c => new {c.f, depth=c.f*c.aim});

(nav.Sum(n=>n.f) * nav.Sum(n=>n.depth)).Dump();


