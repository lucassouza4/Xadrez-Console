using tabuleiro;

namespace xadrez{
    class PartidaXadrez{

        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public int Turno {get;private set;}
        public Cor JogadorAtual {get;private set;}
        public Tabuleiro Tabuleiro {get;private set;}
        public bool Terminada {get;private set;}

        public PartidaXadrez(){
            Pecas = [];
            Capturadas = [];
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Tabuleiro = new Tabuleiro(8,8);
            Terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino){
            Peca? p = Tabuleiro.RetirarPeca(origem);
            if(p != null){
                p.IncrementarMovimento();
                Peca? pecaCapturada = Tabuleiro.RetirarPeca(destino);
                Tabuleiro.ColocarPeca(p,destino);
                if(pecaCapturada != null){
                    Capturadas.Add(pecaCapturada);
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
            ExecutaMovimento(origem,destino);
            Turno++;
            MudaJogador();
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
            if(p != null && !p.PodeMoverPara(destino)){
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void MudaJogador(){
            if(JogadorAtual == Cor.Branca){
                JogadorAtual = Cor.Preta;
            }else{
                JogadorAtual = Cor.Branca;
            }
        }

        public void ColocarNovaPeca(char coluna,int linha, Peca peca){
            Tabuleiro.ColocarPeca(peca,new PosicaoXadrez(coluna,linha).ToPosicao());
            Pecas.Add(peca);
        }
        private void ColocarPecas(){
            ColocarNovaPeca('c',1,new Torre(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('c',2,new Torre(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('d',2,new Torre(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('e',2,new Torre(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('e',1,new Torre(Tabuleiro,Cor.Branca));
            ColocarNovaPeca('d',1,new Rei(Tabuleiro,Cor.Branca));

            ColocarNovaPeca('c',7,new Torre(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('c',8,new Torre(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('d',7,new Torre(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('e',7,new Torre(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('e',8,new Torre(Tabuleiro,Cor.Preta));
            ColocarNovaPeca('d',8,new Rei(Tabuleiro,Cor.Preta));
        }
    }
}