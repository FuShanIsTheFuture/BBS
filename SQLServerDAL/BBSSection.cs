using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using System.Data;

namespace SQLServerDAL
{
    public class BBSSection:IDAL.IBBSSection
    {
        public DataSet GetList(int sid, int top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" tid,TTopic,TTime ");
            strSql.Append(" FROM BBSTopic,BBSSection ");
            strSql.Append(" where SID="+sid+" and BBSTopic.tsid=BBSSection.SID ");
            strSql.Append(" order by tid desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
