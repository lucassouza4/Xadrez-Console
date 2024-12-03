namespace tabuleiro{
    class Tabuleiro(int linha, int coluna){
        public int Linha {get;set;} = linha;
        public int Coluna {get;set;} = coluna;
        private Peca?[,] Pecas = new Peca[linha, coluna];

        public Peca? PegarPeca(int linha, int coluna){
            return Pecas[linha,coluna];
        }
        public Peca? PegarPeca(Posicao pos){
            ValidarPosicao(pos);
            return Pecas[pos.Linha,pos.Coluna];
        }
        
        public bool ExistePeca(Posicao pos){
            ValidarPosicao(pos);
            return PegarPeca(pos) != null; 
        }

        public void ColocarPeca(Peca p, Posicao pos){
            if(ExistePeca(pos)) throw new TabuleiroException("Já existe uma peça nessa posição!");
            Pecas[pos.Linha,pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca? RetirarPeca(Posicao pos){
            Peca? aux = PegarPeca(pos);
            if(aux == null){
                return null;
            }
            aux.Posicao = null;
            Pecas[pos.Linha,pos.Coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao pos){
            if(pos.Linha < 0 || pos.Linha >= Linha || pos.Coluna < 0 || pos.Coluna >= Coluna) return false;
            return true;
        }

        public void ValidarPosicao(Posicao pos){
            if(!PosicaoValida(pos)){
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}