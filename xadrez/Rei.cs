using tabuleiro;

namespace xadrez{
    class Rei(Tabuleiro tabuleiro, Cor cor):Peca(tabuleiro,cor){
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linha,Tabuleiro.Coluna];
            if (Tabuleiro == null)
            {
                throw new TabuleiroException("O tabuleiro não pode ser nulo.");
            }
            
            if(Posicao != null){
                //acima
                Posicao pos = new(Posicao.Linha - 1, Posicao.Coluna);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                //diagonal superior direita
                pos = new(Posicao.Linha - 1, Posicao.Coluna + 1);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                //direita
                pos = new(Posicao.Linha, Posicao.Coluna + 1);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                //diagonal inferior direita
                pos = new(Posicao.Linha + 1, Posicao.Coluna + 1);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                //abaixo
                pos = new(Posicao.Linha + 1, Posicao.Coluna);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                //diagona inferior esquerda
                pos = new(Posicao.Linha + 1, Posicao.Coluna - 1);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                //esquerda
                pos = new(Posicao.Linha, Posicao.Coluna - 1);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                //diagona superior esquerda
                pos = new(Posicao.Linha -1 , Posicao.Coluna - 1);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
            }
            return mat;

        }

        public override string ToString()
        {
            return "R";
        }
    }
}