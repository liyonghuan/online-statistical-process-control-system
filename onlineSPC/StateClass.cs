using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace onlineSPC
{
    class StateClass
    {
        SQL_Class SQLClass = new SQL_Class();

        public int state;

        public void UpdateProcess(int measure_id, float measure, string ucl, string lcl)
        {
            if(ucl == "" && lcl == "")
            {
                state = 3;
            }
            else if(ucl == "")
            {
                float process_lcl = Convert.ToSingle(lcl);
                if (measure >= process_lcl)
                {
                    state = 3;
                }
                else
                {
                    state = 0;
                }
            }
            else if (lcl == "")
            {
                float process_ucl = Convert.ToSingle(ucl);
                if(measure <= process_ucl)
                {
                    state = 3;
                }
                else
                {
                    state = 0;
                }
            }
            else
            {
                float process_ucl = Convert.ToSingle(ucl);
                float process_lcl = Convert.ToSingle(lcl);
                if (measure >= process_lcl && measure <= process_ucl)
                {
                    state = 3;
                }
                else
                {
                    state = 0;
                }
            }

            SQLClass.getsqlcom("update measure set measure_state = '" + state + "' where measure_id = '" + measure_id + "'");

        }

        public int UpdateMeasure(float measure,int process_id)
        {
            DataSet DSet = SQLClass.getDataSet("select process_ucl,process_lcl from process where process_id = '" + process_id + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象

            if (dt.Rows.Count > 0)
            {
                string ucl = dt.Rows[0][0].ToString();
                string lcl = dt.Rows[0][1].ToString();

                if (ucl == "absoluteness" && lcl == "absoluteness")
                {
                    state = 3;
                }
                else if (ucl == "absoluteness")
                {
                    float process_lcl = Convert.ToSingle(lcl);
                    if (measure >= process_lcl)
                    {
                        state = 3;
                    }
                    else
                    {
                        state = 0;
                    }
                }
                else if (lcl == "absoluteness")
                {
                    float process_ucl = Convert.ToSingle(ucl);
                    if (measure <= process_ucl)
                    {
                        state = 3;
                    }
                    else
                    {
                        state = 0;
                    }
                }
                else
                {
                    float process_ucl = Convert.ToSingle(ucl);
                    float process_lcl = Convert.ToSingle(lcl);
                    if (measure >= process_lcl && measure <= process_ucl)
                    {
                        state = 3;
                    }
                    else
                    {
                        state = 0;
                    }
                }

            }
            else
            {

            }

            return state;
        }
    }
}
