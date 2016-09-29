using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Bay
{
    public class Peixe
    {
        private const int LARGURA = 56;
        private Point coordAntigo;
        private Point coord;
        private int direcao;
        private Figura skin;
        private bool pescado, nadando, pescando;
        private int posMesa;

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

        public int Direcao
        {
            get
            {
                return direcao;
            }

            set
            {
                direcao = value;
            }
        }

        public Figura Skin
        {
            get
            {
                return skin;
            }

            set
            {
                skin = value;
            }
        }

        public Point CoordAntigo
        {
            get
            {
                return coordAntigo;
            }

            set
            {
                coordAntigo = value;
            }
        }

        public Point Diferenca
        {
            get
            {
                return new Point(this.coord.X - this.coordAntigo.X, this.coord.Y - this.coordAntigo.Y);
            }
        }

        public bool Pescado
        {
            get
            {
                return pescado;
            }

            set
            {
                nadando = !value;
                pescando = !value;
                pescado = value;
            }
        }

        public bool Pescando
        {
            get
            {
                return pescando;
            }

            set
            {
                nadando = !value;
                pescando = value;
                pescado = !value;
            }
        }

        public bool Nadando
        {
            get
            {
                return nadando;
            }

            set
            {
                nadando = value;
                pescando = !value;
                pescado = !value;
            }
        }

        public int PosMesa
        {
            get
            {
                return posMesa;
            }

            set
            {
                posMesa = value;
            }
        }

        public Peixe(Point novaCoordenada, int direcaoAndar, Figura novaSkin)
        {
            this.coord.X = novaCoordenada.X;
            this.coord.Y = novaCoordenada.Y;
            this.direcao = direcaoAndar;
            this.skin = novaSkin;
            this.pescado = false;
            this.posMesa = 212;
        }

        public Peixe(Peixe clonado)
        {
            this.coord.X = clonado.Coord.X;
            this.coord.Y = clonado.Coord.Y;
            this.direcao = clonado.direcao;
            this.skin = clonado.Skin;
            this.pescado = clonado.Pescado;
            this.posMesa = clonado.PosMesa;
        }

        public void nadar()
        {
            this.coordAntigo = this.coord;
            this.coord.X += direcao;
        }

        public void nadar(int velocidade)
        {
            this.coordAntigo = this.coord;
            this.coord.X += velocidade*direcao;
        }
        public void voltarAoZero()
        {
            this.coordAntigo = this.coord;
            this.coord.X = 0;
            Random rand = new Random();
            this.coord.Y = rand.Next(380, 530);
        }

        public bool pescou(Point pontoLinha, int ALTURA)
        {
            if (this.pescado)
                return false;
            return ((pontoLinha.X <= this.coord.X + this.Diferenca.X && 
                pontoLinha.X + this.Diferenca.X >= this.coord.X) 
                && (pontoLinha.Y <= this.coord.Y + ALTURA &&
                pontoLinha.Y >= this.coord.Y));
        }

        public void desenharDebug(Graphics g, int ALTURA)
        {
            g.DrawLine(new Pen(Color.Red, 5), this.coord.X - this.Diferenca.X + LARGURA, this.Coord.Y         , this.coordAntigo.X                    + LARGURA, this.coordAntigo.Y + ALTURA);
            g.DrawLine(new Pen(Color.Red, 5), this.coord.X                    + LARGURA, this.Coord.Y         , this.coordAntigo.X + this.Diferenca.X + LARGURA, this.coordAntigo.Y + ALTURA);
            g.DrawLine(new Pen(Color.Red, 5), this.coord.X - this.Diferenca.X + LARGURA, this.Coord.Y + ALTURA, this.coordAntigo.X                    + LARGURA, this.coordAntigo.Y);
            g.DrawLine(new Pen(Color.Red, 5), this.coord.X                    + LARGURA, this.Coord.Y + ALTURA, this.coordAntigo.X + this.Diferenca.X + LARGURA, this.coordAntigo.Y);
            
        }

        public Peixe clone()
        {
            return new Peixe(this);
        }
    }
}
