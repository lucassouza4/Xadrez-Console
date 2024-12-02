using tabuleiro;

namespace xadrez{
    class Program{
        public static void Main(){
            Tabuleiro t = new(8,8);

            Tela.ImprimirTabuleiro(t);
        }
    }
}