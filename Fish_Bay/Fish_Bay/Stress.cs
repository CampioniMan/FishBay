using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Bay
{
    public class Stress
    {
        private double porcentagem;
        private Color cor;
        public Point coord, tamanhos;

        public double Porcentagem
        {
            get
            {
                return porcentagem;
            }

            set
            {
                porcentagem = value;
            }
        }

        public Point Coord
        {
            get
            {
                return coord;
            }

            set
            {
                coord = value;
            }
        }


        public Point Tamanhos // altura e largura limite do stress
        {
            get
            {
                return tamanhos;
            }

            set
            {
                tamanhos = value;
            }
        }

        public void desenhar(Graphics g)
        {
            atualizarCor();
            g.DrawRectangle(new Pen(Color.Black), coord.X, coord.Y, tamanhos.X, tamanhos.Y);
            g.FillRectangle(new SolidBrush(this.cor), coord.X, coord.Y, tamanhos.X, tamanhos.Y);
            g.DrawString(this.porcentagem+"", new Font("Consolas", 15), new SolidBrush(Color.Black), coord);
        }

        private void atualizarCor()
        {
            if (this.porcentagem < 50)
                this.cor = Color.Green;
            else if (this.porcentagem < 80)
                this.cor = Color.Yellow;
            else
                this.cor = Color.Red;
        }

        public void stressar()
        {
            if (this.porcentagem < 100)
            this.porcentagem += 0.1;
        }

        public void stressar(int velo)
        {
            if (this.porcentagem < 100)
                this.porcentagem += 0.1*velo;
        }

        public Stress(int novaPorcentagem, Point ondeFigura, Point novosTamanhos)
        {
            this.porcentagem = novaPorcentagem;
            this.coord = ondeFigura;
            this.tamanhos = novosTamanhos;
            atualizarCor();
        }

        public Stress() : this(0, default(Point), default(Point))
        {
        }

        public Stress(int novaPorcentagem) : this(novaPorcentagem, default(Point), default(Point))
        {
        }

        public Stress(int novaPorcentagem, Point Figura) : this(novaPorcentagem, Figura, default(Point))
        {
        }

        public Stress(Point Figura, Point Tamanho) : this(0 ,Figura, Tamanho)
        {
        }
    }
}
