<Query Kind="Program">
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

void Main() {
	string file = @"C:\Users\heebinho\source\repos\adventofcode\input8.txt";
	var lines = File.ReadAllLines(file);

	Func<IEnumerable<Command>, Command, List<int>, int, int> Run = null;
	Run = (commands, command, ops, acc) => {
		if(ops.Contains(command.I)) return acc;
		ops.Add(command.I);
		
		return Run(commands, commands.Single(c=>c.I == command.I + ((command.Op=="jmp") ? command.Arg :1)), 
			ops, acc += (command.Op=="acc") ? command.Arg :0);
	};
	
	var commands = lines.Select( (l,i) => new Command(i, l.Split(" ")[0], int.Parse( l.Split(" ")[1]) ));
	int accumulator = Run(commands, commands.First(), new List<int>(), 0).Dump();
}

record Command(int I, string Op, int Arg);