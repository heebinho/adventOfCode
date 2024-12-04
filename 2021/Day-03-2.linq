<Query Kind="Statements" />

// 6987776
//2.try 683
var lines = File.ReadAllLines(@"C:\Users\renato\code\adventOfCode\input3.txt").Select(li => li.ToCharArray().Select(c => c - 48).ToArray());
//lines.Dump();

Func<IEnumerable<int[]>, int, bool, int> filterBy = (l, pos, common) => (l.Count()/2 >= l.Sum(a=>a.Skip(pos).First())==common) ? 1:0 ;

Func<IEnumerable<int[]>, int, bool, int[]> distil = null;
distil = (l, pos, common) => {
	l.Dump();
	if (l.Count() == 1) return l.First();
	int bit = filterBy(l, pos, common);
	bit.Dump();
	return distil( l.Where(a=>a.Skip(pos).First() ==     bit           ), ++pos, common );
};
 

var ox = distil(lines, 0, true); ox.Dump();
var co2 = distil(lines, 0, false); co2.Dump();


var a = ox.Select((b,i)=>Math.Pow(2,i)*b);
var b = co2.Select((b,i)=>Math.Pow(2,i)*b);

a.Dump(); b.Dump();

b.Sum().Dump();