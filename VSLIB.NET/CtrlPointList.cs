using System;
using System.Collections.Generic;
using System.Text;

namespace VSLIB.NET
{
    public class CtrlPointList
    {
        public readonly Item item;

        public CtrlPoint this[int index]
        {
            get
            {
                return new CtrlPoint(item, index);
            }
        }

        public CtrlPointList(Item item)
        {
            this.item = item;
        }

        public int Length
        {
            get
            {
                return item.CtrlPntNum;
            }
        }
    }
}
