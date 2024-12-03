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
        public abstract bool[,] MovimentosPossiveis();
    }
}