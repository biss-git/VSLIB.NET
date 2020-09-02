using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Schema;

namespace VSLIB.NET
{
    public class TrackList
    {
        public readonly VSProject project;
        private Track[] Tracks = new Track[Const.VSLIB_MAX_TRACK];

        public Track this[int index]
        {
            get
            {
                return Tracks[index];
            }
        }

        public TrackList(VSProject project)
        {
            this.project = project;
            for(int i = 0; i < Tracks.Length; i++)
            {
                Tracks[i] = new Track(project, i);
            }
        }

        public int Length
        {
            get
            {
                project.LastErrorCode = VSFunction.VslibGetTrackMaxNum(project.hVsprj, out int trackMaxNum);
                return trackMaxNum;
            }
        }

        public void Add()
        {
            project.LastErrorCode = VSFunction.VslibAddTrack(project.hVsprj);
        }
        
        public int Add(Track trackSrc)
        {
            project.LastErrorCode = VSFunction.VslibCopyTrack(project.hVsprj, out int trackNumDist, trackSrc.Project.hVsprj, trackSrc.Index);
            return trackNumDist;
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
