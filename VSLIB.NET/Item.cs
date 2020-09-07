using System;
using System.Collections.Generic;
using System.Text;

namespace VSLIB.NET
{
    /// <summary>
    /// アイテム
    /// </summary>
    public class Item
    {
        /// <summary>
        /// 親プロジェクト
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
        /// アイテム番号
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="project">親プロジェクト</param>
        /// <param name="index">アイテム番号</param>
        public Item(VSProject project, int index)
        {
            this.Project = project;
            this.Index = index;
            this.CtrlPoints = new CtrlPointList(this);
            this.TimeCtrlPoints = new TimeCtrlPointList(this);
        }

        /// <summary>
        /// アイテムの破棄
        /// </summary>
        public void Dispose()
        {
            Project.LastErrorCode = VSFunction.VslibDeleteItem(Project.hVsprj, Index);
        }

        /// <summary>
        /// イコライザ情報の取得
        /// </summary>
        /// <param name="eqNum">イコライザ番号(0または1)</param>
        /// <returns>イコライザ情報</returns>
        public int[] GetEQGain(int eqNum)
        {
            int[] gain = new int[15];
            Project.LastErrorCode = VSFunction.VslibGetEQGain(Project.hVsprj, Index, eqNum, gain);
            return gain;
        }

        /// <summary>
        /// イコライザ情報の設定
        /// </summary>
        /// <param name="eqNum">イコライザ番号(0または1)</param>
        /// <param name="gain">イコライザ情報</param>
        public void SetEQGain(int eqNum, int[] gain)
        {
            Project.LastErrorCode = VSFunction.VslibSetEQGain(Project.hVsprj, Index, eqNum, gain);
        }

        /// <summary>
        /// タイムストレッチ前時間を取得[秒]
        /// </summary>
        /// <param name="timeEdt_Sec">タイムストレッチ後時間[秒]</param>
        /// <returns>タイムストレッチ前時間[秒]</returns>
        public double GetTimeOrg_Sec(double timeEdt_Sec)
        {
            Project.LastErrorCode = VSFunction.VslibGetStretchOrgSec(Project.hVsprj, Index, timeEdt_Sec, out double timeOrg_Sec);
            return timeOrg_Sec;
        }
        /// <summary>
        /// タイムストレッチ後時間を取得[秒]
        /// </summary>
        /// <param name="timeOrg_Sec">タイムストレッチ前時間[秒]</param>
        /// <returns>タイムストレッチ後時間[秒]</returns>
        public double GetTimeEdt_Sec(double timeOrg_Sec)
        {
            Project.LastErrorCode = VSFunction.VslibGetStretchOrgSec(Project.hVsprj, Index, timeOrg_Sec, out double timeEdt_Sec);
            return timeEdt_Sec;
        }
        /// <summary>
        /// タイムストレッチ前時間を取得[サンプル]
        /// </summary>
        /// <param name="timeEdt_Sample">タイムストレッチ後時間[サンプル]</param>
        /// <returns>タイムストレッチ前時間[サンプル]</returns>
        public double GetTimeOrg_Sample(double timeEdt_Sample)
        {
            Project.LastErrorCode = VSFunction.VslibGetStretchOrgSample(Project.hVsprj, Index, timeEdt_Sample, out double timeOrg_Sample);
            return timeOrg_Sample;
        }
        /// <summary>
        /// タイムストレッチ後時間を取得[サンプル]
        /// </summary>
        /// <param name="timeOrg_Sample">タイムストレッチ前時間[サンプル]</param>
        /// <returns>タイムストレッチ後時間[サンプル]</returns>
        public double GetTimeEdt_Sample(double timeOrg_Sample)
        {
            Project.LastErrorCode = VSFunction.VslibGetStretchOrgSample(Project.hVsprj, Index, timeOrg_Sample, out double timeEdt_Sample);
            return timeEdt_Sample;
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
        /// (R/W)音声合成方式
        /// </summary>
        public SYNTHMODE SynthMode
        {
            get
            {
                return (SYNTHMODE)Info.synthMode;
            }
            set
            {
                VSITEMINFO info = this.Info;
                if (Project.LastErrorCode == 0)
                {
                    info.synthMode = (int)value;
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
