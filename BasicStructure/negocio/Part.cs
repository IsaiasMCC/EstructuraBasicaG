using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

using System.Text.Json.Serialization;

namespace BasicStructure.negocio
{
    public class Part: IObject
    {
        public double centerX { get; set; }
        public double centerY { get; set; }
        public double centerZ { get; set; }

        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public List<Polygon> polygons { get; set; }

        [JsonConstructor]
        public Part(double width, double height, double depth, double centerX, double centerY, double centerZ)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.centerZ = centerZ;

            this.width = width;
            this.height = height;
            this.depth = depth;
            polygons = new List<Polygon>();
        }

        public void Draw()
        {
            foreach(Polygon polygon in polygons)
            {
                polygon.Draw();
            }
        }

        public void Rotate(double angle, double x, double y, double z)
        {
            this.Translate(-centerX, -centerY, -centerZ);
            foreach (Polygon polygon in polygons)
            {
                polygon.Rotate(angle, x, y, z);
            }
            this.Translate(centerX, centerY, centerZ);
        }

        public void Translate(double x, double y, double z)
        {
            foreach (Polygon polygon in polygons)
            {
                polygon.Translate(x, y, z);
            }
        }

        public void Scale(double size)
        {
            foreach(Polygon polygon in polygons)
            {
                polygon.Scale(size);
            }
        }

        public void Add(Polygon polygon)
        {
            this.polygons.Add(polygon);
        }

    }
}
