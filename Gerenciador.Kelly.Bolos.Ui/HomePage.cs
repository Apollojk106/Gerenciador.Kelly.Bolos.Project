using Gerenciador.Kelly.Bolos.Bo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador.Kelly.Bolos.Ui
{
    public partial class HomePage : Form
    {
        public HomePage(bool Darkmode)
        {
            InitializeComponent();
            rjToggleButton1.Checked = Darkmode;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Form1 page = new Form1();
            page.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            TabelasPage page = new TabelasPage(rjToggleButton1.Checked);
            page.Show();
            this.Hide();
 
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarPage page = new AdicionarPage(rjToggleButton1.Checked);
            page.Show();
            this.Hide();
            
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            BancoDeDadosClass banco = new BancoDeDadosClass();
            float[] valores = banco.RetornarFaturamento();

            lblFaturamento.Text = $"R$ {valores[0]}"; //Faturamento
            lblLucro.Text = $"R$ {valores[2]}"; //Lucro 
            lblCusto.Text = $"R$ {valores[1]}"; //Gasto

            string[] ItemMaisRepetidos = banco.ItemMaisRepetidos();



            int count = 1;
            foreach (string texto in ItemMaisRepetidos)
            {
                lbLista.Items.Add($"{count}º-{texto}");
                count++;
            }

            chartLine.Series["Lucro"].Points.AddXY("Lucro", valores[2]);
            chartLine.Series["Lucro"].Points.AddXY("Gasto", valores[1]);
            chartLine.Series["Lucro"].Points.AddXY("Fatoramento", valores[0]);
            /*
            Dictionary<string, float> LucroDoMes = banco.LucroDoMes();
            foreach(KeyValuePair<string, float> x in LucroDoMes) {
                chartLine.Series["Lucro"].Points.AddXY(x.Key.ToString(),x.Value);
            }
            */
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void rjToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            Color Colorchoice = Color.White;

            if (rjToggleButton1.Checked == false)
            {
                this.BackColor = Color.FromArgb(242, 228, 216);
                Colorchoice = Color.Black;

            }
            else 
            {
                this.BackColor = Color.FromArgb(51, 51, 51);
            }

            foreach (Control control in this.Controls)
            {
                if (control is Label || control is Button || control is CheckBox) // Check for Label, Button, and CheckBox
                {
                    if (control is Label label) // Cast to Label if it's a Label
                    {
                        label.ForeColor = Colorchoice; // Set font color for Label
                    }
                    else if (control is Button button) // Cast to Button if it's a Button
                    {
                        button.ForeColor = Colorchoice;// Set font color for Button
                    }
                    else if (control is CheckBox checkbox) // Cast to CheckBox if it's a CheckBox
                    {
                        checkbox.ForeColor = Colorchoice;// Set font color for CheckBox
                    }
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (rjToggleButton1.Checked == true) { rjToggleButton1.Checked = false; }
            else { rjToggleButton1.Checked = true; }
        }
    }
}
