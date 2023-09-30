using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStructure.negocio
{
    class Object: IObject
    {
        public double centerX;
        public double centerY;
        public double centerZ;

        public Dictionary<string, Part> parts;

        public Object(double centerX, double centerY, double centerZ)
        {
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
