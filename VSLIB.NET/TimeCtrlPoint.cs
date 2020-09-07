using System;
using System.Collections.Generic;
using System.Text;

namespace VSLIB.NET
{
    /// <summary>
    /// タイミング制御点
    /// </summary>
    public class TimeCtrlPoint
    {
        /// <summary>
        /// 親アイテム
        /// </summary>
        public readonly Item Item;
        /// <summary>
        /// タイミング制御点番号
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="item">親アイテム</param>
        /// <param name="index">タイミング制御点番号</param>
        public TimeCtrlPoint(Item item, int index)
        {
            this.Item = item;
            this.Index = index;
        }


        /// <summary>
        /// 制御点情報の取得
        /// </summary>
        /// <returns>(編集前,編集後)タイミング[サンプル]</returns>
        public (int time1, int time2) GetInfo()
        {
            Item.Project.LastErrorCode = VSFunction.VslibGetTimeCtrlPnt(Item.Project.hVsprj, Item.Index, Index, out int time1, out int time2);
            return (time1, time2);
        }

        /// <summary>
        /// 制御点情報の設定
        /// </summary>
        /// <param name="time1">編集前タイミング[サンプル]</param>
        /// <param name="time2">編集後タイミング[サンプル]</param>
        public void SetInfo(int time1, int time2)
        {
            Item.Project.LastErrorCode = VSFunction.VslibSetTimeCtrlPnt(Item.Project.hVsprj, Item.Index, Index, time1, time2);
        }

        /// <summary>
        /// タイミング制御点の破棄
        /// </summary>
        public void Dispose()
        {
            Item.Project.LastErrorCode = VSFunction.VslibDeleteTimeCtrlPnt(Item.Project.hVsprj, Item.Index, Index);
        }

        /// <summary>
        /// 編集前タイミング[サンプル]
        /// </summary>
        public int time1
        {
            get
            {
                (int time1, int time2) = GetInfo();
                return time1;
            }
            set
            {
                (int time1, int time2) = GetInfo();
                SetInfo(value, time2);
            }
        }

        /// <summary>
        /// 編集後タイミング[サンプル]
        /// </summary>
        public int time2
        {
            get
            {
                (int time1, int time2) = GetInfo();
                return time2;
            }
            set
            {
                (int time1, int time2) = GetInfo();
                SetInfo(time1, value);
            }
        }


    }
}
