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
            cbFiltro.Items.Add("Nome");
            cbFiltro.Items.Add("Item");

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void cbFiltro_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            TabelasClass tabelasClass = new TabelasClass();
            List<string> items = tabelasClass.BuscarResultado(cbFiltro.Text);

            cbResultado.Items.Clear();

            foreach (string x in items)
            {
                if (!cbResultado.Items.Contains(x.ToString()) && x.ToString() != "")
                {
                    cbResultado.Items.Add(x.ToString());
                }
            }

            cbResultado.Enabled = true;
        }

        private void cbResultado_SelectedIndexChanged(object sender, EventArgs e)
        {
            BancoDeDadosClass bancoDeDadosClass = new BancoDeDadosClass();
            DataTable dataTable = bancoDeDadosClass.ObterTabelaDoFiltro(cbFiltro.Text, cbResultado.Text);

            dataGridView1.DataSource = dataTable;

            btnLimpar.Enabled = true;
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
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

            cbResultado.Items.Clear();
            cbResultado.Text = "";
            cbResultado.Enabled = false;

            cbFiltro.Text = "";
            btnLimpar.Enabled = false;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {

        }
    }
}
