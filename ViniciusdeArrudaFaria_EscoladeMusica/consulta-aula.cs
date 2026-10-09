using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                sql = "select * from funcionarios";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            if (textBox1.Text == "")
            {
                sql = "select * from aula where codigo =" + textBox1.Text + "";
            }
            else if (radioButton2.Checked)
            {
                sql = "select * from aula where professor like '%'" + textBox1.Text + "";
            }
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
                MessageBox.Show("Erro ao conectar ao banco de dados", erro.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void consulta_aula_Load(object sender, EventArgs e)
        {

        }
    }
}
