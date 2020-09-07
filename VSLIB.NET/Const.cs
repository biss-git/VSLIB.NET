using System;
using System.Collections.Generic;
using System.Text;

namespace VSLIB.NET
{
    /// <summary>
    /// vslibに利用される定数
    /// </summary>
    public static class Const
    {
        /// <summary>
        /// ファイル名の最大長　256文字
        /// </summary>
        public const int VSLIB_MAX_PATH = 256;
        /// <summary>
        /// トラックの最大数　64
        /// </summary>
        public const int VSLIB_MAX_TRACK = 64;
        /// <summary>
        /// トラックの最大数　1024
        /// </summary>
        public const int VSLIB_MAX_ITEM = 1024;

    }

    /// <summary>
    /// エラーコード
    /// VSProjectの
    /// LastErrorCodeに対応する
    /// </summary>
    public enum ERROR_CODE
    {
        /// <summary>
        /// エラーなし　0
        /// </summary>
        VSERR_NOERR = 0,
        /// <summary>
        /// パラメータ不正　1
        /// </summary>
        VSERR_PRM = 1,
        /// <summary>
        /// PRJファイルオープンに失敗　2
        /// </summary>
        VSERR_PRJOPEN = 2,
        /// <summary>
        /// PRJファイルフォーマット不正　3
        /// </summary>
        VSERR_PRJFORMAT = 3,
        /// <summary>
        /// WAVファイルオープンに失敗　4
        /// </summary>
        VSERR_WAVEOPEN = 4,
        /// <summary>
        /// WAVファイルフォーマット不正　5
        /// </summary>
        VSERR_WAVEFORMAT = 5,
        /// <summary>
        /// サンプリング周波数不正　6
        /// </summary>
        VSERR_FREQ = 6,
        /// <summary>
        /// 最大数制限　7
        /// </summary>
        VSERR_MAX = 7,
        /// <summary>
        /// メモリ不足　8
        /// </summary>
        VSERR_NOMEM = 8,
    }

    /// <summary>
    /// 合成のモード
    /// </summary>
    public enum SYNTHMODE
    {
        /// <summary>
        /// 単音　0
        /// </summary>
        SYNTHMODE_M = 0,
        /// <summary>
        /// 単音フォルマント補正　0
        /// </summary>
        SYNTHMODE_MF = 1,
        /// <summary>
        /// 和音　0
        /// </summary>
        SYNTHMODE_P = 2,
    }

}
