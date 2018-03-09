using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mineração
{
    class Program
    {
        static void Main(string[] args)
        {
            var regra=new Regra();
            regra=new Regra();
            regra.metodo1(new Conjunto(0,0).conjuntos(),regra.lerAquivo(),0.0005,0.04);



            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
