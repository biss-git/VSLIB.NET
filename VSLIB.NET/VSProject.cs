using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace VSLIB.NET
{
    public class VSProject
    {
        /// <summary>
        /// 最後に実行されたvslib関数のエラーコード
        /// </summary>
        public int LastErrorCode = 0;

        /// <summary>
        /// プロジェクトハンドル
        /// </summary>
        public IntPtr hVsprj;

        /// <summary>
        /// トラックのリスト
        /// </summary>
        public TrackList TrackList;

        /// <summary>
        /// アイテムのリスト
        /// </summary>
        public ItemList ItemList;


        public VSProject()
        {
            LastErrorCode = VSFunction.VslibCreateProject(out hVsprj);
            init();
        }

        public VSProject(string fileName)
        {
            LastErrorCode = VSFunction.VslibOpenProject(out hVsprj, fileName);
            init();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void init()
        {
            this.TrackList = new TrackList(this);
            this.ItemList = new ItemList(this);
        }

        /// <summary>
        /// プロジェクトの保存
        /// </summary>
        /// <param name="fileName">保存先ファイル名</param>
        public void Save(string fileName)
        {
            LastErrorCode = VSFunction.VslibSaveProject(hVsprj, fileName);
        }


        /// <summary>
        /// プロジェクト情報
        /// </summary>
        public VSPRJINFO vsPrjInfo
        {
            get
            {
                LastErrorCode = VSFunction.VslibGetProjectInfo(hVsprj, out VSPRJINFO info);
                return info;
            }
            set
            {
                LastErrorCode = VSFunction.VslibSetProjectInfo(hVsprj, value);
            }
        }

        /// <summary>
        /// (R/W)マスターボリューム[倍]
        /// </summary>
        public double masterVolume
        {
            get
            {
                return vsPrjInfo.MasterVolume;
            }
            set
            {
                LastErrorCode = VSFunction.VslibGetProjectInfo(hVsprj, out VSPRJINFO info);
                if (LastErrorCode == 0)
                {
                    info.MasterVolume = value;
                    vsPrjInfo = info;
                }
            }
        }

        /// <summary>
        /// (R/W)サンプリング周波数[Hz]
        /// </summary>
        public int sampFreq
        {
            get
            {
                return vsPrjInfo.SampFreq;
            }
            set
            {
                LastErrorCode = VSFunction.VslibGetProjectInfo(hVsprj, out VSPRJINFO info);
                if (LastErrorCode == 0)
                {
                    info.SampFreq = value;
                    vsPrjInfo = info;
                }
            }
        }

        public int MixSample
        {
            get
            {
                LastErrorCode = VSFunction.VslibGetMixSample(hVsprj, out int sample);
                return sample;
            }
        }


        public (int[] data1, int[] data2) ReadMixData(int channel, int index, int size)
        {
            size = Math.Max(Math.Min(size, MixSample - index - 10000), 0);
            channel = Math.Max(Math.Min(channel, 2), 1);
            byte[] bytes = new byte[2 * size * channel];
            LastErrorCode = VSFunction.VslibGetMixData(hVsprj, bytes, 16, channel, index, size);
            if(LastErrorCode != 0 || bytes.Length == 0)
            {
                return (null, null);
            }
            return BytesToInt16(bytes, channel);
        }

        private (int[] data1, int[] data2) BytesToInt16(byte[] bytes, int channel)
        {
            int[] data1 = null;
            int[] data2 = null;
            if (channel == 1)
            {
                data1 = new int[bytes.Length / 2];
                for (int i = 0; i < bytes.Length / 2; i++)
                {
                    data1[i] = BitConverter.ToInt16(bytes, 2 * i);
                }
            }
            else if (channel == 2)
            {
                data1 = new int[bytes.Length / 4];
                data2 = new int[bytes.Length / 4];
                for (int i = 0; i < bytes.Length / 4; i++)
                {
                    data1[i] = BitConverter.ToInt16(bytes, 4 * i);
                    data2[i] = BitConverter.ToInt16(bytes, 4 * i + 2);
                }
            }
            return (data1, data2);
        }

        public void ExportWaveFile(string fileName, int channel)
        {
            LastErrorCode = VSFunction.VslibExportWaveFile(hVsprj, fileName, 16, channel);
        }


        ~VSProject()
        {
            VSFunction.VslibDeleteProject(hVsprj);
        }
    }
}
