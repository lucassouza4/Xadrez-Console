using tabuleiro;
using xadrez;

namespace xadrezConsole{
    class Program{
        public static void Main(){
            PartidaXadrez partida = new();
            while(!partida.Terminada){
                try
                {   
                    Console.Clear();
                    Tela.ImprimirPartida(partida);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarOrigem(origem);
                    
                    Console.Clear();
                    bool[,]? posicoesPossiveis = partida.Tabuleiro.PegarPeca(origem)?.MovimentosPossiveis();  
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarDestino(origem,destino);

                    partida.RealizarJogada(origem,destino);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Tela.ImprimirPartida(partida);
        }
    }
}