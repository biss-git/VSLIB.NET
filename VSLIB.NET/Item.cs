using System;
using System.Collections.Generic;
using System.Text;

namespace VSLIB.NET
{
    public class Item
    {
        /// <summary>
        /// このトラックが属しているプロジェクト
        /// </summary>
        public readonly VSProject Project;

        /// <summary>
        /// 制御点
        /// </summary>
        public readonly CtrlPointList CtrlPoints;

        /// <summary>
        /// タイミング制御点
        /// </summary>
        public readonly TimeCtrlPointList TimeCtrlPoints;

        /// <summary>
        /// トラック番号
        /// </summary>
        public readonly int Index;

        public Item(VSProject project, int index)
        {
            this.Project = project;
            this.Index = index;
            this.CtrlPoints = new CtrlPointList(this);
            this.TimeCtrlPoints = new TimeCtrlPointList(this);
        }

        /// <summary>
        /// 破棄する
        /// </summary>
        public void Dispose()
        {
            Project.LastErrorCode = VSFunction.VslibDeleteItem(Project.hVsprj, Index);
        }

        public int[] GetEQGain(int eqNum)
        {
            int[] gain = new int[15];
            Project.LastErrorCode = VSFunction.VslibGetEQGain(Project.hVsprj, Index, eqNum, gain);
            return gain;
        }

        public void SetEQGain(int eqNum, int[] gain)
        {
            Project.LastErrorCode = VSFunction.VslibSetEQGain(Project.hVsprj, Index, eqNum, gain);
        }

        public double GetTimeOrg_Sec(double timeEdt)
        {
            Project.LastErrorCode = VSFunction.VslibGetStretchOrgSec(Project.hVsprj, Index, timeEdt, out double timeOrg);
            return timeOrg;
        }
        public double GetTimeEdt_Sec(double timeOrg)
        {
            Project.LastErrorCode = VSFunction.VslibGetStretchOrgSec(Project.hVsprj, Index, timeOrg, out double timeEdt);
            return timeEdt;
        }
        public double GetTimeOrg_Sample(double timeEdt)
        {
            Project.LastErrorCode = VSFunction.VslibGetStretchOrgSample(Project.hVsprj, Index, timeEdt, out double timeOrg);
            return timeOrg;
        }
        public double GetTimeEdt_Sample(double timeOrg)
        {
            Project.LastErrorCode = VSFunction.VslibGetStretchOrgSample(Project.hVsprj, Index, timeOrg, out double timeEdt);
            return timeEdt;
        }

        /// <summary>
        /// アイテム情報
        /// </summary>
        public VSITEMINFO Info
        {
            get
            {
                Project.LastErrorCode = VSFunction.VslibGetItemInfo(Project.hVsprj, Index, out VSITEMINFO vsItemInfo);
                return vsItemInfo;
            }
            set
            {
                Project.LastErrorCode = VSFunction.VslibSetItemInfo(Project.hVsprj, Index, value);
            }
        }

        /// <summary>
        /// (R/-) ファイル名
        /// </summary>
        public string FileName
        {
            get
            {
                return Info.fileName;
            }
        }

        /// <summary>
        /// (R/-)サンプリング周波数[Hz]
        /// </summary>
        public int SampleFreq
        {
            get
            {
                return Info.sampFreq;
            }
        }

        /// <summary>
        /// (R/-)チャンネル数(1or2)
        /// </summary>
        public int Channel
        {
            get
            {
                return Info.channel;
            }
        }

        /// <summary>
        /// (R/-)オリジナルの音声ファイルのサンプル数
        /// </summary>
        public int SampleOrg
        {
            get
            {
                return Info.sampleOrg;
            }
        }

        /// <summary>
        /// (R/-)編集後のサンプル数
        /// </summary>
        public int SampleEdit
        {
            get
            {
                return Info.sampleEdit;
            }
        }

        /// <summary>
        /// (R/-)１秒あたりの制御点数
        /// </summary>
        public int CtrlPntPs
        {
            get
            {
                return Info.ctrlPntPs;
            }
        }

        /// <summary>
        /// (R/-)全制御点数
        /// </summary>
        public int CtrlPntNum
        {
            get
            {
                return Info.ctrlPntNum;
            }
        }

        /// <summary>
        /// (R/W)音声合成方式(M:0,MF:1,P:2)
        /// </summary>
        public int SynthMode
        {
            get
            {
                return Info.synthMode;
            }
            set
            {
                VSITEMINFO info = this.Info;
                if (Project.LastErrorCode == 0)
                {
                    info.synthMode = value;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)トラック番号(0~)
        /// </summary>
        public int TrackNum
        {
            get
            {
                return Info.trackNum;
            }
            set
            {
                VSITEMINFO info = this.Info;
                if (Project.LastErrorCode == 0)
                {
                    info.trackNum = value;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)オフセット[sample]
        /// </summary>
        public int Offset
        {
            get
            {
                return Info.offset;
            }
            set
            {
                VSITEMINFO info = this.Info;
                if (Project.LastErrorCode == 0)
                {
                    info.offset = value;
                    this.Info = info;
                }
            }
        }


    }
}
