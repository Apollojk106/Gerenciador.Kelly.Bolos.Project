using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
            Kg = kg.Replace(',', '.'); 
            ValorCobrado = valorCobrado.Replace(',','.');
            ValorGasto = valorGasto.Replace(',', '.'); 

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
                Values += $",'{ FormatarData(Data.Replace('-','/'))}'";
                Columns += $", Data";
                

                      BancoDeDadosClass Banco = new BancoDeDadosClass();
                return    Banco.AdicionarPedido(Nome, Item, Kg, ValorGasto, ValorCobrado, Columns, Values);
            }
        
        }

        public string FormatarData(string data) 
        {
            String[] temp = data.Split('/');

            String DataFinal = $"{temp[2]}-{temp[1]}-{temp[0]}";

            return DataFinal;
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
                if (!char.IsDigit(caractere) && caractere != '.' && caractere != ',')
                {
                    return false;
                }
            }
            return true;
        }

        public void GerarTXT()
                        {
            string caminho = Caminho() + "Pedidos";

            BancoDeDadosClass banco = new BancoDeDadosClass();
            string ID = banco.retornarID(Nome);
            string data = banco.retornarData(ID);

            string[] linhas = ($"--------------------------/" +
                $"Aqui temos o Pedido {ID}/" +
                $"Da Pessoa: {Nome} pedido em {data}/" +
                $"Que deseja: {Item} de {Kg}Kg/" +
                $"Custando: R${ValorCobrado}/" +
                $"--------------------------/").Split('/');

            if (!Directory.Exists(caminho))
            {
                // Cria a pasta se não existir
                Directory.CreateDirectory(caminho);
                Console.WriteLine("Pasta criada com sucesso: {0}", caminho);
            }


            string caminhoArquivo = caminho + $"\\Pedido-{ID}.txt";
            if (File.Exists(caminhoArquivo))
            {
                File.Delete(caminhoArquivo);
                Console.WriteLine("Arquivo criado");
            }

           

            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                foreach (string linha in linhas)
                {
                    writer.WriteLine(linha);
                }

            }
        }

        public string Caminho()
        {
            string diretorioExecutavel = AppDomain.CurrentDomain.BaseDirectory;

            string caminhoSolucao = Path.GetFullPath(Path.Combine(diretorioExecutavel, @"..\..\"));

            return caminhoSolucao;

        }
    }
}
