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
using MySql.Data.MySqlClient;

namespace ViniciusdeArrudaFaria_EscoladeMusica
{
    public partial class Form1 : Form
    {
        public string sql;
        MySqlConnection conexao;
        MySqlDataAdapter adaptador;
        DataTable dados;
        MySqlCommand comando;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexao = new MySqlConnection("server=localhost;user=root;password=");
            conexao.Open();
            
            comando = new MySqlCommand("create database if not exists escola_musica; use escola_musica", conexao);
            comando.ExecuteNonQuery();

            // Tabela de alunos
            comando = new MySqlCommand(
                "create table if not exists alunos(" +
                "matricula int(11) not null auto_increment primary key," +
                "nome varchar(100) not null," +
                "endereco varchar(150) not null," +
                "instrumento varchar(50) not null," +
                "telefone varchar(20) not null," +
                "cpf varchar(14) not null" +
                ")", conexao, null);
            comando.ExecuteNonQuery();

            // Tabela de aulas
            comando = new MySqlCommand(
                "create table if not exists aulas(" +
                "codigo int(11) not null auto_increment primary key," +
                "instrumento varchar(50) not null," +
                "dia_semana varchar(20) not null," +
                "professor varchar(100) not null" +
                ")", conexao, null);
            comando.ExecuteNonQuery();

            conexao.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var consulta_aluno = new consulta_aluno();
            consulta_aluno.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var cadastro_aluno = new cadastro_aluno();
            cadastro_aluno.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var cadastro_aula = new cadastro_aula();
            cadastro_aula.Show() ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var consulta_aula = new consulta_aula();
            consulta_aula.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
