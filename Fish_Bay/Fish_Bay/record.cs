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

namespace Fish_Bay
{
    public partial class Record : Form
    {
        public Record()
        {
            InitializeComponent();
        }

        private void frmRecordes_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnn = Conexao.getConexao();
                SqlCommand cmd = new SqlCommand("SELECT q.* FROM(SELECT TOP 10 pontos, nomeJog FROM Recordes ORDER BY pontos DESC) q", cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                string record = reader[0].ToString();
                string nome = reader[1].ToString();
                lblNome1.Text = nome;
                lblRec1.Text = record;

                reader.Read();
                record = reader[0].ToString();
                nome = reader[1].ToString();
                lblNome2.Text = nome;
                lblRec2.Text = record;

                reader.Read();
                record = reader[0].ToString();
                nome = reader[1].ToString();
                lblNome3.Text = nome;
                lblRec3.Text = record;

                reader.Read();
                record = reader[0].ToString();
                nome = reader[1].ToString();
                lblNome4.Text = nome;
                lblRec4.Text = record;

                reader.Read();
                record = reader[0].ToString();
                nome = reader[1].ToString();
                lblNome5.Text = nome;
                lblRec5.Text = record;

                reader.Read();
                record = reader[0].ToString();
                nome = reader[1].ToString();
                lblNome6.Text = nome;
                lblRec6.Text = record;

                reader.Read();
                record = reader[0].ToString();
                nome = reader[1].ToString();
                lblNome7.Text = nome;
                lblRec7.Text = record;

                reader.Read();
                record = reader[0].ToString();
                nome = reader[1].ToString();
                lblNome8.Text = nome;
                lblRec8.Text = record;

                reader.Read();
                record = reader[0].ToString();
                nome = reader[1].ToString();
                lblNome9.Text = nome;
                lblRec9.Text = record;

                reader.Read();
                record = reader[0].ToString();
                nome = reader[1].ToString();
                lblNome10.Text = nome;
                lblRec10.Text = record;

                reader.Close();

                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro de conexão com o servidor.\n"+
                                "                  Tente novamente mais tarde.", "Erro de conexão");
                this.Close();
            }
        }
    }
}
