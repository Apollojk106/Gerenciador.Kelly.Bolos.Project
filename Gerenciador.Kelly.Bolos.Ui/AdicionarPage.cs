﻿using Gerenciador.Kelly.Bolos.Bo;
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
        public AdicionarPage(bool DarkMode)
        {
            InitializeComponent();
            rjToggleButton1.Checked = DarkMode;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Adicionar
            Adicionar();

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
                      AdiocionarClass adiocionar = new AdiocionarClass(
                txtNome.Text, txtItem.Text, txtKg.Text, txtValorGasto.Text, txtValorCobrado.Text);

            //Adicionar e gerar Boleto
            if (Adicionar())
            {
                adiocionar.GerarTXT();
                MessageBox.Show("Arquivo Criado!");
            }

        }

        private void cbkData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkData.Checked) { txtData.Enabled = true; }
            if (!cbkData.Checked) { txtData.Enabled = false; }
        }

        private bool Adicionar() 
        {
            string Values = "";
            string Columns = "";
            if (ckbEndereço.Checked) { Values += $",'{txtEndereço.Text}'"; Columns += ",Endereco"; }
            if (ckbDescrição.Checked) { Values += $",'{txtDescrição.Text}'"; Columns += ",Descricao"; }


            AdiocionarClass adiocionar = new AdiocionarClass(
                txtNome.Text, txtItem.Text, txtKg.Text, txtValorGasto.Text, txtValorCobrado.Text);
            string temp = adiocionar.Adicionar(Columns, Values, txtData.Text);

            MessageBox.Show(temp);

            if (temp == "Cadastro Realizado!")
            {
                LimparTXT();
                return true;
            }
            else { return false; }

        }

        private void LimparTXT() 
        {
            txtData.Text
                = txtDescrição.Text 
                = txtEndereço.Text 
                = txtItem.Text 
                = txtKg.Text 
                = txtValorCobrado.Text 
                = txtValorGasto.Text 
                = txtNome.Text 
                = null;
        }

        private void AdicionarPage_Load(object sender, EventArgs e)
        {
            BancoDeDadosClass banco = new BancoDeDadosClass();
            List<string> items = banco.ObterFiltros("Item");

            foreach (string item in items) 
            {
                txtItem.Items.Add(item);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

        }

        private void btnTables_Click_1(object sender, EventArgs e)
        {
            TabelasPage page = new TabelasPage(rjToggleButton1.Checked);
            page.Show();
            this.Hide();
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            HomePage page = new HomePage(rjToggleButton1.Checked);
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
                if (control is Label || control is CheckBox) // Check for Label, Button, and CheckBox
                {
                    if (control is Label label) // Cast to Label if it's a Label
                    {
                        label.ForeColor = Colorchoice; // Set font color for Label
                    }                  
                    else if (control is CheckBox checkbox) // Cast to CheckBox if it's a CheckBox
                    {
                        checkbox.ForeColor = Colorchoice;// Set font color for CheckBox
                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimparTXT();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (rjToggleButton1.Checked == true) { rjToggleButton1.Checked = false; }
            else { rjToggleButton1.Checked = true; }
        }
    }
}
