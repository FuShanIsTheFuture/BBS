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

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SID,SName,SMasterID,SStatement ");
            strSql.Append(" FROM BBSSection ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string adminIDlist)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("delete from BBSSection ");
            strSql.Append(" where SID in (" + adminIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.BBSSection model)
        {
            //SID,SName,SMasterID,SStatement
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BBSSection set ");
            strSql.Append("SName='" + model.SName + "',");
            strSql.Append("SStatement='" + model.SStatement + "',");
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where SID=" + model.SID + "");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
