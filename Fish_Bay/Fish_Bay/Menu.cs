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
    public partial class Menu : Form
    {
        private Color cor;
        private int indexCor;
        private Color[] cores = new Color[2];
        List<Peixe> peixes;
        List<Cliente> clientes;
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            indexCor = 0;
            cores[0] = Color.SkyBlue;
            cores[1] = Color.Yellow;
            atualizarCor();

            pbDesenho.Invalidate();

            timer.Start();
        }

        private void pbDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("../../../../Imagens/Fundo/capa_inicio.png"), new Point(0,0));
            g.DrawString("Fish Bay", new Font("Consolas", 65), new SolidBrush(this.cor), new Point(300 ,40));
        }

        public void atualizarCor()
        {
            cor = cores[indexCor++];
            if (indexCor == 2)
                indexCor = 0;

            pbDesenho.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            atualizarCor();
        }

        private void btnRecordes_Click(object sender, EventArgs e)
        {
            Record rec = new Record();
            rec.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.reiniciar();
        }

        public void reiniciar()
        {
            Jogo jogo = new Jogo(this, txtNomeJog.Text);
            jogo.Show();
            this.Hide();
        }

        private void btnComoJogar_Click(object sender, EventArgs e)
        {
            ComoJogar comoJogar = new ComoJogar();
            comoJogar.Show();
        }
    }
}
