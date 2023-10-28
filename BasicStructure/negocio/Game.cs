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
        public Object ejes;
        public Object ejesY;

        //private float rotationAngle = 0.0f; // Ángulo de rotación inicial
        private float rotationSpeed = 0.1f; // Velocidad de rotación
        private double rotationAngle = 0;  // Ángulo inicial de rotación
        double scaleFactor = 1.0; // Factor de escala inicial
        double scaleSize = 0.01;
        private static float xPosition = 0.0f; // Posición en el eje X
        private static float yPosition = 0.0f; // Posición en el eje Y
        private static float moveSpeed = 0.001f;  // Velocidad de movimiento
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
            // rotar el objeto en función de las teclas
            if (input.IsKeyDown( Key.A ))
            {
                rotationAngle += rotationSpeed;
                escenario.Rotate(rotationAngle, 0, 1, 0);
            }
            else if (input.IsKeyDown( Key.D))
            {
                rotationAngle -= rotationSpeed;
                escenario.Rotate(rotationAngle, 0, 1, 0);
            }
            else if (input.IsKeyDown(Key.W))
            {
                rotationAngle += rotationSpeed;
                escenario.Rotate(rotationAngle, 1, 0, 0);
            }
            else if (input.IsKeyDown(Key.S))
            {
                rotationAngle -= rotationSpeed;
                escenario.Rotate(rotationAngle, 1, 0, 0);
            }
            // Mover el objeto en función de las teclas
            if (input.IsKeyDown(Key.Left))
            {
                escenario.Translate(xPosition, 0, 0);
                xPosition -= moveSpeed;
            }
            else if (input.IsKeyDown(Key.Right))
            {
                escenario.Translate(xPosition, 0, 0);
                xPosition += moveSpeed;
            }
            else if (input.IsKeyDown(Key.Up))
            {
                escenario.Translate(0, yPosition, 0);
                yPosition += moveSpeed;
            }
            else if (input.IsKeyDown(Key.Down))
            {
                escenario.Translate(0, yPosition, 0);
                yPosition -= moveSpeed;
            }
            //Escalar el objeto en función de las teclas
            else if (input.IsKeyDown(Key.Number1))
            {
                escenario.Scale(scaleFactor);
                scaleFactor += scaleSize;
            }
            else if (input.IsKeyDown(Key.Number2))
            {
                escenario.Scale(scaleFactor);
                scaleFactor -= scaleSize;
            }


            /*------------------ AUTO ---------------------------------*/
            // rotar el objeto en función de las teclas
            if (input.IsKeyDown(Key.F))
            {
                rotationAngle += rotationSpeed;
                escenario.Get("Objeto car").Rotate(rotationAngle, 0, 1, 0);
            }
            else if (input.IsKeyDown(Key.H))
            {
                rotationAngle -= rotationSpeed;
                escenario.Get("Objeto car").Rotate(rotationAngle, 0, 1, 0);
            }
            else if (input.IsKeyDown(Key.T))
            {
                rotationAngle += rotationSpeed;
                escenario.Get("Objeto car").Rotate(rotationAngle, 1, 0, 0);
            }
            else if (input.IsKeyDown(Key.G))
            {
                rotationAngle -= rotationSpeed;
                escenario.Get("Objeto car").Rotate(rotationAngle, 1, 0, 0);
            }

            // Mover el objeto en función de las teclas
            if (input.IsKeyDown(Key.J))
            {
                escenario.Get("Objeto car").Translate(xPosition, 0, 0);
                xPosition -= moveSpeed;
            }
            else if (input.IsKeyDown(Key.L))
            {
                escenario.Get("Objeto car").Translate(xPosition, 0, 0);
                xPosition += moveSpeed;
            }
            else if (input.IsKeyDown(Key.I))
            {
                escenario.Get("Objeto car").Translate(0, yPosition, 0);
                yPosition += moveSpeed;
            }
            else if (input.IsKeyDown(Key.K))
            {
                escenario.Get("Objeto car").Translate(0, yPosition, 0);
                yPosition -= moveSpeed;
            }
            //Escalar el objeto en función de las teclas
            else if (input.IsKeyDown(Key.P))
            {
                escenario.Get("Objeto car").Scale(scaleFactor);
                scaleFactor += scaleSize;
            }
            else if (input.IsKeyDown(Key.O))
            {
                escenario.Get("Objeto car").Scale(scaleFactor);
                scaleFactor -= scaleSize;
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            //TODO LOAD Instancias
            /* ESCENARIO */
            escenario = new Escenario(0, 0, 0);

            /* OBJETOS */
            pared = new Object(0.8, 0.9, 0.15, escenario.centerX, escenario.centerY, escenario.centerZ);
            repisa = new Object(0.8, 0.07, 0.7, escenario.centerX, escenario.centerY, escenario.centerZ + 0.4);
            car = new Object(0.3, 0.2, 0.2, escenario.centerX, escenario.centerY + 0.15, escenario.centerZ + 0.4);
            ejes = new Object(1.4, 0.01, 0.01, escenario.centerX, escenario.centerY, escenario.centerZ);
            ejesY = new Object(0.01, 1.4, 0.01, escenario.centerX, escenario.centerY, escenario.centerZ);
            /* COLORES */
            Color color = new Color(0.698, 0.133, 0.133);
            Color colorRepisa = new Color(0.0f, 0.0f, 0.5f);
            Color colorCar = new Color(1,1,1);
            Color colorRueda = new Color(0, 0, 0);
            Color colorVerde = new Color(1, 1, 0);
            Color colorAmarillo = new Color(0, 1, 1);
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


            Part ParteEjes = new Part(ejes.width, ejes.height, ejes.depth, ejes.centerX, ejes.centerY, ejes.centerZ);
            Part ParteEjes2 = new Part(ejesY.width, ejesY.height, ejesY.depth, ejesY.centerX, ejesY.centerY, ejesY.centerZ);
            /* FRONT pared */
            Point[] pointsEjeFront = {
                new Point(ejes.centerX - (ejes.width / 2), ejes.centerY - (ejes.height / 2), ejes.centerZ - (ejes.depth / 2)),
                new Point(ejes.centerX - (ejes.width / 2), ejes.centerY + (ejes.height / 2), ejes.centerZ - (ejes.depth / 2)),
                new Point(ejes.centerX + (ejes.width / 2), ejes.centerY + (ejes.height / 2), ejes.centerZ - (ejes.depth / 2)),
                new Point(ejes.centerX + (ejes.width / 2), ejes.centerY - (ejes.height / 2), ejes.centerZ - (ejes.depth / 2)),
            };
            Polygon polygonEjeFront = new Polygon(colorVerde);
            polygonEjeFront.LoadVertices(pointsEjeFront);

            /* BACK pared */
            Point[] pointsRepisaX = {
                new Point(ejesY.centerX - (ejesY.width / 2), ejesY.centerY - (ejesY.height / 2), ejesY.centerZ - (ejesY.depth / 2)),
                new Point(ejesY.centerX - (ejesY.width / 2), ejesY.centerY + (ejesY.height / 2), ejesY.centerZ - (ejesY.depth / 2)),
                new Point(ejesY.centerX + (ejesY.width / 2), ejesY.centerY + (ejesY.height / 2), ejesY.centerZ - (ejesY.depth / 2)),
                new Point(ejesY.centerX + (ejesY.width / 2), ejesY.centerY - (ejesY.height / 2), ejesY.centerZ - (ejesY.depth / 2)),
            };
            Polygon polygonRepisaX = new Polygon(colorAmarillo);
            polygonRepisaX.LoadVertices(pointsRepisaX);

            ParteEjes.Add(polygonEjeFront);
            ParteEjes2.Add(polygonRepisaX);


            /* AGREGANDO PARTES AL OBJETO*/
            pared.Add("pared", Partepared);
            repisa.Add("repisa", ParteRepisa);
            car.Add("car", ParteCar);
            ejes.Add("eje", ParteEjes);
            ejesY.Add("eje", ParteEjes2);
            /* AGREGANDO OBJECTOS AL ESCENARIO */
            escenario.Add("Objeto pared", pared);
            escenario.Add("Objeto repisa", repisa);
            escenario.Add("Objeto car", car);
            escenario.Add("Objeto ejes", ejes);
            escenario.Add("Objeto ejes2", ejesY);



            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //CODE GOES
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            escenario.Draw();
            Context.SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            float d = 2;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -d, d, -d, d);
            //GL.Frustum(-80, 80, -80, 80, 4, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            base.OnUnload(e);
        }
    }


}
