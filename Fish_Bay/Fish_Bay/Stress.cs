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
        private int porcentagem;
        private Color cor;
        private Point coord, tamanhos;

        public int Porcentagem
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

        public Point Tamanhos
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
        }

        public void atualizarCor()
        {
            if (this.porcentagem < 25)
                this.cor = Color.Green;
            else if (this.porcentagem < 50)
                this.cor = Color.Yellow;
            else
                this.cor = Color.Red;
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
    }
}
