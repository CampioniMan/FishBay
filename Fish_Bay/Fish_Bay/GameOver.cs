using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Fish_Bay
{
    public partial class GameOver : Form
    {
        private string nomeJog, pontos,peixes;
        private Jogo jog;

        public GameOver(string novoNomeJog, string novoPontos,string novoPeixes, Jogo novoJog)
        {
            this.nomeJog = novoNomeJog;
            this.pontos = novoPontos;
            this.peixes = novoPeixes;
            this.jog = novoJog;
            InitializeComponent();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            lblJogador.Text += this.nomeJog;
            lblPontos.Text += this.pontos;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            this.Close();
            jog.setReiniciar(true);
            jog.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //Application.Exit(); // Hardcore
            this.Close();
            jog.setReiniciar(false);
            jog.Close();
        }

        private void adicionarRecord()
        {
            try
            {
                string query = "insert into Recordes values(@nome, @pontos,@peixes)";
                SqlCommand sqlCom = new SqlCommand(query, this.getConexao());

                sqlCom.Parameters.AddWithValue("@nome", this.nomeJog);
                sqlCom.Parameters.AddWithValue("@pontos", this.pontos);
                sqlCom.Parameters.AddWithValue("@peixes", this.peixes);
                sqlCom.ExecuteNonQuery();

                MessageBox.Show("Recorde Cadastrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Desculpe-nos, mas houve um erro de conexão com o servidor.\n" +
                                "                  Tente novamente mais tarde.", "Erro de conexão");
            }
        }

        private SqlConnection getConexao()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(strConnection);

            if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

            return sqlConnection;
        }

        private void GameOver_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.adicionarRecord();
        }
    }
}
