using System;
using System.Collections.Generic;

namespace Negocio
{
    //clase Tarjeta
    public class Tarjeta
    {
        List<Beneficio> beneficios = new List<Beneficio>();
        string nombre;
        string banco;
        int formaPago;
        double totalCompra;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Banco { get => banco; set => banco = value; }
        public int FormaPago { get => formaPago; set => formaPago = value; }
        public double TotalCompra { get => totalCompra; set => totalCompra = value; }
        public List<Beneficio> Beneficios { get => beneficios;}


        //constructores

        public Tarjeta()
        {
            
        }
        public Tarjeta(string nombre, string banco, int formaPago, double totalCompra)
        {
            this.nombre = nombre;
            this.banco = banco;
            this.formaPago = formaPago;
            this.totalCompra = totalCompra;
        }

        //******* MÉTODOS **********
        //Sobreescribo el ToString para imprimir las tarjetas
        public override string ToString()
        {
            return "Nombre = " + Nombre + " |Banco = " + Banco + " |Cantidad Formas de Pago = " + FormaPago + " \nTotal Compras = " + TotalCompra; // + "\nCuotas = " + array2d[0,0] + " Interes = %" + array2d[0,1]+"\n";
        }

        //Agregar Beneficio (Cuotas + Intereses)
        public void AgregarBeneficio(int cantCuotas, int interes)
        {
            //Esta línea me instancia la clase Beneficio
            //Luego a la tarjeta seleccionada desde el menú en el main le agrego el beneficio
            Beneficio benef = new Beneficio(cantCuotas, interes);
            beneficios.Add(benef);
            formaPago += 1;
        }

        //Listar Beneficios
        public void ListarBeneficios()
        {
            for (int i = 0; i < Beneficios.Count; i++)
            {
                Beneficio benef = Beneficios[i]; //benef es solo una Variable de tipo Beneficio
                Console.WriteLine("Cuotas " + benef.CantCuotas + " interes " + benef.Interes);
            }
        }
    }

}
