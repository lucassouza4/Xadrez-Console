using tabuleiro;

namespace xadrez{
    class PosicaoXadrez(char coluna, int linha){
        public char Coluna {get;set;} = coluna;
        public int Linha {get;set;} = linha;

        public Posicao ToPosicao(){
            return new Posicao(8-Linha,Coluna-'a');
        }
        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}