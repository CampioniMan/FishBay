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
        public const int 
            LIMITE_PEIXES = 7,
            LARGURA_PEIXE = 56,
            LARGURA_BOTA = 44,
            ALTURA_BOTA = 36,
            ALTURA_PEIXE = 22,
            LARGURA_DOURADO = 26,
            ALTURA_DOURADO = 14;
        private Peixe[] peixes, peixesPescados, peixePescando;
        private Peixe bota,botaPescada;
        private int qtosPeixesNadando, qtosPeixesPescando, qtosPeixesPescados;
        private Point posicaoMinima;

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

        public int QtosPeixesPescados
        {
            get
            {
                return qtosPeixesPescados;
            }

            set
            {
                qtosPeixesPescados = value;
            }
        }

        public int QtosPeixesPescando
        {
            get
            {
                return qtosPeixesPescando;
            }

            set
            {
                qtosPeixesPescando = value;
            }
        }

        public Peixe Bota
        {
            get
            {
                return bota;
            }

            set
            {
                bota = value;
            }
        }

        public Peixe Bota1
        {
            get
            {
                return bota;
            }

            set
            {
                bota = value;
            }
        }

        /**
        * Faz os peixes nadarem em uma proporção parecida
        *   param randomico -> número randômico aí
        */
        public void nadem(int randomico)
        {
            Random rand = new Random();
            for (int i = 0; i < qtosPeixesNadando; i++)
                peixes[i].nadar(randomico+rand.Next(1, 3));
        }

        /**
        * Desenha todos os peixes dos 3 vetores
        *   param g -> Gráfico para desenho
        *   param vara -> Coordenada da vara para desenhar o peixe pescado
        */
        public void desenharTodos(Graphics g, Point vara)
        {
            for (int i = 0; i < qtosPeixesNadando; i++)
                peixes[i].Skin.desenhar(g, peixes[i].Coord);
            
            for (int ind = 0; ind < QtosPeixesPescados; ind++)
                peixesPescados[ind].Skin.desenhar(g, new Point(this.posicaoMinima.X, ondeDesenharPilhaNoIndice(ind)));

            if (this.peixePescando[0] != null)
                g.DrawImage(Figura.RotateImage(this.peixePescando[0].Skin.Img), vara);
            
        }

        /**
        * Verifica se há a possibilidade de pescar algum peixe, caso tenha ele é pescado
        *   param vara -> Coordenada da vara para ver se "está" em algum peixe
        */
        public void verSePescouAlgumPeixe(Point vara)
        {
            for (int i = 0; i < this.qtosPeixesNadando; i++)
            {
                if (!this.peixes[i].Pescado)
                {
                    if (this.peixes[i].pescou(vara, ALTURA_PEIXE))
                        this.pescarPeixeNoIndice(i);
                }
            }
        }

        /**
        * Remove o peixe do vetor de "nadando" e adiciona um igual no "pescaNdo"
        *   param index -> ìndice do peixe que irá para a vara
        */
        public void pescarPeixeNoIndice(int index)
        {
            if (index < 0 || index >= this.qtosPeixesNadando || this.peixePescando[0] != null)
                return;

            this.adicionarPescando(this.PegarOQueEstaNadando(index));
        }

        /**
        * Remove do vetor de "pescaNdo" e adiciona em "pescado"(quando vai botar na mesa)
        * 
        */
        public void verSeDaPraBotarNaMesa()
        {
            if (this.peixePescando[0] != null)
                this.adicionarPescado(this.removerPescando());
        }

        /**
        * Adiciona um novo peixe ao vetor de "pescado"
        *   param peixe -> O peixe a ser pescado
        */
        private void adicionarPescado(Peixe peixe)
        {
            if (peixe != null)
                this.peixesPescados[this.QtosPeixesPescados++] = peixe.clone();
        }

        private Peixe PegarOQueEstaNadando(int index)
        {
            Peixe aux = this.peixes[index].clone();
            Random rand = new Random();
            this.peixes[index] = new Peixe(new Point(-LARGURA_PEIXE - rand.Next(2000, 4000), rand.Next(380, 530)), 1, this.peixes[index].Skin, aux.Dourado);
            return aux;
        }

        private void adicionarPescando(Peixe outro)
        {
            outro.Pescado = true;
            this.peixePescando[0] = outro.clone();
            this.qtosPeixesPescando++;
        }

        private Peixe removerPescando()
        {
            if (this.qtosPeixesPescados < 6)
            {
                Peixe aux = this.peixePescando[0].clone();
                this.peixePescando[0] = null;
                this.qtosPeixesPescando--;
                return aux;
            }
            return null;
        }

        public Peixe voltarANadarPeixe()
        {
            if (this.qtosPeixesPescados > 0)
                return removerPescado();
            return null;
        }

        private Peixe removerPescado()
        {
            Peixe aux = peixesPescados[this.QtosPeixesPescados - 1];
            peixesPescados[this.QtosPeixesPescados - 1] = null;
            this.qtosPeixesPescados--;
            return aux;
        }

        private int ondeDesenharPilhaNoIndice(int index)
        {
            return (this.posicaoMinima.Y) - (ALTURA_PEIXE+1) * index;
        }

        public void limparMesa()
        {
            for (int i = QtosPeixesPescados; i > 0; i--)
                this.removerPescado();
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
