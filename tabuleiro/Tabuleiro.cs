namespace tabuleiro{
    class Tabuleiro(int linha, int coluna){
        public int Linha {get;set;} = linha;
        public int Coluna {get;set;} = coluna;
        private Peca[,] Pecas = new Peca[linha, coluna];

        public Peca PegarPeca(int linha, int coluna){
            return Pecas[linha,coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos){
            Pecas[pos.Linha,pos.Coluna] = p;
            p.Posicao = pos;
        }
    }
}