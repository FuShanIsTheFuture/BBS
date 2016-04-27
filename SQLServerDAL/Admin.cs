﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using System.Data;

namespace SQLServerDAL
{
  public  class Admin:IDAL.IAdmin
    {
        /// <summary>
        /// 增加一条用户记录
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns>用户id</returns>
        public int add(Model.Admin model)
        {
            int sex1 = 0;
            if (model.Usex) { sex1 = 1; }//用户性别
            //获取当前用户的最大编号
            string bir = model.UBirthday;
            string sql = string.Format(@"INSERT INTO [dbo].[BBSUsers]
           ([Uname]
           ,[UPassword]
           ,[UEmail]
           ,[UBirthday]
           ,[Usex]
           ,[UClass]
           ,[UStatement]
           ,[URegDate]
           ,[UState]
           ,[UPoint])
     VALUES
           ('{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}',{8},'{9}')",
            model.Uname,model.UPassword,model.UEmail,model.UBirthday,sex1,0,model.UStatement,model.URegDate,1,0
           );//为用户表增加数据
            //sql 字符串类型的值要用‘’。数字、日期类型不需要‘’
            string sql1 = string.Format(@"select top 1 Uid from BBSUsers where Uname='{0}'",model.Uname);
            
            object ob= DbHelperSQL.GetSingle(sql);
            object ob1 = DbHelperSQL.GetSingle(sql1.ToString());
            if (ob1 == null) { return 0; }
            else
            { return Convert.ToInt32(ob1); }

          
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户姓名</param>
        /// <param name="pwd">密码</param>
        /// <returns>用户id</returns>
        public int Login(string name, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Uid ");
            strSql.Append(" from BBSUsers ");
            strSql.Append(" where Uname='" + name + "' collate Chinese_PRC_CS_AI and UPassword='" + pwd + "' collate Chinese_PRC_CS_AI");

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }


        }
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
            strSql.Append(" Uid,Uname,UPassword,UEmail,UBirthday,URegDate ");
            strSql.Append(" FROM BBSUsers ");

            strSql.Append(" order by Uid desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <returns>对象实体</returns>
        public Model.Admin GetModel(int Uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" * ");
            strSql.Append(" from BBSUsers ");
            strSql.Append(" where Uid=" + Uid + "");
            Model.Admin model = new Model.Admin();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Uid= int.Parse(ds.Tables[0].Rows[0][0].ToString());
                model.Uname = ds.Tables[0].Rows[0][1].ToString();
                model.UPassword = ds.Tables[0].Rows[0][2].ToString();
                model.UEmail = ds.Tables[0].Rows[0][3].ToString();
                model.UBirthday = ds.Tables[0].Rows[0][4].ToString();
                model.Usex = true;
                if (ds.Tables[0].Rows[0][5].ToString() == "False")
                {
                    model.Usex = false;
                }
                model.UClass = int.Parse(ds.Tables[0].Rows[0][6].ToString());
                model.UStatement = ds.Tables[0].Rows[0][7].ToString();
                model.UState = int.Parse(ds.Tables[0].Rows[0][9].ToString());
                model.UPoint = int.Parse(ds.Tables[0].Rows[0][10].ToString());
                
                return model;
            }
            else
            {
                return null;
            }
        }

    }
}