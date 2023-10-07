using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Text.Json.Serialization;

namespace BasicStructure.negocio
{
    public class Polygon
    {
        public List<Point> vertices { get; set; }
        public Color color { get; set; }

        [JsonConstructor]
        public Polygon(Color color)
        {
            vertices = new List<Point>();
            this.color = color;
        }

        public void Draw()
        {
            //GL.LoadIdentity();
            //GL.PushMatrix();
            //GL.Translate(0, 0, 0);
            //GL.Rotate(-25f, 1, 1, 0);
            GL.Begin(PrimitiveType.Polygon);
            this.SetColor();
            foreach(Point vertex in vertices)
            {
                GL.Vertex3(vertex.x, vertex.y, vertex.z);
            }
            GL.End();
            //GL.PopMatrix();
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
