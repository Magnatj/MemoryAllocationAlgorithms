using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFit
{
    class Program
    {
        static bool seHizoCambio;
        static void Main(string[] args)
        {
            List<List<BloqueMemoria>> HDD = new List<List<BloqueMemoria>>();
            List<BloqueMemoria> Ceros = new List<BloqueMemoria>();
            Ceros.Add(new BloqueMemoria(11));
            Ceros.Add(new BloqueMemoria(19));
            List<BloqueMemoria> Veintes = new List<BloqueMemoria>();
            Veintes.Add(new BloqueMemoria(21));
            Veintes.Add(new BloqueMemoria(39));
            List<BloqueMemoria> Cuarentas = new List<BloqueMemoria>();
            Cuarentas.Add(new BloqueMemoria(45));
            Cuarentas.Add(new BloqueMemoria(51));
            List<BloqueMemoria> Sesentas = new List<BloqueMemoria>();
            Sesentas.Add(new BloqueMemoria(66));
            Sesentas.Add(new BloqueMemoria(69));
            List<BloqueMemoria> Ochentas = new List<BloqueMemoria>();
            Ochentas.Add(new BloqueMemoria(81));
            Ochentas.Add(new BloqueMemoria(87));
            HDD.Add(Ceros);
            HDD.Add(Veintes);
            HDD.Add(Cuarentas);
            HDD.Add(Sesentas);
            HDD.Add(Ochentas);

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

        public static void BuscarMemoria(int memoriaPedida, List<List<BloqueMemoria>> HDD)
        {
            List<BloqueMemoria> categoria = new List<BloqueMemoria>();

            seHizoCambio = false;

            if(memoriaPedida>=80)
            {
                categoria = HDD[4]; //Ochentas
            }

            else if(memoriaPedida>=60)
            {
                categoria = HDD[3]; //Sesentas
            }

            else if(memoriaPedida>=40)
            {
                categoria = HDD[2]; //Cuarentas
            }

            else if(memoriaPedida>=20)
            {
                categoria = HDD[1]; //Veintes
            }

            else if(memoriaPedida>=0)
            {
                categoria = HDD[0]; //Ceros
            }


            for (int i = 0; i < categoria.Count; i++)
            {
                if (memoriaPedida <= categoria[i].Tamano && categoria[i].Disponible)
                {
                    categoria[i].Disponible = false;
                    seHizoCambio = true;
                    Console.WriteLine("Se encontro un espacio vacio de {0} en la posicion {1}, memoria perdida {2}", categoria[i].Tamano, i, (categoria[i].Tamano - memoriaPedida));
                    break;
                }
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
