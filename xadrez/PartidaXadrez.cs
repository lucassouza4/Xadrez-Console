using tabuleiro;

namespace xadrez{
    class PartidaXadrez{
        public int Turno {get;private set;}
        public Cor JogadorAtual {get;private set;}
        public Tabuleiro Tabuleiro {get;private set;}
        public bool Terminada {get;private set;}

        public PartidaXadrez(){
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Tabuleiro = new Tabuleiro(8,8);
            Terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino){
            Peca? p = Tabuleiro.RetirarPeca(origem);
            p?.IncrementarMovimento();
            Peca? pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p,destino);
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

        private void ColocarPecas(){
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Branca),new PosicaoXadrez('c',1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Branca),new PosicaoXadrez('c',2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Branca),new PosicaoXadrez('d',2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Branca),new PosicaoXadrez('e',2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Branca),new PosicaoXadrez('e',1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro,Cor.Branca),new PosicaoXadrez('d',1).ToPosicao());

            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Preta),new PosicaoXadrez('c',7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Preta),new PosicaoXadrez('c',8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Preta),new PosicaoXadrez('d',7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Preta),new PosicaoXadrez('e',7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro,Cor.Preta),new PosicaoXadrez('e',8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro,Cor.Preta),new PosicaoXadrez('d',8).ToPosicao());
        }
    }
}