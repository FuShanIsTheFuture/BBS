using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Admin
    {
        #region BBS用户字段
        private int uid;//用户编号
        private string uname;//用户姓名
        private string uPassword;//用户密码
        private string uEmail;//用户邮箱
        private string uBirthday;//用户生日
        private bool usex;//用户性别
        private int uClass;//用户等级
        private string uStatement;//用户个人说明
        private DateTime uRegDate;//用户注册时间
        private int uState;//用户状态
        private int uPoint;//用户积分

        public int Uid
        {
            get
            {
                return uid;
            }

            set
            {
                uid = value;
            }
        }

        public string Uname
        {
            get
            {
                return uname;
            }

            set
            {
                uname = value;
            }
        }

        public string UPassword
        {
            get
            {
                return uPassword;
            }

            set
            {
                uPassword = value;
            }
        }

        public string UEmail
        {
            get
            {
                return uEmail;
            }

            set
            {
                uEmail = value;
            }
        }

        public string UBirthday
        {
            get
            {
                return uBirthday;
            }

            set
            {
                uBirthday = value;
            }
        }

        public bool Usex
        {
            get
            {
                return usex;
            }

            set
            {
                usex = value;
            }
        }

        public int UClass
        {
            get
            {
                return uClass;
            }

            set
            {
                uClass = value;
            }
        }

        public string UStatement
        {
            get
            {
                return uStatement;
            }

            set
            {
                uStatement = value;
            }
        }

        public DateTime URegDate
        {
            get
            {
                return uRegDate;
            }

            set
            {
                uRegDate = value;
            }
        }

        public int UState
        {
            get
            {
                return uState;
            }

            set
            {
                uState = value;
            }
        }

        public int UPoint
        {
            get
            {
                return uPoint;
            }

            set
            {
                uPoint = value;
            }
        }


        #endregion
        

        
    }
}
