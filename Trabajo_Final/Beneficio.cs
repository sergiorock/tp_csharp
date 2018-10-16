using System;
namespace Negocio
{
    public class Beneficio
    {
        int cantCuotas;
        int interes;

        public int CantCuotas { get => cantCuotas; set => cantCuotas = value; }
        public int Interes { get => interes; set => interes = value; }

        //Constructor
        //Crea el Beneficio
        public Beneficio(int cantCuotas, int interes)
        {
            this.cantCuotas = cantCuotas;
            this.interes = interes;
        }
    }
}
