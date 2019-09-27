using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace onlineSPC
{
    class ChartClass
    {
        public float xbar = 0;      //X数据的平均数
        public float xbarbar = 0;       //X分组平均数的平均数
        public float xmedianbar = 0;        //X的中位值平均数
        public float xmax = 0;
        public float xmin = 0;
        public float rmax = 0;
        public float rmin = 0;
        public float r = 0;     //极差平均值
        public float svalue = 0;        //标准偏差
        public float xcl = 0;       //X中线
        public float xucl = 0;      //X控制图上限
        public float xlcl = 0;      //X控制图下限
        public float rcl = 0;       //R控制图中线
        public float rucl = 0;      //R控制图上限
        public float rlcl = 0;      //R控制图下限
        public float[] xarr;      //X数组
        public string[] rtemp;       //
        public float[] rlist;       //各组极差R列表
        public string[] xtemp;    //
        public float[] xlist;       //各组平均值Xbar列表
        public int n;       //分组数量
        public string charttype;        //控制图类型

        public ChartClass(float[] x, string type, int nnum = 2)
        {
            n = nnum;       //定义数组
            charttype = type;       //定义类型
            xarr = new float[x.Count()];       //确定数组大小
            for (int i = 0; i < x.Count(); i++)     //循环
            {
                xarr[i] = x[i];     //赋值新数组
            }
            ControlLine();
        }

        private void ControlLine()
        {
            float[] parameter = new float[10];      //定义参数数组，用于获取参数表
            StandardClass standardclass = new StandardClass();      //新建一个标准数据获取类
            parameter = standardclass.controlParameter(n);      //获取标准参数值

            switch (charttype)      //判断类型并执行相应程序
            {
                case "X":       //当类型为X时执行
                    //确定数组大小，数组大小与传入的样本数量相同
                    xlist = new float[xarr.Count()];
                    rlist = new float[xarr.Count()];

                    xtemp = new string[xarr.Count()];
                    rtemp = new string[xarr.Count()];

                    for (int i = 0; i < xarr.Count(); i++)      //循环求得所有样本X的和
                    {
                        xlist[i] = xarr[i];
                        xtemp[i] = xarr[i].ToString();
                    }
                    xbar = xAve(xlist);       //样本X的总和除以样本个数，求出平均值Xbar

                    double sumxx = 0;       //定义一个双精度变量
                    for (int i = 0; i < xarr.Count(); i++)      //循环，并求出标准偏差
                    {
                        sumxx += Math.Pow((Convert.ToSingle(xarr[i]) - Convert.ToSingle(xbar)), 2);
                    }
                    svalue = Convert.ToSingle(Math.Sqrt(sumxx / xarr.Count()));     //求得标准偏差
                    
                    //计算出控制界限
                    xcl = xbar;
                    xucl = xbar + (3 * svalue);
                    xlcl = xbar - (3 * svalue);
                    break;
                case "Xbar-R":      //当类型为Xbar-R时执行
                    //确定数组大小，数组大小为传入样本数量除以每个样本组包含的样本数
                    xlist = new float[xarr.Count() / n];
                    rlist = new float[xarr.Count() / n];

                    xtemp = new string[xarr.Count() / n];
                    rtemp = new string[xarr.Count() / n];

                    for (int i = 0; i < xarr.Count() / n; i++)      //循环，次数为样本组数
                    {
                        float[] tempxarr = new float[n];       //定义一个临时变量，用以储存单个样本组，为之后计算提供便利，数组大小为样本组样本数量
                        for(int j = 0; j < n; j++)      //循环，次数为样本组样本数量
                        {
                            tempxarr[j] = xarr[i * n + j];     //获取样本数据，注意下标，很关键。
                        }
                        xlist[i] = xAve(tempxarr);      //获取第i样本组平均值
                        xtemp[i] = xlist[i].ToString();
                        rlist[i] = dValue(tempxarr);        //获取第i样本组极差
                        rtemp[i] = rlist[i].ToString();
                    }
                    xbarbar = xAve(xlist);      //个样本组平均值的平均值
                    r = xAve(rlist);        //各样本组极差的平均值

                    //计算出控制上下限
                    xcl = xbarbar;
                    xucl = xbarbar + parameter[0] * r;
                    xlcl = xbarbar - parameter[0] * r;
                    rcl = r;
                    rucl = parameter[8] * r;
                    rlcl = parameter[7] * r;
                    break;
                case "Xmedian-R":       //当类型为Xmedian-R时执行
                    //确定数组大小，数组大小为传入样本数量除以每个样本组包含的样本数
                    xlist = new float[xarr.Count() / n];
                    rlist = new float[xarr.Count() / n];

                    xtemp = new string[xarr.Count() / n];
                    rtemp = new string[xarr.Count() / n];

                    //获取各个样本组的中位值和极差
                    for (int i = 0; i < xarr.Count() / n; i++)
                    {
                        float[] tempxarr = new float[n];
                        for(int j = 0; j < n; j++)
                        {
                            tempxarr[j] = xarr[i * n + j];     //获取样本数据，注意下标，很关键。
                        }
                        xlist[i] = xMid(tempxarr);      //获取第i样本组中位值
                        xtemp[i] = xlist[i].ToString();
                        rlist[i] = dValue(tempxarr);        //获取第i样本组极差
                        rtemp[i] = rlist[i].ToString();
                    }
                    xmedianbar = xAve(xlist);      //个样本组平均值的平均值
                    r = xAve(rlist);        //各样本组极差的平均值

                    //计算出控制上下限
                    xcl = xmedianbar;
                    xucl = xmedianbar + parameter[3] * r;
                    xlcl = xmedianbar - parameter[3] * r;
                    rcl = r;
                    rucl = parameter[8] * r;
                    rlcl = parameter[7] * r;
                    break;
                case "X-Rs":        //当类型为X-Rs时执行
                    n = 2;      //定义样本组数量，此处固定为2
                    xlist = new float[xarr.Count()];        //确定数组大小，数组大小为传入样本数量
                    rlist = new float[xarr.Count() - 1];        ////确定数组大小，数组大小为传入样本数量减一

                    xtemp = new string[xarr.Count()];
                    rtemp = new string[xarr.Count() - 1];

                    //默认2个样本为一组，极差数比总样本数少一
                    for (int i = 0; i < (xarr.Count() - 1); i++)        //设置下标-1是由于循环中会优先使用当前上标+1的数据，为了防止错误，此处使用了总样本数据量-1，循环结束后再补上未添加的数据
                    {
                        xlist[i] = xarr[i];
                        xtemp[i] = xarr[i].ToString();
                        rlist[i] = Math.Abs(xarr[i] - xarr[i + 1]);
                        rtemp[i] = rlist[i].ToString();
                    }

                    //此处是由于上部分循环还遗漏了最后一个X样本数据没有加入而再次补充
                    xlist[(xarr.Count() - 1)] = xarr[(xarr.Count() - 1)];       //补上xlist未添加的最后一个X的值
                    xtemp[(xarr.Count() - 1)] = xarr[(xarr.Count() - 1)].ToString();

                    xbar = xAve(xlist);
                    r = xAve(rlist);
                    parameter = standardclass.controlParameter(n);
                    xcl = xbar;
                    xucl = xbar + parameter[9] * r;
                    xlcl = xbar - parameter[9] * r;
                    rcl = r;
                    rucl = parameter[8] * r;
                    rlcl = parameter[7] * r;
                    break;
            }
            setMM();

            for (int i = 0; i < xlist.Count(); i++)
            {
                xlist[i] = Convert.ToSingle(xtemp[i]);
            }

            for (int i = 0; i < rlist.Count(); i++)
            {
                rlist[i] = Convert.ToSingle(rtemp[i]);
            }

        }

        public float xAve(float[] tempx)     //求平均数函数
        {
            float tempxbar = 0;
            for (int i = 0; i < tempx.Count(); i++)      //循环求得所有样本X的和
            {
                tempxbar += tempx[i];
            }
            return tempxbar /= tempx.Count();       //样本X的总和除以样本个数，求出平均值Xbar
        }

        public void sDev(float[] tempx)      //求标准差函数
        {

        }

        public float dValue(float[] tempx)        //求极差函数
        {
            tempx = maxTomin(tempx);        //将数组进行有大到小的排序
            return (tempx[0] - tempx[tempx.Count() - 1]);       //返回极差
        }

        public float[] maxTomin(float[] tempx)      //数组由达到小的排序
        {
            for (int i = 1; i < tempx.Count(); i++)
            {

                for (int j = 0; j < i; j++)
                {
                    if (tempx[j] < tempx[i])
                    {
                        float tempxvalue;
                        tempxvalue = tempx[i];
                        tempx[i] = tempx[j];
                        tempx[j] = tempxvalue;
                    }
                    else
                    {

                    }
                }
            }
            return tempx;
        }

        public float xMid(float[] tempx)       //获取中位值
        {
            tempx = maxTomin(tempx);
            //如果样本数为偶数，则取中间两个样本数据之和的平均值，否则直接取中位值
            if ((n % 2) == 0)
            {
                return ((tempx[(n / 2)] + tempx[((n / 2) - 1)]) / 2);       //注意下标
            }
            else
            {
                return tempx[((n / 2) - 1)];
            }
        }

        public void setMM()     //获取最大值和最小值
        {
            float[] tempx = maxTomin(xlist);
            float[] tempr = maxTomin(rlist);

            xmax = tempx[0];
            xmin = tempx[tempx.Count() - 1];
            rmax = tempr[0];
            rmin = tempr[tempr.Count() - 1];
        }

    }
}
