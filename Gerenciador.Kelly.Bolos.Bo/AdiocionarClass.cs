﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Kelly.Bolos.Bo
{
    public class AdiocionarClass
    {
        public string Nome { get; set; }

        public string Item { get; set; }

        public string Kg { get; set; }

        public string ValorGasto { get; set; }

        public string ValorCobrado { get; set; }


        public AdiocionarClass(string nome, string item, string kg, string valorGasto, string valorCobrado)
        {
            Nome = nome;
            Item = item;
            Kg = kg;
            ValorCobrado = valorCobrado;
            ValorGasto = valorGasto;

        }

        public string Adicionar(string Columns, string Values, string Data) 
        {
            if (Data == "")
            {
                DateTime dataAtual = DateTime.Today;
                Data = dataAtual.ToString("dd/MM/yyyy");
            }

            if (StringNulo(Nome) ||
                StringNulo(Item) ||
                StringNulo(Kg) ||
                StringNulo(ValorCobrado) ||
                StringNulo(ValorGasto))
            {
                return "Campos Vazios";

            }
            else if (!ContemApenasNumeros(Kg))
            {
                return "Kg contem letras";
            }
            else if (!ContemApenasNumeros(ValorGasto))
            {
                return "ValorGasto contem letras";
            }
            else if (!ContemApenasNumeros(ValorCobrado))
            {
                return "ValorCobrado contem letras";
            }
            
            else if (!VerificarData(Data))
            {
                return "Data Incorreta";
            }
            else
            {
                return "Adicionado com sucesso!";

                BancoDeDadosClass Banco = new BancoDeDadosClass();
                Banco.AdicionarPedido(Nome, Item, Kg, ValorGasto, ValorCobrado, Columns, Values);
            }
        
        }

        private bool VerificarData(string dataStr, string formato = "dd/MM/yyyy") 
        {
            DateTime data;
            // Tenta converter a string para um objeto DateTime
            bool sucesso = DateTime.TryParseExact(dataStr, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out data);
            return sucesso;
        }

        private bool StringNulo(string t)
        {
            if (t == null || t == "" || t == " ")
            {
                return true;
            }
            else { return false; }
        }

        public bool ContemApenasNumeros(string texto)
        {
            foreach (char caractere in texto)
            {
                if (!char.IsDigit(caractere))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
