using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    public partial class consulta_aula : Form
    {
        public string sql;
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter adaptador;
        DataTable dados;
        public consulta_aula()
        {
            InitializeComponent();
        }
        public void listar()
        {
            conexao = new MySqlConnection("server=localhost; user=root; password=; database=escola_musica");
            sql = "Select * from aulas";
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

        private void consulta_aula_Load(object sender, EventArgs e)
        {
            listar();
        }
        public void FormatarDG()
        {
            //Formatação de legenda

            dataGridView1.Columns[1].HeaderText = "Nome do instrumento";
            dataGridView1.Columns[2].HeaderText = "Nome do professor";
            dataGridView1.Columns[3].HeaderText = "Dia da semana";
            



            dataGridView1.Columns[0].Visible = false;

            //Alinhamento das colunas
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            

            //Largura das colunas
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;


            dataGridView1.Columns[1].HeaderText = "Instrumento";
            dataGridView1.Columns[2].HeaderText = "Professor";
            dataGridView1.Columns[3].HeaderText = "Dia da Semana";

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sql = "update aulas set instrumento ='" + this.txtnomeinst.Text + "'," + " dia_semana = '"
              + this.txtdias.Text + "'" + ", professor ='" + this.txtnomeprof.Text + "'" + " where codigo = '" + this.txtcodigo.Text + "'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = new Form1();
            form1.Show();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtcodigo.Text = row.Cells[0].Value.ToString();
            txtnomeinst.Text = row.Cells[1].Value.ToString();
            txtnomeprof.Text = row.Cells[2].Value.ToString();
            txtdias.Text = row.Cells[3].Value.ToString();
           
        }
    }
}
