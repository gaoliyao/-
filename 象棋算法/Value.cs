﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace 象棋算法
{
    class Value
    {
        static int getValue(int current_flag)
        {
            return 0;
        }

        /*
        static void getMap()
        {
            manValue.Add(,);
        }

        static Hashtable manValue= new Hashtable();
    */

        public static int[,] Ma = { {70,80,90,80,70,80,90,80,70 }, { 80, 110, 125, 90,70,90,125,110,80},
        { 90,100,120,125,120,125,120,100,90}, { 90,100,120,130,110,130,120,100,90}
        , { 90,110,110,120,100,120,110,110,90}, { 90,100,100,110,100,110,100,100,90}
        , { 80,90,100,100,90,100,100,90,80}, { 80,80,90,90,80,90,90,80,80}, 
        {70,75,75,70,50,70,75,75,70 }, { 60,70,75,70,60,70,75,70,60} };

        public static int[,] Xiang = { { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0,0,0,0,0,0,0,0,0 },{0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 },{0,0,25,0,0,0,25,0,0 },
        {0,0,0,0,0,0,0,0,0 },{20,0,0,0,35,0,0,0,20 },
        {0,0,0,0,0,0,0,0,0 },{0,0,30,0,0,0,30,0,0 }};

        public static int[,] Ju = { {160,170,160,150,150,150,160,170,160 }, { 170, 180, 170, 190,250,190,170,180,170},
        { 170,190,200,220,240,220,200,190,170}, { 180,220,210,240,250,240,210,220,180}
        , { 180,220,210,240,250,240,210,220,180}, { 180,220,210,240,250,240,210,220,180}
        , { 170,190,180,220,240,220,200,190,170}, { 170,180,170,170,160,170,170,180,170},
        {160,170,160,160,150,160,165,170,160 }, { 150,160,150,160,150,160,155,160,150} };

        public static int[,] Shuai = { {0,0,0,0,0,0,0,0,0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 1, 1, 1, 0, 0, 0 }, 
            { 0, 0, 0, 10, 10, 10, 0, 0, 0 }, { 0, 0, 0, 15, 20, 15, 0, 0, 0 } };

        public static int[,] Bing = { {70,80,90,80,70,80,90,80,70 }, { 80, 110, 125, 90,70,90,125,110,80},
        { 90,100,120,125,120,125,120,100,90}, { 90,100,120,130,110,130,120,100,90}
        , { 90,110,110,120,100,120,110,110,90}, { 90,100,100,110,100,110,100,100,90}
        , { 80,90,100,100,90,100,100,90,80}, { 80,80,90,90,80,90,90,80,80},
        {70,75,75,70,50,70,75,75,70 }, { 60,70,75,70,60,70,75,70,60} };

        public static int[,] Pao = { {125,130,100,70,60,70,100,130,125 }, { 80, 110, 125, 90,70,90,125,110,80},
        { 90,100,120,125,120,125,120,100,90}, { 90,100,120,130,110,130,120,100,90}
        , { 90,110,110,120,100,120,110,110,90}, { 90,100,100,110,100,110,100,100,90}
        , { 80,90,100,100,90,100,100,90,80}, { 80,80,90,90,80,90,90,80,80},
        {70,75,75,70,50,70,75,75,70 }, { 60,70,75,70,60,70,75,70,60} };

        public static int[,] Shi = { {0,0,0,0,0,0,0,0,0 }, {0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 },{0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 },{0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 },{0,0,0,30,0,30,0,0,0 },
        {0,0,0,0,22,0,0,0,0 },{0,0,0,30,0,30,0,0,0 }
        };

        public static int[] capacity = { 1000, 25, 25, 20, 20, 45, 45, 40, 40, 90, 90, 10, 10, 10, 10, 10 };

        public static int[,] Start={ { 171, 141, 131, 121, 111, 122, 132, 142, 172 } ,

  {  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0  } ,

  {  0 , 151,  0 ,  0 ,  0 ,  0 ,  0 , 152,  0  } ,

  { 161,  0 , 162,  0 , 163,  0 , 164,  0 , 165 } ,

  {  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0  } ,

  {  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0  } ,

  {  61,  0 ,  62,  0 ,  63,  0 ,  64,  0 ,  65 } ,

  {  0 ,  51,  0 ,  0 ,  0 ,  0 ,  0 ,  52,  0  } ,

  {  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0  } ,

  {  71,  41,  31,  21,  11,  22,  32,  42,  72 } };
    }
}
