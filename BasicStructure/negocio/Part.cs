using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStructure.negocio
{
    class Part: IObject
    {
        public double centerX;
        public double centerY;
        public double centerZ;

        public double width;
        public double height;
        public double depth;
        public List<Polygon> polygons;

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

        public Part(double width, double height, double depth, double centerX, double centerY, double centerZ, List<Polygon> polygons)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.centerZ = centerZ;

            this.width = width;
            this.height = height;
            this.depth = depth;
            this.polygons = polygons;
        }

        public void Draw()
        {
            foreach(Polygon polygon in polygons)
            {
                polygon.Draw();
            }
        }

        public void Add(Polygon polygon)
        {
            this.polygons.Add(polygon);
        }

    }
}
