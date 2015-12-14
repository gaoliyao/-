using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//为Thinking树的结点
namespace 象棋算法
{
    class CurrentPhase
    {
        Chessboard phase;
        int currentScore;
        bool isChecked;
        int depth;
        List<Chessboard> moves;
        List<Chessboard> next_move_list;

        CurrentPhase(Chessboard phases,int d)
        {
            phase = phases;
            depth = d;
            currentScore=Scoring.Score(phase);
            isChecked = false;
            moves = Moves.AllMove(phase);
            next_move_list = moves;
        }

        public static 


    }
}
