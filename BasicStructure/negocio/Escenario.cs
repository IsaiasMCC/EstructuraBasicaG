using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BasicStructure.negocio
{
    public class Escenario: IObject
    {
        public double centerX { get; set; }
        public double centerY { get; set; }
        public double centerZ { get; set; }
        public Dictionary<string, Object> objects { get; set; }

        [JsonConstructor]
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

        public void Rotate(double angle, double x, double y, double z)
        {
            foreach (KeyValuePair<string, Object> objecto in objects)
            {
                objecto.Value.Rotate(angle, x, y, z);
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
