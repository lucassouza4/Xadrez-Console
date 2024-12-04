using tabuleiro;

namespace xadrez{
    class Cavalo(Tabuleiro tabuleiro, Cor cor):Peca(tabuleiro,cor){
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linha,Tabuleiro.Coluna];
            if (Tabuleiro == null)
            {
                throw new TabuleiroException("O tabuleiro não pode ser nulo!");
            }
            
            if(Posicao != null){
                
                Posicao pos = new(Posicao.Linha - 1, Posicao.Coluna - 2);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                
                pos = new(Posicao.Linha - 2, Posicao.Coluna - 1);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                
                pos = new(Posicao.Linha - 2 , Posicao.Coluna + 1);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                
                pos = new(Posicao.Linha - 1, Posicao.Coluna + 2);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                
                pos = new(Posicao.Linha + 1, Posicao.Coluna + 2);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                
                pos = new(Posicao.Linha + 2, Posicao.Coluna + 1);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                //esquerda
                pos = new(Posicao.Linha + 2, Posicao.Coluna - 1);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
                
                pos = new(Posicao.Linha + 1 , Posicao.Coluna - 2);
                if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                }
            }
            return mat;

        }

        public override string ToString()
        {
            return "C";
        }
    }
}