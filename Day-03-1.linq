<Query Kind="Statements" />

// 2250414
var lines = File.ReadAllLines(@"C:\Users\renato\code\adventOfCode\input3.txt").Select(l=>l.ToCharArray().Select(c=>c-48).ToArray());
var bits = lines.Aggregate((a,b)=> a.Select((v,i)=>v+b[i]).ToArray() ).Select(t=>t>lines.Count()/2).Reverse().ToArray();

int[] a = new int[2];
new BitArray(bits).CopyTo(a,0);
new BitArray(bits).Not().CopyTo(a,1);

a.Aggregate((a,b)=>a*b).Dump();

