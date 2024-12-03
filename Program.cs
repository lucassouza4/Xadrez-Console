using tabuleiro;

namespace xadrez{
    class Program{
        public static void Main(){
            try
            {
                Tabuleiro tab = new(8,8);

                tab.ColocarPeca(new Rei(tab,Cor.Branca),new(0,0));
                tab.ColocarPeca(new Torre(tab,Cor.Branca),new(2,4));

                Tela.ImprimirTabuleiro(tab); 
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}