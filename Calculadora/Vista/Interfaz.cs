using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloVistaControlador.Vista
{
    public partial class Interfaz : Form
    {
        public event EventHandler BotonPresionado;
        public event KeyEventHandler TeclaPresionada;

        public Interfaz()
        {
            InitializeComponent();
            button22.TabStop = false;
            button22.CausesValidation = false;
            this.KeyPreview = true; // Permite que el formulario capture eventos de teclado
            this.KeyDown += (s, e) => 
            {
                if(e.KeyCode == Keys.Enter)
                {
                    TeclaPresionada?.Invoke(this, e);
                    e.Handled = true; // Evita que el evento se propague
                    e.SuppressKeyPress = true; // Evita el "ding" del sistema al presionar Enter
                }

                TeclaPresionada?.Invoke(this, e);
            };
            
        }

        public void AgregarListener(EventHandler listener)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Click += listener;
                }
            }
        }


        public string TextoActual
        {
            get => textBox1.Text;
            set => textBox1.Text = value;

        }

        public void LimpiarPantalla()
        {
            textBox1.Clear();
        }
        







    }
}
