using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// API返回的Json模型（用于Select等需要返回数据集的场景）
    /// </summary>
    public class ResultJsonInfo<T> : ResultJsonBase
    {
        public ResultJsonInfo()
        {

        }

        #region field

        private T data;

        #endregion

        #region property

        /// <summary>
        /// 返回数据
        /// </summary>
        [Description("返回数据")]
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        #endregion
    }
}
