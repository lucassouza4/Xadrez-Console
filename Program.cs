using tabuleiro;

namespace xadrez{
    class Program{
        public static void Main(){
            try
            {
                PartidaXadrez partida = new();
                
                while(!partida.Terminada){
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    
                    Console.Clear();
                    bool[,]? posicoesPossiveis = partida.Tabuleiro.PegarPeca(origem)?.MovimentosPossiveis();  
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem,destino);
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}