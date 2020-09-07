using System;
using System.Collections.Generic;
using System.Text;

namespace VSLIB.NET
{
    /// <summary>
    /// タイミング制御点の配列
    /// </summary>
    public class TimeCtrlPointList
    {
        /// <summary>
        /// 親アイテム
        /// </summary>
        public readonly Item item;

        /// <summary>
        /// タイミング制御点にアクセスするためのインデクサー
        /// newしているのでやや非効率な点に注意
        /// </summary>
        /// <param name="index">タイミング制御点番号</param>
        /// <returns>タイミング制御点</returns>
        public TimeCtrlPoint this[int index]
        {
            get
            {
                return new TimeCtrlPoint(item, index);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="item">親アイテム</param>
        public TimeCtrlPointList(Item item)
        {
            this.item = item;
        }

        /// <summary>
        /// タイミング制御点の数
        /// </summary>
        public int Length
        {
            get
            {
                item.Project.LastErrorCode = VSFunction.VslibGetTimeCtrlPntNum(item.Project.hVsprj, item.Index, out int timeCtrlPntNum);
                return timeCtrlPntNum;
            }
        }

        /// <summary>
        /// タイミング制御点の追加
        /// </summary>
        /// <param name="time1">編集前タイミング[サンプル]</param>
        /// <param name="time2">編集後タイミング[サンプル]</param>
        public void Add(int time1, int time2)
        {
            item.Project.LastErrorCode = VSFunction.VslibAddTimeCtrlPnt(item.Project.hVsprj, item.Index, time1, time2);
        }
    }
}
