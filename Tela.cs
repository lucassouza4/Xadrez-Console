using tabuleiro;

namespace xadrez{
    class Tela{
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro){
            for(int i = 0; i < tabuleiro.Linha; i++){
                Console.Write($"{8-i} ");
                for(int j = 0; j < tabuleiro.Coluna; j++){
                    Peca? peca = tabuleiro.PegarPeca(i,j);
                    if(peca == null){
                        Console.Write("- ");
                    }
                    else{
                        ImprimirPeca(peca);
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

        public static PosicaoXadrez LerPosicaoXadrez(){
            string input = Console.ReadLine() ?? "";
            char coluna = input[0];
            int linha = int.Parse(input[1]+"");
            return new PosicaoXadrez(coluna,linha);
        }
    }
}