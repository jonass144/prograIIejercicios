
using actividad1._5facturacion.dominio;
using System;
using System.Collections.Generic;
using actividad1._5facturacion.servicio;
using actividad1._5facturacion.dominio;

namespace actividad1._5facturacion
{
    class Program
    {
        static void Main(string[] args)
        {
            ArticuloManager articuloManager = new ArticuloManager();
            FacturaManager facturaManager = new FacturaManager();

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Menú Principal:");
                Console.WriteLine("1. Gestionar Artículos");
                Console.WriteLine("2. Gestionar Facturas");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        GestionarArticulos(articuloManager);
                        break;
                    case "2":
                        GestionarFacturas(facturaManager);
                        break;
                    case "3":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
        }

        static void GestionarArticulos(ArticuloManager articuloManager)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nGestión de Artículos:");
                Console.WriteLine("1. Ver todos los artículos");
                Console.WriteLine("2. Buscar artículo por ID");
                Console.WriteLine("3. Agregar nuevo artículo");
                Console.WriteLine("4. Actualizar un artículo");
                Console.WriteLine("5. Borrar un artículo");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        List<Articulos> articulos = articuloManager.ObtenerArticulos();
                        Console.WriteLine("\nLista de Artículos:");
                        foreach (var articulo in articulos)
                        {
                            Console.WriteLine($"ID: {articulo.Codigo}, Nombre: {articulo.Nombre}, Precio: {articulo.Precio}");
                        }
                        break;
                    case "2":
                        Console.Write("Ingrese el ID del artículo: ");
                        int idBuscar = int.Parse(Console.ReadLine());
                        Articulos articuloBuscado = articuloManager.ObtenerPorId(idBuscar);
                        if (articuloBuscado != null)
                        {
                            Console.WriteLine($"ID: {articuloBuscado.Codigo}, Nombre: {articuloBuscado.Nombre}, Precio: {articuloBuscado.Precio}");
                        }
                        else
                        {
                            Console.WriteLine("Artículo no encontrado.");
                        }
                        break;
                    case "3":
                        Articulos nuevoArticulo = new Articulos();
                        Console.Write("Ingrese el nombre del artículo: ");
                        nuevoArticulo.Nombre = Console.ReadLine();
                        Console.Write("Ingrese el precio del artículo: ");
                        nuevoArticulo.Precio = Convert.ToInt32(Console.ReadLine());
                        bool guardado = articuloManager.GuardarArticulo(nuevoArticulo);
                        Console.WriteLine(guardado ? "Artículo guardado con éxito." : "Error al guardar el artículo.");
                        break;
                    case "4":
                        Articulos articuloActualizar = new Articulos();
                        Console.Write("Ingrese el ID del artículo a actualizar: ");
                        articuloActualizar.Codigo = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el nuevo nombre del artículo: ");
                        articuloActualizar.Nombre = Console.ReadLine();
                        Console.Write("Ingrese el nuevo precio del artículo: ");
                        articuloActualizar.Precio = Convert.ToInt32(Console.ReadLine());
                        bool actualizado = articuloManager.Actualizar(articuloActualizar);
                        Console.WriteLine(actualizado ? "Artículo actualizado con éxito." : "Error al actualizar el artículo.");
                        break;
                    case "5":
                        Console.Write("Ingrese el ID del artículo a borrar: ");
                        int idBorrar = int.Parse(Console.ReadLine());
                        bool borrado = articuloManager.Borrar(idBorrar);
                        Console.WriteLine(borrado ? "Artículo borrado con éxito." : "Error al borrar el artículo.");
                        break;
                    case "6":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
        }

        static void GestionarFacturas(FacturaManager facturaManager)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nGestión de Facturas:");
                Console.WriteLine("1. Ver todas las facturas");
                Console.WriteLine("2. Buscar factura por ID");
                Console.WriteLine("3. Agregar nueva factura");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        List<Factura> facturas = facturaManager.ObtenerFacturas();
                        Console.WriteLine("\nLista de Facturas:");
                        foreach (var factura in facturas)
                        {
                            Console.WriteLine($"ID: {factura.NroFactura}, Cliente: {factura.Cliente}, Total: {factura.Total}");
                        }
                        break;
                    case "2":
                        Console.Write("Ingrese el ID de la factura: ");
                        int idBuscar = int.Parse(Console.ReadLine());
                        Factura facturaBuscada = facturaManager.ObtenerPorId(idBuscar);
                        if (facturaBuscada != null)
                        {
                            Console.WriteLine($"ID: {facturaBuscada.NroFactura}, Cliente: {facturaBuscada.Cliente}, Total: {facturaBuscada.Total}");
                        }
                        else
                        {
                            Console.WriteLine("Factura no encontrada.");
                        }
                        break;
                    case "3":
                        Factura nuevaFactura = new Factura();
                        Console.Write("Ingrese el nombre del cliente: ");
                        nuevaFactura.Cliente.Id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ingrese el total de la factura: ");
                      
                        bool guardado = facturaManager.Guardar(nuevaFactura);
                        Console.WriteLine(guardado ? "Factura guardada con éxito." : "Error al guardar la factura.");
                        break;
                    case "4":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
        }
    }
}


