using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Bay
{
    public partial class GameOver : Form
    {
        private string nomeJog, pontos;
        private Jogo jog;

        public GameOver(string novoNomeJog, string novoPontos, Jogo novoJog)
        {
            this.nomeJog = novoNomeJog;
            this.pontos = novoPontos;
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
            jog.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
