using System;
using System.Collections.Generic;
using System.Text;

namespace VSLIB.NET
{
    /// <summary>
    /// 制御点の配列
    /// </summary>
    public class CtrlPointList
    {
        /// <summary>
        /// 親アイテム
        /// </summary>
        public readonly Item item;

        /// <summary>
        /// 制御点にアクセスするためのインデクサー
        /// newするのでやや非効率な点に注意
        /// </summary>
        /// <param name="index">制御点番号</param>
        /// <returns>制御点</returns>
        public CtrlPoint this[int index]
        {
            get
            {
                return new CtrlPoint(item, index);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="item">親アイテム</param>
        public CtrlPointList(Item item)
        {
            this.item = item;
        }

        /// <summary>
        /// 制御点の数
        /// </summary>
        public int Length
        {
            get
            {
                return item.CtrlPntNum;
            }
        }
    }
}
