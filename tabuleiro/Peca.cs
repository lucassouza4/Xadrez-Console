namespace tabuleiro{
    abstract class Peca(Tabuleiro tabuleiro, Cor cor){
        public Posicao? Posicao {get;set;} = null;
        public Cor Cor {get;protected set;} = cor;
        public int Movimentos {get;protected set;} = 0;
        public Tabuleiro Tabuleiro {get;protected set;} = tabuleiro;

        public void IncrementarMovimento(){
            Movimentos++;
        }

        public virtual bool PodeMover(Posicao pos){
            Peca? p = Tabuleiro.PegarPeca(pos);
            return p == null || p.Cor != Cor;
        }

        public bool PodeMoverPara(Posicao pos){
            return MovimentosPossiveis()[pos.Linha,pos.Coluna];
        }

        public bool ExisteMovimentosPossiveis(){
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i < Tabuleiro.Linha; i++){
                for(int j = 0; j < Tabuleiro.Coluna; j++){
                    if(mat[i,j]){
                        return true;
                    }
                }
            }
            return false;
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}