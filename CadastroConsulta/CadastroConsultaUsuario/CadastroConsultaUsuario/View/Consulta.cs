using CadastroConsultaUsuario;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroConsultaUsuario.View
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            DataGridView dgv = new DataGridView();
            DataTable dt = new DataTable("Dados");
            dt.Columns.Add("Nome Completo");
            dt.Columns.Add("CPF");
            dt.Columns.Add("Data Nascimento");
            dt.Columns.Add("Endereço Completo");
            dgv.DataSource = dt;
            dataGridView1.DataSource = dt;
            Controller.Json json = new Controller.Json();
            List<Object> data = json.JsonDecode(Controller.Json.filename);
            List<JArray> data_JARRAY = new List<JArray>();
            List<Endereco> enderecos = new List<Endereco>();
            List<Data> datas = new List<Data>();
            for (int cont = 0; cont < data.Count; cont++)
            {
                data_JARRAY.Add((JArray)data[cont]);
                String string_json = data_JARRAY[cont][0].ToString();
                JObject json_inteiro = JObject.Parse(data_JARRAY[cont][0].ToString());
                JToken dataToken = json_inteiro.GetValue("data");
                Data data1 = dataToken.ToObject<Data>();
                datas.Add(data1);

                string_json = data_JARRAY[cont][1].ToString();
                json_inteiro = JObject.Parse(data_JARRAY[cont][1].ToString());
                dataToken = json_inteiro.GetValue("endereco");
                Endereco endereco = dataToken.ToObject<Endereco>();
                enderecos.Add(endereco);
                
                dt.Rows.Add();
                dt.Rows[cont][0] = datas[cont].nome+ " " + data1.sobrenome;
                dt.Rows[cont][1] = datas[cont].cpf;
                dt.Rows[cont][2] = datas[cont].data_nascimento.ToShortDateString();
                dt.Rows[cont][3] = enderecos[cont].endereco + "," + enderecos[cont].numero + "-" + " " 
                    + enderecos[cont].complemento + " " + enderecos[cont].cidade + "/" + enderecos[cont].estado + " - CEP:" + enderecos[cont].cep;
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
         
        }
    }
}
