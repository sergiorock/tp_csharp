using System;
namespace Negocio
{
    public class Cliente
    {
        string nombre;
        string apellido;
        int dni;
        string fecNac;
        double totalGastado;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public string FecNac { get => fecNac; set => fecNac = value; }
        public double TotalGastado { get => totalGastado; set => totalGastado = value; }


        //Constructores 
        //Default
        public Cliente()
        {
        }

        //Constructor utilizado para Productos Hardcodeados
        public Cliente(string nombre, string apellido, int dni, string fecNac, double totalGastado)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.fecNac = fecNac;
            this.totalGastado = totalGastado;
        }

        //******* MÉTODOS **********
        //Sobreescribo el ToString para imprimir los clientes en el listado
        public override string ToString()
        {
            return "\nCliente: \nNombre=" + Nombre + " Apellido=" + Apellido + " DNI=" + dni + " Fec Nac=" + fecNac + " Total Gastado=" + totalGastado;
        }
    }
}
