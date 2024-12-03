using tabuleiro;

namespace xadrez{
    class Tela{
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro){
            for(int i = 0; i < tabuleiro.Linha; i++){
                Console.Write($"{8-i} ");
                for(int j = 0; j < tabuleiro.Coluna; j++){
                    Peca? peca = tabuleiro.PegarPeca(i,j);
                    ImprimirPeca(peca);   
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,]? posicoesPossiveis){
            ConsoleColor backgroundOriginal = Console.BackgroundColor;
            ConsoleColor backgroundMovimento = ConsoleColor.DarkGray;
            for(int i = 0; i < tabuleiro.Linha; i++){
                Console.Write($"{8-i} ");
                for(int j = 0; j < tabuleiro.Coluna; j++){
                    if(posicoesPossiveis!=null && posicoesPossiveis[i,j]){
                        Console.BackgroundColor = backgroundMovimento;
                    }
                    else{
                        Console.BackgroundColor = backgroundOriginal;
                    }
                    Peca? peca = tabuleiro.PegarPeca(i,j);
                    ImprimirPeca(peca);   
                    Console.BackgroundColor = backgroundOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = backgroundOriginal;
        }

        public static void ImprimirPeca(Peca? peca){
            if(peca == null){
                Console.Write("- ");
            }
            else {
                if(peca.Cor == Cor.Branca){
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez(){
            string input = Console.ReadLine() ?? "";
            char coluna = input[0];
            int linha = int.Parse(input[1]+"");
            return new PosicaoXadrez(coluna,linha);
        }
    }
}