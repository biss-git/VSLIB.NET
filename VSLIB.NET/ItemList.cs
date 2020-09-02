using System;
using System.Collections.Generic;
using System.Text;

namespace VSLIB.NET
{
    public class ItemList
    {
        public readonly VSProject project;
        private Item[] Items = new Item[Const.VSLIB_MAX_ITEM];

        public Item this[int index]
        {
            get
            {
                return Items[index];
            }
        }

        public ItemList(VSProject project)
        {
            this.project = project;
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = new Item(project, i);
            }
        }

        public int Length
        {
            get
            {
                project.LastErrorCode = VSFunction.VslibGetItemMaxNum(project.hVsprj, out int itemMaxNum);
                return itemMaxNum;
            }
        }

        public void Add(string fileName)
        {
            project.LastErrorCode = VSFunction.VslibAddItem(project.hVsprj, fileName, out int itemNum);
        }

        public void Add(string fileName, int nnOffset, int nnRange, bool skipPitFlg)
        {
            project.LastErrorCode = VSFunction.VslibAddItemEx(project.hVsprj, fileName, out int itemNum, nnOffset, nnRange, skipPitFlg? 1: 0);
        }

        public int Add(Item itemSrc)
        {
            project.LastErrorCode = VSFunction.VslibCopyItem(project.hVsprj, out int itemNumDist, itemSrc.Project.hVsprj, itemSrc.Index);
            return itemNumDist;
        }

        public void Clear()
        {
            while (Length > 0)
            {
                this[0].Dispose();
            }
        }
    }
}
