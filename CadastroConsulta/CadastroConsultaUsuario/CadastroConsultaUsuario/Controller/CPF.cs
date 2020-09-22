using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroConsultaUsuario.Controller
{
    class CPF
    {
        public static int _dv1 = -1, _dv2 = -1;
      
        public int dv1 = -1, dv2 = -1;
        public bool Validate(String cpfString)
        {
            int[] cpfIntArray = new int[11];
            if (cpfString.Length > 11)
            {
                return false;
            }
            for(int cont = 0; cont < cpfString.Length; cont++)
            {
                cpfIntArray[cont] = int.Parse(cpfString.Substring(cont, 1));
            }

            int soma = 0;
            int index = 10;
            for(int cont = 0; index>=2; cont++)
            {
                soma += cpfIntArray[cont]*index;
                index--;
            }

            if ((soma % 11) > 2)
            {
                dv1 = 11 - (soma % 11);
            }
            else
            {
                dv1 = 0;
            }
            //Assume-se que o dv1 é igual ao da fórmula Aplicada
            //cpfIntArray[9] = dv1;
            //Calcula-se o Dv2
            soma = 0;
            index = 11;

            for(int cont = 0; index >= 2; cont++)
            {
                soma += cpfIntArray[cont] * index;
                index--;
            }

            if ((soma % 11) > 2)
            {
                dv2 = 11 - (soma % 11);
            }
            else
            {
                dv2 = 0;
            }
            _dv1 = dv1;
            _dv2 = dv2;
          //Verifica se o CPF é válido
          if(dv1==cpfIntArray[9] && dv2 == cpfIntArray[10])
            {
                return true;
            }
            return false;
        }

        public static bool _Validate(String cpfString)
        {
            CPF cpf = new CPF();
            return cpf.Validate(cpfString);
        }

     
       
    }
}
