using Method_Klark_Right.FilaHandler;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//var fileHandler = new FileHandler("E-n51-k5.vrp (1).txt");
var fileHandler = new FileHandler("E-n51-k5.vrp-short.txt");

var points = fileHandler.GetPointsFromFile();
var depo = points.FirstOrDefault();

//fileHandler.CreateFullPointObject(points);

Console.WriteLine($"depo: {depo}");
Console.WriteLine("--------");

foreach (var point in points)
{
    Console.WriteLine(point);
}

Console.WriteLine("The end");

