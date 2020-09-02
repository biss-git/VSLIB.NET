using System;
using System.Collections.Generic;
using System.Text;

namespace VSLIB.NET
{
    public class TimeCtrlPointList
    {
        public readonly Item item;

        public TimeCtrlPoint this[int index]
        {
            get
            {
                return new TimeCtrlPoint(item, index);
            }
        }

        public TimeCtrlPointList(Item item)
        {
            this.item = item;
        }

        public int Length
        {
            get
            {
                item.Project.LastErrorCode = VSFunction.VslibGetTimeCtrlPntNum(item.Project.hVsprj, item.Index, out int timeCtrlPntNum);
                return timeCtrlPntNum;
            }
        }

        public void Add(int time1, int time2)
        {
            item.Project.LastErrorCode = VSFunction.VslibAddTimeCtrlPnt(item.Project.hVsprj, item.Index, time1, time2);
        }
    }
}
