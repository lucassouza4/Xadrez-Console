namespace tabuleiro{
    class Posicao(int linha, int coluna){
        public int Linha {get;set;} = linha;
        public int Coluna {get;set;} = coluna;

        public override string ToString()
        {
            return "Posição: " + Linha + "," + Coluna;
        }
    }
}