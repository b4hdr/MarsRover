using MarsRover.Plateau;
using MarsRover.Compass;
using MarsRover.Rover;
using MarsRover.Interface;
using Microsoft.Extensions.DependencyInjection;
using MarsRover.Model;

//Services
var serviceProvider = new ServiceCollection()
            .AddSingleton<IPlateauParser, PlateauParser>()
            .AddSingleton<IPlateau, Plateau>()
            .AddSingleton<ICompass, Compass>()
            .AddTransient<IRover, Rover>()
            .AddTransient<IRoverParser, RoverParser>()
            .BuildServiceProvider();

//Init directions
var compass = serviceProvider.GetService<ICompass>();
compass.AddDirection("N", 0, 1);
compass.AddDirection("E", 1, 0);
compass.AddDirection("S", 0, -1);
compass.AddDirection("W", -1, 0);

//Start
Console.WriteLine("Mars Rover!");

//Plateau input
Point plateauBoundary = null;
var plateauParser = serviceProvider.GetService<IPlateauParser>();

do
{
    Console.WriteLine("Enter plateau boundary. (Ex: '5 5')");
    var plateuBoundaryString = Console.ReadLine();
    plateauBoundary = plateauParser.Parse(plateuBoundaryString);

    if(plateauBoundary == null)
    {
        Console.WriteLine("Invalid plateau values. Try again");
    }
} while (plateauBoundary == null);

var plateu = serviceProvider.GetService<IPlateau>();
plateu.SetBoundary(plateauBoundary);


//Rover inputs
var continueString = string.Empty;
var rovers = new List<IRover>();

do
{
    Console.WriteLine("Enter rover position and direction. (Ex: '1 2 N')");
    Console.WriteLine("Valid directions are 'N', 'E', 'S', 'W'"); //TODO: auto
    var roverPositionString = Console.ReadLine();

    var roverParser = serviceProvider.GetService<IRoverParser>();
    var roverLocation = roverParser.ParseLocation(roverPositionString);

    Console.WriteLine("Enter rover commands. (Ex: 'LMLMLMLMM')");
    Console.WriteLine("Valid commands are 'L', 'R', 'M'");
    var roverCommandString = Console.ReadLine();

    var roverCommand = roverParser.ParseCommand(roverCommandString);

    if (roverLocation.Item1 != null && roverLocation.Item2 != null && roverCommand != null)
    {
        var rover = serviceProvider.GetService<IRover>();
        rover.SetPosition(roverLocation.Item1);
        rover.SetDirection(roverLocation.Item2);
        rover.SetCommand(roverCommand);

        rovers.Add(rover);

        Console.WriteLine("Do you want to add more rover? (y/n)");
        continueString = Console.ReadLine();
    }
    else
    {
        Console.WriteLine("Invalid rover values. Try again");
        continueString = "y";
    }

} while (continueString == "y");

Console.WriteLine("-------------------------------");
Console.WriteLine("-------------------------------");

foreach (var rover in rovers)
{
    rover.Start();

    var roverPosition = rover.GetFullPosition();

    Console.WriteLine(roverPosition);
}