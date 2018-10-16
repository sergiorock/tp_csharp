using System;
namespace Negocio
{
    //Clase Producto
    public class Producto
    {
        string tipo;
        string marca;
        string talle;
        double precio;
        int descuento;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Talle { get => talle; set => talle = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Descuento { get => descuento; set => descuento = value; }

        //******* MÉTODOS **********
        //Sobreescribo el ToString para imprimir los productos en el listado
        public override string ToString()
        {
            return "Producto: Tipo=" + tipo + " Marca=" + marca + " Talle=" + talle + " Precio=" + precio + " Descuento=" + descuento;
        }

        //Constructores
        //Default
        public Producto()
        {

        }
        //Este constructor está solo porque harcodee unos productos.
        public Producto(string tipo, string marca, string talle, double precio, int descuento)
        {
            this.tipo = tipo;
            this.marca = marca;
            this.talle = talle;
            this.precio = precio;
            this.descuento = descuento;
        }
    }
}
