using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace onlineSPC
{
    class CommonClass
    {

        /*
         * xSorting(float[])    输入一个浮点型数组，返回数组中的最大值[0]、中值[1]、最小值[2]
         * maxTomin(float[])    输入一个浮点型数组，返回由大到小排列的新数组
         * Dvalue(float[])      输入一个浮点型数组，返回数组中最大最小值的差，即极差
         * xBar(float[])        输入一个浮点型数组，返回数组的平均值
         * sDeviation(float[])  输入一个浮点型数组，返回数组的标准偏差
         * 
         * 
         */

        public float[] xSorting(float[] tempxarr)       //排序
        {
            float[] xsorting = new float[3];
            tempxarr = maxTomin(tempxarr);
            xsorting[2] = tempxarr[tempxarr.Count() - 1];
            if((tempxarr.Count() % 2) == 0)
            {
                xsorting[1] = (tempxarr[(tempxarr.Count() / 2)] + tempxarr[(tempxarr.Count() / 2) - 1]) / 2;
            }
            else
            {
                xsorting[1] = tempxarr[(tempxarr.Count() / 2)];
            }
            xsorting[0] = tempxarr[0];
            return xsorting;
        }

        public float[] minTomax(float[] temptempxarr)
        {
            for (int i = 1; i < temptempxarr.Count(); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (temptempxarr[i] >= temptempxarr[j])
                    {

                    }
                    else if (temptempxarr[i] < temptempxarr[j])
                    {
                        float tempxvalue;
                        tempxvalue = temptempxarr[i];
                        temptempxarr[i] = temptempxarr[j];
                        temptempxarr[j] = tempxvalue;
                    }
                }
            }
            return temptempxarr;
        }

        public float[] maxTomin(float[] temptempxarr)
        {
            for (int i = 1; i < temptempxarr.Count(); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (temptempxarr[i] >= temptempxarr[j])
                    {
                        float tempxvalue;
                        tempxvalue = temptempxarr[i];
                        temptempxarr[i] = temptempxarr[j];
                        temptempxarr[j] = tempxvalue;
                    }
                    else if (temptempxarr[i] < temptempxarr[j])
                    {
                        
                    }
                }
            }
            return temptempxarr;
        }

        public int[] minTomax(int[] temptempxarr)
        {
            for (int i = 1; i < temptempxarr.Count(); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (temptempxarr[i] >= temptempxarr[j])
                    {

                    }
                    else if (temptempxarr[i] < temptempxarr[j])
                    {
                        int tempxvalue;
                        tempxvalue = temptempxarr[i];
                        temptempxarr[i] = temptempxarr[j];
                        temptempxarr[j] = tempxvalue;
                    }
                }
            }
            return temptempxarr;
        }

        public int[] maxTomin(int[] temptempxarr)
        {
            for (int i = 1; i < temptempxarr.Count(); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (temptempxarr[i] >= temptempxarr[j])
                    {
                        int tempxvalue;
                        tempxvalue = temptempxarr[i];
                        temptempxarr[i] = temptempxarr[j];
                        temptempxarr[j] = tempxvalue;
                    }
                    else if (temptempxarr[i] < temptempxarr[j])
                    {
                        
                    }
                }
            }
            return temptempxarr;
        }

        public float Dvalue(float[] tempxarr)       //求极差
        {
            float[] xsorting = xSorting(tempxarr);
            return (xsorting[2] - xsorting[0]);
        }

        public float xBar(float[] tempxarr)     //标准公式求平均值
        {
            float xbar = 0;
            for (int i = 0; i < tempxarr.Count(); i++)
            {

                xbar = xbar + tempxarr[i];
            }
            return (xbar / tempxarr.Count());
        }

        public float sDeviation(float[] tempxarr)     //通过标准公式求标准偏差的函数
        {
            double sumxx = 0;
            float xbar = xBar(tempxarr);
            for (int i = 0; i < tempxarr.Count(); i++)
            {
                sumxx += Math.Pow((tempxarr[i] - xbar), 2);
            }
            float s = Convert.ToSingle(Math.Sqrt(sumxx / tempxarr.Count()));
            return s;
        }
    }
}
