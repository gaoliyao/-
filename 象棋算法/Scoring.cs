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
            GetRedPositions(phase);
            Score_for_red.isGetted = 1;
        }

        public void GetRedTroops(Chessboard phase)
        {
            int troops = 0;
            for(int i=0;i<16;i++)
            {
                if (phase.Red_Chessman[i] != -1) troops = troops + Value.capacity[i];
            }
            Score_for_red.troops = troops;
        }
    }
}
