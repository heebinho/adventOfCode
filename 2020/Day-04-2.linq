<Query Kind="Statements" />

string file = @"C:\Users\heebinho\source\repos\adventofcode\input4.txt";
var passports = File.ReadAllText(file).Split("\r\n\r\n");

Func<string, bool> isValidHgt = h => {
	if(string.IsNullOrWhiteSpace(h) || h.All(char.IsDigit)) return false;
	if(! (h.EndsWith("cm") || h.EndsWith("in")) ) return false;
	string value = h.Substring(0, h.Length-2);
	if(!value.All(char.IsDigit)) return false;
	int val = int.Parse(value);
	if(h.EndsWith("cm")) return Enumerable.Range(150, 44).Contains(val);
	else return Enumerable.Range(59, 18).Contains(val); 
};
Func<string, IEnumerable<int>, bool> isValidYear = (yyyy, r) => yyyy.Length == 4 && yyyy.All(char.IsDigit) && r.Contains(int.Parse(yyyy));
Func<string, bool> isValidHairColor = hcl => new Regex("^[#][0-9a-f]{6}$").IsMatch(hcl);
Func<string, bool> isValidEyeColor = ecl => new List<string>() {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}.Contains(ecl);
Func<string, bool> isValidPassportId = pid => pid.Length == 9 && pid.Any(char.IsDigit);

passports.Select(p => p.Split(' ', '\n'))
		.Select(p => p.ToDictionary(k => k.Split(":")[0], v => v.Split(":")[1]))
		.Where(p => p.Count == 8 || (p.Count == 7 && !p.ContainsKey("cid")))
		.Where(p => isValidYear(p["byr"].Trim(), Enumerable.Range(1920, 83)))
		.Where(p => isValidYear(p["iyr"].Trim(), Enumerable.Range(2010, 11)))
		.Where(p => isValidYear(p["eyr"].Trim(), Enumerable.Range(2020, 11)))
		.Where(p => isValidHgt(p["hgt"].Trim()))
		.Where(p => isValidHairColor(p["hcl"].Trim()))
		.Where(p => isValidEyeColor(p["ecl"].Trim()))
		.Where(p => isValidPassportId(p["pid"].Trim()))
.Dump();