using Method_Klark_Right.FilaHandler;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var fileHandler = new FileHandler("E-n51-k5.vrp (1).txt");

var points = fileHandler.GetPointsFromFile();
var depo = points.FirstOrDefault();
fileHandler.CreateFullPointObject(points);
Console.WriteLine(depo);

