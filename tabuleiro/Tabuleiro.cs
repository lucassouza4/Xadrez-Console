namespace tabuleiro{
    class Tabuleiro(int linha, int coluna){
        public int Linha {get;set;} = linha;
        public int Coluna {get;set;} = coluna;
        private Peca[,] Pecas = new Peca[linha, coluna];

        public Peca GetPeca(int linha, int coluna){
            return Pecas[linha,coluna];
        }
    }
}