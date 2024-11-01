using Lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.VertexFileReaders
{
    public class TxtControlPointsReader
    {
        public int ControlPointsCount { get; set; }
        public List<Vector3> Read(string path)
        {
            List<Vector3> controlPoints = new(ControlPointsCount);
            using StreamReader sr = new(path);
            string? line;

            for(int i =  0; i < ControlPointsCount && (line = sr.ReadLine()) is not null; i++)
            {
                float[] coords = line.Split(' ').Select(float.Parse).ToArray();
                controlPoints.Add(new Vector3(coords[0], coords[1], coords[2]));
            }

            return controlPoints;
        }
    }
}
