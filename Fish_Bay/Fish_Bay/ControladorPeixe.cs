using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Bay
{
    public class ControladorPeixe
    {
        public const int LIMITE_PEIXES = 6;
        private Peixe[] peixes, peixesPescados, peixePescando;
        private int qtosPeixesNadando;
        private Point posicaoMinima;

        public int QtosPeixesPescados
        {
            get
            {
                return LIMITE_PEIXES - qtosPeixesNadando;
            }
        }

        public Peixe[] Peixes
        {
            get
            {
                return peixes;
            }

            set
            {
                peixes = value;
            }
        }

        public Peixe[] PeixesPescados
        {
            get
            {
                return peixesPescados;
            }

            set
            {
                peixesPescados = value;
            }
        }

        public int QtosPeixesNadando
        {
            get
            {
                return qtosPeixesNadando;
            }

            set
            {
                qtosPeixesNadando = value;
            }
        }

        public Peixe[] PeixePescando
        {
            get
            {
                return peixePescando;
            }

            set
            {
                peixePescando = value;
            }
        }

        public void nadem(int randomico)
        {
            for (int i = 0; i < qtosPeixesNadando; i++)
                peixes[i].nadar(randomico);
        }

        public void desenharTodos(Graphics g, Point vara)
        {
            for (int i = 0; i < qtosPeixesNadando; i++)
            {
                peixes[i].Skin.desenhar(g, peixes[i].Coord);
            }
            for (int ind = 0; ind < QtosPeixesPescados; ind++)
            {
                peixesPescados[ind].Skin.desenhar(g, new Point(this.posicaoMinima.X, ondeDesenharPilhaNoIndice(ind)));
            }

            if (this.peixePescando[0] != null)
                g.DrawImage(Figura.RotateImage(this.peixePescando[0].Skin.Img, -90), vara);
        }

        public void verSePescouAlgumPeixe(Point vara)
        {
            for (int i = 0; i < this.qtosPeixesNadando; i++)
            {
                if (!this.peixes[i].Pescado)
                {
                    if (this.peixes[i].pescou(vara, Jogo.ALTURA_PEIXE))
                        this.pescarPeixeNoIndice(i);
                }
            }
        }

        public void pescarPeixeNoIndice(int index)
        {
            if (index < 0 || index >= this.qtosPeixesNadando)
                return;

            this.adicionarPescado(this.removerNadando(index));
        }

        private void adicionarPescado(Peixe peixe)
        {
            this.peixesPescados[this.QtosPeixesPescados - 1] = peixe;
        }

        private Peixe removerNadando(int index)
        {
            Peixe auxiliar = this.peixes[index];
            for (int i = index; i < this.qtosPeixesNadando-1; i++)
            {
                this.peixes[i] = this.peixes[i+1];
            }
            this.peixes[--this.qtosPeixesNadando] = null;

            return auxiliar;
        }

        private void adicionarPescando(Peixe outro)
        {
            this.peixePescando[0] = outro;
        }

        private Peixe removerPescando()
        {
            Peixe aux = this.peixePescando[0];
            this.peixePescando[0] = null;
            return aux;
        }
        /// ////////////////
        public void voltarANadarPeixeNoIndice(int index)
        {
            if (index < 0 || index >= this.QtosPeixesPescados)
                return;
            
            adicionarNadando(removerPescado());
        }

        private void adicionarNadando(Peixe v)
        {
            Random rand = new Random();
            peixes[this.qtosPeixesNadando++] = new Peixe(new Point(-Jogo.LARGURA_PEIXE - rand.Next(0, 4000), rand.Next(380, 530)), 1, v.Skin);
        }

        private Peixe removerPescado()
        {
            Peixe aux = peixesPescados[this.QtosPeixesPescados - 1];
            peixesPescados[this.QtosPeixesPescados - 1] = null;
            return aux;
        }

        private int ondeDesenharPilhaNoIndice(int index)
        {
            return (this.posicaoMinima.Y) - (Jogo.ALTURA_PEIXE+1) * index;
        }

        public ControladorPeixe(Peixe[] novosPeixes, Point novaPosicaoMinima)
        {
            this.peixes = novosPeixes;
            this.qtosPeixesNadando = novosPeixes.Length;
            this.peixesPescados = new Peixe[this.qtosPeixesNadando];
            this.posicaoMinima = novaPosicaoMinima;
            this.peixePescando = new Peixe[1];
        }
    }
}
