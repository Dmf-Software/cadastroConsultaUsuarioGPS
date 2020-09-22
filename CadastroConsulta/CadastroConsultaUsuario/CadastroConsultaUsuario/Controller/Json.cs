using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace CadastroConsultaUsuario.Controller
{

    class Json
    {
        public static String filename = Environment.CurrentDirectory + "\\data.txt";
        //Converte qualquer objeto para Json 
        public String JsonEncode(Object e)
        {
            String jsonReturn = JsonConvert.SerializeObject(e);
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\data.txt") == false)
            {
                System.IO.File.Create(Environment.CurrentDirectory + "\\data.txt").Close();

            }

        
           
            System.IO.StreamWriter sw = new System.IO.StreamWriter(Environment.CurrentDirectory + "\\data.txt", true);
            sw.WriteLine(jsonReturn);
            sw.Close();
            
            return jsonReturn;
        }

        public List<Object> JsonDecode(String filename)
        {
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\data.txt") == false)
            {
                System.IO.File.Create(Environment.CurrentDirectory + "\\data.txt");
            }
            else
            {
                using (System.IO.StreamReader leitor = new System.IO.StreamReader(Environment.CurrentDirectory + "\\data.txt"))
                {
                    int cont = File.ReadAllLines(filename).Length;
                    List<Object> listaObj = new List<object>();
                    for(int linha = 0; linha < cont; linha++)
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        Object obj = JsonConvert.DeserializeObject(leitor.ReadLine());
                        listaObj.Add(obj);
                      
                    }

                    return listaObj;  
                    
                 
                }
                
            }
            return null;
        }
    }
}
