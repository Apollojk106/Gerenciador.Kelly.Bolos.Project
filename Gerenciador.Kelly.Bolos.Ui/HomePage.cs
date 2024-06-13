using Gerenciador.Kelly.Bolos.Bo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador.Kelly.Bolos.Ui
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
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
            TabelasPage page = new TabelasPage();
            page.Show();
            this.Hide();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarPage page = new AdicionarPage();
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

        }
    }
}
