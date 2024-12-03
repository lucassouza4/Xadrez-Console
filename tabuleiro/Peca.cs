namespace tabuleiro{
    class Peca(Posicao posicao, Cor cor, Tabuleiro tabuleiro){
        public Posicao Posicao {get;set;} = posicao;
        public Cor Cor {get;protected set;} = cor;
        public int Movimentos {get;protected set;} = 0;
        public Tabuleiro Tabuleiro {get;protected set;} = tabuleiro;
    }
}