using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// ResultJsonBase
    /// </summary>
    public class ResultJsonBase
    {

        public ResultJsonBase()
        {

        }

        #region field

        private int status;
        private string info;

        #endregion

        #region property

        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态(0:失败 1:成功)")]
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        [Description("提示信息")]
        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        #endregion
    }

    public class ResultConfig
    {
        public const int Fail = 0;
        public const int Success = 1;
    }
}
