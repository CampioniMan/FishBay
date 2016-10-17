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
        // Quanto está o stress do personagem
        private double porcentagem;

        // cor atual do stress
        private Color cor;

        // coordenadas úteis para a classe
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

        public bool PodeStressar
        {
            get
            {
                return porcentagem < 100;
            }
        }

        // método que desenha o stress
        public void desenhar(Graphics g)
        {
            atualizarCor();
            g.FillRectangle(new SolidBrush(this.cor), coord.X, coord.Y+tamanhos.Y - (int)(tamanhos.Y * porcentagem / 100), tamanhos.X, (int)(tamanhos.Y * porcentagem/100));
            g.DrawRectangle(new Pen(Color.Black), coord.X, coord.Y, tamanhos.X, tamanhos.Y);
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
            stressar(1);
        }

        public void stressar(int velo)
        {
            if (this.PodeStressar)
                this.porcentagem += 0.1*velo;
        }

        public Stress(int novaPorcentagem, Point ondeFigura, Point novosTamanhos) //tamanhos = largura e altura
        {
            this.porcentagem = novaPorcentagem;
            this.coord = ondeFigura;
            this.tamanhos = novosTamanhos;
            atualizarCor();
        }

        public Stress(Point Figura, Point Tamanho) : this(0 ,Figura, Tamanho)
        {
        }
    }
}
