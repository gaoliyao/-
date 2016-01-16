using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 象棋算法
{
    class Program
    {
        static void Main(string[] args)
        {
            main.start();
            main.moves();
            Console.Read();
            //main.think();
           /* while (1==1)
            {
                if (main.current.Black_Chessman[0] == 0) break;
                if (main.current.Red_Chessman[0] == 0) break;
                main.Battle();
            }*/
        }
    }
}
