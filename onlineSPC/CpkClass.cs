using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace onlineSPC
{
    class CpkClass
    {
        public float Xbar;		//平均值，由外部传入
        public float Svalue;		//标准偏差值，由外部传入
        public float Tucl;		//上控制界限
        public float Tlcl;		//下控制界限
        public float Cp;		//过程能力指数
        public float Cpk;		//修正过程能力指数 最终使用的数据
        public float Tvalue;		//上下控制界限差
        public float Mvalue;		//中心值
        public float Kvalue;		//修正系数
        public bool is_ok;		//是否成功求得过程能力指数

        public CpkClass(float  xave, float snum, string ucl, string lcl)
        {
            Xbar = xave;
            Svalue = snum;
            if((ucl == "" || ucl == "absoluteness") && (lcl == "" || lcl == "absoluteness"))
            {
                is_ok = false;
            }
            else if(ucl == "" || ucl == "absoluteness")
            {
                if (lcl == "" || lcl == "absoluteness")
                {
                    is_ok = false;
                }
                else
                {
                    Tlcl = Convert.ToSingle(lcl);
                    SingleLcl();
                    is_ok = true;
                }
            }
            else if(lcl == "" || lcl == "absoluteness")
            {
                if(ucl == "" || ucl == "absoluteness")
                {
                    is_ok = false;
                }
                else
                {
                    Tucl = Convert.ToSingle(ucl);
                    SingleUcl();
                    is_ok = true;
                }
            }
            else
            {
                Tucl = Convert.ToSingle(ucl);
                Tlcl = Convert.ToSingle(lcl);
                Doublecl();
                is_ok = true;
            }
        }

        private void SingleUcl()
        {
            if(Convert.ToString(Math.Abs(Tucl - Xbar)) == (Tucl - Xbar).ToString())
            {
                Cpk = (Tucl - Xbar) / (3 * Svalue);
            }
            else
            {
                Cpk = 0;
            }
            
        }

        private void SingleLcl()
        {
            if (Convert.ToString(Math.Abs(Xbar - Tlcl)) == (Xbar - Tlcl).ToString())
            {
                Cpk = (Xbar - Tlcl) / (3 * Svalue);
            }
            else
            {
                Cpk = 0;
            }
        }

        private void Doublecl()
        {
            Mvalue = (Tucl + Tlcl) / 2;
            Tvalue = Tucl - Tlcl;
            Kvalue = Math.Abs(Mvalue - Xbar) / (Tvalue / 2);
            Cp = Tvalue / (6 * Svalue);
            Cpk = Cp * (1 - Kvalue);
        }
    }
}
