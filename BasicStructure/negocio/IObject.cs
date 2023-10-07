using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStructure.negocio
{
    interface IObject
    {
        void Draw();
        void Rotate(double angle, double x, double y, double z);
    }
}
