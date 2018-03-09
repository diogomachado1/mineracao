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
            regra.metodo1(new Conjunto(0,0).conjuntos(),regra.lerAquivo("./Info.csv"),0.0005,0.04);//usei um banco de dados



            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
