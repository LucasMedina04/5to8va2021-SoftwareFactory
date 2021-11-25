using System;
using SoftwareFactory.ADOMySql;
using SoftwareFactory.Core;

namespace Admin.Consola
{
    static class MenuCliente
    {
        public static void Iniciar(AdoSoftwareFactory Ado)
        {
            int Opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu de Tabla 'Cliente'\n" +
                                  "0) Para volver al menú principal\n" +
                                  "1) Para dar de alta un cliente\n" +
                                  "2) Para ver los clientes");
                Opcion = int.Parse(Console.ReadLine());
                switch (Opcion)
                {
                    case 1:
                    Console.WriteLine("Dando de alta un cliente...");
                    Ado.AltaCliente(new Cliente(cuit(), razonSocial()));
                    break;
                    case 2:
                    MostrarClientes(Ado);
                    break;
                    default:
                    if (Opcion != 0)
                    {
                        Console.WriteLine("Ingrese un número entre 0 y 2");
                    }
                    break;
                }
            } while (Opcion != 0);
        }
        static int cuit()
        {
            Console.Write("Ingrese el cuit del cliente: ");
            return int.Parse(Console.ReadLine());
        }
        static string razonSocial()
        {
            Console.Write("Ingrese la razón social del cliente: ");
            return Console.ReadLine().ToString();
        }

        static void MostrarClientes(AdoSoftwareFactory Ado)
        {
            Console.WriteLine("Lista de Clientes:");
            foreach (Cliente item in Ado.ObtenerClientes())
            {
                Console.WriteLine("[ Cuit: {0} ] , [ Razón Social: {1} ]", item.cuit, item.razonSocial);
            }
            Console.Write("Presione una tecla para continuar... ");
            Console.ReadKey();
        }
    }
}
