using tabuleiro;

namespace xadrez{
    class Torre(Tabuleiro tabuleiro, Cor cor):Peca(tabuleiro,cor){
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linha,Tabuleiro.Coluna];
            
            if(Posicao != null){
                //acima
                Posicao pos = new(Posicao.Linha - 1, Posicao.Coluna);
                while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                    if(Tabuleiro.PegarPeca(pos) != null && Tabuleiro.PegarPeca(pos)?.Cor != Cor){
                        break;
                    }
                    pos.Linha -= 1;
                }
                //abaixo
                pos = new(Posicao.Linha + 1, Posicao.Coluna);
                while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                    if(Tabuleiro.PegarPeca(pos) != null && Tabuleiro.PegarPeca(pos)?.Cor != Cor){
                        break;
                    }
                    pos.Linha += 1;
                }
                //direita
                pos = new(Posicao.Linha, Posicao.Coluna + 1);
                while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                    if(Tabuleiro.PegarPeca(pos) != null && Tabuleiro.PegarPeca(pos)?.Cor != Cor){
                        break;
                    }
                    pos.Coluna += 1;
                }
                //esquerda
                pos = new(Posicao.Linha, Posicao.Coluna - 1);
                while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                    mat[pos.Linha,pos.Coluna] = true;
                    if(Tabuleiro.PegarPeca(pos) != null && Tabuleiro.PegarPeca(pos)?.Cor != Cor){
                        break;
                    }
                    pos.Coluna -= 1;
                }
                
            }
            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}