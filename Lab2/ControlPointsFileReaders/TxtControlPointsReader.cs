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
        public int ControlPointsFirstDimensionCount { get; set; }
        public int ControlPointsSecondDimensionCount { get; set; }
        public TxtControlPointsReader(int controlPointsFirstDimensionCount, int controlPointsSecondDimensionCount)
        {
            ControlPointsFirstDimensionCount = controlPointsFirstDimensionCount;
            ControlPointsSecondDimensionCount = controlPointsSecondDimensionCount;
        }

        public Vector3[,] Read(string path)
        {
            Vector3[,] controlPoints = new Vector3[ControlPointsFirstDimensionCount, ControlPointsSecondDimensionCount];
            using StreamReader sr = new(path);
            string? line;
            for(int i = 0; i < ControlPointsFirstDimensionCount; i++)
            {
                for(int j = 0; j < ControlPointsSecondDimensionCount; j++)
                {
                    if ((line = sr.ReadLine()) is null)
                        throw new Exception("Not enough control points in the file");

                    float[] coords = line.Split(' ').Select(float.Parse).ToArray();
                    controlPoints[i, j] = new Vector3(coords[0], coords[1], coords[2]);
                }
            }

            return controlPoints;
        }
    }
}
