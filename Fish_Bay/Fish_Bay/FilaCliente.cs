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
            MAXIMO_FILA = 10, 
            ALTURA_NPC = 56,
            NPC_ANDAR_FRENTE = 1,
            NPC_ANDAR_TRAS = -1;

        private Cliente[] clientes;
        private Point limite;
        private bool primeira = true;
        private int tam ;

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

        public int TamanhoFila
        {
            get
            {
                return clientes.Length;
            }
        }

        public Cliente Primeiro
        {
            get
            {
                return clientes[tam];
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

        public FilaCliente(Cliente[] novosClientes, Point novoLimite)
        {
            this.Clientes = novosClientes;
            this.Limite = novoLimite;
        }

        // este construtor deverá sumir
        public FilaCliente(Cliente[] novosClientes, Point novoLimite, int tama)
        {
            this.Clientes = novosClientes;
            this.Limite = novoLimite;
            this.tam = tama;
        }

        public void andar()
        {
            for (int i = 0; i < clientes.Length; i++)
                if(this.clientes[i].PodeAndar)
                if (this.clientes[i].Coord.X < this.limite.X) this.clientes[i].andar(NPC_ANDAR_FRENTE);
                else this.limite = new Point(this.limite.X - LARGURA_NPC, 0);
        }

        public bool querPeixe()
        {
            for (int i = 0; i < clientes.Length; i++)
                if (this.clientes[i].QuerPeixe)
                    return true;
            return false;
        }

        // faz o NPC sair da fila de espera por motivos adversos
        public void sair(int indice)
        {
            for (int i = 0; i < tam-1; i++)
            {
                clientes[i] = clientes[i + 1];
            }
            tam--;

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
            clientes[acharPrimeiroVazio()] = new Cliente(new Stress(new Point(-500, 215 - ALTURA_NPC - 5), new Point(LARGURA_NPC / 2, ALTURA_NPC / 2)), 
                                                         false, Image.FromFile("../../../../imagens/NPCs/" + "NPC" + rand.Next(2, 11) + ".png"), new Point(-500, 215));
        }

        // apenas esta classe irá utilizar-se dessa função
        protected int acharPrimeiroVazio()
        {
            for (int i = 0; i > TamanhoFila; i++)
            {
                if (clientes[i] == null)
                    return i;
            }
            return MAXIMO_FILA;
        }
    }
}
