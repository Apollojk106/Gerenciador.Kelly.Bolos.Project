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
        const string conexao = "server=localhost;uid=root;pwd=jk106;database=kellybolos";

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

        public DataTable ObterTabelaDePedido() 
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conexao))
                {
                    connection.Open();
                    string query = "select Nome, Item, Data from pedidos;"; // Substitua pelo nome da sua tabela

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
