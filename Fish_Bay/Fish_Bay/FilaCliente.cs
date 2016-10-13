using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Bay
{
    class FilaCliente
    {
        public const int LARGURA_NPC = 34, 
            MAXIMO_FILA = 9, 
            ALTURA_NPC = 56,
            NPC_ANDAR_FRENTE = 1,
            NPC_ANDAR_TRAS = -1;

        private Cliente[] clientes;
        private Point limite;
        private int tamanhoUtil;

        public Cliente[] Clientes
        {
            get
            {
                return clientes;
            }

            set
            {
                clientes = value;
            }
        }

        public bool EstaVazia
        {
            get
            {
                return tamanhoUtil == 0;
            }
        }

        public int TamanhoFila
        {
            get
            {
                return tamanhoUtil;
            }
        }

        public Cliente Primeiro
        {
            get
            {
                return clientes[0];
            }
        }

        public Point Limite
        {
            get
            {
                return limite;
            }

            set
            {
                limite = value;
            }
        }

        public int PrimeiroEspacoVazio
        {
            get
            {
                for (int i = 0; i > TamanhoFila; i++)
                {
                    if (clientes[i] == null)
                        return i;
                }
                return MAXIMO_FILA + 1;
            }
        }

        public void andar()
        {
            for (int i = 0; i < this.TamanhoFila; i++)
                if (this.clientes[i].PodeAndar(this.limiteParaIndice(i)))
                    this.clientes[i].andar(NPC_ANDAR_FRENTE);
        }

        public bool queremPeixe()
        {
            for (int i = 0; i < this.TamanhoFila; i++)
                if (this.clientes[i].QuerPeixe)
                    return true;
            return false;
        }

        // faz o NPC sair da fila de espera por motivos adversos
        public void sair(int indice)
        {
            if (indice > MAXIMO_FILA || indice < 0) // indice inválido
                return;

            for (int i = indice; i < this.tamanhoUtil - 1; i++)
            {
                clientes[i] = clientes[i + 1];
            }
            retirarUltimo();
        }

        protected void retirarUltimo()
        {
            if (this.tamanhoUtil > 0)
                this.clientes[this.tamanhoUtil-- - 1] = null;
        }

        // faz o PRIMEIRO NPC sair da fila de espera porque ganhou um peixe
        public void sairIndice(int ind)
        {
            
            this.sair(ind);
        }

        public int vaiSair()
        {
            int indice = 0;
            for (int i = 0; i < this.tamanhoUtil - 1; i++)
            {
                if (clientes[i].EhVIP && !this.clientes[i].PodeAndar(this.limiteParaIndice(i)))
                {
                    indice = i;
                    break;
                }


            }
            return indice;
        }

        // entra um personagem randômico na fila
        public void entrarRandomico()
        {
            if (MAXIMO_FILA <= this.TamanhoFila)//fila cheia
                return;

            Random rand = new Random();
            this.clientes[this.tamanhoUtil++] = new Cliente(new Stress(new Point(-this.tamanhoUtil*(LARGURA_NPC+2), 215 - ALTURA_NPC - 5), new Point(LARGURA_NPC / 2, ALTURA_NPC / 2)), 
                                                (rand.Next(0, 100) >65 )?true:false, Image.FromFile(Jogo.DEFAULT_IMAGES[1] + "NPC" + rand.Next(2, 11) + ".png"), new Point(-this.tamanhoUtil * (LARGURA_NPC + 2), 215));
        }

        public int limiteParaIndice(int index)
        {
            return this.limite.X - (LARGURA_NPC + 2)*index;
        }

        public FilaCliente(Cliente[] novosClientes, Point novoLimite)
        {
            this.clientes = novosClientes;
            this.limite = novoLimite;
            this.tamanhoUtil = this.PrimeiroEspacoVazio-1;
        }
    }
}
