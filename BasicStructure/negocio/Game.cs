using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace BasicStructure.negocio
{
    class Game: GameWindow
    {
        public Escenario escenario;
        public Object pared;
        public Object repisa;
        public Object car;


        private double rotationAngle = 0.1;  // Ángulo inicial de rotación
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            Run(60.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            base.OnUpdateFrame(e);
            // Actualiza el ángulo de rotación
            rotationAngle += (1.0 * e.Time);  // Cambia esto para ajustar la velocidad de rotación
            if (rotationAngle >= 360.0)
            {
                rotationAngle -= 360.0;
            }
            
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            //TODO LOAD Instancias
            /* ESCENARIO */
            escenario = new Escenario(0, 0, 0);

            /* OBJETOS */
            pared = new Object(0.8, 0.9, 0.15, 0, 0, 0);
            repisa = new Object(0.8, 0.07, 0.7, 0, 0, 0);
            car = new Object(0.3, 0.2, 0.2, 0, 0.16, 0);

            /* COLORES */
            Color color = new Color(0.698, 0.133, 0.133);
            Color colorRepisa = new Color(0.0f, 0.0f, 0.5f);
            Color colorCar = new Color(1,1,1);
            Color colorRueda = new Color(0, 0, 0);

            /*PARTES*/

            /********************** PARTE PARED *****************/
            Part Partepared = new Part(pared.width, pared.height, pared.depth, pared.centerX, pared.centerY, pared.centerZ);

            /* FRONT pared */
            Point[] pointsparedFront = {
                new Point(pared.centerX - (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ - (pared.depth / 2)),
                new Point(pared.centerX - (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ - (pared.depth / 2)),
                new Point(pared.centerX + (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ - (pared.depth / 2)),
                new Point(pared.centerX + (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ - (pared.depth / 2)),
            };
            Polygon polygonparedFront = new Polygon(color);
            polygonparedFront.LoadVertices(pointsparedFront);

            /* BACK pared */
            Point[] pointsparedBack = {
                new Point(pared.centerX - (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ + (pared.depth / 2)),
                new Point(pared.centerX - (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ + (pared.depth / 2)),
                new Point(pared.centerX + (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ + (pared.depth / 2)),
                new Point(pared.centerX + (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ + (pared.depth / 2)),
            };
            Polygon polygonparedBack = new Polygon(color);
            polygonparedBack.LoadVertices(pointsparedBack);

            /* LEFT pared */
            Point[] pointsparedLeft = {
                new Point(pared.centerX - (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ - (pared.depth / 2)),
                new Point(pared.centerX - (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ - (pared.depth / 2)),
                new Point(pared.centerX - (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ + (pared.depth / 2)),
                new Point(pared.centerX - (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ + (pared.depth / 2)),
            };
            Polygon polygonparedLeft = new Polygon(color);
            polygonparedLeft.LoadVertices(pointsparedLeft);

            /* RIGHT pared */
            Point[] pointsparedRight = {
                new Point(pared.centerX + (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ - (pared.depth / 2)),
                new Point(pared.centerX + (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ - (pared.depth / 2)),
                new Point(pared.centerX + (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ + (pared.depth / 2)),
                new Point(pared.centerX + (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ + (pared.depth / 2)),
            };
            Polygon polygonparedRight = new Polygon(color);
            polygonparedRight.LoadVertices(pointsparedRight);

            /* RIGHT TOP */
            Point[] pointsparedTop = {
                new Point(pared.centerX - (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ - (pared.depth / 2)),
                new Point(pared.centerX + (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ - (pared.depth / 2)),
                new Point(pared.centerX + (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ + (pared.depth / 2)),
                new Point(pared.centerX - (pared.width / 2), pared.centerY + (pared.height / 2), pared.centerZ + (pared.depth / 2)),
            };
            Polygon polygonparedTop = new Polygon(color);
            polygonparedTop.LoadVertices(pointsparedTop);

            /* RIGHT BOTTOM */
            Point[] pointsparedBottom = {
                new Point(pared.centerX - (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ - (pared.depth / 2)),
                new Point(pared.centerX + (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ - (pared.depth / 2)),
                new Point(pared.centerX + (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ + (pared.depth / 2)),
                new Point(pared.centerX - (pared.width / 2), pared.centerY - (pared.height / 2), pared.centerZ + (pared.depth / 2)),
            };
            Polygon polygonparedBottom = new Polygon(color);
            polygonparedBottom.LoadVertices(pointsparedBottom);

            /* AGREGANDO POLIGONOS A LA PARTE*/

            Partepared.Add(polygonparedFront);
            Partepared.Add(polygonparedBack);
            Partepared.Add(polygonparedLeft);
            Partepared.Add(polygonparedRight);
            Partepared.Add(polygonparedTop);
            Partepared.Add(polygonparedBottom);

            /********************** PARTE REPISA *****************/
            Part ParteRepisa = new Part(pared.width, pared.height, pared.depth, pared.centerX, pared.centerY, pared.centerZ);

            /* FRONT pared */
            Point[] pointsRepisaFront = {
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
            };
            Polygon polygonRepisaFront = new Polygon(colorRepisa);
            polygonRepisaFront.LoadVertices(pointsRepisaFront);

            /* BACK pared */
            Point[] pointsRepisaBack = {
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
            };
            Polygon polygonRepisaBack = new Polygon(colorRepisa);
            polygonRepisaBack.LoadVertices(pointsRepisaBack);

            /* LEFT pared */
            Point[] pointsRepisaLeft = {
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
            };
            Polygon polygonRepisaLeft = new Polygon(colorRepisa);
            polygonRepisaLeft.LoadVertices(pointsRepisaLeft);

            /* RIGHT pared */
            Point[] pointsRepisaRight = {
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
            };
            Polygon polygonRepisaRight = new Polygon(colorRepisa);
            polygonRepisaRight.LoadVertices(pointsRepisaRight);

            /* RIGHT TOP */
            Point[] pointsRepisaTop = {
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY + (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
            };
            Polygon polygonRepisaTop = new Polygon(colorRepisa);
            polygonRepisaTop.LoadVertices(pointsRepisaTop);

            /* RIGHT BOTTOM */
            Point[] pointsRepisaBottom = {
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ - (repisa.depth / 2)),
                new Point(repisa.centerX + (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
                new Point(repisa.centerX - (repisa.width / 2), repisa.centerY - (repisa.height / 2), repisa.centerZ + (repisa.depth / 2)),
            };
            Polygon polygonRepisaBottom = new Polygon(colorRepisa);
            polygonRepisaBottom.LoadVertices(pointsRepisaBottom);

            /********************** AUTO *****************/
            /********************** PARTE AUTO *****************/
            Part ParteCar = new Part(car.width, car.height, car.depth, car.centerX, car.centerY, car.centerZ);

            /* FRONT CAR */
            Point[] pointsCarFront = {
                new Point(car.centerX - (car.width / 2), car.centerY - (car.height / 2), car.centerZ - (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY + (car.height / 2), car.centerZ - (car.depth / 2)),
                new Point(car.centerX + (car.width / 2), car.centerY + (car.height / 2), car.centerZ - (car.depth / 2)),
                new Point(car.centerX + (car.width / 2), car.centerY - (car.height / 2), car.centerZ - (car.depth / 2)),
            };
            Polygon polygonCarFront = new Polygon(colorCar);
            polygonCarFront.LoadVertices(pointsCarFront);

            /* BACK CAR */
            Point[] pointsCardBack = {
                new Point(car.centerX - (car.width / 2), car.centerY - (car.height / 2), car.centerZ + (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY + (car.height / 2), car.centerZ + (car.depth / 2)),
                new Point(car.centerX + (car.width / 2), car.centerY + (car.height / 2), car.centerZ + (car.depth / 2)),
                new Point(car.centerX + (car.width / 2), car.centerY - (car.height / 2), car.centerZ + (car.depth / 2)),
            };
            Polygon polygonCarBack = new Polygon(colorCar);
            polygonCarBack.LoadVertices(pointsCardBack);

            /* LEFT pared */
            Point[] pointsCarLeft = {
                new Point(car.centerX - (car.width / 2), car.centerY - (car.height / 2), car.centerZ - (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY + (car.height / 2), car.centerZ - (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY + (car.height / 2), car.centerZ + (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY - (car.height / 2), car.centerZ + (car.depth / 2)),
            };
            Polygon polygonCarLeft = new Polygon(colorCar);
            polygonCarLeft.LoadVertices(pointsCarLeft);

            /* RIGHT CAR */
            Point[] pointsCarRight = {
                new Point(car.centerX + (car.width / 2), car.centerY + (car.height / 2), car.centerZ - (car.depth / 2)),
                new Point(car.centerX + (car.width / 2), car.centerY - (car.height / 2), car.centerZ - (car.depth / 2)),
                new Point(car.centerX + (car.width / 2), car.centerY - (car.height / 2), car.centerZ + (car.depth / 2)),
                new Point(car.centerX + (car.width / 2), car.centerY + (car.height / 2), car.centerZ + (car.depth / 2)),
            };
            Polygon polygonCarRight = new Polygon(colorCar);
            polygonCarRight.LoadVertices(pointsCarRight);

            /* RIGHT TOP */
            Point[] pointsCarTop = {
                new Point(car.centerX - (car.width / 2), car.centerY + (car.height / 2), car.centerZ - (car.depth / 2)),
                new Point(car.centerX + (car.width / 2), car.centerY + (car.height / 2), car.centerZ - (car.depth / 2)),
                new Point(car.centerX + (car.width / 2), car.centerY + (car.height / 2), car.centerZ + (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY + (car.height / 2), car.centerZ + (car.depth / 2)),
            };
            Polygon polygonCarTop = new Polygon(colorCar);
            polygonCarTop.LoadVertices(pointsCarTop);

            /* RIGHT BOTTOM */
            Point[] pointsCarBottom = {
                new Point(car.centerX - (car.width / 2), car.centerY - (car.height / 2), car.centerZ - (car.depth / 2)),
                new Point(car.centerX + (car.width / 2), car.centerY - (car.height / 2), car.centerZ - (car.depth / 2)),
                new Point(car.centerX + (car.width / 2), car.centerY - (car.height / 2), car.centerZ + (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY - (car.height / 2), car.centerZ + (car.depth / 2)),
            };
            Polygon polygonCarBottom = new Polygon(colorCar);
            polygonCarBottom.LoadVertices(pointsCarBottom);

            
            
            // Ventanas Car

            /* VENTANA FRONT*/
            Point[] pointsVentanaFront = {
                new Point(car.centerX - (car.width / 2), car.centerY, car.centerZ - (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY + (car.height / 6) * 2, car.centerZ - (car.depth / 2)),
                new Point(car.centerX - (car.width / 3), car.centerY + (car.height / 6) * 2, car.centerZ - (car.depth / 2)),
                new Point(car.centerX - (car.width / 3), car.centerY, car.centerZ - (car.depth / 2)),
            };
            Polygon polygonVentanaFront = new Polygon(colorRueda);
            polygonVentanaFront.LoadVertices(pointsVentanaFront);

            /* VENTANA BACK*/
            Point[] pointsVentanaBack = {
                new Point(car.centerX - (car.width / 2), car.centerY, car.centerZ + (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY + (car.height / 6) * 2, car.centerZ + (car.depth / 2)),
                new Point(car.centerX - (car.width / 3), car.centerY + (car.height / 6) * 2, car.centerZ + (car.depth / 2)),
                new Point(car.centerX - (car.width / 3), car.centerY, car.centerZ + (car.depth / 2)),
            };
            Polygon polygonVentanaBack = new Polygon(colorRueda);
            polygonVentanaBack.LoadVertices(pointsVentanaBack);

            /* VENTANA LEFT*/
            Point[] pointsVentanaLeft = {
                new Point(car.centerX - (car.width / 2), car.centerY, car.centerZ - (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY + (car.height / 6) * 2, car.centerZ - (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY + (car.height / 6) * 2, car.centerZ + (car.depth / 2)),
                new Point(car.centerX - (car.width / 2), car.centerY, car.centerZ + (car.depth / 2)),
            };
            Polygon polygonVentanaLeft = new Polygon(colorRueda);
            polygonVentanaLeft.LoadVertices(pointsVentanaLeft);

            // Ruedas Car

            /* VENTANA FRONT*/
            Point[] pointsRuedaFront = {
                new Point(car.centerX - (car.width / 4) - (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) + (car.height / 8), car.centerZ - (car.depth / 2)),
                new Point(car.centerX - (car.width / 4) - (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) - (car.height / 8), car.centerZ - (car.depth / 2)),
                new Point(car.centerX - (car.width / 4) + (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) - (car.height / 8), car.centerZ - (car.depth / 2)),
                new Point(car.centerX - (car.width / 4) + (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) + (car.height / 8), car.centerZ - (car.depth / 2)),
            };
            Polygon polygonRuedaFront = new Polygon(colorRueda);
            polygonRuedaFront.LoadVertices(pointsRuedaFront);
            /* AGREGANDO POLIGONOS A LA PARTE*/

            /* VENTANA FRONT*/
            Point[] pointsRuedaFront2 = {
                new Point(car.centerX + (car.width / 4) - (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) + (car.height / 8), car.centerZ - (car.depth / 2)),
                new Point(car.centerX + (car.width / 4) - (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) - (car.height / 8), car.centerZ - (car.depth / 2)),
                new Point(car.centerX + (car.width / 4) + (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) - (car.height / 8), car.centerZ - (car.depth / 2)),
                new Point(car.centerX + (car.width / 4) + (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) + (car.height / 8), car.centerZ - (car.depth / 2)),
            };
            Polygon polygonRuedaFront2 = new Polygon(colorRueda);
            polygonRuedaFront2.LoadVertices(pointsRuedaFront2);

            /* VENTANA FRONT*/
            Point[] pointsRuedaFront3 = {
                new Point(car.centerX - (car.width / 4) - (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) + (car.height / 8), car.centerZ + (car.depth / 2)),
                new Point(car.centerX - (car.width / 4) - (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) - (car.height / 8), car.centerZ + (car.depth / 2)),
                new Point(car.centerX - (car.width / 4) + (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) - (car.height / 8), car.centerZ + (car.depth / 2)),
                new Point(car.centerX - (car.width / 4) + (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) + (car.height / 8), car.centerZ + (car.depth / 2)),
            };
            Polygon polygonRuedaFront3 = new Polygon(colorRueda);
            polygonRuedaFront3.LoadVertices(pointsRuedaFront3);
            /* AGREGANDO POLIGONOS A LA PARTE*/

            /* VENTANA FRONT*/
            Point[] pointsRuedaFront4 = {
                new Point(car.centerX + (car.width / 4) - (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) + (car.height / 8), car.centerZ + (car.depth / 2)),
                new Point(car.centerX + (car.width / 4) - (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) - (car.height / 8), car.centerZ + (car.depth / 2)),
                new Point(car.centerX + (car.width / 4) + (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) - (car.height / 8), car.centerZ + (car.depth / 2)),
                new Point(car.centerX + (car.width / 4) + (car.centerX - (car.width / 4) * 0.3), car.centerY - (car.height / 2) + (car.height / 8), car.centerZ + (car.depth / 2)),
            };
            Polygon polygonRuedaFront4 = new Polygon(colorRueda);
            polygonRuedaFront4.LoadVertices(pointsRuedaFront4);
            /* AGREGANDO POLIGONOS A LA PARTE*/

            Partepared.Add(polygonparedFront);
            Partepared.Add(polygonparedBack);
            Partepared.Add(polygonparedLeft);
            Partepared.Add(polygonparedRight);
            Partepared.Add(polygonparedTop);
            Partepared.Add(polygonparedBottom);

            /* AGREGANDO POLIGONOS A LA PARTE REPISA*/

            ParteRepisa.Add(polygonRepisaFront);
            ParteRepisa.Add(polygonRepisaBack);
            ParteRepisa.Add(polygonRepisaLeft);
            ParteRepisa.Add(polygonRepisaRight);
            ParteRepisa.Add(polygonRepisaTop);
            ParteRepisa.Add(polygonRepisaBottom);

            /* AGREGANDO POLIGONOS A LA PARTE CAR*/

            ParteCar.Add(polygonCarFront);
            ParteCar.Add(polygonCarBack);
            ParteCar.Add(polygonCarLeft);
            ParteCar.Add(polygonCarRight);
            ParteCar.Add(polygonCarTop);
            ParteCar.Add(polygonCarBottom);

            ParteCar.Add(polygonVentanaFront);
            ParteCar.Add(polygonVentanaBack);
            ParteCar.Add(polygonVentanaLeft);

            ParteCar.Add(polygonRuedaFront);
            ParteCar.Add(polygonRuedaFront2);
            ParteCar.Add(polygonRuedaFront3);
            ParteCar.Add(polygonRuedaFront4);


            /* AGREGANDO PARTES AL OBJETO*/
            pared.Add("pared", Partepared);
            repisa.Add("repisa", ParteRepisa);
            car.Add("car", ParteCar);
            /* AGREGANDO OBJECTOS AL ESCENARIO */
            escenario.Add("Objeto pared", pared);
            escenario.Add("Objeto repisa", repisa);
            escenario.Add("Objeto car", car);



            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //CODE GOES
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.PushMatrix();

            /*********** COMENTAR SEGUNDO*/
            /* LEE EL ARCHIVO JSON Y LO ABRE (CONSTRUYE) */
            //string fileName = "escenario2.json"; 
            //string fileJson = File.ReadAllText(fileName);  /*Lee el archivo y lo asigna en otro archivo */
            //escenario = JsonSerializer.Deserialize<Escenario>(fileJson); /* Deserializa el json y lo convierte a objeto de tipo Escenario*/

            escenario.Rotate(rotationAngle, 1, 01, 0.0);
            rotationAngle = rotationAngle + 0.1;
            escenario.Draw();

            /* ESTO SERIALIZA EN UN ARCHIVO JSON EL ESCENARIO*/
            //string fileName = "escenario2.json";  /* Asigna el nombre con el que se guardara el archivo*/
            //string fileJson = JsonSerializer.Serialize(escenario); /* Guarda en el archivo filejson  el escenario serializado*/
            //File.WriteAllText(fileName, fileJson); /* Guarda el archivo con el nombre asignado en la computadora en la ruta --->  /bin/Debug          */
            GL.PopMatrix();
            Context.SwapBuffers();
            
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            base.OnUnload(e);
        }
    }


}
