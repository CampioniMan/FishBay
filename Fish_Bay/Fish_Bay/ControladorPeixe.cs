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
        ////// vetores de peixes geral, peixes na mesa e peixes nadando, respectivamente
        private Peixe[] peixes, peixesPescados, peixePescando;
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
        * Verifica se há a possibilidade de pescar algum peixe
        *   param vara -> Coordenada da vara para ver se "está" em algum peixe
        */
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

        /**
        * Remove o peixe do vetor de "nadando" e adiciona um igual no "pescaNdo"
        *   param index -> ìndice do peixe que irá para a vara
        */
        public void pescarPeixeNoIndice(int index)
        {
            if (index < 0 || index >= this.qtosPeixesNadando)
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
            {
                this.peixesPescados[this.QtosPeixesPescados] = peixe.clone();
                this.qtosPeixesPescados++;
            }
        }

        private Peixe PegarOQueEstaNadando(int index)
        {
            return this.peixes[index].clone();
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

        public void voltarANadarPeixe()
        {
            if (this.qtosPeixesPescados > 0)
                removerPescado();
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
