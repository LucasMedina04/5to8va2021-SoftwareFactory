using System;
using et12.edu.ar.AGBD.Ado;
using SoftwareFactory.ADOMySql;
using SoftwareFactory.Core;

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
                Console.Clear();
                Console.WriteLine("Menú Principal\n" +
                                  "0) Para salir\n" +
                                  "1) Para acciones sobre Tabla 'Clientes'");
                Opcion = int.Parse(Console.ReadLine());
                switch (Opcion)
                {
                    case 1:
                    MenuCliente.Iniciar(Ado);
                    break;
                    
                    default:
                    if (Opcion != 0)
                    {
                        Console.WriteLine("Ingrese un valor entre 0 y (CantidadClases)");
                        Console.ReadKey();
                    }
                    break;
                }
            } while (Opcion != 0);
        }
    }
}
