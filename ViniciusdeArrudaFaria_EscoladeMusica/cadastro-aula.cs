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
    public partial class cadastro_aula : Form
    {
        public string sql;
        MySqlConnection conexao;

        MySqlCommand comando;
        public cadastro_aula()
        {
            InitializeComponent();
        }

        private void txtcpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comando = new MySqlCommand(
   "insert into alunos( nome, endereco, cpf, ) " +
   "values( '" + txtnomeinst.Text + "','" + txtnomeprof.Text + "','" + txtdias.Text + "')", conexao);
            comando.ExecuteNonQuery();


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
            


            
            txtnomeprof.Clear();
            txtdias.Clear();
            txtnomeinst.Clear();
        }

        private void cadastro_aula_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
