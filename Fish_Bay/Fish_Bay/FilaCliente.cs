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
                if (this.clientes[i].PodeAndar(this.limite.X))
                    this.clientes[i].andar(NPC_ANDAR_FRENTE);
                else
                    this.limite = new Point(this.limite.X - LARGURA_NPC, 0);
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
            if (indice > MAXIMO_FILA) // indice inválido
                return;

            for (int i = indice; i < clientes.Length - 1; i++)
            {
                clientes[i] = clientes[i + 1];
            }
            retirarUltimo();
        }

        protected void retirarUltimo()
        {
            this.clientes[this.tamanhoUtil--] = null;
        }

        // faz o PRIMEIRO NPC sair da fila de espera porque ganhou um peixe
        public void sairPrimeiro()
        {
            this.sair(0);
        }

        // entra um personagem randômico na fila
        public void entrarRandomico()
        {
            if (MAXIMO_FILA >= this.TamanhoFila)//fila cheia
                return;

            Random rand = new Random();
            this.clientes[this.tamanhoUtil++] = new Cliente(new Stress(new Point(-500, 215 - ALTURA_NPC - 5), new Point(LARGURA_NPC / 2, ALTURA_NPC / 2)), 
                                                         false, Image.FromFile(Jogo.DEFAULT_IMAGES[0] + "NPC" + rand.Next(2, 11) + ".png"), new Point(-500, 215));
        }

        public FilaCliente(Cliente[] novosClientes, Point novoLimite)
        {
            this.clientes = novosClientes;
            this.limite = novoLimite;
            this.tamanhoUtil = this.PrimeiroEspacoVazio-1;
        }
    }
}
