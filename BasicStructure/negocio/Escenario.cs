using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStructure.negocio
{
    class Escenario: IObject
    {
        public double centerX;
        public double centerY;
        public double centerZ;
        public Dictionary<string, Object> objects;

        public Escenario(double centerX, double centerY, double centerZ)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.centerZ = centerZ;
            this.objects = new Dictionary<string, Object>();
        }

        public void Add(String key, Object Value)
        {
            this.objects.Add(key, Value);
        }

        public void Draw()
        {
            foreach(KeyValuePair<string, Object> objecto in objects)
            {
                objecto.Value.Draw();
            }
        }

        public Object Get(string key)
        {
            Object value = null;
            foreach(KeyValuePair<string, Object> objec in objects)
            {
                if (objec.Key == key)
                {
                    value = objec.Value;
                }
            }
            return value;
        }
    }
}
