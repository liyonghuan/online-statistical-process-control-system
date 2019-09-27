using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace onlineSPC
{
    class StandardClass
    {
        public string[] CpkStandard(float cpk)
        {
            string[] returncpk = { "级别", "工序能力指数", "对应关系", "不合格品率", "工序能力分析" };
            float[,] cpkstandard = { { 1.67F, 10, 0.0000006F }, { 1.33F, 8, 0.00006F }, { 1F, 6, 0.0027F }, { 0.67F, 4, 0.0445F } };
            if(cpk > 1.67)
            {
                returncpk[0] = "特级";
                returncpk[1] = "Cpk > 1.67";
                returncpk[2] = "P < 0.000 06%";
                returncpk[3] = "工序能力很充分";
            }
            else if(cpk > 1.33 && cpk <= 1.67)
            {
                returncpk[0] = "一级";
                returncpk[1] = "1.33 < Cpk <= 1.67";
                returncpk[2] = "0.000 06% < P <= 0.006%";
                returncpk[3] = "工序能力充分";
            }
            else if(cpk > 1 && cpk <= 1.33)
            {
                returncpk[0] = "二级";
                returncpk[1] = "1 < Cpk <= 1.33";
                returncpk[2] = "0.006% < P <= 0.27%";
                returncpk[3] = "工序能力尚可";
            }else if(cpk > 0.67 && cpk <= 1)
            {
                returncpk[0] = "三级";
                returncpk[1] = "0.67 < Cpk <= 1";
                returncpk[2] = "0.27% < P <= 4.45%";
                returncpk[3] = "工序能力不足";
            }
            else
            {
                returncpk[0] = "四级";
                returncpk[1] = "Cpk <= 0.67";
                returncpk[2] = "P > 4.45%";
                returncpk[3] = "工序能力严重不足";
            }
            return returncpk;
        }

        public float[] controlParameter(int n)
        {
            float [] returnparameter = new float[10];
            switch(n)
            {
                case 2:
                    returnparameter[0] = 1.880F;        //A2
                    returnparameter[1] = 2.224F;        //A3
                    returnparameter[2] = 1.000F;        //m3
                    returnparameter[3] = 1.880F;        //m3A2
                    returnparameter[4] = 1.128F;        //d2
                    returnparameter[5] = 0.853F;        //d3
                    returnparameter[6] = 3.686F;        //D2
                    //returnparameter[7] = ;        //D3
                    returnparameter[8] = 3.267F;        //D4
                    returnparameter[9] = 2.660F;        //E2
                    break;
                case 3:
                    returnparameter[0] = 1.023F;
                    returnparameter[1] = 1.099F;
                    returnparameter[2] = 1.160F;
                    returnparameter[3] = 1.187F;
                    returnparameter[4] = 1.693F;
                    returnparameter[5] = 0.888F;
                    returnparameter[6] = 4.358F;
                    //returnparameter[7] = ;
                    returnparameter[8] = 2.575F;
                    returnparameter[9] = 1.772F;
                    break;
                case 4:
                    returnparameter[0] = 0.729F;
                    returnparameter[1] = 0.758F;
                    returnparameter[2] = 1.092F;
                    returnparameter[3] = 0.796F;
                    returnparameter[4] = 2.059F;
                    returnparameter[5] = 0.880F;
                    returnparameter[6] = 4.698F;
                    //returnparameter[7] = ;
                    returnparameter[8] = 2.282F;
                    returnparameter[9] = 1.457F;
                    break;
                case 5:
                    returnparameter[0] = 0.577F;
                    returnparameter[1] = 0.594F;
                    returnparameter[2] = 1.198F;
                    returnparameter[3] = 0.691F;
                    returnparameter[4] = 9.326F;
                    returnparameter[5] = 0.864F;
                    returnparameter[6] = 4.918F;
                    //returnparameter[7] = ;
                    returnparameter[8] = 2.115F;
                    returnparameter[9] = 1.290F;
                    break;
                case 6:
                    returnparameter[0] = 0.483F;
                    returnparameter[1] = 0.495F;
                    returnparameter[2] = 1.135F;
                    returnparameter[3] = 0.549F;
                    returnparameter[4] = 2.534F;
                    returnparameter[5] = 0.848F;
                    returnparameter[6] = 5.078F;
                    //returnparameter[7] = ;
                    returnparameter[8] = 2.004F;
                    returnparameter[9] = 1.184F;
                    break;
                case 7:
                    returnparameter[0] = 0.419F;
                    returnparameter[1] = 0.429F;
                    returnparameter[2] = 1.214F;
                    returnparameter[3] = 0.509F;
                    returnparameter[4] = 2.704F;
                    returnparameter[5] = 0.833F;
                    returnparameter[6] = 5.203F;
                    returnparameter[7] = 0.076F;
                    returnparameter[8] = 1.924F;
                    returnparameter[9] = 1.109F;
                    break;
                case 8:
                    returnparameter[0] = 0.373F;
                    returnparameter[1] = 0.380F;
                    returnparameter[2] = 1.166F;
                    returnparameter[3] = 0.432F;
                    returnparameter[4] = 2.847F;
                    returnparameter[5] = 0.820F;
                    returnparameter[6] = 5.307F;
                    returnparameter[7] = 0.136F;
                    returnparameter[8] = 1.864F;
                    returnparameter[9] = 1.054F;
                    break;
                case 9:
                    returnparameter[0] = 0.337F;
                    returnparameter[1] = 0.343F;
                    returnparameter[2] = 1.223F;
                    returnparameter[3] = 0.412F;
                    returnparameter[4] = 2.970F;
                    returnparameter[5] = 0.808F;
                    returnparameter[6] = 5.394F;
                    returnparameter[7] = 0.184F;
                    returnparameter[8] = 1.816F;
                    returnparameter[9] = 1.010F;
                    break;
                case 10:
                    returnparameter[0] = 0.308F;
                    returnparameter[1] = 0.314F;
                    returnparameter[2] = 1.177F;
                    returnparameter[3] = 0.363F;
                    returnparameter[4] = 3.173F;
                    returnparameter[5] = 0.797F;
                    returnparameter[6] = 5.469F;
                    returnparameter[7] = 0.223F;
                    returnparameter[8] = 1.777F;
                    returnparameter[9] = 0.975F;
                    break;
            }

            return returnparameter;
        }
    }
}
