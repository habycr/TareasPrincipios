using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StrategyPelea
{
    public partial class Form1 : Form
    {
        private Peleador j1, j2;
        private Random rand = new Random();
        private List<Golpe> comboJ1 = new();
        private List<Golpe> comboJ2 = new();

        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            j1 = new Peleador("Jugador 1", GenerarArtesAleatorias());
            j2 = new Peleador("Jugador 2", GenerarArtesAleatorias());

            cmbSeleccionJ1.DataSource = j1.Estrategias.Select(e => e.Nombre).ToList();
            ActualizarPanelesArtes(pnlArtesJ1, j1);
            ActualizarPanelesArtes(pnlArtesJ2, j2);

            ActualizarVidas();


            ActualizarImagenJ1();
            ActualizarImagenesJ2();

            cmbSeleccionJ1.SelectedIndexChanged += (s, e) => ActualizarImagenJ1();




        }

        private List<IEstrategia> GenerarArtesAleatorias()
        {
            var todas = new List<IEstrategia>
            {
                new Karate(), new Boxeo(), new Capoeira(), new KungFu(), new Judo(),
                new Aikido(), new Wushu(), new Sambo(), new Taekwondo(), new Sumo()
            };
            return todas.OrderBy(_ => rand.Next()).Take(3).ToList();
        }

        private void ActualizarPanelesArtes(FlowLayoutPanel panel, Peleador jugador)
        {
            panel.Controls.Clear();

            foreach (var estrategia in jugador.Estrategias)
            {
                var groupBox = new GroupBox
                {
                    Text = estrategia.Nombre,
                    Width = 150,
                    Height = 100
                };

                var listBox = new ListBox
                {
                    Dock = DockStyle.Fill,
                    Enabled = false
                };

                listBox.Items.AddRange(estrategia.ObtenerGolpes()
                    .Select(g => $"{g.Nombre} ({g.Poder})").ToArray());

                groupBox.Controls.Add(listBox);
                panel.Controls.Add(groupBox);
            }
        }

        private void btnReasignarJ1_Click(object sender, EventArgs e)
        {
            j1.ReasignarEstrategias(GenerarArtesAleatorias());
            cmbSeleccionJ1.DataSource = j1.Estrategias.Select(e => e.Nombre).ToList();
            ActualizarPanelesArtes(pnlArtesJ1, j1);

            ActualizarImagenJ1();

        }

        private void btnReasignarJ2_Click(object sender, EventArgs e)
        {
            j2.ReasignarEstrategias(GenerarArtesAleatorias());
            ActualizarPanelesArtes(pnlArtesJ2, j2);

            ActualizarImagenesJ2();
        }

        private void btnGenerarComboJ1_Click(object sender, EventArgs e)
        {
            int indice = cmbSeleccionJ1.SelectedIndex;
            var estrategia = j1.Estrategias[indice];
            var golpes = estrategia.ObtenerGolpes();
            int cantidad = rand.Next(3, 7);

            comboJ1 = Enumerable.Range(0, cantidad)
                                .Select(_ => golpes[rand.Next(golpes.Count)])
                                .ToList();
        }

        private void btnGenerarComboJ2_Click(object sender, EventArgs e)
        {
            var golpesDisponibles = j2.Estrategias.SelectMany(e => e.ObtenerGolpes()).ToList();
            int cantidad = rand.Next(3, 7);

            comboJ2 = Enumerable.Range(0, cantidad)
                                .Select(_ => golpesDisponibles[rand.Next(golpesDisponibles.Count)])
                                .ToList();
        }

        private void btnAtacarJ1_Click(object sender, EventArgs e)
        {
            if (comboJ1.Count == 0)
            {
                MessageBox.Show("Genera un combo para J1 antes de atacar.");
                return;
            }

            foreach (var golpe in comboJ1)
            {
                int danio = golpe.Poder + (golpe.DanaExtra ? 5 : 0);
                j2.RecibirDanio(danio);
                if (golpe.Cura) j1.Curar(10);

                j1.Bitacora.Add($"{j1.Nombre} usó {golpe.Nombre} causando {danio}" +
                                (golpe.Cura ? " [cura +10]" : "") +
                                (golpe.DanaExtra ? " [extra +5]" : ""));
            }

            MostrarBitacora(txtBitacoraJ1, j1.Bitacora);
            ActualizarVidas();
            RevisarFinDelJuego();
            comboJ1.Clear();
        }

        private void btnAtacarJ2_Click(object sender, EventArgs e)
        {
            if (comboJ2.Count == 0)
            {
                MessageBox.Show("Genera un combo para J2 antes de atacar.");
                return;
            }

            foreach (var golpe in comboJ2)
            {
                int danio = golpe.Poder + (golpe.DanaExtra ? 5 : 0);
                j1.RecibirDanio(danio);
                if (golpe.Cura) j2.Curar(10);

                j2.Bitacora.Add($"{j2.Nombre} usó {golpe.Nombre} causando {danio}" +
                                (golpe.Cura ? " [cura +10]" : "") +
                                (golpe.DanaExtra ? " [extra +5]" : ""));
            }

            MostrarBitacora(txtBitacoraJ2, j2.Bitacora);
            ActualizarVidas();
            RevisarFinDelJuego();
            comboJ2.Clear();
        }

        private void MostrarBitacora(TextBox destino, List<string> bitacora)
        {
            destino.Clear();
            foreach (var linea in bitacora)
                destino.AppendText(linea + Environment.NewLine);
        }

        private void ActualizarVidas()
        {
            lblVidaJ1.Text = $"Vida J1: {j1.Vida}";
            lblVidaJ2.Text = $"Vida J2: {j2.Vida}";
        }

        private void RevisarFinDelJuego()
        {
            if (j1.Vida <= 0)
                MessageBox.Show("¡Jugador 2 gana!");
            else if (j2.Vida <= 0)
                MessageBox.Show("¡Jugador 1 gana!");
        }

        private void pnlArtesJ2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBitacoraJ1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlArtesJ1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarImagenJ1()
        {
            if (cmbSeleccionJ1.SelectedItem is string nombreArte)
            {
                string ruta = Path.Combine(Application.StartupPath, "Imagenes", $"{nombreArte}.jpg");

                if (File.Exists(ruta))
                    picArteJ1.Image = Image.FromFile(ruta);
                else
                    picArteJ1.Image = null;
            }
        }


        private void ActualizarImagenesJ2()
        {
            var imagenes = new[] { picArteJ2_1, picArteJ2_2, picArteJ2_3 };

            for (int i = 0; i < j2.Estrategias.Count && i < 3; i++)
            {
                string nombre = j2.Estrategias[i].Nombre;
                string ruta = Path.Combine(Application.StartupPath, "Imagenes", $"{nombre}.jpg");

                if (File.Exists(ruta))
                    imagenes[i].Image = Image.FromFile(ruta);
                else
                    imagenes[i].Image = null;
            }
        }


        private void CargarImagen(PictureBox pic, string nombreArte)
        {
            try
            {
                string ruta = $"Imagenes/{nombreArte}.png";
                if (System.IO.File.Exists(ruta))
                    pic.Image = Image.FromFile(ruta);
                else
                    pic.Image = null;
            }
            catch
            {
                pic.Image = null;
            }
        }

        private void picArteJ2_1_Click(object sender, EventArgs e)
        {

        }
    }
}
