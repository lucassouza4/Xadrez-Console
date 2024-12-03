using tabuleiro;

namespace xadrez{
    class Tela{
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro){
            for(int i = 0; i < tabuleiro.Linha; i++){
                Console.Write($"{8-i} ");
                for(int j = 0; j < tabuleiro.Coluna; j++){
                    Peca peca = tabuleiro.PegarPeca(i,j);
                    if(peca == null){
                        Console.Write("- ");
                    }
                    else{
                        ImprimirPeca(tabuleiro.PegarPeca(i,j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca){
            if(peca.Cor == Cor.Branca){
                Console.Write(peca);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}