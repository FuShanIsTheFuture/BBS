using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class BBSSection
    {
        #region 板块信息字段
        private int sID;
        private string sName;
        private int sMasterID;
        private string sStatement;
        private int sClickCount;
        private int sTopicCount;

        public int SID
        {
            get
            {
                return sID;
            }

            set
            {
                sID = value;
            }
        }

        public string SName
        {
            get
            {
                return sName;
            }

            set
            {
                sName = value;
            }
        }

        public int SMasterID
        {
            get
            {
                return sMasterID;
            }

            set
            {
                sMasterID = value;
            }
        }

        public string SStatement
        {
            get
            {
                return sStatement;
            }

            set
            {
                sStatement = value;
            }
        }

        public int SClickCount
        {
            get
            {
                return sClickCount;
            }

            set
            {
                sClickCount = value;
            }
        }

        public int STopicCount
        {
            get
            {
                return sTopicCount;
            }

            set
            {
                sTopicCount = value;
            }
        }


        #endregion

    }
}
