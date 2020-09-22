using Newtonsoft.Json;
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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            Endereco endereco = new Endereco();
            if (txtBoxCPF.Text == "")
            {
                MessageBox.Show("Preencha um valor numérico para o CPF");
                return;
            }
            if (Controller.CPF._Validate(txtBoxCPF.Text) == false)
            {
                MessageBox.Show("CPF Inválido");

                return;
            }
            if (txtNome.Text == "")
            {
                MessageBox.Show("Digite um nome!");
                return;
            }
            if (txtSobrenome.Text == "")
            {
                MessageBox.Show("Digite um sobrenome!");
                return;
            }

            if (txtDataNascimento.Text == "")
            {
                MessageBox.Show("Digite uma data de nascimento!");
                return;
            }
            try
            {
                DateTime dataNascimento = DateTime.Parse(txtDataNascimento.Text);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Digite uma data de nascimento válida");
                return;
            }

        
          
            if (txtCEP.Text == "")
            {
                MessageBox.Show("Digite um CEP!");
                return;
            }
            if (txtEndereco.Text == "")
            {
                MessageBox.Show("Digite um endereço!");
                return;
            }
            if (txtNumero.Text == "")
            {
                MessageBox.Show("Digite um número para o endereço acima");
                return;
            }
            try
            {
                int.Parse(txtNumero.Text);
            }
            catch
            {
                MessageBox.Show("Digite um número válido");
                return;
            }
            if (txtComplemento.Text == "")
            {
                MessageBox.Show("Caso não haja complemento, preencha com um N/D ou Nenhum");
                return;
            }
            if (txtCidade.Text == "")
            {
                MessageBox.Show("Digite o nome da cidade!");
                return;
            }
            if(txtEstado.Text == "")
            {
                MessageBox.Show("Digite a UF (Estado)");
                return;
            }

            data.cpf = txtBoxCPF.Text;
            data.data_nascimento = DateTime.Parse(txtDataNascimento.Text);
            data.nome = txtNome.Text;
            data.sobrenome = txtSobrenome.Text;
            var dados = new
            {
                data = new
                {
                    cpf = data.cpf,
                    data_nascimento = data.data_nascimento,
                    nome = data.nome,
                    sobrenome = data.sobrenome
                }
                
            };
            endereco.cep = txtCEP.Text;
            endereco.endereco = txtEndereco.Text;
            endereco.numero = int.Parse(txtNumero.Text);
            endereco.complemento = txtComplemento.Text;
            endereco.cidade = txtCidade.Text;
            endereco.estado = txtEstado.Text;
            var address = new
            {
                endereco = new
                {
                    cep = endereco.cep,
                    endereco = endereco.endereco,
                    numero = endereco.numero,
                    complemento = endereco.complemento,
                    cidade = endereco.cidade,
                    estado = endereco.estado,
                   
                }
            };

            List<Object> lista = new List<object>();
            lista.Add(dados);
            lista.Add(address);


            Controller.Json json = new Controller.Json();
            if (json.JsonEncode(lista) != null)
            {
                MessageBox.Show("Cadastro efetuado com sucesso!", "Cadastro bem sucedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível efetuar o cadastro!", "Cadastro bem sucedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
           



        }
    }
}
