using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace VSLIB.NET
{
    /**
     * 
     * 　VocalShifterライブラリの構造体をここにまとめておく
     * 
     */


    /// <summary>
    /// プロジェクト情報
    /// </summary>
    public struct VSPRJINFO
    {
        /// <summary>
        /// (R/W)マスターボリューム[倍]
        /// </summary>
        public double MasterVolume;
        /// <summary>
        /// (R/W)サンプリング周波数[Hz]
        /// </summary>
        public int SampFreq;
    }


    /// <summary>
    /// トラック情報
    /// </summary>
    public struct VSTRACKINFO
    {
        /// <summary>
        /// (R/W)ボリューム[倍]
        /// </summary>
        public double volume;
        /// <summary>
        /// (R/W)パン(-1.0~1.0)
        /// </summary>
        public double pan;
        /// <summary>
        /// (R/W)逆相フラグ
        /// </summary>
        public int invPhaseFlg;
        /// <summary>
        /// (R/W)ソロフラグ
        /// </summary>
        public int soloFlg;
        /// <summary>
        /// (R/W)ミュートフラグ
        /// </summary>
        public int muteFlg;
    }


    /// <summary>
    /// アイテム情報
    /// </summary>
    public struct VSITEMINFO
    {
        /// <summary>
        /// (R/-) ファイル名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst=256)]    // char[256]で格納
        public string fileName;
        /// <summary>
        /// (R/-)サンプリング周波数[Hz]
        /// </summary>
        public int sampFreq;
        /// <summary>
        /// (R/-)チャンネル数(1or2)
        /// </summary>
        public int channel;
        /// <summary>
        /// (R/-)オリジナルの音声ファイルのサンプル数
        /// </summary>
        public int sampleOrg;
        /// <summary>
        /// (R/-)編集後のサンプル数
        /// </summary>
        public int sampleEdit;
        /// <summary>
        /// (R/-)１秒あたりの制御点数
        /// </summary>
        public int ctrlPntPs;
        /// <summary>
        /// (R/-)全制御点数
        /// </summary>
        public int ctrlPntNum;
        /// <summary>
        /// (R/W)音声合成方式(M:0,MF:1,P:2)
        /// </summary>
        public int synthMode;
        /// <summary>
        /// (R/W)トラック番号(0~)
        /// </summary>
        public int trackNum;
        /// <summary>
        /// (R/W)オフセット[sample]
        /// </summary>
        public int offset;
    }


    /// <summary>
    /// アイテム制御点情報
    /// </summary>
    public struct VSCPINFOEX
    {
        /// <summary>
        /// (R/-)編集前ダイナミクス[倍]
        /// </summary>
        public double dynOrg;
        /// <summary>
        /// (R/W)編集後ダイナミクス[倍]
        /// </summary>
        public double dynEdit;
        /// <summary>
        /// (R/W)ボリューム[倍]
        /// </summary>
        public double volume;
        /// <summary>
        /// (R/W)パン(-1.0~1.0)
        /// </summary>
        public double pan;
        /// <summary>
        /// (R/-)スペクトルダイナミクス
        /// </summary>
        public double spcDyn;
        /// <summary>
        /// (R/-)ピッチ解析値[cent,C4=6000]
        /// </summary>
        public int pitAna;
        /// <summary>
        /// (R/W)ピッチ編集前[cent,C4=6000]
        /// </summary>
        public int pitOrg;
        /// <summary>
        /// (R/W)ピッチ編集後[cent,C4=6000]
        /// </summary>
        public int pitEdit;
        /// <summary>
        /// (R/W)フォルマント[cent]
        /// </summary>
        public int formant;
        /// <summary>
        /// (R/-)編集前ピッチ有無フラグ
        /// </summary>
        public int pitFlgOrg;
        /// <summary>
        /// (R/W)編集後ピッチ有無フラグ
        /// </summary>
        public int pitFlgEdit;
        /// <summary>
        /// (R/W)ブレ市ネス[-10000~10000]
        /// </summary>
        public int breathiness;
        /// <summary>
        /// (R/W)EQ1[-10000~10000]
        /// </summary>
        public int eq1;
        /// <summary>
        /// (R/W)EQ2[-10000~10000]
        /// </summary>
        public int eq2;
    }

}
