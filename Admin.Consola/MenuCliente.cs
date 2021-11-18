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
                Console.WriteLine("Menu de Tabla 'Cliente'\n" +
                                  "0) Para salir\n" +
                                  "1) Para dar de alta un cliente\n" +
                                  "2) Para ver los clientes");
                Opcion = int.Parse(Console.ReadLine());
                switch (Opcion)
                {
                    case 1:
                        Ado.AltaCliente(new Cliente(Cuit(), razonSocial));
                        break;
                    default:
                        Console.WriteLine("Ingrese un número entre 0 y 2");
                        break;
                }
            } while (Opcion != 0);
        }
        public static int Cuit()
        {
            int cuit;
            do
            {
                Console.Write("Ingrese un cuit: ");
            } while (int.TryParse(Console.ReadLine(), out cuit));
            return cuit;
        }
    }
}
