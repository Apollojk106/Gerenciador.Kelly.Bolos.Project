using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerenciador.Kelly.Bolos.Bo;

namespace Gerenciador.Kelly.Bolos.Bo
{
    public class TabelasClass
    {
        private string filtro { get; set; }

        private string resultados { get; set; }

        public TabelasClass()
        {

        }

        public List<string> BuscarResultado(string filtro)
        {
            BancoDeDadosClass bancoDeDadosClass = new BancoDeDadosClass();

            List<string> filtros = bancoDeDadosClass.ObterFiltros(filtro);

            return filtros;
        }
    }
}
