using tabuleiro;

namespace xadrez{
    class PartidaXadrez{
        private int Turno;
        private Cor JogadorAtual;
        public Tabuleiro Tabuleiro {get;private set;}
        public bool Terminada {get;private set;}

        public PartidaXadrez(){
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Tabuleiro = new Tabuleiro(8,8);
            Terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino){
            Peca? p = Tabuleiro.RetirarPeca(origem);
            p?.IncrementarMovimento();
            Peca? pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p,destino);
        }

        private void ColocarPecas(){
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Branca),new PosicaoXadrez('c',1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Branca),new PosicaoXadrez('c',2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Branca),new PosicaoXadrez('d',2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Branca),new PosicaoXadrez('e',2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Branca),new PosicaoXadrez('e',1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro,Cor.Branca),new PosicaoXadrez('d',1).ToPosicao());

            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Preta),new PosicaoXadrez('c',7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Preta),new PosicaoXadrez('c',8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Preta),new PosicaoXadrez('d',7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Preta),new PosicaoXadrez('e',7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Preta),new PosicaoXadrez('e',8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro,Cor.Preta),new PosicaoXadrez('d',8).ToPosicao());
        }
    }
}