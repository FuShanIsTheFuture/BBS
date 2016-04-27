using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class BBSReply
    {
        #region 回帖信息字段
        private int rID;
        private int rTID;
        private int rSID;
        private int rUID;
        private string rTopic;
        private string rContents;
        private DateTime rTime;
        private int rClickCount;

        public int RID
        {
            get
            {
                return rID;
            }

            set
            {
                rID = value;
            }
        }

        public int RTID
        {
            get
            {
                return rTID;
            }

            set
            {
                rTID = value;
            }
        }

        public int RSID
        {
            get
            {
                return rSID;
            }

            set
            {
                rSID = value;
            }
        }

        public int RUID
        {
            get
            {
                return rUID;
            }

            set
            {
                rUID = value;
            }
        }

        public string RTopic
        {
            get
            {
                return rTopic;
            }

            set
            {
                rTopic = value;
            }
        }

        public string RContents
        {
            get
            {
                return rContents;
            }

            set
            {
                rContents = value;
            }
        }

        public DateTime RTime
        {
            get
            {
                return rTime;
            }

            set
            {
                rTime = value;
            }
        }

        public int RClickCount
        {
            get
            {
                return rClickCount;
            }

            set
            {
                rClickCount = value;
            }
        }
        #endregion
    }
}
