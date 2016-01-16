using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 象棋算法
{
    class Thinking
    {
        CurrentPhase head;

        public static List<CurrentPhase> think_for_oneself(CurrentPhase phase)
        {
            List<CurrentPhase> moves_list = new List<CurrentPhase>();

            List<Chessboard> moves = Moves.AllMove(phase.phase);
            for(int i=0;i<moves.Count;i++)
            {
                CurrentPhase new_phase = new CurrentPhase(moves[i]);
                moves_list.Add(new_phase);
            }
            return moves_list;       
        }

        public static List<CurrentPhase> Get_Next_Phases(CurrentPhase currentphase)
        {
            List<Chessboard> moves = Moves.AllMove(currentphase.phase);
            List<CurrentPhase> next_phases = new List<CurrentPhase>();
            for (int i=0;i<moves.Count;i++)
            {
                CurrentPhase newCurrentPhase = new CurrentPhase(moves[i]);
                next_phases.Add(newCurrentPhase);
            }
            if (next_phases.Count == 0) return null;
            else
            return next_phases;
        }

        /*   public List<CurrentPhase> Think_For_Once (CurrentPhase currentPhase)
           {
               List<CurrentPhase> my_phases = Get_Next_Phases(currentPhase);

               CurrentPhase[] top_phases = new CurrentPhase[5];
               int[] top_scores = new int[5];
               for(int i=0;i<5;i++)
               {
                   top_scores[i] = 0;
               }
               int lowest = 0;
               int index_lowest=0;
               int count = 0;


               for (int i = 0; i < my_phases.Count; i++)//进入其中一步
               {
                   count = 0;
                   List<CurrentPhase> oppo_phases = Get_Next_Phases(my_phases[i]);
                   for(int j=0;j<oppo_phases.Count;j++)
                   {
                       count = count + oppo_phases[j].currentScore;
                   }
                   count = count / my_phases.Count + 1;
                   if (count <= lowest) ;
                   else
                   {
                       top_scores[index_lowest] = count;
                       lowest = count;
                       top_phases[index_lowest] = my_phases[i];
                       for(int q=0;q<5;q++)
                       {
                           if (top_scores[q] < lowest) {
                               lowest = top_scores[q];
                               index_lowest = q;
                           }
                       }

                   }
               }
               List<CurrentPhase> ResultMoves = new List<CurrentPhase>();

               for (int i=0;i<5;i++)
               {
                   if(top_scores[i]!=0)
                   ResultMoves.Add(top_phases[i]);
               }
               return ResultMoves;
           }
           */
        /* public void Think_For_One(CurrentPhase currentPhase)
         {
             List<CurrentPhase> my_phases = Get_Next_Phases(currentPhase);

             CurrentPhase[] top_phases = new CurrentPhase[5];
             int[] top_scores = new int[5];
             for (int i = 0; i < 5; i++)
             {
                 top_scores[i] = 0;
             }
             int lowest = 0;
             int index_lowest = 0;
             for (int i=0;i<my_phases.Count;i++)
             {
                 if (my_phases[i].currentScore <= lowest) ;
                 else
                 {
                     top_phases[index_lowest] = my_phases[i];
                     lowest = my_phases[i].currentScore;
                     for(int j=0;j<5;j++)
                     {
                         if(top_scores[j]<=lowest)
                         {
                             lowest = top_scores[j];
                             index_lowest = j;
                         }
                     }
                 }
             }
             List<CurrentPhase> ResultPhases = new List<CurrentPhase>();
             List<CurrentPhase> ResultPhase = new List<CurrentPhase>();
             for (int i=0;i<5;i++)
             {
                 if(top_scores[i]!=0)
                 {
                     ResultPhases.Add(top_phases[i]);
                 }
                 if(top_scores[i]==10000)
                 {
                     ResultPhase.Add(top_phases[i]);
                 }
             }
             if (ResultPhase.Count != 0)
                 currentPhase.Child = ResultPhase;
             else
                 currentPhase.Child = ResultPhases;
         }*/
        static CurrentPhase q = new CurrentPhase();
public static void Think_Child(CurrentPhase p,CurrentPhase fa)
        {
            p.Father = fa;
            p.init_Child();
            if (fa != null)
                p.depth = fa.depth + 1;
            else p.depth = 1;
            if (p.depth < 8)
            {
                for (int i = 0; i < p.Child.Count; i++)
                {
                    Think_Child(p.Child[i], p);

                }
            }
            if (p.depth == 1) q = p;
        }
        public static CurrentPhase Think(CurrentPhase currentPhase)
        {
            CurrentPhase phase_now = q;
            Think_Child(currentPhase, null);
            for(int i=0;i<phase_now.Child.Count;i++)
            {
                phase_now.Child[i].Calculate(phase_now.Child[i]);
            }
            int highest = -10001;
            int highest_phase_index=0;
            for(int i=0;i<phase_now.Child.Count;i++)
            {
                if(phase_now.Child[i].futureScore>highest)
                {
                    highest_phase_index = i;
                    highest = phase_now.Child[i].futureScore;
                }
            }
            return phase_now.Child[highest_phase_index];

        }
    }
}
