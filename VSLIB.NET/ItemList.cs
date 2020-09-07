using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VSLIB.NET
{
    /// <summary>
    /// アイテムの配列
    /// </summary>
    public class ItemList
    {
        /// <summary>
        /// 親プロジェクト
        /// </summary>
        public readonly VSProject project;
        /// <summary>
        /// アイテムの配列
        /// 最大数が固定なので最初に作ってしまう
        /// プライベートな配列なので必要ないが、一応完全なreadonly属性にしておく
        /// </summary>
        private readonly ReadOnlyCollection<Item> Items;

        /// <summary>
        /// アイテムにアクセスするためのインデクサー
        /// </summary>
        /// <param name="index">アイテム番号</param>
        /// <returns>アイテム</returns>
        public Item this[int index]
        {
            get
            {
                return Items[index];
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="project">親プロジェクト</param>
        public ItemList(VSProject project)
        {
            this.project = project;
            Item[] items = new Item[Const.VSLIB_MAX_ITEM];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item(project, i);
            }
            Items = Array.AsReadOnly(items);
        }

        /// <summary>
        /// アイテムの数
        /// </summary>
        public int Length
        {
            get
            {
                project.LastErrorCode = VSFunction.VslibGetItemMaxNum(project.hVsprj, out int itemMaxNum);
                return itemMaxNum;
            }
        }

        /// <summary>
        /// アイテムの追加
        /// </summary>
        /// <param name="fileName">音声ファイルのパス</param>
        /// <returns>追加されたアイテムの番号</returns>
        public int Add(string fileName)
        {
            project.LastErrorCode = VSFunction.VslibAddItem(project.hVsprj, fileName, out int itemNum);
            return itemNum;
        }

        /// <summary>
        /// アイテムの追加
        /// </summary>
        /// <param name="fileName">音声ファイルのパス</param>
        /// <param name="nnOffset">解析する最低音のノートナンバー(C4=60)</param>
        /// <param name="nnRange">解析する音階の範囲[半音](つまり12で１オクターブ)</param>
        /// <param name="skipPitFlg">ピッチ解析無効フラグ</param>
        /// <returns>追加されたアイテムの番号</returns>
        public int Add(string fileName, int nnOffset, int nnRange, bool skipPitFlg)
        {
            project.LastErrorCode = VSFunction.VslibAddItemEx(project.hVsprj, fileName, out int itemNum, nnOffset, nnRange, skipPitFlg? 1: 0);
            return itemNum;
        }

        /// <summary>
        /// アイテムの追加（コピー）
        /// </summary>
        /// <param name="itemSrc">コピー元のアイテム</param>
        /// <returns>追加されたアイテムの番号</returns>
        public int Add(Item itemSrc)
        {
            project.LastErrorCode = VSFunction.VslibCopyItem(project.hVsprj, out int itemNumDist, itemSrc.Project.hVsprj, itemSrc.Index);
            return itemNumDist;
        }

        /// <summary>
        /// アイテムをすべて破棄
        /// </summary>
        public void Clear()
        {
            while (Length > 0)
            {
                this[0].Dispose();
            }
        }
    }
}
