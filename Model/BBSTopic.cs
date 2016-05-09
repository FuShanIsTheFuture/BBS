using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class BBSTopic
    {
        #region 主贴信息字段
        private int tid;
        private int tsid;
        private int tuid;
        private int treplycount;
        private string tTopic;
        private string tContents;
        private DateTime tTime;
        private int tClickCount;
        private DateTime tLastClickT;
        private int tGoodCount;

        public int Tid
        {
            get
            {
                return tid;
            }

            set
            {
                tid = value;
            }
        }

        public int Tsid
        {
            get
            {
                return tsid;
            }

            set
            {
                tsid = value;
            }
        }

        public int Tuid
        {
            get
            {
                return tuid;
            }

            set
            {
                tuid = value;
            }
        }

        public int Treplycount
        {
            get
            {
                return treplycount;
            }

            set
            {
                treplycount = value;
            }
        }

        public string TTopic
        {
            get
            {
                return tTopic;
            }

            set
            {
                tTopic = value;
            }
        }

        public string TContents
        {
            get
            {
                return tContents;
            }

            set
            {
                tContents = value;
            }
        }

        public DateTime TTime
        {
            get
            {
                return tTime;
            }

            set
            {
                tTime = value;
            }
        }

        public int TClickCount
        {
            get
            {
                return tClickCount;
            }

            set
            {
                tClickCount = value;
            }
        }

        public DateTime TLastClickT
        {
            get
            {
                return tLastClickT;
            }

            set
            {
                tLastClickT = value;
            }
        }

        public int TGoodCount
        {
            get
            {
                return tGoodCount;
            }

            set
            {
                tGoodCount = value;
            }
        }




        #endregion
    }
}
