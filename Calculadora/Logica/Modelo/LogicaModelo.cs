using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ModeloVistaControlador.Logica.Modelo
{
    internal class LogicaModelo
    {
        private List<string> operaciones;
        private Queue<string> memoria;
        private string num1, num2, total;

        public string Num1
        {
            get { return num1; }
            set { num1 = value; }
        }

        public string Num2
        {
            get { return num2; }
            set { num2 = value; }
        }

        public string Total
        {
            get { return total; }
            set { total = value; }
        }

        public LogicaModelo()
        {
            operaciones = new List<string>();
            Num1 = "";
            Num2 = "";
            Total = "";
            memoria = new Queue<string>();
        }

        public void escribirHistorial(string expresion, string total)
        {
            operaciones.Add($"{expresion} = {total}");
        }

        public void GuardarHistorial()
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "operaciones.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(ruta))
                {
                    foreach (var linea in operaciones)
                    {
                        writer.WriteLine(linea);
                    }
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("Error al guardar: " + e.Message);
            }
        }

        public string ImprimirHistorial()
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "operaciones.txt");
            StringBuilder contenido = new StringBuilder();

            try
            {
                using (StreamReader reader = new StreamReader(ruta))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        contenido.AppendLine(linea);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return "Error al leer archivo";
            }

            return contenido.ToString();
        }

        /*
        public bool ComprobarPrimo(double num)
        {
            int numInt = (int)num;
            if (numInt <= 1) return false;

            for (int i = 2; i <= Math.Sqrt(numInt); i++)
            {
                if (numInt % i == 0)
                    return false;
            }

            return true;
        }
        */

        public double SacarPromedio()
        {
            double suma = 0;
            int cantidad = memoria.Count;

            if (cantidad > 0)
            {
                foreach (var num in memoria)
                {
                    if (double.TryParse(num, out double valor))
                    {
                        suma += valor;
                    }
                }
            }

            Total = cantidad > 0 ? (suma / cantidad).ToString() : "0";
            return cantidad > 0 ? suma / cantidad : 0;
        }

        /*
        public string ConvertirABinario(double numeroDecimal)
        {
            int numero = (int)numeroDecimal;
            return Convert.ToString(numero, 2);
        }*/

        public double Suma()
        {
            double suma = 0;
            try
            {
                suma = double.Parse(num1) + double.Parse(num2);
                Total = suma.ToString();
                escribirHistorial($"{num1} + {num2}", Total);
            }
            catch (FormatException)
            {
                Total = "Error";
            }
            return suma;
        }

        public void Resta()
        {
            try
            {
                double resultado = double.Parse(num1) - double.Parse(num2);
                Total = resultado.ToString();
                escribirHistorial($"{num1} - {num2}", Total);
            }
            catch (FormatException)
            {
                Total = "Error";
            }
        }

        public void Multiplicacion()
        {
            try
            {
                double resultado = double.Parse(num1) * double.Parse(num2);
                Total = resultado.ToString();
                escribirHistorial($"{num1} * {num2}", Total);
            }
            catch (FormatException)
            {
                Total = "Error";
            }
        }

        public void Division()
        {
            try
            {
                
                if (double.Parse(num2) == 0)
                {
                    Total = "Error: División por 0";
                    return;
                }

                double resultado = double.Parse(num1) / double.Parse(num2);
                Total = resultado.ToString();
                escribirHistorial($"{num1} / {num2}", Total);
            }
            catch (FormatException)
            {
                Total = "Error";
            }
        }

        public void EsPrimo()
        {
            try
            {
                double numero = double.Parse(num1);
                if (double.Parse(num1) <= 1)
                {
                    Total = "No es primo";
                    return;
                }

                bool primo = true;
                for (int i = 2; i <= Math.Sqrt(numero); i++)
                {
                    if (numero % i == 0)
                    {
                        primo = false;
                        break;
                    }
                }

                Total = primo ? "Es primo" : "No es primo";
                escribirHistorial($"Primo {num1}", primo.ToString());
            }
            catch (FormatException)
            {
                Total = "Error";
            }
        }

        public void ConversionBinaria()
        {
            try
            {
                double numero = double.Parse(num1);
                int parteEntera = (int)numero;
                double parteDecimal = numero - parteEntera;

                string parteEnteraBinaria = Convert.ToString(parteEntera, 2);
                StringBuilder parteDecimalBinaria = new StringBuilder(".");

                while (parteDecimal > 0)
                {
                    parteDecimal *= 2;
                    int bit = (int)parteDecimal;
                    parteDecimalBinaria.Append(bit);
                    parteDecimal -= bit;

                    if (parteDecimalBinaria.Length > 10)
                        break;
                }

                Total = parteEnteraBinaria + parteDecimalBinaria.ToString();
                escribirHistorial($"Binario {num1}", Total);
            }
            catch (FormatException)
            {
                Total = "Error";
            }
        }

        public void GuardarMemoria()
        {
            if (memoria.Count == 10)
            {
                memoria.Dequeue();
            }
            memoria.Enqueue(num1);
            Console.WriteLine("Número guardado en memoria");
        }
    }
}

