using tabuleiro;

namespace xadrez{
    class Program{
        public static void Main(){
            Tabuleiro tab = new(8,8);

            tab.ColocarPeca(new Rei(tab,Cor.Branca),new(0,0));

            Tela.ImprimirTabuleiro(tab);
        }
    }
}