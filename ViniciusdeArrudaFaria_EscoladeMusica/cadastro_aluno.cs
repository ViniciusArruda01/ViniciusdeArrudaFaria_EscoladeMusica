using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViniciusdeArrudaFaria_EscoladeMusica
{
    public partial class cadastro_aluno : Form
    {
        public string sql;
        MySqlConnection conexao;

        MySqlCommand comando;
        public cadastro_aluno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql =
   "insert into alunos( nome, endereco, instrumento, cpf, telefone) " +
   "values( '" + txtnome.Text + "','" + txtendereco.Text + "','" + txtnomeinst.Text + "','" + txtcpf.Text + "','" + txttelefone.Text + "')";
            


            try
            {
                conexao.Open();
                try
                {
                    comando = new MySqlCommand(sql, conexao);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados salvos com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao salvar dados!!!", erro.Message);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao conectar ao banco!!!", erro.Message);
            }
            finally
            {
                conexao.Close();
            }
            txtnome.Clear();
            
            
            txtendereco.Clear();
            txttelefone.Clear();
            txtcpf.Clear();
            txtnomeinst.Clear();
        }

<<<<<<< HEAD:ViniciusdeArrudaFaria_EscoladeMusica/cadastro_aluno.cs
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var consulta_aluno = new consulta_aluno();
            consulta_aluno.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = new Form1();
            form1.Show();
        }

        private void cadastro_aluno_Load(object sender, EventArgs e)
        {
            conexao = new MySqlConnection("server=localhost;user=root;password=");
            conexao.Open();
            conexao.Close();
=======
        private void cadastro_aluno_Load(object sender, EventArgs e)
        {

>>>>>>> 781c310bd9759a08fb88f228af3cfdcb9baba6ba:ViniciusdeArrudaFaria_EscoladeMusica/cadastro-aluno.cs
        }
    }
    }

