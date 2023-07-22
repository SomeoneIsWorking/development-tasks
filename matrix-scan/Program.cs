if (args.Any())
{
    var output = new MatrixScanner(args.First()).Scan();
    Console.WriteLine($"Number of areas: {output}");
    return;
}

var inputOutputs = new[]{
    new {
        Input = "1,0,1;0,1,0",
        Output = 3
    },
    new {
        Input = "1,0,1;1,1,0",
        Output = 2
    },
    new {
        Input = "1,1,1,1;0,0,1,0",
        Output = 1
    }
};

foreach (var io in inputOutputs)
{
    var output = new MatrixScanner(io.Input).Scan();
    Console.WriteLine($"Expected: {io.Output}, actual: {output}");
}