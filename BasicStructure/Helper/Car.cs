using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BasicStructure.negocio;

namespace BasicStructure.Helper
{
    class Car : negocio.Object
    {
        public double width;
        public double heigth;
        public double depth;

        public Car(double width, double height, double depth, double centerX, double centerY, double centerZ) : base(centerX, centerY, centerZ)
        {
            this.width = width;
            this.heigth = height;
            this.depth = depth;

            Color color = new Color(0.698, 0.133, 1);
            Color negro = new Color(0, 0, 0);
            // Front
            List<Polygon> polygonsFront = new List<Polygon>();
            Polygon polygon = new Polygon(color);
            Point[] points = {
                new Point(centerX - (width / 2), centerY - (height / 2) , centerZ + (depth / 2)),
                new Point(centerX - (width / 2), centerY, centerZ + (depth / 2)),
                new Point(centerX, centerY, centerZ + (depth / 2)),
                new Point(centerX, centerY + (height / 2), centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2) , centerZ + (depth / 2)),
                new Point(centerX + ((width / 2)), centerY - (height / 2), centerZ + (depth / 2)),

                new Point(centerX + (width * 0.5), centerY, centerZ + (depth / 2)),
                new Point(centerX, centerY + (height / 2), centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2) , centerZ + (depth / 2)),
                new Point(centerX + ((width / 2)), centerY - (height / 2), centerZ + (depth / 2)),

            };
            polygon.LoadVertices(points);

            // Ventana
            Polygon polygon2 = new Polygon(negro);
            Point[] points2 = {

                new Point(centerX - (width / 8 ), centerY, centerZ + (depth / 2)),
                new Point(centerX , centerY + (height / 4), centerZ + (depth / 2)),
                new Point(centerX, centerY + (height / 4), centerZ + (depth / 2)),
                new Point(centerX + (width / 4), centerY + (height / 4) , centerZ + (depth / 2)),
                new Point(centerX + (width / 4), centerY, centerZ + (depth / 2)),

            };
            polygon2.LoadVertices(points2);

            // RUEDA
            Polygon polygon3 = new Polygon(negro);
            Point[] points3 = {

                new Point(centerX - (width / 4 ), centerY - (height / 2) + (height/ 6), centerZ + (depth / 2)),
                new Point(centerX - (width / 4 ) + (width / 6 ), centerY - (height / 2) + (height/ 6), centerZ + (depth / 2)),
                new Point(centerX - (width / 4 ) + (width / 6 ), centerY - (height / 2) - (height / 4 ) , centerZ + (depth / 2)),
                new Point(centerX - (width / 4 ), centerY - (height / 2) - (height / 4 ) , centerZ + (depth / 2)),
               

            };
            polygon3.LoadVertices(points3);


            // RUEDA
            Polygon polygonorueda = new Polygon(negro);
            Point[] pointrueda = {

                new Point(centerX + (width / 4 ), centerY - (height / 2) + (height/ 6), centerZ + (depth / 2)),
                new Point(centerX + (width / 4 ) + (width / 6 ), centerY - (height / 2) + (height/ 6), centerZ + (depth / 2)),
                new Point(centerX + (width / 4 ) + (width / 6 ), centerY - (height / 2) - (height / 4 ) , centerZ + (depth / 2)),
                new Point(centerX + (width / 4 ), centerY - (height / 2) - (height / 4 ) , centerZ + (depth / 2)),


            };
            polygonorueda.LoadVertices(pointrueda);

            polygonsFront.Add(polygon);
            polygonsFront.Add(polygon2);
            polygonsFront.Add(polygon3);
            polygonsFront.Add(polygonorueda);

            this.parts.Add("front", new Part(width, height, depth, centerX, centerY, centerZ, polygonsFront));

            // BACK
            List<Polygon> polygonsBack = new List<Polygon>();
            polygon = new Polygon(color);
            Point[] pointss = {
                new Point(centerX - (width / 2), centerY - (height / 2) , centerZ - (depth / 2)),
                new Point(centerX - (width / 2), centerY, centerZ - (depth / 2)),
                new Point(centerX, centerY, centerZ - (depth / 2)),
                new Point(centerX, centerY + (height / 2), centerZ - (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2) , centerZ - (depth / 2)),
                new Point(centerX + ((width / 2)), centerY - (height / 2), centerZ - (depth / 2)),

                new Point(centerX + (width * 0.5), centerY, centerZ - (depth / 2)),
                new Point(centerX, centerY + (height / 2), centerZ - (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2) , centerZ - (depth / 2)),
                new Point(centerX + ((width / 2)), centerY - (height / 2), centerZ - (depth / 2)),

            };
            polygon.LoadVertices(pointss);

            // Ventana
             polygon2 = new Polygon(negro);
             Point[] points2s = {

                new Point(centerX - (width / 8 ), centerY, centerZ - (depth / 2)),
                new Point(centerX , centerY + (height / 4), centerZ - (depth / 2)),
                new Point(centerX, centerY + (height / 4), centerZ - (depth / 2)),
                new Point(centerX + (width / 4), centerY + (height / 4) , centerZ - (depth / 2)),
                new Point(centerX + (width / 4), centerY, centerZ - (depth / 2)),

            };
            polygon2.LoadVertices(points2s);

            // RUEDA
            Polygon polygonrueda2 = new Polygon(negro);
            Point[] pointrueda2 = {

                new Point(centerX - (width / 4 ), centerY - (height / 2) + (height/ 6), centerZ - (depth / 2)),
                new Point(centerX - (width / 4 ) + (width / 6 ), centerY - (height / 2) + (height/ 6), centerZ - (depth / 2)),
                new Point(centerX - (width / 4 ) + (width / 6 ), centerY - (height / 2) - (height / 4 ) , centerZ - (depth / 2)),
                new Point(centerX - (width / 4 ), centerY - (height / 2) - (height / 4 ) , centerZ - (depth / 2)),


            };
            polygonrueda2.LoadVertices(pointrueda2);


            // RUEDA
            Polygon polygonorueda3 = new Polygon(negro);
            Point[] pointrueda3 = {

                new Point(centerX + (width / 4 ), centerY - (height / 2) + (height/ 6), centerZ - (depth / 2)),
                new Point(centerX + (width / 4 ) + (width / 6 ), centerY - (height / 2) + (height/ 6), centerZ - (depth / 2)),
                new Point(centerX + (width / 4 ) + (width / 6 ), centerY - (height / 2) - (height / 4 ) , centerZ - (depth / 2)),
                new Point(centerX + (width / 4 ), centerY - (height / 2) - (height / 4 ) , centerZ - (depth / 2)),


            };
            polygonorueda3.LoadVertices(pointrueda3);

            polygonsBack.Add(polygon);
            polygonsBack.Add(polygon2);
            polygonsFront.Add(polygonrueda2);
            polygonsFront.Add(polygonorueda3);

            this.parts.Add("back", new Part(width, height, depth, centerX, centerY, centerZ, polygonsBack));

            // LEFT
            List<Polygon> polygonsLeft = new List<Polygon>();
            polygon = new Polygon(color);
            Point[] pointsss = {
                new Point(centerX - (width / 2), centerY - (height / 2) , centerZ + (depth / 2)),
                new Point(centerX - (width / 2), centerY, centerZ + (depth / 2)),
                new Point(centerX - (width / 2), centerY, centerZ - (depth / 2)),
                new Point(centerX - (width / 2), centerY - (height / 2) , centerZ - (depth / 2)),
                

            };
            polygon.LoadVertices(pointsss);
            polygonsLeft.Add(polygon);
            //polygonsFront.Add(polygon3);

            this.parts.Add("left", new Part(width, height, depth, centerX, centerY, centerZ, polygonsLeft));

            // RIGHT
            List<Polygon> polygonsRight = new List<Polygon>();
            polygon = new Polygon(color);
            Point[] pointsssS = {
                new Point(centerX + (width / 2), centerY + (height / 2) , centerZ + (depth / 2)),
                new Point(centerX + ((width / 2)), centerY - (height / 2), centerZ + (depth / 2)),
                new Point(centerX + ((width / 2)), centerY - (height / 2), centerZ - (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2) , centerZ - (depth / 2)),
                


            };
            polygon.LoadVertices(pointsssS);
            polygonsRight.Add(polygon);
            //polygonsFront.Add(polygon3);

            this.parts.Add("right", new Part(width, height, depth, centerX, centerY, centerZ, polygonsRight));


            // TOP
            List<Polygon> polygonsTop = new List<Polygon>();
            polygon2 = new Polygon(color);
            Point[] points2sq = {

                new Point(centerX, centerY + (height / 2), centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2) , centerZ + (depth / 2)),
                new Point(centerX + (width / 2), centerY + (height / 2) , centerZ - (depth / 2)),
                new Point(centerX, centerY + (height / 2), centerZ - (depth / 2)),
                

            };
            polygon2.LoadVertices(points2sq);

            polygonsTop.Add(polygon2);
            

            this.parts.Add("top", new Part(width, height, depth, centerX, centerY, centerZ, polygonsTop));


            // BOTTON
            List<Polygon> polygonsBotton = new List<Polygon>();
            polygon2 = new Polygon(color);
            Point[] points2sqd = {

                new Point(centerX - (width / 2), centerY - (height / 2) , centerZ + (depth / 2)),
                new Point(centerX + ((width / 2)), centerY - (height / 2), centerZ + (depth / 2)),
                new Point(centerX + ((width / 2)), centerY - (height / 2), centerZ - (depth / 2)),
                new Point(centerX - (width / 2), centerY - (height / 2) , centerZ - (depth / 2)),


            };
            polygon2.LoadVertices(points2sqd);

            polygonsBotton.Add(polygon2);


            this.parts.Add("botton", new Part(width, height, depth, centerX, centerY, centerZ, polygonsBotton));

        }
    }
}
