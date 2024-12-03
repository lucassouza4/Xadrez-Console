using tabuleiro;

namespace xadrez{
    class Tela{
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro){
            for(int i = 0; i < tabuleiro.Linha; i++){
                for(int j = 0; j < tabuleiro.Coluna; j++){
                    Peca peca = tabuleiro.PegarPeca(i,j);
                    if(peca == null){
                        Console.Write("- ");
                    }
                    else{
                        Console.Write($"{tabuleiro.PegarPeca(i,j)} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}