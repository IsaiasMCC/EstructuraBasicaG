using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BasicStructure.negocio
{
    public class Color
    {
        public double red { get; set; }
        public double green { get; set; }
        public double blue { get; set; }

        [JsonConstructor]
        public Color(double red, double green, double blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

    }
}
