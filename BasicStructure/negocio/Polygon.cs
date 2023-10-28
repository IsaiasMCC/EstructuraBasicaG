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

        Matrix4d matrixScalation = Matrix4d.Identity;
        Matrix4d matrixTranslation = Matrix4d.Identity;
        Matrix4d matrixRotation = Matrix4d.Identity;
        Matrix4d matrixMain = Matrix4d.Identity;

        [JsonConstructor]
        public Polygon(Color color)
        {
            vertices = new List<Point>();
            this.color = color;
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Polygon);
            this.SetColor();
            matrixMain = matrixTranslation * matrixRotation * matrixScalation;
            foreach (Point vertex in vertices)
            {   
                Vector4d v4 = new Vector4d(vertex.x, vertex.y, vertex.z, 1.0);
                v4 = Vector4d.Transform(v4, matrixMain);
                GL.Vertex3(v4.X, v4.Y, v4.Z);
            }
            GL.End();
            //DrawEjes();
        }

        public void SetColor()
        {
            GL.Color3(color.red, color.green, color.blue);
        }

        public void Translate(double x, double y, double z)
        {
            matrixTranslation = matrixTranslation * Matrix4d.CreateTranslation(new Vector3d(x, y, z));
            //matrixMain = matrixTranslation * matrixRotation * matrixScalation;
        }
            
        public void Rotate(double angle, double x, double y, double z)
        {
            if(x == 1)
            {
                matrixRotation = matrixRotation * Matrix4d.CreateRotationX(MathHelper.DegreesToRadians(angle));
            } else
            if (y == 1)
            {
                matrixRotation = matrixRotation * Matrix4d.CreateRotationY(MathHelper.DegreesToRadians(angle));
            } else
             if(z == 1)
            {
                matrixRotation = matrixRotation * Matrix4d.CreateRotationZ(MathHelper.DegreesToRadians(angle));
            }
            //matrixTranslation * matrixRotation * matrixScalation;
        }

        public void Scale(double size)
        {
            matrixScalation = matrixScalation * Matrix4d.Scale(size);
            //matrixMain = matrixTranslation * matrixRotation * matrixScalation;
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
