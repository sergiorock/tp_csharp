using System;
using Negocio;
using Datos;

namespace Trabajo_Final
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            BaseDeDatos bd = new BaseDeDatos();
            Carrito carrito = new Carrito();

             MenuPrincipal();

            // **** MENÜ PRINCIPAL *****+
            void MenuPrincipal()
            {
                Console.Clear();
                string title_ppal = "TIENDA ONLINE";
                cartelTitulo(title_ppal);
                Console.WriteLine("\n" + "¿A qué modulo desea ingresar?" + "\n");
                Console.WriteLine("1) Productos y promociones");
                Console.WriteLine("2) Compras");
                Console.WriteLine("3) Tarjetas de crédito");
                Console.WriteLine("4) Administración");
                Console.WriteLine("5) Salir del sistema \n");
                int opcion = 0;
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nIngrese una opcion válida");
                    opcion = int.Parse(Console.ReadLine());
                }
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        MenuProductos();
                        break;
                    case 2:
                        Console.Clear();
                        MenuCompras();
                        break;
                    case 3:
                        Console.Clear();
                        MenuTarjetas();
                        break;
                    case 4:
                        Console.Clear();
                        MenuAdministracion();
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            }

            // ********* MÓDULO PRODUCTOS ***************
            // Menú Productos y promociones
            void MenuProductos()
            {
                Console.Clear();
                string title_prod = "MODULO PRODUCTOS";
                cartelTitulo(title_prod);
                Console.WriteLine("\n" + "¿Qué desea hacer?" + "\n");
                Console.WriteLine("1) Dar de alta Productos");
                Console.WriteLine("2) Dar de alta Promociones");
                Console.WriteLine("3) Listar Productos");
                Console.WriteLine("4) Listar Promociones");
                Console.WriteLine("5) Volver \n");
                int opcion_producto = 0;
                try
                {
                    opcion_producto = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nIngrese una opcion válida");
                    opcion_producto = int.Parse(Console.ReadLine());
                }

                switch (opcion_producto)
                {
                    case 1:
                        bd.CrearProducto();
                        MenuPrincipal();
                        break;
                    case 2:
                        bd.CrearPromocion();
                        MenuProductos();
                        break;
                    case 3:
                        Console.Clear();
                        string title_list = "LISTADO DE PRODUCTOS";
                        cartelTitulo(title_list);
                        bd.ListarProductos();
                        Console.WriteLine("\nPresione cualquier tecla para volver...");
                        Console.ReadKey();
                        MenuProductos();
                        break;
                    case 4:
                        Console.Clear();
                        string title_prom = "LISTADO DE PROMOCIONES";
                        cartelTitulo(title_prom);
                        bd.ListarPromociones();
                        Console.WriteLine("\nPresione cualquier tecla para volver...");
                        Console.ReadKey();
                        MenuProductos();
                        break;
                    case 5:
                        Console.Clear();
                        MenuPrincipal();
                        break;
                    default:
                        break;
                }
            }
    
            // ********* MÓDULO COMPRAS ***************
            // Menú Compra
            void MenuCompras()
            {
                Console.Clear();
                string title_compras = "MODULO COMPRAS";
                cartelTitulo(title_compras);
                Console.WriteLine("\n¿Qué desea hacer?\n");
                Console.WriteLine("1) Agregar productos al carro");
                Console.WriteLine("2) Identificar Cliente");
                Console.WriteLine("3) Volver \n");
                int opcion_compra = 0;
                try
                {
                    opcion_compra = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nIngrese una opcion válida");
                    opcion_compra = int.Parse(Console.ReadLine());
                }
                switch (opcion_compra)
                {
                    case 1:
                        Console.Clear();
                        MenuCarro();
                        break;
                    case 2:
                        Console.Clear();
                        double total = carrito.TotalCarrito();
                        bd.IdentificarCliente(total);
                        carrito.VaciarCarrito();

                        Console.ReadKey();
                        MenuCompras();

                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        MenuPrincipal();
                        break;
                    default:
                        break;
                }
            }

            //SUBMODULO CARRO
            void MenuCarro()
            {
                Console.Clear();
                string title_carro = "CARRITO DE COMPRAS";
                cartelTitulo(title_carro);
                Console.WriteLine("");
                Console.WriteLine("¿Qué desea hacer?");
                Console.WriteLine("");
                Console.WriteLine("1) Agregar producto al carro");
                Console.WriteLine("2) Quitar producto del carro");
                Console.WriteLine("3) Listar productos en carro");
                Console.WriteLine("4) Volver \n");
                int opcion_carro = 0;
                try 
                {
                
                    opcion_carro = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nIngrese una opcion valida");
                    opcion_carro = int.Parse(Console.ReadLine());
                }

                switch (opcion_carro)
                {
                    case 1:
                        bd.ListarProductos();
                        Console.WriteLine("\nElija un producto para agregar al carro");
                        int opc = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nIngrese cantidad");
                        int cant = int.Parse(Console.ReadLine());
                        for (int i = 0; i < cant; i++)
                        {
                            Producto prod = bd.BuscarProducto(opc);
                            carrito.AgregarProducto(prod);
                        }
                        Console.WriteLine("\nProducto cargado con éxito!");
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        MenuCarro();
                        break;
                    case 2:
                        carrito.ListarProductosEnCarro();
                        Console.WriteLine("\nElija un producto para eliminar del carro");
                        int opcElim = int.Parse(Console.ReadLine());
                        carrito.QuitarProducto(opcElim);
                        Console.WriteLine("\nProducto eliminado con éxito \nPresione una tecla para continuar...");
                        Console.ReadKey();
                        MenuCarro();
                        break;
                    case 3:
                        string title_miCarrito = "MI CARRITO";
                        cartelTitulo(title_miCarrito);
                        carrito.ListarProductosEnCarro();
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        MenuCarro();
                        break;
                    case 4:
                        MenuCompras();
                        break;
                    default:
                        break;
                }
            }

            // ********* MÓDULO TARJETAS ***************
            // Menú Principal
            void MenuTarjetas()
            {
                Console.Clear();
                string title_prod = "MODULO TARJETAS";
                cartelTitulo(title_prod);
                Console.WriteLine("\n" + "¿Qué desea hacer?" + "\n");
                Console.WriteLine("1) Agregar Tarjeta");
                Console.WriteLine("2) Agregar Beneficio");
                Console.WriteLine("3) Listar Tarjetas");
                Console.WriteLine("4) Listar Tarjetas con Beneficio");
                Console.WriteLine("5) Volver \n");
                int opcion_tarj = 0;
                try
                {
                    opcion_tarj = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nIngrese una opcion válida");
                    opcion_tarj = int.Parse(Console.ReadLine());
                }

                switch (opcion_tarj)
                {
                    case 1:
                        bd.AgregarTarjeta();
                        MenuTarjetas();
                        break;
                    case 2:
                        Console.Clear();
                        bd.AgregarBeneficio();
                        Console.WriteLine("\nPresione una tecla para continuar");
                        Console.ReadKey();
                        MenuTarjetas();
                        break;
                    case 3:
                        Console.Clear();
                        bd.ListarTarjetas();
                        Console.WriteLine("\nPresione una tecla para continuar");
                        Console.ReadKey();
                        MenuTarjetas();
                        break;
                    case 4:
                        Console.Clear();
                        bd.ListarTarjBeneficios();
                        Console.WriteLine("\nPresione una tecla para continuar");
                        Console.ReadKey();
                        MenuTarjetas();
                        break;
                    case 5:
                        MenuPrincipal();
                        break;
                    default:
                        break;
                }
            }

            //Cartel del Título
            void cartelTitulo(string title)
            {
                barrasAste();
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", title));
                barrasAste();
                Console.WriteLine();
            }

            //Barras asteriscos
            void barrasAste()
            {
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("*");
                }
            }

            //********* MÓDULO ADMINISTRATIVO ***************
            //Menú Compra
            void MenuAdministracion()
            {
                Console.Clear();
                string title_admin = "MODULO ADMINISTRATIVO";
                cartelTitulo(title_admin);
                Console.WriteLine("\n¿Qué desea hacer?");
                Console.WriteLine("\n1) Total vendido en la tienda Online");
                Console.WriteLine("2) Total vendido por Cliente");
                Console.WriteLine("3) Total vendido por tarjeta");
                Console.WriteLine("4) Volver \n");
                int opcion_adm = 0;
                try
                {
                    opcion_adm = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nIngrese una opcion válida");
                    opcion_adm = int.Parse(Console.ReadLine());
                }

                switch (opcion_adm)
                {
                    case 1:
                        bd.TotalTienda();
                        Console.WriteLine("\nPresione cualquier tecla para continuar");
                        Console.ReadKey();
                        MenuAdministracion();
                        break;
                    case 2:
                        bd.TotalCliente();
                        Console.WriteLine("\nPresione cualquier tecla para continuar");
                        Console.ReadKey();
                        MenuAdministracion();
                        break;
                    case 3:
                        bd.TotalTarjetas();
                        Console.WriteLine("\nPresione cualquier tecla para continuar");
                        Console.ReadKey();
                        MenuAdministracion();
                        break;
                    case 4:
                        MenuPrincipal();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}