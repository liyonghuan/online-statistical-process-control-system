using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace onlineSPC
{
    class ValueClass
    {
        public float[] xarr;       //传入的样本数据数组
        public float xmax = 0;     //数组中的最大值
        public float xmin = 0;     //数组中的最小值
        public float diff = 0;     //最大值与最小值的差
        public int group = 0;      //样本数据分组数
        public float[] limitnum;       //限制界限,比数组数量大1
        public float h = 0;      //组距
        public float simplex = 0;      //频数最大的组的中心值
        //public float cenplex = 0;       //最大频率
        public float[] cennum;     //中心值数组，和数组数量相同
        public int[] fnum;     //频数数组，和数组数量相同
        public float[] unum;       //简化中心值，和数组数量相同
        public float xave = 0;     //样本数据平均数
        public float snum;     //标准偏差
        public float xx = 0;        //简化公式所求样本平均值
        public float xs = 0;        //简化公式所求样本标准偏差

        CommonClass commonclass = new CommonClass();

        public ValueClass(float[] xvalue, int xgroup = 10)       //带两个参数的构造函数，第一个参数是样本数据数组，第二个参数是分组数
        {
            group = xgroup;
            xarr = new float[xvalue.Count()];
            xarr = xvalue;
            reorderValue();
            xMaxMin();
            hValue();
            limitNum();
            cenNum();
            fNum();
            uNum();
            xAverage();
            xX();
            sNum();
            xS();
        }

        private void reorderValue()        //将数组内的数字由大到小排序,并求出最大最小值的差
        {
            float[] result = commonclass.maxTomin(xarr);
            xmax = Convert.ToSingle(result[0]);
            xmin = Convert.ToSingle(result[result.Count() - 1]);
        }

        private void xMaxMin()        //求得X的最大值与最小值的差
        {
            diff = xmax - xmin;
        }

        public void hValue()     //获取组距h的值,组距为整数
        {
            //int x = Convert.ToInt32(diff) % Convert.ToInt32(group);
            //if (x != 0)
            //{
            //    h = Convert.ToInt32(diff / group);
            //}
            //else
            //{
            //    h = Convert.ToInt32(diff / group);
            //}
            h = diff / group;
        }

        private void limitNum()     //求得各组限制界限的函数
        {
            limitnum = new float[group + 1];
            limitnum[0] = xmin - (h / 2);
            for (int i = 1; i < group + 1; i++)
            {
                limitnum[i] = limitnum[i - 1] + h;
            }
        }

        private void cenNum()       //求得中心值的函数
        {
            cennum = new float[group];
            for(int i = 0; i < group; i++)
            {
                cennum[i] = (limitnum[i + 1] + limitnum[i]) / 2;
            }
        }

        private void fNum()     //求得每组频数的函数
        {
            fnum = new int[group];
            int o = 0;      //第o组频数
            xarr = commonclass.minTomax(xarr);
            for (int i = 0; i < xarr.Count(); i++)
            {
                if (xarr[i] <= limitnum[o + 1])
                {
                    fnum[o]++;
                }
                else
                {
                    if (o >= group - 1)
                    {
                        fnum[group - 1]++;
                    }
                    else
                    {
                        o++;
                        fnum[o]++;
                    }
                }
            }
        }

        private void uNum()     //求得每组的简化中心值函数
        {
            int o = 0;      //
            
            for (int i = 1; i < group; i++)
            {
                if (fnum[o] >= fnum[i])
                {
                    
                }
                else
                {
                    o = i;
                }
            }
            simplex = cennum[o];
            unum = new float[group];
            for(int i = 0; i < group; i++)
            {
                unum[i] = (cennum[i] - simplex) / h;
            }
        }

        private void xAverage()       //求一组数据的平均数
        {
            for (int i = 0; i < xarr.Count(); i++)
            {

                xave += xarr[i];
            }
            xave /= xarr.Count();
        }

        private void xX()       //通过简化公式求样本平均值的函数
        {
            float suma = 0;
            float sumb = 0;
            for(int i = 0; i < group; i++)
            {
                suma += (fnum[i] * unum[i]);
                sumb += fnum[i];
            }
            xx = simplex + h * (suma / sumb);
        }

        private void sNum()     //通过标准公式求标准偏差的函数
        {
            double sumxx = 0;
            for(int i = 0; i < xarr.Count(); i++)
            {
                sumxx += Math.Pow(xarr[i] - xave,2);
            }
            snum = Convert.ToSingle(Math.Sqrt(sumxx / xarr.Count()));
        }

        private void xS()       //通过简化公式求标准偏差的函数
        {
            double suma = 0;
            float sumb = 0;
            float sumc = 0;
            for(int i = 0; i < group; i++)
            {
                suma += (fnum[i] * Math.Pow(unum[i], 2));
                sumb += (fnum[i] * unum[i]);
                sumc += fnum[i];
            }
            xs = Convert.ToSingle(h * Math.Sqrt((suma / sumc) - Math.Pow((sumb / sumc), 2)));
        }

    }
}
