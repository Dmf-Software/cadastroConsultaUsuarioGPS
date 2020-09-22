using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CadastroConsultaUsuario
{
    [Serializable]
    public class Data
    {
        public String nome;
        public String sobrenome;
        public String cpf;
        public DateTime data_nascimento;

     
    }
}
