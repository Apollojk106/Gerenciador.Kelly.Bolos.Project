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
        public TabelasPage(bool DarkMode)
        {
            InitializeComponent();
            rjToggleButton1.Checked = DarkMode;
        }

        string SelectCell;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtenha a célula que foi clicada
                DataGridViewCell clickedCell = dataGridView1.Rows[e.RowIndex].Cells["ID"];
                string cellValue = clickedCell.Value.ToString();

                // Faça algo com o valor da célula
                SelectCell = (cellValue);

                btnDeletar.Visible = true;
                btnDeletar.Enabled = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].ToString() == "")
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    SelectCell = (selectedRow.Cells["ID"].Value.ToString());

                }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Erro com a celula!");
            }
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
            btnDeletar.Visible = false;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Deseja deletar o pedido: {SelectCell}", "Confirmação", MessageBoxButtons.YesNo);

            // Verifique se o usuário clicou em OK
            if (result == DialogResult.Yes)
            {          
                BancoDeDadosClass banco = new BancoDeDadosClass();
                banco.DeletarPedido(SelectCell);

                //Recarregar Tabela e esconder Butão
                DataTable dataTable = banco.ObterTabelaDePedido();
                if (dataTable != null)
                {
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Erro ao carregar dados.");
                }
                btnDeletar.Visible = false;
            }
            
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            HomePage page = new HomePage(rjToggleButton1.Checked);
            page.Show();
            this.Hide();
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            AdicionarPage page = new AdicionarPage(rjToggleButton1.Checked);
            page.Show();
            this.Hide();
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
