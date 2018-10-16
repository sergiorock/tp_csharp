using System;
using System.Collections.Generic;

namespace Negocio
{
    public class Carrito
    {
        List<Producto> productos;

        //Constructor
        //Cuando instancio carrito, creo una lista de tipo Producto que me va a servir como un carrito
        public Carrito()
        {
            productos = new List<Producto>();
        }

        //********* MÉTODOS **************
        //Agregar Productos al carrito
        public void AgregarProducto(Producto p)
        {
            productos.Add(p);
        }

        //Quitar Productos del Carrito
        public void QuitarProducto(int index)
        {
            productos.RemoveAt(index);

        }

        //Vaciar Carrito
        public void VaciarCarrito()
        {
            productos.Clear();
        }

        //Listar Productos del carrito
        public void ListarProductosEnCarro()
        {
            Console.Clear();
            for (int i = 0; i < productos.Count; i++)
            {
                Console.WriteLine(i + ") " + productos[i]);
            }
            Console.WriteLine("\nTotal de la compra: " + TotalCarrito());
        }

        //Devuelvo el total para mostrarlo en la pantalla de cliente registrado
        public double TotalCarrito()
        {
            double total = 0;
            foreach (var producto in productos)
            {
                double precio = producto.Precio;
                if (producto.Descuento > 0) {
                    precio = ((100 - producto.Descuento) * producto.Precio) / 100;
                }

                total = total + precio;
            }
            return total;

        }
    }
}


