using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Byts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Fecha ()
        {
            
                DateTime Fecha = dataFecha.Value;
                int año = Fecha.Year;
                int mes = Fecha.Month;
                int dia = Fecha.Day;

                int tamAño, tamMes, tamDia;

                año -= 1900;

                string cadAño = Convert.ToString(año, 2);
                string cadMes = Convert.ToString(mes, 2);
                string cadDia = Convert.ToString(dia, 2);
                string FechaNumero = "";

                tamAño = cadAño.Length;
                tamMes = cadMes.Length;
                tamDia = cadDia.Length;

                int[] cont = new int[3];

                cont[0] = 7 - tamAño;
                cont[1] = 4 - tamMes;
                cont[2] = 5 - tamDia;

                int con = 0;
                string texto = "";
                string texto1 = "";
                string texto2 = "";
                //string letter = "";

                for (int c = tamAño; c < 7; c++)
                {
                    con++;
                    texto += "0";
                }

                for (int c = tamMes; c < 4; c++)
                {
                    con++;
                    texto1 += "0";
                }

                for (int c = tamDia; c < 5; c++)
                {
                    con++;
                    texto2 += "0";
                }

                cadAño = texto + "" + cadAño;
                cadMes = texto1 + "" + cadMes;
                cadDia = texto2 + "" + cadDia;
                FechaNumero = cadAño + "" + cadMes + "" + cadDia;

                int n = 0;
                string bin = "";


                for (int x = FechaNumero.Length - 1, y = 0; x >= 0; x--, y++)
                {
                    if (FechaNumero[x] == '0' || FechaNumero[x] == '1')
                    {
                        n += (int)(int.Parse(FechaNumero[x].ToString()) * Math.Pow(2, y));
                    }
                }
                txtFechaNum.Text = n.ToString();
                lblPrueba.Text = n + "---" + FechaNumero;
            
        }
        private void Sensores (int valor)
        {
            int contador = 0;
            string cadena1 = " ";
            string text = " ";
            char l; // Letra aux.
            cadena1 = Convert.ToString(valor, 2);//Datos a binario Guardados como string.
            string newCadena = cadena1;
            int tam = cadena1.Length;
            int con = 0;

            if (valor < 256)
            {
                for (int c = tam; c <= 7; c++)
                {
                    con++;
                    text += "0";
                }
                text = text + "" + newCadena;
                lblThree.Text = text;
                string cad2y3 = "";
                string cad4al6 = "";

                for (contador = 0; contador <= 7; contador++)
                {
                    l = text[contador];
                    if (contador == 2 || contador == 3)
                    {
                        cad2y3 += text[contador]; //Tanque
                    }
                    else if (contador >= 4 && contador < 7)
                    {
                        cad4al6 += text[contador];//Dirrecciones
                    }

                    if (contador == 0)//Posición
                    {
                        if (l == '1')
                        {
                            picBien.Image = Byts.Properties.Resources.Bien;
                        }
                        else if (l == '0')
                        {
                            picBien.Image = Byts.Properties.Resources.Mal;
                        }
                    }
                    else if (contador == 1)//Posición 6
                    {
                        if (l == '1')
                        {
                            picBien1.Image = Byts.Properties.Resources.Bien;
                        }
                        else if (l == '0')
                        {
                            picBien1.Image = Byts.Properties.Resources.Mal;
                        }
                    }
                }

                //Nivel Tanque
                if (cad2y3 == "00")
                {
                    //Vacio
                    picTanque.Image = Byts.Properties.Resources.Vacio;
                }
                else if (cad2y3 == "01")
                {
                    //Medio
                    picTanque.Image = Byts.Properties.Resources.Medio;
                }
                else if (cad2y3 == "10")
                {
                    //Lleno
                    picTanque.Image = Byts.Properties.Resources.Lleno;
                }
                else if (cad2y3 == "11")
                {
                    //Llenando
                    picTanque.Image = Byts.Properties.Resources.Llenando;
                }

                //Direcciones
                if (cad4al6 == "000")
                {
                    picDireccion.Image = Byts.Properties.Resources.norte;
                }
                else if (cad4al6 == "001")
                {
                    picDireccion.Image = Byts.Properties.Resources.noreste;
                }
                else if (cad4al6 == "010")
                {
                    picDireccion.Image = Byts.Properties.Resources.este;
                }
                else if (cad4al6 == "011")
                {
                    picDireccion.Image = Byts.Properties.Resources.sureste;
                }
                else if (cad4al6 == "100")
                {
                    picDireccion.Image = Byts.Properties.Resources.sur;
                }
                else if (cad4al6 == "101")
                {
                    picDireccion.Image = Byts.Properties.Resources.suroeste;
                }
                else if (cad4al6 == "110")
                {
                    picDireccion.Image = Byts.Properties.Resources.oeste;
                }
                else if (cad4al6 == "111")
                {
                    picDireccion.Image = Byts.Properties.Resources.noroeste;
                }
            }
            else
            {
                txtBin.Text = "Ingrese un numero menor a 256";
            }
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {

            int val = 0;
            val = Convert.ToInt32(txtValor.Text);//numero ingresado
            Sensores(val);

        }
        private void btnFecha_Click(object sender, EventArgs e)
        {
            Fecha();
        }
    }
}
