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
        private Point coord;
        private int direcao;
        private Figura skin;

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

        public Peixe(Point novaCoordenada, int direcaoAndar, Figura novaSkin)
        {
            this.coord.X = novaCoordenada.X;
            this.coord.Y = novaCoordenada.Y;
            this.direcao = direcaoAndar;
            this.skin = novaSkin;
        }

        public void nadar()
        {
            this.coord.X += direcao;
        }

        public void nadar(int velocidade)
        {
            this.coord.X += velocidade*direcao;
        }
        public void voltarAoZero()
        {
            this.coord.X = 0;
        }
    }
}
