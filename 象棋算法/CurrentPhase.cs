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
        public Chessboard phase;
        public int currentScore;
        public int futureScore;
        public bool isChecked;
        public CurrentPhase Father;
        public List<CurrentPhase> Child = new List<CurrentPhase>();
        public int depth;


        public CurrentPhase()
        {
            depth = 0;
            Father = null;
            Child = new List<CurrentPhase>();
            phase = new Chessboard();
            currentScore = 0;
            futureScore = 0;
            isChecked = false;
        }

        public CurrentPhase(Chessboard phases)
        {
            depth = 0;
            Father = null;
            Child = new List<CurrentPhase>();
            phase = phases;
            phase.Player = !phase.Player;
            currentScore = Scoring.Score(phase);
            futureScore = 0;
            isChecked = false;
        }

        public CurrentPhase(Chessboard phases,CurrentPhase FPhase)
        {
            depth = FPhase.depth+1;
            Father = FPhase;
            Child = new List<CurrentPhase>();
            phase = phases;
            currentScore = Scoring.Score(phase);
            futureScore = 0;
            isChecked = false;
        }
        public void Get_Next_Phases()
        {
            List<Chessboard> moves = Moves.AllMove(phase);
            List<CurrentPhase> next_phases = new List<CurrentPhase>();
            for (int i = 0; i < moves.Count; i++)
            {
                CurrentPhase newCurrentPhase = new CurrentPhase(moves[i]);
                next_phases.Add(newCurrentPhase);
            }
            if (next_phases.Count == 0) Child= null;
            else
                Child= next_phases;
        }
        public void init_Child()
        {
            if (currentScore == 10000 || currentScore == -10000) Child = null;
            else {
                Get_Next_Phases();

                CurrentPhase[] top_phases = new CurrentPhase[5];
                int[] top_scores = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    top_scores[i] = 0;
                }
                int lowest = 0;
                int index_lowest = 0;
                int count = 0;


                for (int i = 0; i < Child.Count; i++)//进入其中一步
                {
                    count = 0;
                    List<CurrentPhase> oppo_phases = new List<CurrentPhase>();
                    for (int j = 0; j < oppo_phases.Count; j++)
                    {
                        count = count + oppo_phases[j].currentScore;
                    }
                    count = count / Child.Count + 1;
                    if (count <= lowest) ;
                    else
                    {
                        top_scores[index_lowest] = count;
                        lowest = count;
                        top_phases[index_lowest] = Child[i];
                        for (int q = 0; q < 5; q++)
                        {
                            if (top_scores[q] < lowest)
                            {
                                lowest = top_scores[q];
                                index_lowest = q;
                            }
                        }

                    }
                }
                List<CurrentPhase> ResultMoves = new List<CurrentPhase>();

                for (int i = 0; i < 5; i++)
                {
                    if (top_scores[i] != 0)
                        ResultMoves.Add(top_phases[i]);
                }
                Child = ResultMoves;
            }
        }

        public void Calculate(CurrentPhase p)
        {
            int score = 0;
            if (p.Child.Count != 0)
            {
                for (int i = 0; i < Child.Count; i++)
                {
                    Calculate(p.Child[i]);
                }
                for (int i = 0; i < Child.Count; i++)
                    score = score - p.Child[i].futureScore;
                p.futureScore = score / (p.Child.Count) + 1;
            }
            else
            {
                p.futureScore = p.currentScore;
            }
        }




    }
}
