using System;
using et12.edu.ar.AGBD.Ado;
using SoftwareFactory.ADOMySql;
using static System.Console;

namespace Admin.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
            var Ado = new AdoSoftwareFactory(adoAGBD);
            int Opcion;
            do
            {
                Menu();
                Opcion = int.Parse(ReadLine());
                switch (Opcion)
                {
                    case 1:
                        MenuCliente.Iniciar(Ado);
                        break;

                    default:
                        if (Opcion != 0)
                        {
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("Ingrese un valor entre 0 y (CantidadClases)");
                            ForegroundColor = ConsoleColor.Gray;
                            WriteLine("Presione una tecla para continuar...");
                            ReadKey();
                        }
                        break;
                }
            } while (Opcion != 0);
        }
        static void Menu()
        {
            Clear();
            ForegroundColor = ConsoleColor.White;
            WriteLine("Menú Principal\n");
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("0) Para salir\n" +
                              "1) Para acciones sobre los Clientes");
        }
    }
}
