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
using static System.Net.Mime.MediaTypeNames;

namespace ViniciusdeArrudaFaria_EscoladeMusica
{
    public partial class consulta_aluno : Form
    {
        public string sql;
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter adaptador;
        DataTable dados;
        public consulta_aluno()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = new Form1();
            form1.Show();
        }

        private void consulta_aluno_Load(object sender, EventArgs e)
        {
            listar();
        }

        public void listar()
        {
            conexao = new MySqlConnection("server=localhost; user=root; password=; database=escola_musica");
            sql = "Select * from alunos";
            try
            {
                conexao.Open();
                comando = new MySqlCommand(sql, conexao);
                adaptador = new MySqlDataAdapter(comando);
                dados = new DataTable();
                adaptador.Fill(dados); //Organiza os dados
                dataGridView1.DataSource = dados;
                FormatarDG();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao conectar no banco de dados", erro.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void FormatarDG()
        {
            //Formatação de legenda

            dataGridView1.Columns[1].HeaderText = "Nome";
            dataGridView1.Columns[2].HeaderText = "Endereço";
            dataGridView1.Columns[3].HeaderText = "Nome do intrumento";
            dataGridView1.Columns[4].HeaderText = "Telefone";
            dataGridView1.Columns[5].HeaderText = "CPF";
            


            dataGridView1.Columns[0].Visible = false;

            //Alinhamento das colunas
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Largura das colunas
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;

          
            dataGridView1.Columns[1].HeaderText = "Nome";
            dataGridView1.Columns[2].HeaderText = "Endereço";
            dataGridView1.Columns[3].HeaderText = "Instrumento";
            dataGridView1.Columns[4].HeaderText = "Telefone";
            dataGridView1.Columns[5].HeaderText = "CPF";

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtcodigo.Text = row.Cells[0].Value.ToString();
            txtnome.Text = row.Cells[1].Value.ToString();
            txtendereco.Text = row.Cells[2].Value.ToString();
            txtcpf.Text = row.Cells[5].Value.ToString();
            txttelefone.Text = row.Cells[4].Value.ToString();
            txtnomeinst.Text = row.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sql = "update alunos set nome ='" + this.txtnome.Text + "'," + " instrumento = '"
               + this.txtnomeinst.Text + "'" + ", endereco ='" + this.txtendereco.Text + "'," + " telefone = '"
               + this.txttelefone.Text + "'," + " cpf = '" + this.txtcpf.Text + "'"  + " where matricula = '" + this.txtcodigo.Text + "'";
            try
            {
                conexao.Open();
                try
                {
                    comando = new MySqlCommand(sql, conexao);
                    adaptador = new MySqlDataAdapter(comando);
                    dados = new DataTable();
                    adaptador.Fill(dados);
                    FormatarDG();
                }//erro ao conectar o banco
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados", erro.Message);
                }
            }//erro ao encontrar o funcionario
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao alterar dados o funcionário do banco de dados", erro.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "Delete from alunos where matricula='" + this.txtcodigo.Text + "'";
            try
            {
                conexao.Open();
                try
                {
                    comando = new MySqlCommand(sql, conexao);
                    adaptador = new MySqlDataAdapter(comando);
                    dados = new DataTable();
                    adaptador.Fill(dados); //Organiza os dados
                    dataGridView1.DataSource = dados;

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao excluir dados do banco de dados", erro.Message);

                }


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados", erro.Message);

            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
