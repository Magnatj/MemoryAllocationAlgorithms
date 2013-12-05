using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_Fit
{
    class Program
    {
        static bool seHizoCambio;
        static int indexAnterior = 0;

        static void Main(string[] args)
        {
            BloqueMemoria[] HDD = new BloqueMemoria[5];
            HDD[0] = new BloqueMemoria(20);
            HDD[1] = new BloqueMemoria(50);
            HDD[2] = new BloqueMemoria(100);
            HDD[3] = new BloqueMemoria(80);
            HDD[4] = new BloqueMemoria(70);

            while (true)
            {
                Console.WriteLine("Ingresa la cantidad de memoria que ocupas ");
                int cantidad = int.Parse(Console.ReadLine());
                BuscarMemoria(cantidad, HDD);

                if (!seHizoCambio)
                {
                    Console.WriteLine("No se encontro un bloque de memoria libre\n");
                }

                Console.WriteLine("Desea continuar? y/n");
                string continua = Console.ReadLine();

                if (continua == "n")
                {
                    break;
                }

                else
                {
                    Console.Clear();
                }
            }
        }

        static void BuscarMemoria(int memoriaPedida, BloqueMemoria[] HDD)
        {
            seHizoCambio = false;
            if (indexAnterior == HDD.Length - 1)
                indexAnterior = 0;
            for (int i = indexAnterior; i < HDD.Length; i++)
            {
                if (HDD[i].Tamano >= memoriaPedida && HDD[i].Disponible)
                {
                    HDD[i].Disponible = false;
                    seHizoCambio = true;
                    Console.WriteLine("Se encontro un espacio vacio de {0} en la posicion {1}, memoria perdida {2}", HDD[i].Tamano, i, (HDD[i].Tamano - memoriaPedida));
                    indexAnterior = i;
                    break;
                }
            }
        }

        class BloqueMemoria
        {
            public bool Disponible { get; set; }
            public int Tamano { get; set; }

            public BloqueMemoria(int tamano)
            {
                Tamano = tamano;
                Disponible = true;
            }
        }
    }
}
