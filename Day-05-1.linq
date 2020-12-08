<Query Kind="Statements" />

string file = @"C:\Users\heebinho\source\repos\adventofcode\input5.txt";
var seats = File.ReadAllLines(file);

Func<int, int, int> calcSeatId = (row, col) => row * 8 + col;
Func<IEnumerable<int>, string, int, int> which = null;
which = (r, seat, i) => {
	var hr = (seat[i]=='F'||seat[i]=='L') ? r.Take(r.Count() / 2) : r.TakeLast(r.Count() / 2);
	if (hr.Count() == 1) return hr.Single();
	return which(hr, seat, ++i);
};

seats.Select(s=> new { row=s.Substring(0, 7), col=s.Substring(7)})
	.Select(s=> new { RowNo = which(Enumerable.Range(0,128), s.row, 0),
					  ColNo = which(Enumerable.Range(0,8), s.col, 0)} )
	.Select(s=>calcSeatId(s.RowNo,s.ColNo))
	.Max()
.Dump();
