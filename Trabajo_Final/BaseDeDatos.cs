using System;
using System.Collections.Generic;
using Negocio;

namespace Datos
{
    public class BaseDeDatos
    {
        //Falsa base de datos
        //Para guardar en memoria los productos que voy cargando.
        //List de Productos para que no me deje insertar otra cosa que no sea un Producto
        List<Producto> productos_db = new List<Producto>();

        //Falso carrito
        //List<Producto> carrito = new List<Producto>();

        //Lista de Tarjetas
        List<Tarjeta> tarjetasCargadas = new List<Tarjeta>();

        //Lista de Clientes registrados
        List<Cliente> clientesReg = new List<Cliente>();

        //Lista de Ventas
        List<Venta> ventas = new List<Venta>();

        public BaseDeDatos()
        {
            //Productos Hardcodeados
            productos_db.Add(new Producto("remera", "nike", "s", 40.23, 0));
            productos_db.Add(new Producto("camisa", "asd", "s", 40.23, 0));
            productos_db.Add(new Producto("pantalon", "levis", "l", 40.23, 0));

            //Algunas tarjetas Hardcodeadas
            Tarjeta t1 = new Tarjeta("visa", "macro", 0, 0);
            t1.AgregarBeneficio(3, 20);
            t1.AgregarBeneficio(6, 40);
            tarjetasCargadas.Add(t1);


            tarjetasCargadas.Add(new Tarjeta("master", "galicia", 0, 0));
            tarjetasCargadas.Add(new Tarjeta("american", "galicia", 0, 0));
            tarjetasCargadas.Add(new Tarjeta("cabal", "bbva", 0, 0));

            //Clientes Hardcodeados
            clientesReg.Add(new Cliente("Sergio", "López", 34021458, "12/11/1988", 0));
            clientesReg.Add(new Cliente("Agustín", "López", 45021458, "26/04/2002", 0));
        }

        //********* MÉTODOS *********
        //********* MODULO PRODUCTOS Y PROMOCIONES *************
        //Crear Produtos
        public void CrearProducto()
        {
            Producto product = new Producto();
            Console.WriteLine("Ingrese tipo de producto");
            product.Tipo = Console.ReadLine();
            Console.WriteLine("Ingrese marca de producto");
            product.Marca = Console.ReadLine();
            Console.WriteLine("Ingrese talle de producto");
            product.Talle = Console.ReadLine();
            Console.WriteLine("Ingrese precio de producto");
            product.Precio = double.Parse(Console.ReadLine());
            product.Descuento = 0;
            productos_db.Add(product);

            Console.WriteLine("\nProducto cargado con éxito!");
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        //Crear promocion
        public void CrearPromocion()
        {
            Console.WriteLine("\nSeleccione un producto para la promo \n");
            ListarProductos();
            int indice_producto = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese un porcentaje de descuento");
            int descuento = int.Parse(Console.ReadLine());
            productos_db[indice_producto].Descuento = descuento;

            Console.WriteLine("\nProducto cargado con éxito!");
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        //Listar Productos
        public void ListarProductos()
        {
            for (int i = 0; i < productos_db.Count; i++)
            {
                Console.WriteLine(i + ") " + productos_db[i]);
            }
        }

        //Listar Promociones
        public void ListarPromociones()
        {
            for (int i = 0; i < productos_db.Count; i++)
            {
                if (productos_db[i].Descuento > 0)
                {
                    Console.WriteLine(i + ") " + productos_db[i]);
                }
            }
        }

        //Buscar Productos en la base de datos
        public Producto BuscarProducto(int opc)
        {
            return productos_db[opc];
        }

        // ********* MÓDULO COMPRAS ***************
        //***********IDENTIFICAR CLIENTES**************
        public void IdentificarCliente(double totalCarrito)
        {
            Console.WriteLine("Ingrese su DNI");
            int dni = int.Parse(Console.ReadLine());
            int tarj;
            int cantCuotas = 1;
            double totalCarro = totalCarrito;
            int interes = 1;
            double totalFinanciado = 1;
            double cuota = 1;

            Cliente cliente = BuscarCliente(dni);

            Console.WriteLine("registrado!");
            Console.WriteLine(cliente);
            Console.WriteLine("\nSeleccione una tarjeta para abonar:\n");
            ListarTarjBeneficios(); //Verificar si es Listar Tarjetas con beneficios
            tarj = int.Parse(Console.ReadLine());
            Console.WriteLine("\nIndique cantidad de cuotas\n");
            cantCuotas = int.Parse(Console.ReadLine());
            Tarjeta seleccionada = tarjetasCargadas[tarj];
            foreach (var item in seleccionada.Beneficios)
            {
                if (cantCuotas == item.CantCuotas)
                {
                    Console.WriteLine("En " + item.CantCuotas + " cuotas tiene un interés de " + item.Interes + "%");
                    interes = item.Interes;
                }
            }
            totalFinanciado = ((totalCarro / 100) * interes) + totalCarro;
            cuota = (totalFinanciado / cantCuotas);
            Console.WriteLine("En el carrito hay un total de = $" + totalCarro);
            Console.WriteLine("Precio total financiado = $" + totalFinanciado + " en " + cantCuotas + " cuotas de $" + cuota + " cada una");
            Console.WriteLine("Confirma la compra? (S/N)");
            string opcion = Console.ReadLine();
            opcion.ToLower();
            if (opcion == "s")
            {
                Venta venta = new Venta(cliente, seleccionada, totalFinanciado);
                ventas.Add(venta);
                cliente.TotalGastado += venta.TotalFinanciado;
                seleccionada.TotalCompra += venta.TotalFinanciado;
                Console.WriteLine("Felicidades por su compra, carro vacío");
            }
            else
            {
                Console.WriteLine("Presione una tecla para volver al Menú anterior");
                Console.ReadKey();
            }
        }

        //Buscar Cliente por Dni
        //Si no existe lo crea
        public Cliente BuscarCliente(int dni)
        {
            Cliente regCliente = null;
            foreach (var client in clientesReg)
            {
                if (client.Dni == dni)
                {
                    regCliente = client;
                }
            }

            if (regCliente == null)
            {
                regCliente = CrearCliente(dni);
                clientesReg.Add(regCliente);
            }
            return regCliente;
        }


        //Crear Cliente
        public Cliente CrearCliente(int dni)
        {
            Console.WriteLine("Nuevo Cliente, ingrese sus datos\n");
            Console.WriteLine("Ingrese nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese fecha de nacimiento");
            string fecNac = Console.ReadLine();
            double totalGastado = 0;
            Cliente c = new Cliente(nombre, apellido, dni, fecNac, totalGastado);
            return c;
        }

         //********* MÓDULO TARJETAS ***************
        //Agregar Tarjeta
        public void AgregarTarjeta()
        {
            Tarjeta tarjeta = new Tarjeta();
            Console.WriteLine("Ingrese Tarjeta");
            tarjeta.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Banco");
            tarjeta.Banco = Console.ReadLine();
            Console.WriteLine("Ingrese cantidad de formas de pago");
            tarjeta.FormaPago = int.Parse(Console.ReadLine());
            tarjeta.TotalCompra = 0;

            for (int i = 0; i < tarjeta.FormaPago; i++)
            {
                Console.WriteLine("Forma de Pago # " + (i + 1));
                Console.WriteLine("Ingrese número de cuotas");
                int cuotas = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese interés para este plan");
                int interes = int.Parse(Console.ReadLine());
                tarjeta.AgregarBeneficio(cuotas, interes);
            }

            tarjetasCargadas.Add(tarjeta);
            Console.WriteLine("\nTarjeta agregada con éxito! \nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        //Agregar Beneficio
        public void AgregarBeneficio()
        {
            ListarTarjetas();
            Console.WriteLine("\nSeleccione una tarjeta para el beneficio: \n");
            int opcionTarj = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese número de cuotas");
            int cuotas = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese interés para este plan");
            int interes = int.Parse(Console.ReadLine());
            tarjetasCargadas[opcionTarj].AgregarBeneficio(cuotas, interes);
        }

        //Listar Tarjetas
        public void ListarTarjetas()
        {
            for (int i = 0; i < tarjetasCargadas.Count; i++)
            {
                Console.WriteLine(i + ") " + tarjetasCargadas[i]);
                tarjetasCargadas[i].ListarBeneficios();
            }
        }

        //Listar Tarjetas con Beneficios
        public void ListarTarjBeneficios()
        {
            for (int i = 0; i < tarjetasCargadas.Count; i++)
            {
                if (tarjetasCargadas[i].FormaPago > 0)
                {
                    Console.WriteLine(i + ") " + tarjetasCargadas[i]);
                    tarjetasCargadas[i].ListarBeneficios();
                }
            }
        }

        //Listar Ventas
        public void ListarVentas()
        {
            for (int i = 0; i < ventas.Count; i++)
            {
                Console.WriteLine(i + " )" + ventas);
            }
        }

        //Total ventas de la tienda
        public void TotalTienda()
        {
            double totalTienda = 0;
            foreach (var item in ventas)
            {
                totalTienda += item.TotalFinanciado;
            }
            Console.WriteLine("El total vendido en la tienda es de: $" + totalTienda);
        }

        //Total vendido por cliente
        public void TotalCliente()
        {
            foreach (var cliente in clientesReg)
            {
                if (cliente.TotalGastado > 0)
                {
                    Console.WriteLine(cliente);
                }
            }
        }

        //Total vendido por tarjeta
        public void TotalTarjetas()
        {
            foreach (var tarjeta in tarjetasCargadas)
            {
                if (tarjeta.TotalCompra > 0)
                {
                    Console.WriteLine(tarjeta);
                }
            }
        }
    }
}
