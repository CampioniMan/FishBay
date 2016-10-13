using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Bay
{
    public class Vendedor
    {
        public const int VELOCIDADE_NORMAL = 1;
        private Figura skin;
        private Point coord;
        private bool podeAndar;
        private int direcao;
        private bool temPeixe;
        private bool[] estaNoCanto; // 0 = <-  && 1 = ->

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

        public bool PodeAndar
        {
            get
            {
                return podeAndar;
            }

            set
            {
                podeAndar = value;
            }
        }

        public bool EstaParado
        {
            get
            {
                return !podeAndar;
            }
            set
            {
                podeAndar = !value;
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

        public bool AndandoAoContrario
        {
            get
            {
                return (direcao == -1);
            }
            set
            {
                if (value)
                    direcao = -1;
                else
                    direcao = 1;
            }
        }

        public Point Coord1
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

        public bool TemPeixe
        {
            get
            {
                return temPeixe;
            }

            set
            {
                temPeixe = value;
            }
        }

        public bool[] EstaNoCanto
        {
            get
            {
                return estaNoCanto;
            }
        }

        public Vendedor(Image novaSkin, Point novaCoordenada, int novaDirecao)
        {
            this.skin = new Figura(novaSkin);
            this.coord = novaCoordenada;
            this.direcao = novaDirecao;
            this.estaNoCanto = new bool[2];
            for (int i = 0; i < this.estaNoCanto.Length; i++)
                    this.estaNoCanto[i] = false;
        }

        public Vendedor(Image novaSkin, Point novaCoordenada) : this(novaSkin, novaCoordenada, 1)
        {
        }

        public void desenhar(Graphics g)
        {
            g.DrawImage(skin.Img, coord);
        }

        /* direcao= 1 ou direcao= -1 para o player andar para frente ou para trás */
        public void andar()
        {
            andar(VELOCIDADE_NORMAL);
        }

        /* è possível juntar as duas variáveis, mas assim é melhor para o entendimento inicial da função */
        public void andar(int velocidade)
        {
            this.coord.X += 5 * direcao * velocidade;
            if (direcao >= 0)
                this.Skin.Invertido = false;
            else
                this.Skin.Invertido = true;
        }
    }
}
