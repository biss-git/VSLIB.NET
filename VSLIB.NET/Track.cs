using System;
using System.Collections.Generic;
using System.Text;

namespace VSLIB.NET
{
    /// <summary>
    /// トラック
    /// </summary>
    public class Track
    {
        /// <summary>
        /// 親プロジェクト
        /// </summary>
        public readonly VSProject Project;

        /// <summary>
        /// トラック番号
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="project">親プロジェクト</param>
        /// <param name="index">トラック番号</param>
        public Track(VSProject project, int index)
        {
            this.Project = project;
            this.Index = index;
        }

        /// <summary>
        /// 上に移動する
        /// </summary>
        public void Up()
        {
            Project.LastErrorCode = VSFunction.VslibUpTrack(Project.hVsprj, Index);
        }

        /// <summary>
        /// 下に移動する
        /// </summary>
        public void Down()
        {
            Project.LastErrorCode = VSFunction.VslibDownTrack(Project.hVsprj, Index);
        }

        /// <summary>
        /// 破棄する
        /// トラック内のアイテムも破棄される
        /// </summary>
        public void Dispose()
        {
            Project.LastErrorCode = VSFunction.VslibDeleteTrack(Project.hVsprj, Index);
        }


        /// <summary>
        /// トラック情報
        /// </summary>
        public VSTRACKINFO Info
        {
            get
            {
                Project.LastErrorCode = VSFunction.VslibGetTrackInfo(Project.hVsprj, Index, out VSTRACKINFO vsTrackInfo);
                return vsTrackInfo;
            }
            set
            {
                Project.LastErrorCode = VSFunction.VslibSetTrackInfo(Project.hVsprj, Index, value);
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
                VSTRACKINFO info = this.Info;
                if (Project.LastErrorCode == 0)
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
                VSTRACKINFO info = this.Info;
                if (Project.LastErrorCode == 0)
                {
                    info.pan = value;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)逆相フラグ
        /// </summary>
        public bool InvPhaseFlg
        {
            get
            {
                return (Info.invPhaseFlg != 0);
            }
            set
            {
                VSTRACKINFO info = this.Info;
                if (Project.LastErrorCode == 0)
                {
                    info.invPhaseFlg = value? 1: 0;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)ソロフラグ
        /// </summary>
        public bool SoloFlg
        {
            get
            {
                return (Info.soloFlg != 0);
            }
            set
            {
                VSTRACKINFO info = this.Info;
                if (Project.LastErrorCode == 0)
                {
                    info.soloFlg = value ? 1 : 0;
                    this.Info = info;
                }
            }
        }

        /// <summary>
        /// (R/W)ミュートフラグ
        /// </summary>
        public bool MuteFlg
        {
            get
            {
                return (Info.muteFlg != 0);
            }
            set
            {
                VSTRACKINFO info = this.Info;
                if (Project.LastErrorCode == 0)
                {
                    info.muteFlg = value ? 1 : 0;
                    this.Info = info;
                }
            }
        }

    }
}
