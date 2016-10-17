# Fish Bay
O jogo **Fish Bay** é o mais novo jogo de pesca que está finalizado.

## Desenvolvedores
Os desenvolvedores do projeto são: Daniel Campioni, Pedro Pezoa e Régis Gabetta. Não há funções definidas para cada um pois todos podem ajudar em qualquer coisa!

## História
A ideia surgiu quando foi proposto um jogo para a matéria de Sistemas Operacionais com o objetivo de simular um sistema operacional, os desenvolvedores do jogo se basearam no Club Penguin e em Sistemas Operacionais.

## Simulação
Em um sistema operacional há processos com mais importância do que outros(clientes VIPs) e assim eles são atendidos primeiro.<br>
O <i>Quantum</i> é, no caso, o stress do cliente, pois também é um limite de tempo.<br>
Como o jogo tem 2 jogadores operando ao mesmo tempo também é possível fazer uma analogia com <i>threads</i>.<br>
Se o usuário que está pescando não realizar a sua tarefa principal(pescar), não haverá peixes para serem vendidos, assim gerando um <i>Dead Lock</i>. Do mesmo modo, o jogador que está vendendo os peixes pode não vender os peixes ao cliente, gerando outro <i>Dead Lock</i>.

## Linguagens
Neste projeto foi utilizada a linguagem C# para programar o jogo em si e os dados são salvos no SQL Server Database.

## Como jogar?
Primeiro é necessário [baixar](https://github.com/CampioniMan/FishBay/archive/dev.zip) o jogo e depois executar o arquivo com a extensão ".exe" que estará disponível.
O jogo é em multiplayer cooperativo local e um dos jogadores terá de pescar peixes para serem vendidos pelo outro jogador sem deixar os seus clientes desistirem de comprar o seu produto de tanto esperar.

## Previsão
O jogo está previsto para ser lançado (versão oficial) no dia 14/10/2016, sem modificações futuras.

## Tabelas do BD

<table>
  <tr>
    <th colspan="5">Recordes</th>
  </tr>
  <tr>
    <td>codRec</td>
    <td>NomeJog</td>
    <td>pontos</td>
    <td>peixes</td>
    <td>dourados</td>
  </tr>
  <tr>
    <td>Conterá o ID do recorde</td>
    <td>Conterá o nome do dono do recorde</td>
    <td>Irá conter quantos pontos foram feitos</td>
    <td>Conterá a quantidade de peixes que foram pescados no total</td>
    <td>Irá conter quantos peixes dourados foram pescados</td>
  </tr>
</table>
