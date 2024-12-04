<Query Kind="Program">
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

void Main() {
	string file = @"C:\Users\heebinho\source\repos\adventofcode\input8.txt";
	var lines = File.ReadAllLines(file);

	Func<IEnumerable<Command>, Command, List<int>, int, Result> Run = null;
	Run = (commands, command, ops, acc) => {
		if(ops.Contains(command.I)) return new Result(false, acc); //Infinite loop
		ops.Add(command.I);
		
		if(commands.Last().I+1 == command.I + ((command.Op=="jmp") ? command.Arg :1))
			return new Result(true, acc); //Exit command reached
		
		return Run(commands, commands.Single(c=>c.I == command.I + ((command.Op=="jmp") ? command.Arg :1)), 
			ops, acc += (command.Op=="acc") ? command.Arg :0);
	};
	
	var commands = lines.Select( (l,i) => new Command(i, l.Split(" ")[0], int.Parse( l.Split(" ")[1]) ));
	foreach (var command in commands.Where(c => c.Op != "acc")) {
		 var candidate = commands.Select(c=> (c.I != command.I) ? c 
		 	: command with { Op = (command.Op == "jmp") ? "nop" :"jmp" });
		 var result = Run(candidate, commands.First(), new List<int>(), 0);
		 if(result.Success) result.Dump();
	}
}

record Command(int I, string Op, int Arg);
record Result(bool Success, int Acc);