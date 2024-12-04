<Query Kind="Statements" />

var seat = "FBFBBFF";

Func<IEnumerable<int>, string, int, int> getRow = null;
getRow = (r, seat, i) => {
	var hr = (seat[i]=='F') ? r.Take(r.Count()/2) : r.TakeLast(r.Count()/2);
	if(hr.Count()==1) return hr.Single();
	return getRow(hr, seat, ++i);
};

getRow(Enumerable.Range(0, 128), seat, 0).Dump();