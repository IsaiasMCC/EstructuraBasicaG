using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BasicStructure.negocio;
namespace BasicStructure.Helper
{
    class Pared: negocio.Object
    { 
        public double width;
        public double heigth;
        public double depth;

        public Pared(double width, double height, double depth, double centerX, double centerY, double centerZ ): base(centerX, centerY, centerZ)
        {
            this.width = width;
            this.heigth = height;
            this.depth = depth;

            Color color = new Color(0.698, 0.133, 0.133);
            // Front
            List<Polygon> polygonsFront = new List<Polygon>();
            Polygon polygon = new Polygon(color);
            Point[] points = {
                new Point(centerX - (width / 2) , centerY - (height / 2) , centerZ + (depth / 2) ),
                new Point(centerX - (width / 2), centerY + (height / 2), centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2), centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY - (height / 2), centerZ + (depth / 2))
            };
            polygon.LoadVertices(points);
            polygonsFront.Add(polygon);

            this.parts.Add("front", new Part(width, height, depth, centerX, centerY, centerZ, polygonsFront));

            // Back
            List<Polygon> polygonsFront2 = new List<Polygon>();
            Polygon polygon2 = new Polygon(color);
            Point[] points2 = {
                new Point(centerX - (width / 2), centerY - (height / 2), centerZ - (depth / 2)),
                new Point(centerX - (width / 2), centerY + (height / 2), centerZ - (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2), centerZ - (depth / 2)),
                new Point(centerX+ (width / 2), centerY - (height / 2), centerZ - (depth / 2))
            }; 
            polygon2.LoadVertices(points2);
            polygonsFront2.Add(polygon2);
            this.parts.Add("back", new Part(width, height, depth, centerX, centerY, centerZ, polygonsFront2));

            // Left
            List<Polygon> polygonsFront3 = new List<Polygon>();
            Polygon polygon3 = new Polygon(color);
            Point[] points3 = {
                new Point(centerX - (width / 2), centerY - (height / 2), centerZ + (depth / 2)),
                new Point(centerX - (width / 2), centerY + (height / 2), centerZ + (depth / 2)),
                new Point(centerX - (width / 2), centerY + (height / 2), centerZ - (depth / 2)),
                new Point(centerX - (width / 2), centerY - (height / 2), centerZ - (depth / 2))
            };
            polygon3.LoadVertices(points3);
            polygonsFront3.Add(polygon3);
            this.parts.Add("left", new Part(width, height, depth, centerX, centerY, centerZ, polygonsFront3));

            // Left
            List<Polygon> polygonsFront4 = new List<Polygon>();
            Polygon polygon4 = new Polygon(color);
            Point[] points4 = {
                new Point(centerX + (width / 2), centerY + (height / 2), centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY - (height / 2), centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY - (height / 2), centerZ - (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2), centerZ - (depth / 2))
            };
            polygon4.LoadVertices(points4);
            polygonsFront4.Add(polygon4);
            this.parts.Add("right", new Part(width, height, depth, centerX, centerY, centerZ, polygonsFront4));

            // Top
            List<Polygon> polygonsFront5 = new List<Polygon>();
            Polygon polygon5 = new Polygon(color);
            Point[] points5 = {
                new Point(centerX - (width / 2), centerY + (height / 2), centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2), centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2), centerZ - (depth / 2)),
                new Point(centerX - (width / 2), centerY + (height / 2), centerZ - (depth / 2))
            };
            polygon5.LoadVertices(points5);
            polygonsFront5.Add(polygon5);
            this.parts.Add("top", new Part(width, height, depth, centerX, centerY, centerZ, polygonsFront5));

            // Botton
            List<Polygon> polygonsFront6 = new List<Polygon>();
            Polygon polygon6 = new Polygon(color);
            Point[] points6 = {
                new Point(centerX - (width / 2), centerY - (height / 2), centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY - (height / 2), centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY - (height / 2), centerZ - (depth / 2)),
                new Point(centerX - (width / 2), centerY - (height / 2), centerZ - (depth / 2))
            };
            polygon6.LoadVertices(points6);
            polygonsFront6.Add(polygon6);
            this.parts.Add("botton", new Part(width, height, depth, centerX, centerY, centerZ, polygonsFront6));
        }
    }
}
