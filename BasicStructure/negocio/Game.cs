using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using BasicStructure.Helper;
namespace BasicStructure.negocio
{
    class Game: GameWindow
    {
        public Escenario escenario;
        public Pared pared;
        public Soporte soporte;
        public Car car;

        private float rotationAngle = 0f;  // Ángulo inicial de rotación
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
            // Actualiza el ángulo de rotación
            rotationAngle += (float)e.Time;  // Cambia esto para ajustar la velocidad de rotación
            base.OnUpdateFrame(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            //TODO LOAD Instancias
            this.escenario = new Escenario(0, 0, 0);
            this.pared = new Pared(0.4, 0.6, 0.1, 0.5, 0.5, 0.5);
            this.soporte = new Soporte(0.4, 0.05, 0.4, 0.5, 0.4, 0.3);
            this.car = new Car(0.4, 0.15, 0.2, 0.5, 0.5, 0.3);
            this.escenario.Add("pared", pared);
            this.escenario.Add("soporte", soporte);
            this.escenario.Add("car", car);

            this.pared = new Pared(0.4, 0.6, 0.1, -0.5, 0.5, 0.5);
            this.soporte = new Soporte(0.4, 0.05, 0.4, -0.5, 0.4, 0.3);
            this.car = new Car(0.4, 0.15, 0.2, -0.5, 0.5, 0.3);

            this.escenario.Add("pared2", pared);
            this.escenario.Add("soporte2", soporte);
            this.escenario.Add("car2", car);
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //CODE GOES
            GL.MatrixMode(MatrixMode.Modelview);
            escenario.Draw();
            Context.SwapBuffers();
            base.OnRenderFrame(e);
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
