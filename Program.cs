using System;
using System.Collections.Generic;

namespace SistemaAtencionClientes
{
    class Program
    {
        static Queue<string> colaClientes = new Queue<string>();

        static void Main(string[] args)
        {
            int opcion = 0;

            do
            {
                Console.Clear();
                MostrarMenu();

                // Validación para evitar errores si el usuario escribe letras
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Error: Debe ingresar un número válido.");
                    Pausa();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        AgregarCliente();
                        break;

                    case 2:
                        AtenderCliente();
                        break;

                    case 3:
                        MostrarCola();
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 4)
                {
                    Pausa();
                }

            } while (opcion != 4);
        }

        static void MostrarMenu()
        {
            Console.WriteLine("===== SISTEMA DE ATENCIÓN AL CLIENTE =====");
            Console.WriteLine("1. Agregar cliente");
            Console.WriteLine("2. Atender cliente");
            Console.WriteLine("3. Ver cola");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void AgregarCliente()
        {
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Error: El nombre no puede estar vacío.");
                return;
            }

            colaClientes.Enqueue(nombre.Trim());
            Console.WriteLine("Cliente agregado correctamente.");

            MostrarCola();
        }

        static void AtenderCliente()
        {
            if (colaClientes.Count == 0)
            {
                Console.WriteLine("No hay clientes en la cola.");
                return;
            }

            string clienteAtendido = colaClientes.Dequeue();
            Console.WriteLine($"Atendiendo a: {clienteAtendido}");

            MostrarCola();
        }

        static void MostrarCola()
        {
            Console.WriteLine("\n--- Cola de Clientes ---");

            if (colaClientes.Count == 0)
            {
                Console.WriteLine("La cola está vacía.");
                return;
            }

            int posicion = 1;
            foreach (string cliente in colaClientes)
            {
                Console.WriteLine($"{posicion}. {cliente}");
                posicion++;
            }
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}