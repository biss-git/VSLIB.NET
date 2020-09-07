using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Xml.Schema;

namespace VSLIB.NET
{
    /// <summary>
    /// トラックの配列
    /// </summary>
    public class TrackList
    {
        /// <summary>
        /// 親プロジェクト
        /// </summary>
        public readonly VSProject project;
        /// <summary>
        /// トラックの配列
        /// 最大数が決まっているので最初に作ってしまう
        /// プライベートな配列なので必要ないが、一応完全なreadonly属性にしておく
        /// </summary>
        private readonly ReadOnlyCollection<Track> Tracks;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Track this[int index]
        {
            get
            {
                return Tracks[index];
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="project">親プロジェクト</param>
        public TrackList(VSProject project)
        {
            this.project = project;
            Track[] tracks = new Track[Const.VSLIB_MAX_TRACK];
            for (int i = 0; i < tracks.Length; i++)
            {
                tracks[i] = new Track(project, i);
            }
            Tracks = Array.AsReadOnly(tracks);
        }

        /// <summary>
        /// トラックの数
        /// </summary>
        public int Length
        {
            get
            {
                project.LastErrorCode = VSFunction.VslibGetTrackMaxNum(project.hVsprj, out int trackMaxNum);
                return trackMaxNum;
            }
        }

        /// <summary>
        /// トラックの追加
        /// </summary>
        public void Add()
        {
            project.LastErrorCode = VSFunction.VslibAddTrack(project.hVsprj);
        }
        
        /// <summary>
        /// トラックの追加（コピー）
        /// トラック内のアイテムも一緒にコピーされる
        /// </summary>
        /// <param name="trackSrc">コピー元のトラック</param>
        /// <returns>追加されたトラック番号</returns>
        public int Add(Track trackSrc)
        {
            project.LastErrorCode = VSFunction.VslibCopyTrack(project.hVsprj, out int trackNumDist, trackSrc.Project.hVsprj, trackSrc.Index);
            return trackNumDist;
        }

        /// <summary>
        /// トラックをすべて破棄
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
