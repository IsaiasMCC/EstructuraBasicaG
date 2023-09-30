using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BasicStructure.negocio;
namespace BasicStructure
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Game game = new Game(900, 700, "Basic Structure");
        }
    }
}
