using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace Gerenciador.Kelly.Bolos.Bo
{
    public class BancoDeDadosClass

    {
        const string conexao = "server=localhost;uid=root;pwd=jk106;database=KellyBolos";

        //HomePage

        public float[] RetornarFaturamento() 
        {
            float[] Valores = new float[3];

            Valores[1] = RetornarValorGasto();  //Gasto
            Valores[0] = RetorValorCobrado();  //Faturamento
            Valores[2] = Valores[0] - Valores[1];   //Lucro

            return Valores;
        }

        private float RetornarValorGasto() 
        {
            float resultado = 0;

            string query = $"SELECT ValorGasto FROM Pedidos";
            
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["ValorGasto"] != DBNull.Value)
                    {
                        resultado += float.Parse(reader[$"ValorGasto"].ToString());
                    }
                }
            }

            return resultado;
        }

        private float RetorValorCobrado() 
        {
            float resultado = 0;

            string query = $"SELECT ValorCobrado FROM Pedidos";

            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["ValorCobrado"] != DBNull.Value)
                    {
                        resultado += float.Parse(reader[$"ValorCobrado"].ToString());
                    }
                }
            }

            return resultado;
        }

        public string[] ItemMaisRepetidos() 
        {
            string[] resultados = new string[3];

            List<String> Items = ObterListaDeItem();

            List<String> MaisRepetidos = ObterMaisRepetidos(Items);

            int index = 0;
            foreach (string Item in MaisRepetidos) 
            {
                resultados[index] = Item;
                index++;
                if (index == 3) { break; }
            }

            return resultados;
        }

        private List<string> ObterMaisRepetidos(List<string> lista) //Ninguem sabe como esta a cabeça do palhaço
        {
            if (lista == null || lista.Count == 0)
            {
                return new List<string>();
            }

            // Dicionário para armazenar a contagem de cada item
            Dictionary<string, int> contagemItens = new Dictionary<string, int>();

            foreach (var item in lista)
            {
                if (contagemItens.ContainsKey(item))
                {
                    contagemItens[item]++;
                }
                else
                {
                    contagemItens[item] = 1;
                }
            }

            // Retornar os itens com a ordem decrescente
            var OrdemDecrescente = contagemItens.OrderByDescending(pair => pair.Value);

            //Transformar em uma lista com somente string
            return OrdemDecrescente.Select(pair => $"{pair.Key}").ToList();

        }

        public List<string> ObterListaDeItem()
        {
            string query = $"SELECT Item FROM Pedidos";

            List<string> items = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["Item"].ToString() != "")
                    {
                        items.Add(reader["Item"].ToString());
                    }
                }
            }

            return items;
        }

        public Dictionary<string, float> LucroDoMes() 
        {
            Dictionary<string, float> Resultado = new Dictionary<string, float>();

            string[] mes = ListadosUltimosMes();

            //float[] LucroBruto = LucroDoMes();

            return Resultado;
        }

        private float[] LucroDoMes(string[] Mes) 
        {
            float[] resultado = new float[5];
            float faturamentototal = 0; 
            float gastototal = 0;

            foreach (var data in Mes)
            {
                string query = $"SELECT ValorGasto,ValorCobrado FROM Pedidos ";

                using (MySqlConnection connection = new MySqlConnection(conexao))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["ValorGasto"] != DBNull.Value)
                        {
                            gastototal += float.Parse(reader["ValorGasto"].ToString());
                        }
                        if (reader["ValorCobrado"] != DBNull.Value)
                        {
                            faturamentototal += float.Parse(reader["ValorCobrado"].ToString());
                        }
                    }

                
                }
            }


            return resultado;
        }

        private string[] ListadosUltimosMes() 
        {
            DateTime dataAtual = DateTime.Today;
            string[] resultado = new string[5];

            for(int x = 0; x < 5; x++)
            {
                float YearTemp = dataAtual.Year;
                float Mounthtemp = dataAtual.Month - x;
                if (Mounthtemp <= 0) 
                {
                    Mounthtemp = Mounthtemp + 12;
                    YearTemp = YearTemp - 1;
                }

                resultado[x] = $"{YearTemp}-{Mounthtemp}";
            }

            return resultado; 
        }

        //TabelasPage

        public void DeletarPedido(string ID)
        {
            using (var Conecao = new MySqlConnection(conexao))
            {
                Conecao.Open();

                string query = $"delete from Pedidos where ID = '{ID}';";

                using (var cmd = new MySqlCommand(query, Conecao))
                {
                    cmd.ExecuteNonQuery();
                }

                Conecao.Close();
            }
        }

        public DataTable ObterTabelaDePedido() 
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conexao))
                {
                    connection.Open();
                    string query = "select Nome,Item,Data,ValorGasto,ValorCobrado,ID from pedidos;"; 

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return dataTable;
        }

        public List<string> ObterFiltros(string Column) 
        {
            string query = $"SELECT {Column} FROM Pedidos";

            List<string> items = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!items.Contains(reader[$"{Column}"].ToString()) && reader[$"{Column}"].ToString() != "") {
                        items.Add(reader[$"{Column}"].ToString());
                    }
                }
            }

            return items;     
        }

        public DataTable ObterTabelaDoFiltro(string column, string resultado) 
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conexao))
                {
                    connection.Open();
                    string query = $"select Nome,Item,Data,ValorGasto,ValorCobrado,ID from pedidos where {column} like '{resultado}';"; 

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return dataTable;
        }

        //loginPage
        public bool LogarUsuario(string Email, string Senha)             
        {
            try
            {
                using (var Conecao = new MySqlConnection(conexao))
                {
                    Conecao.Open();

                    string SaltKey = LerSaltKey(Email);

                    if (SaltKey == "Nenhum Salt.") { return false; }

                    string SenhaHash = GerarSenhaComHash(Senha, SaltKey);

                    string query = $"select * from usuario where Email = '{Email}' and Senha = '{SenhaHash}';";

                    using (var cmd = new MySqlCommand(query, Conecao))
                    {

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool VerificarUsuario(string Email)
        {
            try
            {
                using (var conexaoConnection = new MySqlConnection(conexao))
                {

                    conexaoConnection.Open();

                    string query = $"SELECT * FROM usuario WHERE Email = '{Email}'";

                    using (var command = new MySqlCommand(query, conexaoConnection))
                    {

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }


        }

        //AdicionarPage
        public string AdicionarPedido(string Nome, string Item, string Kg, string ValorGasto, string ValorCobrado, string Columns, string Values) 
        {
            try
            {
                using (var Conecao = new MySqlConnection(conexao))
                {
                    Conecao.Open();
             
                    string query = $"INSERT INTO Pedidos(Nome, Item, Kg, ValorGasto, ValorCobrado {Columns}) VALUES('{Nome}','{Item}','{Kg}','{ValorGasto}','{ValorCobrado}'{Values});";

                    using (var cmd = new MySqlCommand(query, Conecao))
                    {                                          
                        cmd.ExecuteNonQuery();
                    }

                    Conecao.Close();
                    return "Cadastro Realizado!";
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        //criptografia

        public string LerSaltKey(string Email)
        {
            string query = $"SELECT SaltKey FROM Usuario WHERE Email = @Email;";

            try
            {
                using (MySqlConnection Conexao = new MySqlConnection(conexao))
                {

                    Conexao.Open();
                    string salt = "Nenhum Salt.";


                    using (MySqlCommand comando = new MySqlCommand(query, Conexao))
                    {

                        comando.Parameters.AddWithValue("@Email", Email);

                        using (MySqlDataReader leitor = comando.ExecuteReader())
                        {

                            if (leitor.HasRows)
                            {

                                while (leitor.Read())
                                {
                                    salt = leitor.GetString(0);
                                }

                                return salt;
                            }
                            else
                            {
                                return salt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"{ex}";
            }
        }

        public string GerarSenhaComHash(string Senha, string SaltKey)
        {

            string senhasalt = Senha + "." + SaltKey;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(senhasalt);

                byte[] hashBytes = sha256.ComputeHash(bytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

       


    }
}
