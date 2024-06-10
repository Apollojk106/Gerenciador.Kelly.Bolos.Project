using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Kelly.Bolos.Bo
{
    public class LoginClass
    {
        private string Email { get; set; }

        private string Senha { get; set; }

        public LoginClass(string email, string senha) {
            SetEmail(email);
            SetSenha(senha);
        }

        private void SetEmail(string t) 
        {   
            Email = t;
        }

        private void SetSenha(string t) 
        {
            Senha = t;
        }

        public string Logar()
        {
            BancoDeDadosClass BancoDeDadosClass = new BancoDeDadosClass();

            if (StringNulo(Email))
            {
                return "Campo usuario vazio!";
            }
            else if (StringNulo(Senha))
            {
                return "Campo senha vazio!";
            }
            else if (!BancoDeDadosClass.VerificarUsuario(Email))
            {
                return "Usuario Inexistente!";
            }
            else
            {
                if (BancoDeDadosClass.LogarUsuario(Email, Senha))
                {
                    return "Logado com sucesso!";
                }
                else
                {
                    return "Usuario ou Senha Incorretos!";
                }
            }
        }

        private bool StringNulo(string t)
        {
            if (t == null || t == "" || t == " ")
            {
                return true;
            }
            else { return false; }
        }
    }
}
