using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerenciador.Kelly.Bolos.Bo;

namespace Gerenciador.Kelly.Bolos.Ui
{
    public partial class TabelasPage : Form
    {
        public TabelasPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HomePage page = new HomePage();
            page.Show();
            this.Hide();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarPage page = new AdicionarPage();
            page.Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Form1 page = new Form1();
            page.Show();
            this.Hide();
        }

        private void TabelasPage_Load(object sender, EventArgs e)
        {
            BancoDeDadosClass bancoDeDados = new BancoDeDadosClass();
            DataTable dataTable = bancoDeDados.ObterTabelaDePedido();
            if (dataTable != null)
            {
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Erro ao carregar dados.");
            }
        }
    }
}
