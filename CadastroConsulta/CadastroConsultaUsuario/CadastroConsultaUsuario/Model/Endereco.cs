using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CadastroConsultaUsuario
{
    [Serializable]
    public class Endereco
    {
        public string cep { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public String complemento { get; set; }
        public String cidade { get; set; }
        public String estado { get; set; }


    }


    

}
