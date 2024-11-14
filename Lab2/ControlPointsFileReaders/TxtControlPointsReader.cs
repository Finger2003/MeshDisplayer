using System.Globalization;
using System.Numerics;

namespace Lab2.ControlPointsFileReaders
{
    public class TxtControlPointsReader(int controlPointsFirstDimensionCount, int controlPointsSecondDimensionCount)
    {
        public int ControlPointsFirstDimensionCount { get; set; } = controlPointsFirstDimensionCount;
        public int ControlPointsSecondDimensionCount { get; set; } = controlPointsSecondDimensionCount;

        public Vector3[,] Read(string path)
        {
            Vector3[,] controlPoints = new Vector3[ControlPointsFirstDimensionCount, ControlPointsSecondDimensionCount];
            using StreamReader sr = new(path);
            string? line;
            for (int i = 0; i < ControlPointsFirstDimensionCount; i++)
                for (int j = 0; j < ControlPointsSecondDimensionCount; j++)
                {
                    if ((line = sr.ReadLine()) is null)
                        throw new Exception("Niewystarczająca liczba wierzchołków w pliku");

                    float[] coords = line.Split(' ').Select(s => float.Parse(s, CultureInfo.InvariantCulture)).ToArray();
                    controlPoints[i, j] = new Vector3(coords[0], coords[1], coords[2]);
                }

            return controlPoints;
        }
    }
}
