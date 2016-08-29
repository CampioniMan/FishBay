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
    public partial class Jogo : Form
    {
        private Menu menu;
        private Peixe[] peixes;
        public Jogo(Menu menuNovo)
        {
            this.menu = menuNovo;
            InitializeComponent();
        }

        private void Jogo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.menu.Show();
        }

        private void Jogo_Load(object sender, EventArgs e)
        {
            peixes = new Peixe[1];
            peixes[0] = new Peixe(new Point(20, 80), 1, new Figura(Image.FromFile("../../../../Imagens/Peixe1.png")));
            atualizarPeixe();

            timer.Start();
        }

        public void atualizarPeixe()
        {
            peixes[0].nadar(5);
            pbDesenho.Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            atualizarPeixe();
        }

        private void pbDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            peixes[0].Skin.desenhar(g, peixes[0].Coord);
        }
    }
}
