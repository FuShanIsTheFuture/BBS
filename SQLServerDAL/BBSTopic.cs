using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using System.Data;

namespace SQLServerDAL
{
    public class BBSTopic:IDAL.IBBSTopic
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="Top">前top行记录</param>
        /// <returns>表记录</returns>
        public DataSet GetList(int Top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append("tid,treplycount,TTopic,TTime,TLastClickT ");
            strSql.Append(" FROM BBSTopic ");
            strSql.Append(" order by tid desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <returns>对象实体</returns>
        public Model.BBSTopic GetModel(int Uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" TTopic,tsid,TContents,TClickCount,TLastClickT ");
            strSql.Append(" from BBSTopic ");
            strSql.Append(" where tid =" + Uid + "");
            Model.BBSTopic model = new Model.BBSTopic();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TTopic = ds.Tables[0].Rows[0][0].ToString();
                model.Tsid =int.Parse(ds.Tables[0].Rows[0][1].ToString());
                model.TContents = ds.Tables[0].Rows[0][2].ToString();
                model.TClickCount =int.Parse(ds.Tables[0].Rows[0][3].ToString());
                model.TLastClickT =DateTime.Parse(ds.Tables[0].Rows[0][4].ToString());

                //更新点击次数
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("select TClickCount from BBSTopic where tid =" + Uid + "");
                DbHelperSQL db = new DbHelperSQL();
                object ds1 = DbHelperSQL.GetSingle(strSql1.ToString());
                int count = int.Parse(ds1.ToString())+1;
                strSql1.Clear();
                strSql1.Append("update BBSTopic set TClickCount="+count+"where tid="+Uid+"");
                ds1 = DbHelperSQL.GetSingle(strSql1.ToString());

                //更新最后点击时间
                strSql1.Clear();
                //获取当前时间
                string dt = DateTime.Now.ToString();
                strSql1.Append("update BBSTopic set TLastClickT='" + dt + "'where tid=" + Uid + "");
                ds1 = DbHelperSQL.GetSingle(strSql1.ToString());

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tid,tuid,TTopic,TContents ");
            strSql.Append(" FROM BBSTopic ");
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

            strSql.Append("delete from BBSTopic ");
            strSql.Append(" where tid in (" + adminIDlist + ")  ");
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
        /// 增加一条帖子记录
        /// </summary>
        /// <param name="model">帖子实体</param>
        /// <returns>帖子id</returns>
        public int add(Model.BBSTopic model)
        {
            //获取当前用户的最大编号
            //string bir = model.UBirthday;
            string sql = string.Format(@"INSERT INTO [dbo].[BBSTopic]
           ([tsid]
           ,[tuid]
           ,[treplycount]
           ,[TTopic]
           ,[TContents]
           ,[TTime]
           ,[TClickCount]
           ,[TLastClickT])
     VALUES
           ({0}
           ,{1}
           ,{2}
           ,'{3}'
           ,'{4}'
           ,'{5}'
           ,{6}
           ,'{7}')",
            model.Tsid,model.Tuid,model.Treplycount,model.TTopic,model.TContents,model.TTime,model.TClickCount,model.TLastClickT
           );//为用户表增加数据
            //sql 字符串类型的值要用‘’。数字、日期类型不需要‘’
            string sql1 = string.Format(@"select top 1 tid from BBSTopic where TTopic='{0}'", model.TTopic);

            object ob = DbHelperSQL.GetSingle(sql);
            object ob1 = DbHelperSQL.GetSingle(sql1.ToString());
            if (ob1 == null) { return 0; }
            else
            { return Convert.ToInt32(ob1); }


        }
    }
}
