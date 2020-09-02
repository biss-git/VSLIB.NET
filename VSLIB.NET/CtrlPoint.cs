using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace VSLIB.NET
{
    public class CtrlPoint
    {
        public readonly Item Item;
        public readonly int Index;

        public CtrlPoint(Item item, int index)
        {
            this.Item = item;
            this.Index = index;
        }

        /// <summary>
        /// 制御点情報
        /// </summary>
        public VSCPINFOEX Info
        {
            get
            {
                Item.Project.LastErrorCode = VSFunction.VslibGetCtrlPntInfoEx(Item.Project.hVsprj, Item.Index, Index, out VSCPINFOEX vsCpInfo);
                return vsCpInfo;
            }
            set
            {
                Item.Project.LastErrorCode = VSFunction.VslibSetCtrlPntInfoEx(Item.Project.hVsprj, Item.Index, Index, value);
            }
        }



        /// <summary>
        /// (R/-)編集前ダイナミクス[倍]
        /// </summary>
        public double DynOrg
        {
            get
            {
                return Info.dynOrg;
            }
        }

        /// <summary>
        /// (R/W)編集後ダイナミクス[倍]
        /// </summary>
        public double DynEdit 
        {
            get
            {
                return Info.dynEdit;
            }
            set
            {
                VSCPINFOEX info = this.Info;
                if (Item.Project.LastErrorCode == 0)
                {
                    info.dynEdit = value;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)ボリューム[倍]
        /// </summary>
        public double Volume
        {
            get
            {
                return Info.volume;
            }
            set
            {
                VSCPINFOEX info = this.Info;
                if (Item.Project.LastErrorCode == 0)
                {
                    info.volume = value;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)パン(-1.0~1.0)
        /// </summary>
        public double Pan
        {
            get
            {
                return Info.pan;
            }
            set
            {
                VSCPINFOEX info = this.Info;
                if (Item.Project.LastErrorCode == 0)
                {
                    info.pan = value;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/-)スペクトルダイナミクス
        /// </summary>
        public double SpecDyn
        {
            get
            {
                return Info.spcDyn;
            }
        }

        /// <summary>
        /// (R/-)ピッチ解析値[cent,C4=6000]
        /// </summary>
        public int PitAna
        {
            get
            {
                return Info.pitAna;
            }
        }

        /// <summary>
        /// (R/W)ピッチ編集前[cent,C4=6000]
        /// </summary>
        public int PitOrg
        {
            get
            {
                return Info.pitOrg;
            }
            set
            {
                VSCPINFOEX info = this.Info;
                if (Item.Project.LastErrorCode == 0)
                {
                    info.pitOrg = value;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)ピッチ編集後[cent,C4=6000]
        /// </summary>
        public int PitEdit
        {
            get
            {
                return Info.pitEdit;
            }
            set
            {
                VSCPINFOEX info = this.Info;
                if (Item.Project.LastErrorCode == 0)
                {
                    info.pitEdit = value;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)フォルマント[cent]
        /// </summary>
        public int Formant
        {
            get
            {
                return Info.formant;
            }
            set
            {
                VSCPINFOEX info = this.Info;
                if (Item.Project.LastErrorCode == 0)
                {
                    info.formant = value;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/-)編集前ピッチ有無フラグ
        /// </summary>
        public bool PitFlagOrg
        {
            get
            {
                return (Info.pitFlgOrg != 0);
            }
        }

        /// <summary>
        /// (R/W)編集後ピッチ有無フラグ
        /// </summary>
        public bool PitFlgEdit
        {
            get
            {
                return (Info.pitFlgEdit != 0);
            }
            set
            {
                VSCPINFOEX info = this.Info;
                if (Item.Project.LastErrorCode == 0)
                {
                    info.pitFlgEdit = value ? 1 : 0;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)ブレ市ネス[-10000~10000]
        /// </summary>
        public int Breathiness
        {
            get
            {
                return Info.breathiness;
            }
            set
            {
                VSCPINFOEX info = this.Info;
                if (Item.Project.LastErrorCode == 0)
                {
                    info.breathiness = value;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)EQ1[-10000~10000]
        /// </summary>
        public int Eq1
        {
            get
            {
                return Info.eq1;
            }
            set
            {
                VSCPINFOEX info = this.Info;
                if (Item.Project.LastErrorCode == 0)
                {
                    info.eq1 = value;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)EQ2[-10000~10000]
        /// </summary>
        public int Eq2
        {
            get
            {
                return Info.eq2;
            }
            set
            {
                VSCPINFOEX info = this.Info;
                if (Item.Project.LastErrorCode == 0)
                {
                    info.eq2 = value;
                    this.Info = info;
                }
            }
        }

    }
}
