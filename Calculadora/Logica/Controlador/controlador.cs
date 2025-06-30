using ModeloVistaControlador.Logica.Modelo;
using ModeloVistaControlador.Vista;
using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace ModeloVistaControlador.Logica.Controlador
{
    internal class controlador
    {
        private Interfaz vista;
        private LogicaModelo modelo;

        public controlador(Interfaz vista, LogicaModelo modelo)
        {
            this.vista = vista;
            this.modelo = modelo;

            // Suponiendo que Vista tiene un método para conectar eventos
            this.vista.AgregarListener(BotonPresionado);
            this.vista.TeclaPresionada += Accion;
        }

        // Método auxiliar para extraer operandos y operador de una expresión como "12 + 5"
        private string[] ParseExpresion(string expresion)
        {
            expresion = Regex.Replace(expresion, @"\s+", "");

            string operador = "";
            int indice = -1;

            for (int i = 0; i < expresion.Length; i++)
            {
                char ch = expresion[i];
                if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                {
                    operador = ch.ToString();
                    indice = i;
                    break;
                }
            }

            if (operador == "") return null;

            string num1 = expresion.Substring(0, indice);
            string num2 = expresion.Substring(indice + 1);

            return new string[] { num1, operador, num2 };
        }

        // Evento que maneja todos los botones
        public void BotonPresionado(object sender, EventArgs e)
        {
            if (sender is Button boton)
            {
                string comando = boton.Text;
                string expresion = vista.TextoActual;

                if (comando == "M+")
                {
                    modelo.Num1 = vista.TextoActual;
                    modelo.GuardarMemoria();
                }
                else if (Regex.IsMatch(comando, @"^[0-9]$") || comando == ".")
                {
                    vista.TextoActual += comando;
                   
                }
                else if (Regex.IsMatch(comando, @"[\+\-\*/%]"))
                {
                    vista.TextoActual += " " + comando + " ";
                }
                else if (comando == "C")
                {
                    vista.LimpiarPantalla();
                }
                else if (comando == "=")
                {
                    string[] partes = ParseExpresion(expresion);
                    if (partes != null)
                    {
                        string valorNum1 = partes[0];
                        string operador = partes[1];
                        string valorNum2 = partes[2];

                        modelo.Num1 = valorNum1;
                        modelo.Num2 = valorNum2;

                        switch (operador)
                        {
                            case "+":
                                modelo.Suma();
                                break;
                            case "-":
                                modelo.Resta();
                                break;
                            case "*":
                                modelo.Multiplicacion();
                                break;
                            case "/":
                                modelo.Division();
                                break;
                            default:
                                vista.TextoActual = "Error: Operador no reconocido";
                                return;
                        }

                        vista.TextoActual = modelo.Total;
                        Debug.WriteLine($"Resultado: {modelo.Total}");
                    }
                }
                else if (comando == "Primo")
                {
                    modelo.Num1 = vista.TextoActual;
                    modelo.EsPrimo();
                    vista.TextoActual = modelo.Total;
                }
                else if (comando == "Binario")
                {
                    modelo.Num1 = vista.TextoActual;
                    modelo.ConversionBinaria();
                    vista.TextoActual = modelo.Total;
                }
                else if (comando == "PROM")
                {
                    modelo.SacarPromedio();
                    vista.TextoActual = modelo.Total;
                }
                else if (comando == "Historial")
                {
                    modelo.GuardarHistorial();
                    string contenido = modelo.ImprimirHistorial();
                    MessageBox.Show(contenido, "Historial de cálculos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        public void Accion(object sender, KeyEventArgs e)
        {
            Debug.WriteLine($"Tecla presionada: {e.KeyCode}");

            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                vista.TextoActual += (e.KeyCode - Keys.D0).ToString();
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                vista.TextoActual += (e.KeyCode - Keys.NumPad0).ToString();
            else if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
                vista.TextoActual += ".";
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                vista.TextoActual += " + ";
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
                vista.TextoActual += " - ";
            else if (e.KeyCode == Keys.Oemplus && e.KeyCode == Keys.Multiply)
                vista.TextoActual += " * ";
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion)
                vista.TextoActual += " / ";
            else if (e.KeyCode == Keys.Enter)
            {
                string expresion = vista.TextoActual;
                string[] partes = ParseExpresion(expresion);
                if (partes != null)
                {
                    string valorNum1 = partes[0];
                    string operador = partes[1];
                    string valorNum2 = partes[2];

                    modelo.Num1 = valorNum1;
                    modelo.Num2 = valorNum2;

                    switch (operador)
                    {
                        case "+":
                            modelo.Suma();
                            break;
                        case "-":
                            modelo.Resta();
                            break;
                        case "*":
                            modelo.Multiplicacion();
                            break;
                        case "/":
                            modelo.Division();
                            break;
                        default:
                            vista.TextoActual = "Error: Operador no reconocido";
                            return;
                    }

                    vista.TextoActual = modelo.Total;
                    Debug.WriteLine($"Resultado: {modelo.Total}");
                }
            }
            else if (e.KeyCode == Keys.Escape)
                vista.LimpiarPantalla();
            else if (e.KeyCode == Keys.Back)
            {
                string actual = vista.TextoActual;
                if (!string.IsNullOrEmpty(actual))
                {
                    vista.TextoActual = actual.Substring(0, actual.Length - 1);
                }
            }
            else if (e.KeyCode == Keys.C)
                vista.LimpiarPantalla();
            else if (e.KeyCode == Keys.P)
                BotonPresionado(vista.button2, EventArgs.Empty); // "Primo"
            else if (e.KeyCode == Keys.B)
                BotonPresionado(vista.button23, EventArgs.Empty); // "Binario"
            else if (e.KeyCode == Keys.M)
                BotonPresionado(vista.button20, EventArgs.Empty); // "M+"
            else if (e.KeyCode == Keys.H)
                BotonPresionado(vista.button15, EventArgs.Empty); // "Historial"
            else if (e.KeyCode == Keys.A)
                BotonPresionado(vista.button21, EventArgs.Empty); // "PROM"

            else
                return; // Ignorar otras teclas
        }
    }
}

