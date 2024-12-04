using tabuleiro;

namespace xadrez{
    class Peao(Tabuleiro tabuleiro, Cor cor):Peca(tabuleiro,cor){

        private bool ExisteInimigo(Posicao pos){
            Peca? p = Tabuleiro.PegarPeca(pos);
            return p != null && p.Cor != Cor;
        }
        private bool Livre(Posicao pos){
            return Tabuleiro.PegarPeca(pos) == null;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linha,Tabuleiro.Coluna];
            if (Tabuleiro == null)
            {
                throw new TabuleiroException("O tabuleiro não pode ser nulo!");
            }
            
            if(Posicao != null){
                if(Cor == Cor.Branca){
                    //acima
                    Posicao pos = new(Posicao.Linha - 1, Posicao.Coluna);
                    if(Tabuleiro.PosicaoValida(pos) && Livre(pos)){
                        mat[pos.Linha,pos.Coluna] = true;
                    }
                    pos = new(Posicao.Linha - 2, Posicao.Coluna);
                    if(Tabuleiro.PosicaoValida(pos) && Livre(pos) && Movimentos == 0){
                        mat[pos.Linha,pos.Coluna] = true;
                    }
                    //diagonal superior direita
                    pos = new(Posicao.Linha - 1, Posicao.Coluna + 1);
                    if(Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)){
                        mat[pos.Linha,pos.Coluna] = true;
                    }
                    //diagona superior esquerda
                    pos = new(Posicao.Linha - 1 , Posicao.Coluna - 1);
                    if(Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)){
                        mat[pos.Linha,pos.Coluna] = true;
                    }
                }
                else{
                    //acima
                    Posicao pos = new(Posicao.Linha + 1, Posicao.Coluna);
                    if(Tabuleiro.PosicaoValida(pos) && Livre(pos)){
                        mat[pos.Linha,pos.Coluna] = true;
                    }
                    pos = new(Posicao.Linha + 2, Posicao.Coluna);
                    if(Tabuleiro.PosicaoValida(pos) && Livre(pos) && Movimentos == 0){
                        mat[pos.Linha,pos.Coluna] = true;
                    }
                    //diagonal inferior direita
                    pos = new(Posicao.Linha + 1, Posicao.Coluna - 1);
                    if(Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)){
                        mat[pos.Linha,pos.Coluna] = true;
                    }
                    //diagona inferior esquerda
                    pos = new(Posicao.Linha + 1 , Posicao.Coluna + 1);
                    if(Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)){
                        mat[pos.Linha,pos.Coluna] = true;
                    }
                }
            }
            return mat;

        }

        public override string ToString()
        {
            return "P";
        }
    }
}