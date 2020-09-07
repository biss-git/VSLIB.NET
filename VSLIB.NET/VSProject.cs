using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace VSLIB.NET
{
    /// <summary>
    /// VocalShifter プロジェクト
    /// </summary>
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

        /// <summary>
        /// 空のプロジェクト作成
        /// 空のトラックが一つ生成される
        /// </summary>
        public VSProject()
        {
            LastErrorCode = VSFunction.VslibCreateProject(out hVsprj);
            init();
        }

        /// <summary>
        /// .vshpファイルを開く
        /// </summary>
        /// <param name="fileName">.vshpファイルのパス</param>
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
        public VSPRJINFO VsPrjInfo
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
        public double MasterVolume
        {
            get
            {
                return VsPrjInfo.MasterVolume;
            }
            set
            {
                LastErrorCode = VSFunction.VslibGetProjectInfo(hVsprj, out VSPRJINFO info);
                if (LastErrorCode == 0)
                {
                    info.MasterVolume = value;
                    VsPrjInfo = info;
                }
            }
        }

        /// <summary>
        /// (R/W)サンプリング周波数[Hz]
        /// </summary>
        public int SampFreq
        {
            get
            {
                return VsPrjInfo.SampFreq;
            }
            set
            {
                LastErrorCode = VSFunction.VslibGetProjectInfo(hVsprj, out VSPRJINFO info);
                if (LastErrorCode == 0)
                {
                    info.SampFreq = value;
                    VsPrjInfo = info;
                }
            }
        }

        /// <summary>
        /// ミックス後サンプル数
        /// </summary>
        public int MixSample
        {
            get
            {
                LastErrorCode = VSFunction.VslibGetMixSample(hVsprj, out int sample);
                return sample;
            }
        }

        /// <summary>
        /// ミックス後の音声データ
        /// </summary>
        /// <param name="channel">チャンネル数(1または2)</param>
        /// <param name="index">取得位置[サンプル]</param>
        /// <param name="size">取得サイズ[サンプル]</param>
        /// <returns></returns>
        public (int[] dataL, int[] dataR) ReadMixData(int channel, int index, int size)
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

        private (int[] dataL, int[] dataR) BytesToInt16(byte[] bytes, int channel)
        {
            int[] dataL = null;
            int[] dataR = null;
            if (channel == 1)
            {
                dataL = new int[bytes.Length / 2];
                for (int i = 0; i < bytes.Length / 2; i++)
                {
                    dataL[i] = BitConverter.ToInt16(bytes, 2 * i);
                }
            }
            else if (channel == 2)
            {
                dataL = new int[bytes.Length / 4];
                dataR = new int[bytes.Length / 4];
                for (int i = 0; i < bytes.Length / 4; i++)
                {
                    dataL[i] = BitConverter.ToInt16(bytes, 4 * i);
                    dataR[i] = BitConverter.ToInt16(bytes, 4 * i + 2);
                }
            }
            return (dataL, dataR);
        }

        /// <summary>
        /// ミックス後音声をwavファイルに保存
        /// </summary>
        /// <param name="fileName">wavファイルの保存先パス</param>
        /// <param name="channel">チャンネル数(1または2)</param>
        public void ExportWaveFile(string fileName, int channel)
        {
            LastErrorCode = VSFunction.VslibExportWaveFile(hVsprj, fileName, 16, channel);
        }

        /// <summary>
        /// デストラクタ
        /// 既にプロジェクトのメモリが解放されているとエラーになるので注意
        /// </summary>
        ~VSProject()
        {
            VSFunction.VslibDeleteProject(hVsprj);
        }
    }
}
