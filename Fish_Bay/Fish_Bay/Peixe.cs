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
        // constantes
        private const int LARGURA = ControladorPeixe.LARGURA_PEIXE;

        // coordenada anterior do peixe
        private Point coordAntigo;

        // coordenada atual do peixe
        private Point coord;

        // direcao do peixe(nunca alteramos)
        private int direcao;

        // Skin do peixe
        private Figura skin;

        // estado atual do peixe
        private bool pescado, nadando, pescando;
        
        // quanda se o peixe é dourado ou não
        private bool dourado;

        // tipo de função para desenhar
        public delegate void TipoDesenhar(Graphics g);
        private TipoDesenhar desenhar;

        // tipo de função para dar pontos equivalentes à raridade do peixe
        public delegate int TipoDarPontos();
        private TipoDarPontos darPontos;

        public delegate int TipoDarPontosVipado();
        private TipoDarPontosVipado darPontosVipado;

        // tipo de Imagem que será retornada quando o peixe é pêgo na mesa pelo vendedor
        public delegate Image TipoSushi(string nomeAju);
        private TipoSushi transformaAlimento;

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

        public TipoDesenhar Desenhar
        {
            get
            {
                return desenhar;
            }

            set
            {
                desenhar = value;
            }
        }

        public bool Dourado
        {
            get
            {
                return dourado;
            }

            set
            {
                dourado = value;
            }
        }

        public TipoDarPontos DarPontos
        {
            get
            {
                return darPontos;
            }

            set
            {
                darPontos = value;
            }
        }

        public TipoSushi TransformaAlimento
        {
            get
            {
                return transformaAlimento;
            }

            set
            {
                transformaAlimento = value;
            }
        }

        public TipoDarPontosVipado DarPontosVipado
        {
            get
            {
                return darPontosVipado;
            }

            set
            {
                darPontosVipado = value;
            }
        }

        public Peixe(Point novaCoordenada, int direcaoAndar, Figura novaSkin, bool ehDourado)
        {
            this.coord.X = novaCoordenada.X;
            this.coord.Y = novaCoordenada.Y;
            this.direcao = direcaoAndar;
            this.skin = novaSkin;
            this.pescado = false;
            this.dourado = ehDourado;

            // verificando quais funções serão utilizadas(para peixes dourados ou não)
            if (ehDourado)
            {
                desenhar = desenharDourado;
                darPontos = darPontosDourado;
                darPontosVipado = darPontosDouradoVipado;
                transformaAlimento = transformaSushiDourado;
            }
            else
            {
                desenhar = desenharNormal;
                darPontos = darPontosNormal;
                darPontosVipado = darPontosNormalVipado;
                transformaAlimento = transformaSushiNormal;
            }
        }

        public Peixe(Peixe clonado)
        {
            this.coord.X = clonado.Coord.X;
            this.coord.Y = clonado.Coord.Y;
            this.direcao = clonado.direcao;
            this.skin = clonado.Skin;
            this.pescado = clonado.Pescado;
            this.dourado = clonado.Dourado;

            if (this.dourado)
            {
                desenhar = desenharDourado;
                darPontosVipado = darPontosDouradoVipado;
                darPontos = darPontosDourado;
                transformaAlimento = transformaSushiDourado;
            }
            else
            {
                desenhar = desenharNormal;
                darPontos = darPontosNormal;
                darPontosVipado = darPontosNormalVipado;
                transformaAlimento = transformaSushiNormal;
            }
        }

        public int darPontosNormal()
        {
            return 10;
        }

        public int darPontosDourado()
        {
            return 100;
        }

        public int darPontosNormalVipado()
        {
            return 20;
        }
        public int darPontosDouradoVipado()
        {
            return 200;
        }



        public Image transformaSushiNormal(string nomeAju)
        {
            return Image.FromFile(Jogo.DEFAULT_IMAGES[1] + nomeAju + "peixe.png");
        }

        public Image transformaSushiDourado(string nomeAju)
        {
            return Image.FromFile(Jogo.DEFAULT_IMAGES[1] + nomeAju + "peixedourado.png");
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


        public Peixe clone()
        {
            return new Peixe(this);
        }

        private void desenharNormal(Graphics g)
        {
            Skin.desenhar(g, coord);
        }

        private void desenharDourado(Graphics g)
        {
            g.DrawImage(Figura.RotateImage(Skin.Img), coord);
        }
    }
}
