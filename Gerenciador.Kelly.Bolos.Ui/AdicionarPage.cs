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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gerenciador.Kelly.Bolos.Ui
{
    public partial class AdicionarPage : Form
    {
        public AdicionarPage()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Hide();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            TabelasPage page = new TabelasPage();
            page.Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Form1 page = new Form1();
            page.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Adicionar

            string Values = "";
            string Columns = "";
            if (ckbEndereço.Checked) { Values += $",'{txtEndereço.Text}'"; Columns = ",Endereço"; }
            if (ckbDescrição.Checked) { Values += $",'{txtDescrição.Text}'"; Columns = ",Descrição"; }
            if (cbkData.Checked) { Values += $",'{txtData.Text}'"; Columns = ",Data"; }
            

            AdiocionarClass adiocionar = new AdiocionarClass(
                txtNome.Text, txtItem.Text, txtKg.Text, txtValorGasto.Text, txtValorCobrado.Text);
            string temp = adiocionar.Adicionar(Columns, Values, txtData.Text);

            MessageBox.Show(temp);

        }

        private void ckbEndereço_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEndereço.Checked) { txtEndereço.Enabled = true; }
            if (!ckbEndereço.Checked) { txtEndereço.Enabled = false; }
        }

        private void ckbDescrição_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDescrição.Checked) { txtDescrição.Enabled = true; }
            if (!ckbDescrição.Checked) { txtDescrição.Enabled = false; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Adicionar e gerar Boleto

            
        }

        private void cbkData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkData.Checked) { txtData.Enabled = true; }
            if (!cbkData.Checked) { txtData.Enabled = false; }
        }
    }
}
