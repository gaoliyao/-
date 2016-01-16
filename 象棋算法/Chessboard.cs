using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 象棋算法
{
    class Chessboard
    {
        public Chessboard()
        {

        }
        /*     List<ChessBasics> Red;
             List<ChessBasics> Balck;

             public void read()
             {
                 for(int i=0;i<9;i++)
                 {
                     for (int j = 0; j < 10; j++)
                     {
                         if (board[i, j] != 0)
                         { 
                             ChessBasics chess = new ChessBasics(board[i, j], i, j);
                             if (chess.color == 0) Red.Add(chess);
                             if (chess.color == 1) Balck.Add(chess);
                         }
                     }
                 }
             }


             public int current_Basicjudge()
             {
                 int score_red = 0;
                 for(int i=0;i<Red.Count;i++)
                 {
                     score_red=score_red+Red[i].value;
                 }
                 return score_red;
             }

             public int[, ] one_step_thinking_red()
             {
                 int[,] a=  board;
                 return a;
             } 
             */
        public int[,] board = new int[9, 10];
        public bool Player = false;//0为红 1为黑
        public int[] Red_Chessman = new int[16];
        public int[] Black_Chessman = new int[16];
        public Point[] Red_Location = new Point[16];
        public Point[] Black_Location = new Point[16];
        //1.帅 
        //2.士1 
        //3.士2 
        //4.象1 
        //5.象2
        //6.马1 
        //7.马2
        //8.炮1 
        //9.炮2
        //10.车1 
        //11.车2 
        //12.兵1 
        //13.兵2 
        //14.兵3 
        //15.兵4 
        //16.兵5 


        public void init()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = Value.Start[i, j];
                }
            }
        }

        public int index_number(int termini)
        {
            int who = termini / 10;
            int number = termini % 10;
            int index = 0;
            if (who == 1)
            {
                index = 0;
            }
            else if (who == 2)
            {
                index = number;
            }
            else if (who == 3)
            {
                index = 2 + number;
            }
            else if (who == 3)
            {
                index = 4 + number;
            }
            else if (who == 5)
            {
                index = 6 + number;
            }
            else if (who == 6)
            {
                index = 8 + number;
            }
            else if (who == 7)
            {
                index = 10 + number;
            }
            return index;
        }

        public void move_ptop(int x,int y,int a,int b)
        {
            if (a >= 0 && a < 10 && b >= 0 && b < 9)
            {
                int current = board[x, y];
                int termini = board[a, b];
                int index = -1;
                int player = Convert.ToInt16(Player);
                if (termini == 0) ;
                else
                {
                    index = index_number(termini);
                    if (player == 0)
                    {
                        Red_Chessman[index] = -1;
                        Red_Location[index] = new Point(-1, -1);
                    }
                    if (player == 1)
                    {
                        Black_Chessman[index] = -1;
                        Black_Location[index] = new Point(-1, -1);
                    }
                }
                board[a, b] = current;
                board[x, y] = 0;
            }
        }
            /*
            int score_red;
            */
        
    }
}
