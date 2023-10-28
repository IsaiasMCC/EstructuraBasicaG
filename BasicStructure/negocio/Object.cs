using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BasicStructure.negocio
{
    public class Object: IObject
    {
        public double centerX { get; set; }
        public double centerY { get; set; }
        public double centerZ { get; set; }

        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }

        public Dictionary<string, Part> parts { get; set; }

        [JsonConstructor]
        public Object(double width, double height, double depth, double centerX, double centerY, double centerZ)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.centerX = centerX;
            this.centerY = centerY;
            this.centerZ = centerZ;
            this.parts = new Dictionary<string, Part>();
        }

        public void Draw()
        {
            foreach(KeyValuePair<string, Part> part in parts)
            {
                part.Value.Draw();
            }
        }

        public void Rotate(double angle, double x, double y, double z)
        {
            this.Translate(-centerX, -centerY, -centerZ);
            foreach (KeyValuePair<string, Part> part in parts)
            {
                part.Value.Rotate(angle, x, y, z);
            }
            this.Translate(centerX, centerY, centerZ);
        }

        public void Translate(double x, double y, double z)
        {
            foreach(KeyValuePair<string, Part> part in parts)
            {
                part.Value.Translate(x, y, z);
            }
        }

        public void Scale(double size)
        {
            foreach (KeyValuePair<string, Part> part in parts)
            {
                part.Value.Scale(size);
            }
        }

        public void Add(string key, Part value)
        {
            this.parts.Add(key, value);
        }

        public void Remove(string key)
        {
            this.parts.Remove(key);
        }

    }
}
