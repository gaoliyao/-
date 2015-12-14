using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region 棋子
/// <summary>
/// param 棋子名称
/// param 位置
/// param 所属方
/// param 是否存活
/// </summary>
namespace 象棋算法
{
    public class ChessBasics
    {
        internal int name;
        /*for黑
        11 将
        12 士
        13 象
        14 马
        15 炮
        16 卒
        17 车
        */
        /*for红
        1 帅
        2 士
        3 相
        4 马
        5 炮
        6 兵
        7 车
        */

        internal int position_y;
        internal int color;
        internal int isAlive;
        internal int position_x;
        internal int value;

        public ChessBasics()
        {
            position_x = 0;
            position_y = 0;
            isAlive = 1;
            color = 0;
            name = 0;
        }
        public ChessBasics(int i, int x, int y)
        {
                isAlive = 1;
                if (i / 100 == 1)
                {
                    color = 1;
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 1)//黑将
                    {
                        position_x = x;
                        position_y = y;
                        name = 1;
                        value = 1000;
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 2) //黑士
                    {
                        if (i % 10 == 1)//黑士1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 2;
                            value = 25;
                        }
                        else            //黑士2号
                        {
                            position_x = x;
                            position_y = y;
                            name = 2;
                            value = 25;
                        }
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 3) //黑象
                    {
                        if (i % 10 == 1)//黑象1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 3;
                            value = 20;
                        }
                        else            //黑象2号
                        {
                            position_x = x;
                            position_y = y;
                            name = 3;
                            value = 20;
                        }
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 3) //黑马
                    {
                        if (i % 10 == 4)//黑马1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 4;
                            value = 45;
                        }
                        {
                            position_x = x;
                            position_y = y;
                            name = 4;
                            value = 45;
                        }
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 7) //黑车
                    {
                        if (i % 10 == 1)//黑车1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 7;
                            value = 90;
                        }
                        else            //黑车2号
                        {
                            position_x = x;
                            position_y = y;
                            name = 7;
                            value = 90;
                        }
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 5) //黑炮
                    {
                        if (i % 10 == 1)//黑炮1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 5;
                            value = 40;
                        }
                        else            //黑炮2号
                        {
                            position_x = x;
                            position_y = y;
                            name = 5;
                            value = 40;
                        }
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 6) //黑卒
                    {
                        if (i % 10 == 1)//黑卒1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 6;
                            value = 10;
                        }
                        else if (i % 10 == 2)            //黑卒2号
                        {
                            position_x = x;
                            position_y = y;
                            name = 6;
                            value = 10;
                        }
                        else if (i % 10 == 3)            //黑卒3号
                        {
                            position_x = x;
                            position_y = y;
                            name = 6;
                            value = 10;
                        }
                        else if (i % 10 == 4)            //黑卒4号
                        {
                            position_x = x;
                            position_y = y;
                            name = 6;
                            value = 10;
                        }
                        else                             //黑卒5号
                        {
                            position_x = 8;
                            position_y = 3;
                            name = 6;
                            value = 10;
                        }
                    }
                }
                else
                {
                    color = 0;
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 1)//红帅
                    {
                        position_x = x;
                        position_y = y;
                        name = 1;
                        value = 1000+Value.Shuai[x,y];
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 2) //红士
                    {
                        if (i % 10 == 1)//红士1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 2;
                            value = 25+Value.Shi[x,y];
                        }
                        else            //红士2号
                        {
                            position_x = x;
                            position_y = y;
                            name = 2;
                            value = 25+Value.Shi[x,y];
                        }
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 3) //红相
                    {
                        if (i % 10 == 1)//红相1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 3;
                            value = 20+Value.Xiang[x,y];
                        }
                        else            //红相2号
                        {
                            position_x = x;
                            position_y = y;
                            name = 3;
                            value = 20+Value.Xiang[x,y];
                        }
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 4) //红马
                    {
                        if (i % 10 == 1)//红马1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 4;
                            value = 45+Value.Ma[x,y];
                        }
                        else            //红马2号
                        {
                            position_x = x;
                            position_y = y;
                            name = 4;
                            value = 45+Value.Ma[x,y];
                        }
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 7) //红车
                    {
                        if (i % 10 == 1)//红车1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 7;
                            value = 90+Value.Ju[x,y];
                        }
                        else            //红车2号
                        {
                            position_x = x;
                            position_y = y;
                            name = 7;
                            value = 90+Value.Ju[x,y];
                        }
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 5) //红炮
                    {
                        if (i % 10 == 1)//红炮1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 5;
                            value = 40+Value.Pao[x,y];
                        }
                        else            //红炮2号
                        {
                            position_x = x;
                            position_y = y;
                            name = 5;
                            value = 40+Value.Pao[x,y];
                    }
                    }
                    ///
                    ///
                    ///
                    if ((i % 100) / 10 == 6) //红兵
                    {
                        if (i % 10 == 1)//红兵1号
                        {
                            position_x = x;
                            position_y = y;
                            name = 6;
                            value = 10+Value.Bing[x,y];
                        }
                        else if (i % 10 == 2)            //红兵2号
                        {
                            position_x = x;
                            position_y = y;
                            name = 6;
                            value = 10 + Value.Bing[x, y];
                        }
                        else if (i % 10 == 3)            //红兵3号
                        {
                            position_x = x;
                            position_y = y;
                            name = 6;
                        value = 10 + Value.Bing[x, y];
                        }
                        else if (i % 10 == 4)            //红兵4号
                        {
                            position_x = x;
                            position_y = y;
                            name = 6;
                            value = 10 + Value.Bing[x, y];
                        }
                        else if (i % 10 == 5)            //红兵5号
                        {
                            position_x = x;
                            position_y = y;
                            name = 6;
                            value = 10 + Value.Bing[x, y];
                        }
                    }
                }
            }
        }
    }
#endregion