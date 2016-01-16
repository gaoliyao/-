using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;


///此类实现对输入棋子位置的识别以及生成走法

///应传入    当前局面

///应传入    需要判断的棋子

///应返回    变换后的局面 List

namespace 象棋算法

{

    ///此类实现对输入棋子位置的识别以及生成走法

    ///应传入    当前局面

    ///应传入    需要判断的棋子

    ///应返回    变换后的局面 List
    class Moves

    {

        ///此类实现对输入棋子位置的识别以及生成走法

        ///应传入    当前局面

        ///应传入    需要判断的棋子

        ///应返回    变换后的局面 List


        public enum chessman

        {

            Shuai = 1,

            Shi = 2,

            Xiang = 3,

            Ma = 4,

            Pao = 5,

            Bing = 6,

            Ju = 7,


        };

        public static int juege_who(int i)

        {

            i = i % 100;

            return i / 10;

        }

        

        public static List<Chessboard> AllMove(Chessboard phase)
        {
            List<Chessboard> All_moves = new List<Chessboard>();
            List<Chessboard> moves = new List<Chessboard>();
            int player = Convert.ToInt16(phase.Player);
            Chessboard remember = new Chessboard();
            remember = phase;
            for(int i=0;i<10;i++)
            {
                for(int j=0;j<9;j++)
                {
                    phase = remember;
                    if (phase.board[i, j] == 0) ;
                    else if (phase.board[i, j] / 100 != player) ;
                    else
                    {
                        moves = Move(phase, i, j);
                        if (moves!=null)
                        All_moves.AddRange(moves); }
                }
            }
            if (All_moves.Count == 0) return null;
            else return All_moves;
        }

        public static List<Chessboard> Move(Chessboard phase, int x, int y)

        {
            int player = Convert.ToInt16(phase.Player);
            if (phase.board[x, y] == 0)

                return null;

            else

            {

                int who = juege_who(phase.board[x, y]);

                if (who == 1)
                {
                    Console.WriteLine("For Red Shuai");
                    if (player == 0) return Red_Move_Shuai(phase, x, y);
                    else return Black_Move_Shuai(phase, x, y);
                }
                else if (who == 2)
                {
                    Console.WriteLine("For Red Shi");
                    if (player == 0) return Red_Move_Shi(phase, x, y);
                    else return Black_Move_Shi(phase, x, y);
                }
                else if (who == 3)
                {
                    Console.WriteLine("For Red Xiang");
                    if (player == 0) return Red_Move_Xiang(phase, x, y);
                    else return Black_Move_Xiang(phase, x, y);
                }
                else if (who == 4)
                {
                    Console.WriteLine("For Red Ma");
                    return Move_Ma(phase, x, y);
                }
                else if (who == 5) return Move_Pao(phase, x, y);
                else if (who == 6) return Move_Ju(phase, x, y);
                else if (who == 7)
                {
                    Console.WriteLine("For Red Bing");
                    if (player == 0) return Red_Move_Bing(phase, x, y);
                    else return Black_Move_Bing(phase, x, y);
                }
                else
                    return null;
            }

        }




        public static bool Xiaable(Chessboard phase, Point point, int oppo)

        {

            if (phase.board[point.x, point.y] == 0)

            {

                return true;

            }

            if (phase.board[point.x, point.y] / 100 == oppo)

            {

                return true;

            }

            return false;

        }


        public static List<Chessboard> Red_Move_Shuai(Chessboard phases, int x, int y)

        {

            List<Chessboard> moves = new List<Chessboard>();

            int current;

            int opponent = Convert.ToInt16(!phases.Player);

            current = phases.board[x, y];



            /************************向上移动*********************************/

            if (y - 1 > 6)

            {

                if (phases.board[x, y - 1] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[x, y] = 0;

                    //new_phase.board[x, y - 1] = current;

                    new_phase.move_ptop(x, y, x, y - 1);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[x, y] / 100 == opponent)                 //吃子

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[x, y] = 0;

                        //new_phase.board[x, y - 1] = current;

                        new_phase.move_ptop(x, y, x, y - 1);

                        moves.Add(new_phase);

                    }

                }

            }

            /************************************************************/


            /************************向下移动*********************************/

            if (y + 1 < 10)

            {

                if (phases.board[x, y + 1] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[x, y] = 0;

                    //new_phase.board[x, y + 1] = current;

                    new_phase.move_ptop(x, y, x, y + 1);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[x, y] / 100 == opponent)                 //吃子

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[x, y] = 0;

                        //new_phase.board[x, y + 1] = current;

                        new_phase.move_ptop(x, y, x, y + 1);

                        moves.Add(new_phase);

                    }

                }

            }

            /************************************************************/


            /************************向左移动*********************************/

            if (x - 1 > 3)

            {

                if (phases.board[x - 1, y] == 0)

                {
                    Chessboard new_phase = phases;

                    //new_phase.board[x, y] = 0;

                    //new_phase.board[x - 1, y] = current;

                    new_phase.move_ptop(x, y, x - 1, y);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[x - 1, y] / 100 == opponent)                 //吃子

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[x, y] = 0;

                        //new_phase.board[x - 1, y] = current;

                        new_phase.move_ptop(x, y, x - 1, y);

                        moves.Add(new_phase);

                    }

                }

            }

            /************************************************************/


            /************************向右移动*********************************/

            if (x + 1 < 7)

            {

                if (phases.board[x + 1, y] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[x, y] = 0;

                    //new_phase.board[x + 1, y] = current;

                    new_phase.move_ptop(x,y,x+1,y);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[x + 1, y] / 100 == opponent)                 //吃子

                    {
                        Chessboard new_phase = phases;

                        //new_phase.board[x, y] = 0;

                        //new_phase.board[x + 1, y] = current;

                        new_phase.move_ptop(x, y, x + 1, y);

                        moves.Add(new_phase);

                    }

                }

            }

            /************************************************************/

            if (moves.Count == 0) return null;

            return moves;

        }           //帅的走法生成

        public static List<Chessboard> Red_Move_Shi(Chessboard phases, int x, int y)

        {

            List<Chessboard> moves = new List<Chessboard>();

            int current;

            int opponent = Convert.ToInt16(!phases.Player);

            current = phases.board[x, y];


            /************************如果在中间*********************************/

            if (y == 8 && x == 4)

            {


                if (phases.board[3, 7] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[x, y] = 0;

                    //new_phase.board[3, 7] = current;

                    new_phase.move_ptop(x, y, 3, 7);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[3, 7] / 100 == opponent)

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[x, y] = 0;

                        //new_phase.board[3, 7] = current;

                        new_phase.move_ptop(x, y, 3, 7);

                        moves.Add(new_phase);

                    }

                }


                if (phases.board[5, 7] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[4, 8] = 0;

                    //new_phase.board[5, 7] = current;

                    new_phase.move_ptop(4, 8, 5, 7);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[5, 7] / 100 == opponent)

                    {
                        Chessboard new_phase = phases;

                        //new_phase.board[4, 8] = 0;

                        //new_phase.board[5, 7] = current;

                        new_phase.move_ptop(4, 5, 5, 7);

                        moves.Add(new_phase);

                    }

                }


                if (phases.board[5, 9] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[4, 8] = 0;

                    //new_phase.board[5, 9] = current;

                    new_phase.move_ptop(4, 8, 6, 9);

                    moves.Add(new_phase);

                }

                else

                {


                    if (phases.board[5, 9] / 100 == opponent)

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[4, 8] = 0;

                        //new_phase.board[5, 9] = current;

                        new_phase.move_ptop(4, 8, 5, 9);

                        moves.Add(new_phase);

                    }

                }


                if (phases.board[3, 9] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[4, 8] = 0;

                    //new_phase.board[3, 9] = current;

                    new_phase.move_ptop(4, 8, 3, 9);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[3, 9] / 100 == opponent)

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[4, 8] = 0;

                        //new_phase.board[3, 9] = current;

                        new_phase.move_ptop(4,8,3,9);

                        moves.Add(new_phase);

                    }

                }


            }

            else

            {

                if (x == 3)

                {

                    if (phases.board[4, 8] == 0)

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[4, 8] = current;

                        //new_phase.board[3, y] = 0;

                        new_phase.move_ptop(3, y, 4, 8);

                        moves.Add(new_phase);

                    }

                    else

                    {

                        if (phases.board[4, 8] / 100 == opponent)

                        {
                            Chessboard new_phase = phases;

                            //new_phase.board[4, 8] = current;

                            //new_phase.board[3, y] = 0;

                            new_phase.move_ptop(3, y, 4, 8);

                            moves.Add(new_phase);

                        }

                    }

                }


                else if (x == 5)

                {

                    if (phases.board[4, 8] == 0)

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[4, 8] = current;

                        //new_phase.board[5, y] = 0;

                        new_phase.move_ptop(5, y, 4, 8);

                        moves.Add(new_phase);

                    }

                    else

                    {

                        if (phases.board[4, 8] / 100 == opponent)

                        {

                            Chessboard new_phase = phases;

                            //new_phase.board[4, 8] = current;

                            //new_phase.board[5, y] = 0;

                            new_phase.move_ptop(5,y,4,8);

                            moves.Add(new_phase);

                        }

                    }

                }

            }

            /************************************************************/



            if (moves.Count == 0) return null;

            return moves;

        }

        public static List<Chessboard> Black_Move_Shuai(Chessboard phases, int x, int y)

        {

            List<Chessboard> moves = new List<Chessboard>();

            int current;

            int opponent = Convert.ToInt16(!phases.Player);

            current = phases.board[x, y];



            /************************向上移动*********************************/

            if (y + 1 < 3)

            {

                if (phases.board[x, y + 1] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[x, y] = 0;

                    //new_phase.board[x, y + 1] = current;

                    new_phase.move_ptop(x, y, x, y + 1);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[x, y] / 100 == opponent)                 //吃子

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[x, y] = 0;

                        //new_phase.board[x, y + 1] = current;

                        new_phase.move_ptop(x, y, x, y + 1);

                        moves.Add(new_phase);

                    }

                }

            }

            /************************************************************/


            /************************向下移动*********************************/

            if (y - 1 > -1)

            {

                if (phases.board[x, y - 1] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[x, y] = 0;

                    //new_phase.board[x, y - 1] = current;

                    new_phase.move_ptop(x, y, x, y - 1);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[x, y] / 100 == opponent)                 //吃子

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[x, y] = 0;

                        //new_phase.board[x, y - 1] = current;

                        new_phase.move_ptop(x, y, x, y - 1);

                        moves.Add(new_phase);

                    }

                }

            }

            /************************************************************/


            /************************向左移动*********************************/

            if (x - 1 > 3)

            {

                if (phases.board[x - 1, y] == 0)

                {
                    Chessboard new_phase = phases;

                    //new_phase.board[x, y] = 0;

                    //new_phase.board[x - 1, y] = current;

                    new_phase.move_ptop(x, y, x - 1, y);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[x - 1, y] / 100 == opponent)                 //吃子

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[x, y] = 0;

                        //new_phase.board[x - 1, y] = current;

                        new_phase.move_ptop(x, y, x - 1, y);

                        moves.Add(new_phase);

                    }

                }

            }

            /************************************************************/


            /************************向右移动*********************************/

            if (x + 1 < 7)

            {

                if (phases.board[x + 1, y] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[x, y] = 0;

                    //new_phase.board[x + 1, y] = current;

                    new_phase.move_ptop(x, y, x + 1, y);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[x + 1, y] / 100 == opponent)                 //吃子

                    {
                        Chessboard new_phase = phases;

                        //new_phase.board[x, y] = 0;

                        //new_phase.board[x + 1, y] = current;

                        new_phase.move_ptop(x, y, x + 1, y);

                        moves.Add(new_phase);

                    }

                }

            }

            /************************************************************/

            if (moves.Count == 0) return null;

            return moves;

        }           //帅的走法生成

        public static List<Chessboard> Black_Move_Shi(Chessboard phases, int x, int y)

        {

            List<Chessboard> moves = new List<Chessboard>();

            int current;

            int opponent = Convert.ToInt16(!phases.Player);

            current = phases.board[x, y];


            /************************如果在中间*********************************/

            if (y == 1 && x == 4)

            {


                if (phases.board[3, 2] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[x, y] = 0;

                    //new_phase.board[3, 2] = current;

                    new_phase.move_ptop(x, y, 3, 2);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[3, 2] / 100 == opponent)

                    {

                        Chessboard new_phase = phases;
                        //new_phase.board[x, y] = 0;

                        //new_phase.board[3, 2] = current;

                        new_phase.move_ptop(x, y, 3, 2);

                        moves.Add(new_phase);

                    }

                }


                if (phases.board[5, 2] == 0)

                {

                    Chessboard new_phase = phases;
                    //new_phase.board[4, 1] = 0;

                    //new_phase.board[5, 2] = current;

                    new_phase.move_ptop(4, 1, 5, 2);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[5, 2] / 100 == opponent)

                    {
                        Chessboard new_phase = phases;

                        //new_phase.board[4, 1] = 0;

                        //new_phase.board[5, 2] = current;

                        new_phase.move_ptop(4, 1, 5, 2);

                        moves.Add(new_phase);

                    }

                }


                if (phases.board[5, 0] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[4, 1] = 0;

                    //new_phase.board[5, 0] = current;

                    new_phase.move_ptop(4, 1, 5, 0);

                    moves.Add(new_phase);

                }

                else

                {


                    if (phases.board[5, 0] / 100 == opponent)

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[4, 1] = 0;

                        //new_phase.board[5, 0] = current;

                        new_phase.move_ptop(4, 1, 5, 0);

                        moves.Add(new_phase);

                    }

                }


                if (phases.board[3, 0] == 0)

                {

                    Chessboard new_phase = phases;

                    //new_phase.board[4, 1] = 0;

                    //new_phase.board[3, 0] = current;

                    new_phase.move_ptop(4, 1, 3, 0);

                    moves.Add(new_phase);

                }

                else

                {

                    if (phases.board[3, 0] / 100 == opponent)

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[4, 1] = 0;

                        //new_phase.board[3, 0] = current;

                        new_phase.move_ptop(4, 1, 3, 0);

                        moves.Add(new_phase);

                    }

                }


            }

            else

            {

                if (x == 3)

                {

                    if (phases.board[4, 1] == 0)

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[4, 1] = current;

                        //new_phase.board[3, y] = 0;

                        new_phase.move_ptop(3, y, 4, 1);

                        moves.Add(new_phase);

                    }

                    else

                    {

                        if (phases.board[4, 1] / 100 == opponent)

                        {
                            Chessboard new_phase = phases;

                            //new_phase.board[4, 1] = current;

                            //new_phase.board[3, y] = 0;

                            new_phase.move_ptop(3, y, 4, 1);

                            moves.Add(new_phase);

                        }

                    }

                }


                else if (x == 5)

                {

                    if (phases.board[4, 1] == 0)

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[4, 1] = current;

                        //new_phase.board[5,y] = 0;

                        new_phase.move_ptop(5, y, 4, 1);

                        moves.Add(new_phase);

                    }

                    else

                    {

                        if (phases.board[4, 1] / 100 == opponent)

                        {

                            Chessboard new_phase = phases;

                            //new_phase.board[4, 1] = current;

                            //new_phase.board[5, y] = 0;

                            new_phase.move_ptop(5, y, 4, 1);

                            moves.Add(new_phase);

                        }

                    }

                }

            }

            /************************************************************/



            if (moves.Count == 0) return null;

            return moves;

        }





        public static Point v1 = new Point(1, 1);

        public static Point v2 = new Point(-1, 1);

        public static Point v3 = new Point(-1, -1);

        public static Point v4 = new Point(1, -1);

        public static List<Point> vector = new List<Point>();



        public static List<Chessboard> Red_Move_Xiang(Chessboard phases, int x, int y)

        {

            List<Chessboard> moves = new List<Chessboard>();

            Point move_length = new Point(2, 2);

            int current;

            int opponent = Convert.ToInt16(!phases.Player);

            current = phases.board[x, y];

            List<Point> move_path = new List<Point>();
            
            move_path.Add(Point.Point_multi(v1, move_length));

            move_path.Add(Point.Point_multi(v2, move_length));

            move_path.Add(Point.Point_multi(v3, move_length));

            move_path.Add(Point.Point_multi(v4, move_length));

            Point current_position = new Point(x, y);


            for (int i = 0; i < move_path.Count; i++)

            {

                Point new_point;

                new_point = Point.Point_plus(current_position, move_path[i]);

                if (Red_isLegal_Xiang(new_point))

                {

                    if (phases.board[Point.Point_plus(current_position, Point.Point_divide(move_path[i], 2)).x,

                        Point.Point_plus(current_position, Point.Point_divide(move_path[i], 2)).y] != 0)     //象眼判断

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[new_point.x, new_point.y] = current;

                        //new_phase.board[x, y] = 0;

                        new_phase.move_ptop(x, y, new_point.x, new_point.y);

                        moves.Add(new_phase);

                    }

                }

            }


            if (moves.Count == 0) return null;

            return moves;

        }
        public static bool Red_isLegal_Xiang(Point point)

        {

            bool bRet = false;

            do

            {

                if (point.x < 0 || point.x > 8) break;

                if (point.y < 5 || point.y > 9) break;

                bRet = true;

            } while (false);

            return bRet;

        }

        public static List<Chessboard> Black_Move_Xiang(Chessboard phases, int x, int y)

        {

            List<Chessboard> moves = new List<Chessboard>();

            Point move_length = new Point(2, 2);

            int current;

            int opponent = Convert.ToInt16(!phases.Player);

            current = phases.board[x, y];

            List<Point> move_path = new List<Point>();

            move_path.Add(Point.Point_multi(v1, move_length));

            move_path.Add(Point.Point_multi(v2, move_length));

            move_path.Add(Point.Point_multi(v3, move_length));

            move_path.Add(Point.Point_multi(v4, move_length));

            Point current_position = new Point(x, y);


            for (int i = 0; i < move_path.Count; i++)

            {

                Point new_point;

                new_point = Point.Point_plus(current_position, move_path[i]);

                if (Black_isLegal_Xiang(new_point))

                {

                    if (phases.board[Point.Point_plus(current_position, Point.Point_divide(move_path[i], 2)).x,

                        Point.Point_plus(current_position, Point.Point_divide(move_path[i], 2)).y] != 0)     //象眼判断

                    {

                        Chessboard new_phase = phases;

                        //new_phase.board[new_point.x, new_point.y] = current;

                        //new_phase.board[x, y] = 0;

                        new_phase.move_ptop(x, y, new_point.x, new_point.y);

                        moves.Add(new_phase);

                    }

                }

            }


            if (moves.Count == 0) return null;

            return moves;

        }
        public static bool Black_isLegal_Xiang(Point point)

        {

            bool bRet = false;

            do

            {

                if (point.x < 0 || point.x > 8) break;

                if (point.y < 0 || point.y > 4) break;

                bRet = true;

            } while (false);

            return bRet;

        }
        public static bool isLegal_Ma(Point point)

        {


            if (point.x < 0 || point.x > 8) return false;

            if (point.y < 0 || point.y > 9) return false;
            return true;

           

        }


        public static List<Chessboard> Move_Ma(Chessboard phases, int x, int y)

        {

            List<Chessboard> moves = new List<Chessboard>();

            int current;


            int opponent = Convert.ToInt16(!phases.Player);
            int motion=0;

            current = phases.board[x, y];

            List<Point> move_path = new List<Point>();

            Point point1 = new Point(2, 1);
            Point point2 = new Point(1, 2);
            Point point3 = new Point(-1, 2);
            Point point4 = new Point(-2, 1);
            Point point5 = new Point(-2, -1);
            Point point6 = new Point(-1, -2);
            Point point7 = new Point(1, -2);
            Point point8 = new Point(2, -1);


            move_path.Add(point1);
            move_path.Add(point2);
            move_path.Add(point3);
            move_path.Add(point4);
            move_path.Add(point5);
            move_path.Add(point6);
            move_path.Add(point7);
            move_path.Add(point8);

            Point current_position = new Point(x, y);


            for (int i = 0; i < move_path.Count; i++)

            {

                Point new_point;

                new_point = Point.Point_plus(current_position, move_path[i]);



                if (isLegal_Ma(new_point))

                {

                    int e;
                    
                    bool MaRunable=true;
                    if (Math.Abs(move_path[i].x) == 2) { motion = 1; e = move_path[i].x / 2; }
                    else if (Math.Abs(move_path[i].y) == 2) { motion = 2; e = move_path[i].y / 2; }
                    else e=0;
                    if (motion == 1)
                    {
                        if (phases.board[x + e,   y ]!= 0) MaRunable = false;
                    }

                    else if (motion == 2)     
                    {
                        if (phases.board[x ,  y + e] != 0) MaRunable = false;
                    }
                    else e=0;

                    if (MaRunable)
                    {
                        if (Xiaable(phases,new_point,opponent))
                        {
                            Chessboard new_phase = phases;

                            //new_phase.board[new_point.x, new_point.y] = current;

                            //new_phase.board[x, y] = 0;

                            new_phase.move_ptop(x, y, new_point.x, new_point.y);

                            moves.Add(new_phase);
                        }
                    }
                    }
                

            }


            if (moves.Count == 0) return null;

            return moves;

        }

        public static bool Pao_Legal_x(Chessboard phases,int a,int x,int y)
        {
            if (a == x) return false;
            int opponent = Convert.ToInt16(!phases.Player);
            int count = 0;

            int right = 0;
            int left = 0;
            
            if (a < x) { right = x; left = a; }
            if (a > x) { right = a; left = x; }

            for(int i=left+1;i<right;i++)
            {
                if (phases.board[i, y] != 0)
                    count++;
            }
            if (count == 0) return true;
            else if (count == 1 && phases.board[a, y] != 0 && phases.board[a, y] / 100 == opponent) return true;
            else return false;
        }

        public static bool Pao_Legal_y(Chessboard phases, int a, int x, int y)
        {
            if (a == y) return false;
            int opponent = Convert.ToInt16(!phases.Player);
            int count = 0;

            int up = 0;
            int down = 0;

            if (a < x) { up = a; down = x; }
            if (a > x) { down = a; up = x; }

            for (int i = up + 1; i < down; i++)
            {
                if (phases.board[x, i] != 0)
                    count++;
            }
            if (count == 0) return true;
            else if (count == 1 && phases.board[x, a] != 0 && phases.board[x, a] / 100 == opponent) return true;
            else return false;
        }

        public static List<Chessboard> Move_Pao(Chessboard phases,int x,int y)
        {
            //算法思想 上下左右            
            List<Chessboard> moves = new List<Chessboard>();
            int opponent = Convert.ToInt16(!phases.Player);

            int current = phases.board[x, y];
            
            for(int i=0; i<10;i++)
            {
                if(Pao_Legal_x(phases,i,x,y))
                {
                    Chessboard new_phase = phases;
                    //new_phase.board[i, y] = current;
                    //new_phase.board[x, y] = 0;
                    new_phase.move_ptop(x, y, i, y);
                    moves.Add(new_phase);
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (Pao_Legal_y(phases, i, x, y))
                {
                    Chessboard new_phase = phases;
                    //new_phase.board[x, i] = current;
                    //new_phase.board[x, y] = 0;
                    new_phase.move_ptop(x,y,x,i);
                    moves.Add(new_phase);
                }
            }
            if (moves.Count == 0) return null;
            return moves;

        }

        public static List<Chessboard> Move_Ju(Chessboard phases,int x,int y)
        {
            List<Chessboard> moves = new List<Chessboard>();
            int opponent = Convert.ToInt16(!phases.Player);

            int current = phases.board[x, y];

            int x1 = x-1;
            int x2 = x+1;
            int y1 = y-1;
            int y2 = y+1;
            while(x1!=-1)
            {
                if(phases.board[x1,y]==0)
                {
                    Chessboard new_phase = phases;
                    //new_phase.board[x1, y] = current;
                    //new_phase.board[x, y] = 0;
                    new_phase.move_ptop(x, y, x1, y);
                    moves.Add(new_phase);
                    x1--;
                }
                else
                {
                    if(phases.board[x1,y]/100==opponent)
                    {
                        Chessboard new_phase = phases;
                        //new_phase.board[x1, y] = current;
                        //new_phase.board[x, y] = 0;
                        new_phase.move_ptop(x, y, x1, y);
                        moves.Add(new_phase);
                        break;
                    }
                    else
                        break;
                }
            }

            while (x2++ != 9)
            {
                if (phases.board[x2, y] == 0)
                {
                    Chessboard new_phase = phases;
                    //new_phase.board[x2, y] = current;
                    //new_phase.board[x, y] = 0;
                    new_phase.move_ptop(x, y, x2, y);
                    moves.Add(new_phase);
                    x2++;
                }
                else
                {
                    if (phases.board[x2, y] / 100 == opponent)
                    {
                        Chessboard new_phase = phases;
                        //new_phase.board[x2, y] = current;
                        //new_phase.board[x, y] = 0;
                        new_phase.move_ptop(x, y, x2, y);
                        moves.Add(new_phase);
                        break;
                    }
                    else
                        break;
                }
            }



            while (y1 != -1)
            {
                if (phases.board[x, y1] == 0)
                {
                    Chessboard new_phase = phases;
                    //new_phase.board[x, y1] = current;
                    //new_phase.board[x, y] = 0;
                    new_phase.move_ptop(x, y, x, y1);
                    moves.Add(new_phase);
                    y1--;
                }
                else
                {
                    if (phases.board[x, y1] / 100 == opponent)
                    {
                        Chessboard new_phase = phases;
                        //new_phase.board[x, y1] = current;
                        //new_phase.board[x, y] = 0;
                        new_phase.move_ptop(x, y, x, y1);
                        moves.Add(new_phase);
                        break;
                    }
                    else
                        break;
                }
            }

            while (y2++ != 9)
            {
                if (phases.board[x, y2] == 0)
                {
                    Chessboard new_phase = phases;
                    //new_phase.board[x, y2] = current;
                    //new_phase.board[x, y] = 0;
                    new_phase.move_ptop(x, y, x, y2);
                    moves.Add(new_phase);
                    y2++;
                }
                else
                {
                    if (phases.board[x, y2] / 100 == opponent)
                    {
                        Chessboard new_phase = phases;
                        //new_phase.board[x1, y] = current;
                        //new_phase.board[x, y] = 0;
                        new_phase.move_ptop(x,y,x1,y);
                        moves.Add(new_phase);
                        break;
                    }
                    else
                        break;
                }
            }
            if (moves.Count == 0) return null;
            return moves;
        }
        public static List<Chessboard> Red_Move_Bing(Chessboard phases,int x,int y)
        {
            List<Chessboard> moves = new List<Chessboard>();
            int self = Convert.ToInt16(phases.Player);

            int current = phases.board[x, y];

            if(y>5 && phases.board[x,y-1]/100!=self)
            {
                Chessboard new_phase = phases;
                //new_phase.board[x, y + 1] = current;
                //new_phase.board[x, y] = 0;
                new_phase.move_ptop(x, y, x, y - 1);
                moves.Add(new_phase);
            }
            if(y>-1 && y<5)
            {
                Chessboard new_phase1 = phases;
                //new_phase1.board[x, y + 1] = current;
                //new_phase1.board[x, y] = 0;
                new_phase1.move_ptop(x, y, x, y-1);
                moves.Add(new_phase1);

                Chessboard new_phase2 = phases;
                //new_phase2.board[x+1, y] = current;
                //new_phase2.board[x, y] = 0;
                new_phase2.move_ptop(x, y, x + 1, y);
                moves.Add(new_phase2);

                Chessboard new_phase3 = phases;
                //new_phase3.board[x-1, y] = current;
                //new_phase3.board[x, y] = 0;
                new_phase3.move_ptop(x, y, x - 1, y);
                moves.Add(new_phase3);
            }
            if (moves.Count == 0) return null;
            else return moves;
        }



        public static List<Chessboard> Black_Move_Bing(Chessboard phases, int x, int y)
    {
        List<Chessboard> moves = new List<Chessboard>();
        int self = Convert.ToInt16(phases.Player);

        int current = phases.board[x, y];

        if (y < 5 && phases.board[x, y + 1] / 100 != self)
        {
            Chessboard new_phase = phases;
                //new_phase.board[x, y - 1] = current;
                //new_phase.board[x, y] = 0;
                new_phase.move_ptop(x, y, x, y + 1);
            moves.Add(new_phase);
        }
        if (y > 4 && y < 10)
        {
            Chessboard new_phase1 = phases;
                //new_phase1.board[x, y - 1] = current;
                //new_phase1.board[x, y] = 0;
                new_phase1.move_ptop(x, y, x, y + 1);
            moves.Add(new_phase1);

            Chessboard new_phase2 = phases;
                //new_phase2.board[x + 1, y] = current;
                //new_phase2.board[x, y] = 0;
                new_phase2.move_ptop(x, y, x + 1, y);
                moves.Add(new_phase2);

            Chessboard new_phase3 = phases;
                //new_phase3.board[x - 1, y] = current;
                //new_phase3.board[x, y] = 0;
                new_phase2.move_ptop(x, y, x + 1, y);
                moves.Add(new_phase3);
        }
        if (moves.Count == 0) return null;
        else return moves;
    }


        /*  0 ,  1 ,  2 ,  3 ,  4 ,  5 ,  6 ,  7 ,  8

 
       { { 171, 141, 131, 121, 111, 122, 132, 142, 172 } , 0

 
         {  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0  } ,   1

 
         {  0 , 151,  0 ,  0 ,  0 ,  0 ,  0 , 152,  0  } ,   2    

 
         { 161,  0 , 162,  0 , 163,  0 , 164,  0 , 165 } ,   3

 
         {  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0  } ,   4

 
         {  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0  } ,   5

 
         {  61,  0 ,  62,  0 ,  63,  0 ,  64,  0 ,  65 } ,   6

 
         {  0 ,  51,  0 ,  0 ,  0 ,  0 ,  0 ,  52,  0  } ,   7

 
         {  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0  } ,   8

 
         {  71,  41,  31,  21,  11,  22,  32,  42,  72 } };  9

               */

    }

}