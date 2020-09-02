using System;
using System.Collections.Generic;
using System.Text;

namespace VSLIB.NET
{
    public class TimeCtrlPoint
    {
        public readonly Item Item;
        public readonly int Index;

        public TimeCtrlPoint(Item item, int index)
        {
            this.Item = item;
            this.Index = index;
        }


        public (int time1, int time2) GetInfo()
        {
            Item.Project.LastErrorCode = VSFunction.VslibGetTimeCtrlPnt(Item.Project.hVsprj, Item.Index, Index, out int time1, out int time2);
            return (time1, time2);
        }

        public void SetInfo(int time1, int time2)
        {
            Item.Project.LastErrorCode = VSFunction.VslibSetTimeCtrlPnt(Item.Project.hVsprj, Item.Index, Index, time1, time2);
        }

        public void Dispose()
        {
            Item.Project.LastErrorCode = VSFunction.VslibDeleteTimeCtrlPnt(Item.Project.hVsprj, Item.Index, Index);
        }

    }
}
