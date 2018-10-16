using System;
namespace Negocio
{
    public class Venta
    {
        Cliente cliente;
        Tarjeta tarjeta;
        double totalFinanciado;
        double totalVenta;

        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Tarjeta Tarjeta { get => tarjeta; set => tarjeta = value; }

        public double TotalVenta { get => totalVenta; set => totalVenta = value; }
        public double TotalFinanciado { get => totalFinanciado; set => totalFinanciado = value; }

        public Venta(Cliente cliente, Tarjeta tarjeta, double totalFinanciado)
        {
            this.cliente = cliente;
            this.tarjeta = tarjeta;
            this.totalFinanciado = totalFinanciado;
        }

       
    }
}
