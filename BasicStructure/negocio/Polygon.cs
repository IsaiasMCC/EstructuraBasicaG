using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;

namespace BasicStructure.negocio
{
    class Polygon
    {
        public List<Point> vertices;
        private Color color;

        public Polygon(Color color)
        {
            vertices = new List<Point>();
            this.color = color;
        }

        public Polygon(Color color, List<Point> vertices)
        {
            this.vertices = vertices;
            this.color = color;
        }

        public void Draw()
        {
            GL.LoadIdentity();
            //GL.Translate(0, 0, 0);
            GL.Rotate(-25f, 1, 1, 0);
            GL.Begin(PrimitiveType.Polygon);
            this.SetColor();
            foreach(Point vertex in vertices)
            {
                GL.Vertex3(vertex.x, vertex.y, vertex.z);
            }
            GL.End();
        }

        public void SetColor()
        {
            GL.Color3(color.red, color.green, color.blue);
        }

        public void LoadVertices(Point[] vertices)
        {
            foreach(Point vertex in vertices)
            {
                this.vertices.Add(vertex);
            }
        }

    }
}
