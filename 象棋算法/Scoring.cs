using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 象棋算法
{

    //应给当前局面进行打分
    //输入当前局面 Chessboard phase
    //对红方进行打分 对黑方进行打分 分值差（方便进行比较）！（当前打分）
    //（思考打分 一步）
    class Scoring
    {
        struct StaticScore
        {
            public int All;
            public int troops;
            public int position;
            public int isGetted;
        }

        StaticScore Score_for_red;
        StaticScore Score_for_black;

        public int Score(Chessboard phase)
        {
            int score_red = -1;
            int score_black = -1;
            GetScore(phase);
            if (Score_for_red.isGetted == 1) score_red = Score_for_red.All;
            if (Score_for_black.isGetted == 1) score_black = Score_for_black.All;
            if (score_red == -1 || score_black == -1) return -1;
            int player = Convert.ToInt16(phase.Player);
            if (player == 0) return score_red-score_black;
            else return score_black - score_red;
        }

        public void GetScore(Chessboard phase)
        {
            GetScoreRed(phase);
            GetScoreBlack(phase);
        }

        public void GetScoreRed(Chessboard phase)
        {
            GetRedTroops(phase);
            GetRedAll(phase);
            Score_for_red.isGetted = 1;
        }

        public void GetScoreBlack(Chessboard phase)
        {
            GetBlackTroops(phase);
            GetBlackAll(phase);
            Score_for_black.isGetted = 1;
        }

        public void GetRedTroops(Chessboard phase)
        {
            int troops = 0;
            if (phase.Red_Chessman[0] == -1)
            {
                Score_for_red.All = 0;
            }
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    if (phase.Red_Chessman[i] != -1) troops = troops + Value.capacity[i];
                }
                Score_for_red.troops = troops - 1;
            }
            
        }

        public int RedPositionCount(int i,Point point)
        {
            if (Score_for_red.All == -1) return -1;
            if (i == 0)
            {
                return Value.capacity[i] * Value.Shuai[point.x, point.y];
            }
            else if (i == 1 || i == 2)
            {
                return Value.capacity[i] * Value.Shi[point.x, point.y];
            }
            else if (i == 3 || i == 4)
            {
                return Value.capacity[i] * Value.Xiang[point.x, point.y];
            }
            else if (i == 5 || i == 6)
            {
                return Value.capacity[i] * Value.Ma[point.x, point.y];
            }
            else if (i == 7 || i == 8)
            {
                return Value.capacity[i] * Value.Pao[point.x, point.y];
            }
            else if (i == 9 || i == 10)
            {
                return Value.capacity[i] * Value.Ju[point.x, point.y];
            }
            else if (i == 11 || i == 12)
            {
                return Value.capacity[i] * Value.Bing[point.x, point.y];
            }
            else if (i == 13 || i == 14)
            {
                return Value.capacity[i] * Value.Bing[point.x, point.y];
            }
            else if (i == 15)
            {
                return Value.capacity[i] * Value.Bing[point.x, point.y];
            }
            else return 0;
            
        }


        public void GetRedAll(Chessboard phase)
        {
            int position = 0;
            Point falsePoint = new Point(-1, -1);
            if (Score_for_red.All == -1) Score_for_red.All=-1;
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    if (phase.Red_Location[i] != falsePoint) position = position + RedPositionCount(i, phase.Red_Location[i]);
                }
                Score_for_red.All = position;
            }
        }





        public void GetBlackTroops(Chessboard phase)
        {
            int troops = 0;
            if (phase.Black_Chessman[0] == -1)
            {
                Score_for_black.All = 0;
            }
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    if (phase.Black_Chessman[i] != -1) troops = troops + Value.capacity[i];
                }
                Score_for_black.troops = troops - 1;
            }

        }

        public int BlackPositionCount(int i, Point point)
        {
            if (Score_for_black.All == -1) return -1;
            point = Point.Point_reverse(point);
            if (i == 0)
            {
                return Value.capacity[i] * Value.Shuai[point.x, point.y];
            }
            else if (i == 1 || i == 2)
            {
                return Value.capacity[i] * Value.Shi[point.x, point.y];
            }
            else if (i == 3 || i == 4)
            {
                return Value.capacity[i] * Value.Xiang[point.x, point.y];
            }
            else if (i == 5 || i == 6)
            {
                return Value.capacity[i] * Value.Ma[point.x, point.y];
            }
            else if (i == 7 || i == 8)
            {
                return Value.capacity[i] * Value.Pao[point.x, point.y];
            }
            else if (i == 9 || i == 10)
            {
                return Value.capacity[i] * Value.Ju[point.x, point.y];
            }
            else if (i == 11 || i == 12)
            {
                return Value.capacity[i] * Value.Bing[point.x, point.y];
            }
            else if (i == 13 || i == 14)
            {
                return Value.capacity[i] * Value.Bing[point.x, point.y];
            }
            else if (i == 15)
            {
                return Value.capacity[i] * Value.Bing[point.x, point.y];
            }
            else return 0;

        }


        public void GetBlackAll(Chessboard phase)
        {
            int position = 0;
            Point falsePoint = new Point(-1, -1);
            if (Score_for_black.All == -1) Score_for_black.All = -1;
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    if (phase.Black_Location[i] != falsePoint) position = position + BlackPositionCount(i, phase.Black_Location[i]);
                }
                Score_for_black.All = position;
            }
        }


    }
}
