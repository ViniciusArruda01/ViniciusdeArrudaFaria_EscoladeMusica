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
            comando = new MySqlCommand(
   "insert into alunos( nome, endereco, cpf, telefone, instrumento) " +
   "values( '" + txtnome.Text + "','" + txtendereco.Text + "','" + txtcpf.Text + "','" + txttelefone.Text + "','" + txtnomeinst.Text + "',)", conexao);
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
            txtnome.Clear();
            
            
            txtendereco.Clear();
            txttelefone.Clear();
            txtcpf.Clear();
            txtnomeinst.Clear();
        }

        }
    }

