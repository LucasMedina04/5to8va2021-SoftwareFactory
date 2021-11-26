using System;
using SoftwareFactory.ADOMySql;
using SoftwareFactory.Core;
using static System.Console;

namespace Admin.Consola
{
    static class MenuCliente
    {
        public static void Iniciar(AdoSoftwareFactory Ado)
        {
            int Opcion;
            do
            {
                Menu();
                Opcion = int.Parse(ReadLine());
                switch (Opcion)
                {
                    case 1:
                    Ado.AltaCliente(new Cliente(cuit(Ado), razonSocial()));
                    break;
                    case 2:
                    MostrarClientes(Ado);
                    break;
                    default:
                    if (Opcion != 0)
                    {
                        WriteLine("Ingrese un número entre 0 y 2");
                    }
                    break;
                }
            } while (Opcion != 0);
        }
        static int cuit(AdoSoftwareFactory Ado)
        {
            bool aux = false;
            int x = 0;
            do
            {
                try
                {
                    Clear();
                    ForegroundColor = ConsoleColor.White;
                    WriteLine("Dando de alta un cliente\n");
                    ForegroundColor = ConsoleColor.Gray;
                    Write("Ingrese el cuit del cliente: ");
                    x = int.Parse(ReadLine());
                    foreach (Cliente item in Ado.ObtenerClientes())
                    {
                        if (x == item.cuit)
                        {
                            aux = false;
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("El cuit ingresado ya se encuentra en la base de datos (clave duplicada)");
                            ForegroundColor = ConsoleColor.Gray;
                            WriteLine("Presione una tecla para continuar...");
                            ReadKey();
                            break;
                        }
                        else
                        {
                            aux = true;
                        }
                    }
                }
                catch (Exception)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("El dato ingresado no es válido");
                    ForegroundColor = ConsoleColor.Gray;
                    WriteLine("Presione una tecla para continuar...");
                    ReadKey();
                }
            } while (aux == false);
            return x;
        }
        static string razonSocial()
        {
            bool aux = false;
            string razon = "";
            do
            {
                try
                {
                    Clear();
                    ForegroundColor = ConsoleColor.White;
                    WriteLine("Dando de alta un cliente\n");
                    ForegroundColor = ConsoleColor.Gray;
                    Write("Ingrese la razón social del cliente: ");
                    razon = ReadLine().ToString();
                    aux = true;
                }
                catch (Exception)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("El dato ingresado no es válido");
                    ForegroundColor = ConsoleColor.Gray;
                    WriteLine("Presione una tecla para continuar...");
                    ReadKey();
                }
            } while (aux == false);
            return razon;
        }

        static void MostrarClientes(AdoSoftwareFactory Ado)
        {
            Clear();
            WriteLine("Lista de Clientes:");
            foreach (Cliente item in Ado.ObtenerClientes())
            {
                WriteLine("[ Cuit: {0} ] , [ Razón Social: {1} ]", item.cuit, item.razonSocial);
            }
            Write("Presione una tecla para continuar... ");
            ReadKey();
        }
        static void Menu()
        {
            Clear();
            ForegroundColor = ConsoleColor.White;
            WriteLine("Menu de Tabla 'Cliente\n'");
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("0) Para volver al menú principal\n" +
                              "1) Para dar de alta un cliente\n" +
                              "2) Para ver los clientes");
        }
    }
}
