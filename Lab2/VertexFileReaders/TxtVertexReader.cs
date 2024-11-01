using Lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.VertexFileReaders
{
    public class TxtVertexReader
    {
        public int VertexCount { get; set; }
        public List<Vertex> Read(string path)
        {
            List<Vertex> vertices = new(VertexCount);
            using StreamReader sr = new(path);
            string? line;

            for(int i =  0; i < VertexCount && (line = sr.ReadLine()) is not null; i++)
            {
                float[] coords = line.Split(' ').Select(float.Parse).ToArray();
                vertices.Add(new Vertex(coords[0], coords[1], coords[2]));
            }

            return vertices;
        }
    }
}
