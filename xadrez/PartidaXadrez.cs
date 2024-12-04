using tabuleiro;

namespace xadrez{
    class PartidaXadrez{

        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque {get;private set;}
        public int Turno {get;private set;}
        public Cor JogadorAtual {get;private set;}
        public Tabuleiro Tabuleiro {get;private set;}
        public bool Terminada {get;private set;}
        
        public PartidaXadrez(){
            Pecas = [];
            Capturadas = [];
            Xeque = false;
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Tabuleiro = new Tabuleiro(8,8);
            Terminada = false;
            ColocarPecas();
        }
        public Peca? ExecutaMovimento(Posicao origem, Posicao destino){
            Peca? p = Tabuleiro.RetirarPeca(origem);
            if(p != null){
                p.IncrementarMovimento();
                Peca? pecaCapturada = Tabuleiro.RetirarPeca(destino);
                Tabuleiro.ColocarPeca(p,destino);
                if(pecaCapturada != null){
                    Capturadas.Add(pecaCapturada);
                    return pecaCapturada;
                }
            }
            return null;
        }
        public void DesfazerMovimento(Posicao origem, Posicao destino, Peca? pecaCapturada){
            Peca? p = Tabuleiro.RetirarPeca(destino);
            if(p != null){
                p.DecrementarMovimento();
                Tabuleiro.ColocarPeca(p,origem);
                if(pecaCapturada != null){
                    Tabuleiro.ColocarPeca(pecaCapturada,destino);
                    Capturadas.Remove(pecaCapturada);
                }
            }
        }
        public HashSet<Peca> PecasCapturadas(Cor cor){
            HashSet<Peca> aux = [];
            foreach(Peca p in Capturadas){
                if(p.Cor == cor) aux.Add(p);
            }

            return aux;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor){
            HashSet<Peca> aux = [];
            foreach(Peca p in Pecas){
                if(p.Cor == cor) aux.Add(p);
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        public void RealizarJogada(Posicao origem, Posicao destino){
            Peca? p = ExecutaMovimento(origem,destino);

            if(EstaEmXeque(JogadorAtual)){
                DesfazerMovimento(origem,destino,p);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            if(EstaEmXeque(Adversario(JogadorAtual))){
                Xeque = true;
            }
            else {
                Xeque = false;
            }
            if(XequeMate(Adversario(JogadorAtual))){
                Terminada = true;
            }
            else{
                Turno++;
                MudaJogador();
            }
        }
        public bool XequeMate(Cor cor){
            if(!EstaEmXeque(cor)){
                return false;
            }
            foreach(Peca p in PecasEmJogo(cor)){
                bool[,] aux = p.MovimentosPossiveis();
                for(int i = 0; i < Tabuleiro.Linha; i++){
                    for(int j = 0; j < Tabuleiro.Coluna; j++){
                        if(aux[i,j] && p.Posicao != null){
                            Posicao origem = p.Posicao;
                            Posicao destino = new(i,j);
                            Peca? pecaCapturada = ExecutaMovimento(origem,destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazerMovimento(origem,destino,pecaCapturada);
                            if(!testeXeque){
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void ValidarOrigem(Posicao pos){
            Peca? p = Tabuleiro.PegarPeca(pos);
            if(p == null){
                throw new TabuleiroException("Não existe peça na posição de origem!");
            }
            else if(JogadorAtual != p.Cor){
                throw new TabuleiroException("Peça de origem não pertence ao jogador!");
            }
            else if(!p.ExisteMovimentosPossiveis()){
                throw new TabuleiroException("Não há movimentos disponíveis para a peça de origem escolhida!");
            }
        }
        public void ValidarDestino(Posicao origem, Posicao destino){
            Peca? p = Tabuleiro.PegarPeca(origem);
            if(p != null && !p.MovimentoPossivel(destino)){
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        public void ColocarNovaPeca(char coluna,int linha, Peca peca){
            Tabuleiro.ColocarPeca(peca,new PosicaoXadrez(coluna,linha).ToPosicao());
            Pecas.Add(peca);
        }
        public bool EstaEmXeque(Cor cor){
            Peca? r = EncontrarRei(cor);
            if(r == null) {
                throw new TabuleiroException($"Não há rei da cor {cor} no taboleiro!");
            }
            foreach(Peca p in PecasEmJogo(Adversario(cor))){
                if(r.Posicao != null){
                    bool[,] aux = p.MovimentosPossiveis();
                    if(aux[r.Posicao.Linha,r.Posicao.Coluna]){
                        return true;
                    }
                }
            }
            return false;
        }
        private Peca? EncontrarRei(Cor cor){
            foreach(Peca p in PecasEmJogo(cor)){
                if(p is Rei){
                    return p;
                }
            }
            return null;
        }
        private static Cor Adversario(Cor cor){
            if(cor == Cor.Branca) return Cor.Preta;
            return Cor.Branca;
        }
        private void MudaJogador(){
            if(JogadorAtual == Cor.Branca){
                JogadorAtual = Cor.Preta;
            }else{
                JogadorAtual = Cor.Branca;
            }
        }
        private void ColocarPecas(){

            ColocarNovaPeca('a',1,new Torre(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('b',1,new Cavalo(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('c',1,new Bispo(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('d',1,new Rei(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('e',1,new Dama(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('f',1,new Bispo(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('g',1,new Cavalo(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('h',1,new Torre(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('a',2,new Peao(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('b',2,new Peao(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('c',2,new Peao(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('d',2,new Peao(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('e',2,new Peao(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('f',2,new Peao(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('g',2,new Peao(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('h',2,new Peao(Tabuleiro,Cor.Branca));

            ColocarNovaPeca('a',8,new Torre(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('b',8,new Cavalo(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('c',8,new Bispo(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('d',8,new Rei(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('e',8,new Dama(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('f',8,new Bispo(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('g',8,new Cavalo(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('h',8,new Torre(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('a',7,new Peao(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('b',7,new Peao(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('c',7,new Peao(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('d',7,new Peao(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('e',7,new Peao(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('f',7,new Peao(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('g',7,new Peao(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('h',7,new Peao(Tabuleiro,Cor.Preta));
        }
    }
}