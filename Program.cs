using System;

namespace BatalhaNaval
{
    class Program
    {
        static char[,] tabuleiroJogador1 = new char[10, 10];
        static char[,] tabuleiroJogador2 = new char[10, 10];
        static int barcosJogador1 = 5;
        static int barcosJogador2 = 5;

        static void Main(string[] args)
        {
            InicializarTabuleiros();

            while (barcosJogador1 > 0 && barcosJogador2 > 0)
            {
                Console.Clear();
                Console.WriteLine("Batalha Naval - Jogador 1 vs Jogador 2");
                Console.WriteLine("======================================\n");

                ExibirTabuleiro(tabuleiroJogador1);
                Console.WriteLine("Placar: Jogador 1: " + barcosJogador1 + " Jogador 2: " + barcosJogador2);

                Console.WriteLine("Jogador 1, faça sua jogada (linha coluna):");
                FazerJogada(tabuleiroJogador2, tabuleiroJogador1);

                if (barcosJogador2 <= 0)
                {
                    Console.Clear();
                    ExibirTabuleiro(tabuleiroJogador1);
                    Console.WriteLine("Placar: Jogador 1: " + barcosJogador1 + " Jogador 2: " + barcosJogador2);
                    Console.WriteLine("Jogador 1 venceu!");
                    break;
                }

                Console.Clear();
                Console.WriteLine("Batalha Naval - Jogador 1 vs Jogador 2");
                Console.WriteLine("======================================\n");

                ExibirTabuleiro(tabuleiroJogador2);
                Console.WriteLine("Placar: Jogador 1: " + barcosJogador1 + " Jogador 2: " + barcosJogador2);

                Console.WriteLine("Jogador 2, faça sua jogada (linha coluna):");
                FazerJogada(tabuleiroJogador1, tabuleiroJogador2);

                if (barcosJogador1 <= 0)
                {
                    Console.Clear();
                    ExibirTabuleiro(tabuleiroJogador2);
                    Console.WriteLine("Placar: Jogador 1: " + barcosJogador1 + " Jogador 2: " + barcosJogador2);
                    Console.WriteLine("Jogador 2 venceu!");
                    break;
                }
            }
        }

        static void InicializarTabuleiros()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tabuleiroJogador1[i, j] = ' ';
                    tabuleiroJogador2[i, j] = ' ';
                }
            }

            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                int linha, coluna;
                do
                {
                    linha = random.Next(10);
                    coluna = random.Next(10);
                } while (tabuleiroJogador1[linha, coluna] == 'B');

                tabuleiroJogador1[linha, coluna] = 'B';

                do
                {
                    linha = random.Next(10);
                    coluna = random.Next(10);
                } while (tabuleiroJogador2[linha, coluna] == 'B');

                tabuleiroJogador2[linha, coluna] = 'B';
            }
        }

        static void ExibirTabuleiro(char[,] tabuleiro)
        {
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 10; j++)
                {
                    if (tabuleiro[i, j] == ' ')
                        Console.Write("- ");
                    else if (tabuleiro[i, j] == 'X')
                        Console.Write("X ");
                    else if (tabuleiro[i, j] == 'O')
                        Console.Write("O ");
                    else if (tabuleiro[i, j] == 'B')
                        Console.Write("- ");
                }
                Console.WriteLine();
            }
        }

        static void FazerJogada(char[,] tabuleiro, char[,] tabuleiroAdversario)
        {
            int linha = -1;
            int coluna = -1;

            do
            {
                try
                {
                    string[] jogada = Console.ReadLine().Split(' ');
                    linha = int.Parse(jogada[0]);
                    coluna = int.Parse(jogada[1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Jogada inválida. Use o formato 'linha coluna'.");
                }

                if (linha < 0 || linha > 9 || coluna < 0 || coluna > 9)
                {
                    Console.WriteLine("Jogada fora dos limites do tabuleiro. Tente novamente.");
                }
                else if (tabuleiro[linha, coluna] == 'X' || tabuleiro[linha, coluna] == 'O')
                {
                    Console.WriteLine("Você já fez essa jogada. Tente novamente.");
                }
                else
                {
                    if (tabuleiroAdversario[linha, coluna] == 'B')
                    {
                        tabuleiro[linha, coluna] = 'X';
                        tabuleiroAdversario[linha, coluna] = 'X';
                        Console.Clear();
                        Console.WriteLine("Jogada certeira! Você acertou um barco.");
                        if (tabuleiroAdversario == tabuleiroJogador2)
                            barcosJogador2 = barcosJogador2 - 1;
                        else
                            barcosJogador1 = barcosJogador1 - 1;
                    }
                    else
                    {
                        tabuleiro[linha, coluna] = 'O';
                        tabuleiroAdversario[linha, coluna] = 'O';
                        Console.Clear();
                        Console.WriteLine("Tiro na água! Não há barco nesta posição.");
                    }
                }
            } while (linha < 0 || linha > 9 || coluna < 0 || coluna > 9);
        }
    }
}
