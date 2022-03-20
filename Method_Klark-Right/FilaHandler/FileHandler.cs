using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Method_Klark_Right.Models;

namespace Method_Klark_Right.FilaHandler
{
    public class FileHandler
    {
        public string Path { get; set; }

        private List<Point> PointsWithoutDemands { get; } = new List<Point>();
        private List<Point> Points { get; } = new List<Point>();
        private List<Demand> Demands { get; } = new List<Demand>();

        public static readonly List<string> AllDataFromFile = new List<string>();

        public FileHandler(string path)
        {
            Path = path;
            GetData();
            GetDemandsFromFile();
        }

        private List<string> GetData()
        {
            var fileLines = File.ReadAllLines(Path);
            foreach (var line in fileLines)
            {
                AllDataFromFile.Add(line);
            }
            return AllDataFromFile;
        }

        public List<Point> GetPointsFromFile()
        {
            bool wasDetectedDemandSection = false;

            foreach (var line in AllDataFromFile)
            {
                if (line == "DEMAND_SECTION")
                {
                    wasDetectedDemandSection = true;
                }

                if (!wasDetectedDemandSection && char.IsNumber(line[0]))
                {
                    string[] pointInfo = line.Split(' ');

                    int id = int.Parse(pointInfo[0]);
                    int x = int.Parse(pointInfo[1]);
                    int y = int.Parse(pointInfo[2]);

                    Point point = new Point(id, x, y);

                    PointsWithoutDemands.Add(point);
                }
            }
            return PointsWithoutDemands;
        }

        public List<Demand> GetDemandsFromFile()
        {
            bool isDemandSection = false;

            foreach (var line in AllDataFromFile)
            {
                if (line == "DEMAND_SECTION")
                {
                    isDemandSection = true;
                }

                if (isDemandSection && char.IsNumber(line[0]))
                {

                    string[] demandInfo = line.Split(' ');

                    int id = int.Parse(demandInfo[0]);
                    int reqWeight = int.Parse(demandInfo[1]);

                    Demand demand = new Demand(id, reqWeight);

                    Demands.Add(demand);
                }
            }
            return Demands;
        }

        public void WriteToFile(char separator, string path)
        {
            //// inside [] we write quantity of lines in list 
            //var linesOfPoints = new string[Points.Count]; // its initial length is 48

            //for (int i = 0; i < Points.Count; i++)
            //{                                            //we save to the array the formatted point
            //                                             // formated so that:
            //                                             // Index of the point + seperator + x coordinate + separator + y coordinate + separator + new line
            //    Point point = Points[i];
            //    linesOfPoints[i] = $"{i}{separator}{point.X}{separator}{point.Y}";
            //}

            //File.WriteAllLines(path, linesOfPoints);
        }



        public void CreateFullPointObject(List<Point> PointsWithoutDemands)
        {
            foreach (var itemPoint in PointsWithoutDemands)
            {
                foreach (var itemDemand in Demands)
                    if (itemPoint.Id == itemDemand.Id)
                    {
                        try
                        {
                            itemPoint.Demand = itemDemand;
                            Point point = new Point(itemPoint.Id, itemPoint.X, itemPoint.Y, itemDemand);
                            Points.Add(point);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
            }
        }

    }
}
