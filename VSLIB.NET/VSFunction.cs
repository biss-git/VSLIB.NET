using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace VSLIB.NET
{
    /// <summary>
    /// vslib.dllを呼び出すクラス
    /// </summary>
    public static class VSFunction
    {
        /**
         * 
         * 　ライブラリ関連
         * 　
         */

        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetVersion")]
        static extern int VslibGetVersion_64bit();
        [DllImport("vslib.dll", EntryPoint = "VslibGetVersion")]
        static extern int VslibGetVersion_32bit();
        public static int VslibGetVersion()
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetVersion_64bit() :
                    VslibGetVersion_32bit();
        }


        /**
         * 
         * 　プロジェクト関連
         * 　
         */

        [DllImport("vslib_x64.dll", EntryPoint = "VslibCreateProject")]
        static extern int VslibCreateProject_64bit(out IntPtr hVsprj);
        [DllImport("vslib.dll", EntryPoint = "VslibCreateProject")]
        static extern int VslibCreateProject_32bit(out IntPtr hVsprj);
        public static int VslibCreateProject(out IntPtr hVsprj)
        {
            return (Environment.Is64BitProcess) ?
                    VslibCreateProject_64bit(out hVsprj) :
                    VslibCreateProject_32bit(out hVsprj);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibOpenProject")]
        static extern int VslibOpenProject_64bit(out IntPtr hVsprj, [In] string fileName);
        [DllImport("vslib.dll", EntryPoint = "VslibOpenProject")]
        static extern int VslibOpenProject_32bit(out IntPtr hVsprj, [In] string fileName);
        public static int VslibOpenProject(out IntPtr hVsprj, [In] string fileName)
        {
            return (Environment.Is64BitProcess) ?
                    VslibOpenProject_64bit(out hVsprj, fileName) :
                    VslibOpenProject_32bit(out hVsprj, fileName);
        }


        [DllImport("vslib_x64.dll", EntryPoint = "VslibSaveProject")]
        static extern int VslibSaveProject_64bit(IntPtr hVsprj, [In] string fileName);
        [DllImport("vslib.dll", EntryPoint = "VslibSaveProject")]
        static extern int VslibSaveProject_32bit(IntPtr hVsprj, [In] string fileName);
        public static int VslibSaveProject(IntPtr hVsprj, [In] string fileName)
        {
            return (Environment.Is64BitProcess) ?
                    VslibSaveProject_64bit(hVsprj, fileName) :
                    VslibSaveProject_32bit(hVsprj, fileName);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibDeleteProject")]
        static extern int VslibDeleteProject_64bit(IntPtr hVsprj);
        [DllImport("vslib.dll", EntryPoint = "VslibDeleteProject")]
        static extern int VslibDeleteProject_32bit(IntPtr hVsprj);
        public static int VslibDeleteProject(IntPtr hVsprj)
        {
            return (Environment.Is64BitProcess) ?
                    VslibDeleteProject_64bit(hVsprj) :
                    VslibDeleteProject_32bit(hVsprj);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetProjectInfo")]
        static extern int VslibGetProjectInfo_64bit(IntPtr hVsprj, out VSPRJINFO vsProjInfo);
        [DllImport("vslib.dll", EntryPoint = "VslibGetProjectInfo")]
        static extern int VslibGetProjectInfo_32bit(IntPtr hVsprj, out VSPRJINFO vsProjInfo);
        public static int VslibGetProjectInfo(IntPtr hVsprj, out VSPRJINFO vsProjInfo)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetProjectInfo_64bit(hVsprj, out vsProjInfo) :
                    VslibGetProjectInfo_32bit(hVsprj, out vsProjInfo);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibSetProjectInfo")]
        static extern int VslibSetProjectInfo_64bit(IntPtr hVsprj, in VSPRJINFO vsProjInfo);
        [DllImport("vslib.dll", EntryPoint = "VslibSetProjectInfo")]
        static extern int VslibSetProjectInfo_32bit(IntPtr hVsprj, in VSPRJINFO vsProjInfo);
        public static int VslibSetProjectInfo(IntPtr hVsprj, in VSPRJINFO vsProjInfo)
        {
            return (Environment.Is64BitProcess) ?
                    VslibSetProjectInfo_64bit(hVsprj, in vsProjInfo) :
                    VslibSetProjectInfo_32bit(hVsprj, in vsProjInfo);
        }


        /**
         * 
         * 　トラック関連
         * 
         */

        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetTrackMaxNum")]
        static extern int VslibGetTrackMaxNum_64bit(IntPtr hVsprj, out int trackMaxNum);
        [DllImport("vslib.dll", EntryPoint = "VslibGetTrackMaxNum")]
        static extern int VslibGetTrackMaxNum_32bit(IntPtr hVsprj, out int trackMaxNum);
        public static int VslibGetTrackMaxNum(IntPtr hVsprj, out int trackMaxNum)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetTrackMaxNum_64bit(hVsprj, out trackMaxNum) :
                    VslibGetTrackMaxNum_32bit(hVsprj, out trackMaxNum);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibAddTrack")]
        public static extern int VslibAddTrack_64bit(IntPtr hVsprj);
        [DllImport("vslib.dll", EntryPoint = "VslibAddTrack")]
        public static extern int VslibAddTrack_32bit(IntPtr hVsprj);
        public static int VslibAddTrack(IntPtr hVsprj)
        {
            return (Environment.Is64BitProcess) ?
                    VslibAddTrack_64bit(hVsprj) :
                    VslibAddTrack_32bit(hVsprj);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibCopyTrack")]
        static extern int VslibCopyTrack_64bit(IntPtr hVsprjDst, out int trackNumDst, IntPtr hVsprjSrc, int trackNumSrc);
        [DllImport("vslib.dll", EntryPoint = "VslibCopyTrack")]
        static extern int VslibCopyTrack_32bit(IntPtr hVsprjDst, out int trackNumDst, IntPtr hVsprjSrc, int trackNumSrc);
        public static int VslibCopyTrack(IntPtr hVsprjDst, out int trackNumDst, IntPtr hVsprjSrc, int trackNumSrc)
        {
            return (Environment.Is64BitProcess) ?
                    VslibCopyTrack_64bit(hVsprjDst, out trackNumDst, hVsprjSrc, trackNumSrc) :
                    VslibCopyTrack_32bit(hVsprjDst, out trackNumDst, hVsprjSrc, trackNumSrc);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibUpTrack")]
        static extern int VslibUpTrack_64bit(IntPtr hVsprj, int trackNum);
        [DllImport("vslib.dll", EntryPoint = "VslibUpTrack")]
        static extern int VslibUpTrack_32bit(IntPtr hVsprj, int trackNum);
        public static int VslibUpTrack(IntPtr hVsprj, int trackNum)
        {
            return (Environment.Is64BitProcess) ?
                    VslibUpTrack_64bit(hVsprj, trackNum) :
                    VslibUpTrack_32bit(hVsprj, trackNum);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibDownTrack")]
        static extern int VslibDownTrack_64bit(IntPtr hVsprj, int trackNum);
        [DllImport("vslib.dll", EntryPoint = "VslibDownTrack")]
        static extern int VslibDownTrack_32bit(IntPtr hVsprj, int trackNum);
        public static int VslibDownTrack(IntPtr hVsprj, int trackNum)
        {
            return (Environment.Is64BitProcess) ?
                    VslibDownTrack_64bit(hVsprj, trackNum) :
                    VslibDownTrack_32bit(hVsprj, trackNum);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibDeleteTrack")]
        static extern int VslibDeleteTrack_64bit(IntPtr hVsprj, int trackNum);
        [DllImport("vslib.dll", EntryPoint = "VslibDeleteTrack")]
        static extern int VslibDeleteTrack_32bit(IntPtr hVsprj, int trackNum);
        public static int VslibDeleteTrack(IntPtr hVsprj, int trackNum)
        {
            return (Environment.Is64BitProcess) ?
                    VslibDeleteTrack_64bit(hVsprj, trackNum) :
                    VslibDeleteTrack_32bit(hVsprj, trackNum);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetTrackInfo")]
        static extern int VslibGetTrackInfo_64bit(IntPtr hVsprj, int trackNum, out VSTRACKINFO vsTrackInfo);
        [DllImport("vslib.dll", EntryPoint = "VslibGetTrackInfo")]
        static extern int VslibGetTrackInfo_32bit(IntPtr hVsprj, int trackNum, out VSTRACKINFO vsTrackInfo);
        public static int VslibGetTrackInfo(IntPtr hVsprj, int trackNum, out VSTRACKINFO vsTrackInfo)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetTrackInfo_64bit(hVsprj, trackNum, out vsTrackInfo) :
                    VslibGetTrackInfo_32bit(hVsprj, trackNum, out vsTrackInfo);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibSetTrackInfo")]
        static extern int VslibSetTrackInfo_64bit(IntPtr hVsprj, int trackNum, in VSTRACKINFO vsTrackInfo);
        [DllImport("vslib.dll", EntryPoint = "VslibSetTrackInfo")]
        static extern int VslibSetTrackInfo_32bit(IntPtr hVsprj, int trackNum, in VSTRACKINFO vsTrackInfo);
        public static int VslibSetTrackInfo(IntPtr hVsprj, int trackNum, in VSTRACKINFO vsTrackInfo)
        {
            return (Environment.Is64BitProcess) ?
                    VslibSetTrackInfo_64bit(hVsprj, trackNum, in vsTrackInfo) :
                    VslibSetTrackInfo_32bit(hVsprj, trackNum, in vsTrackInfo);
        }


        /**
         * 
         * 　アイテム関連
         * 
         */

        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetItemMaxNum")]
        static extern int VslibGetItemMaxNum_64bit(IntPtr hVsprj, out int itemMaxNum);
        [DllImport("vslib.dll", EntryPoint = "VslibGetItemMaxNum")]
        static extern int VslibGetItemMaxNum_32bit(IntPtr hVsprj, out int itemMaxNum);
        public static int VslibGetItemMaxNum(IntPtr hVsprj, out int itemMaxNum)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetItemMaxNum_64bit(hVsprj, out itemMaxNum) :
                    VslibGetItemMaxNum_32bit(hVsprj, out itemMaxNum);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibAddItem")]
        static extern int VslibAddItem_64bit(IntPtr hVsprj, string fileName, out int itemNum);
        [DllImport("vslib.dll", EntryPoint = "VslibAddItem")]
        static extern int VslibAddItem_32bit(IntPtr hVsprj, string fileName, out int itemNum);
        public static int VslibAddItem(IntPtr hVsprj, string fileName, out int itemNum)
        {
            return (Environment.Is64BitProcess) ?
                    VslibAddItem_64bit(hVsprj, fileName, out itemNum) :
                    VslibAddItem_32bit(hVsprj, fileName, out itemNum);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibAddItemEx")]
        static extern int VslibAddItemEx_64bit(IntPtr hVsprj, string fileName, out int itemNum, int nnOffset, int nnRange, int skipPitFlg);
        [DllImport("vslib.dll", EntryPoint = "VslibAddItemEx")]
        static extern int VslibAddItemEx_32bit(IntPtr hVsprj, string fileName, out int itemNum, int nnOffset, int nnRange, int skipPitFlg);
        public static int VslibAddItemEx(IntPtr hVsprj, string fileName, out int itemNum, int nnOffset, int nnRange, int skipPitFlg)
        {
            return (Environment.Is64BitProcess) ?
                    VslibAddItemEx_64bit(hVsprj, fileName, out itemNum, nnOffset, nnRange, skipPitFlg) :
                    VslibAddItemEx_32bit(hVsprj, fileName, out itemNum, nnOffset, nnRange, skipPitFlg);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibCopyItem")]
        static extern int VslibCopyItem_64bit(IntPtr hVsprjDst, out int itemNumDst, IntPtr hVsprjSrc, int itemNumSrc);
        [DllImport("vslib.dll", EntryPoint = "VslibCopyItem")]
        static extern int VslibCopyItem_32bit(IntPtr hVsprjDst, out int itemNumDst, IntPtr hVsprjSrc, int itemNumSrc);
        public static int VslibCopyItem(IntPtr hVsprjDst, out int itemNumDst, IntPtr hVsprjSrc, int itemNumSrc)
        {
            return (Environment.Is64BitProcess) ?
                    VslibCopyItem_64bit(hVsprjDst, out itemNumDst, hVsprjSrc, itemNumSrc) :
                    VslibCopyItem_32bit(hVsprjDst, out itemNumDst, hVsprjSrc, itemNumSrc);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibDeleteItem")]
        static extern int VslibDeleteItem_64bit(IntPtr hVsprj, int itemNum);
        [DllImport("vslib.dll", EntryPoint = "VslibDeleteItem")]
        static extern int VslibDeleteItem_32bit(IntPtr hVsprj, int itemNum);
        public static int VslibDeleteItem(IntPtr hVsprj, int itemNum)
        {
            return (Environment.Is64BitProcess) ?
                    VslibDeleteItem_64bit(hVsprj, itemNum) :
                    VslibDeleteItem_32bit(hVsprj, itemNum);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetItemInfo")]
        static extern int VslibGetItemInfo_64bit(IntPtr hVsprj, int itemNum, out VSITEMINFO vsItemInfo);
        [DllImport("vslib.dll", EntryPoint = "VslibGetItemInfo")]
        static extern int VslibGetItemInfo_32bit(IntPtr hVsprj, int itemNum, out VSITEMINFO vsItemInfo);
        public static int VslibGetItemInfo(IntPtr hVsprj, int itemNum, out VSITEMINFO vsItemInfo)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetItemInfo_64bit(hVsprj, itemNum, out vsItemInfo) :
                    VslibGetItemInfo_32bit(hVsprj, itemNum, out vsItemInfo);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibSetItemInfo")]
        static extern int VslibSetItemInfo_64bit(IntPtr hVsprj, int itemNum, in VSITEMINFO vsItemInfo);
        [DllImport("vslib.dll", EntryPoint = "VslibSetItemInfo")]
        static extern int VslibSetItemInfo_32bit(IntPtr hVsprj, int itemNum, in VSITEMINFO vsItemInfo);
        public static int VslibSetItemInfo(IntPtr hVsprj, int itemNum, in VSITEMINFO vsItemInfo)
        {
            return (Environment.Is64BitProcess) ?
                    VslibSetItemInfo_64bit(hVsprj, itemNum, in vsItemInfo) :
                    VslibSetItemInfo_32bit(hVsprj, itemNum, in vsItemInfo);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetCtrlPntInfoEx")]
        static extern int VslibGetCtrlPntInfoEx_64bit(IntPtr hVsprj, int itemNum, int pntNum, out VSCPINFOEX vsCpInfo);
        [DllImport("vslib.dll", EntryPoint = "VslibGetCtrlPntInfoEx")]
        static extern int VslibGetCtrlPntInfoEx_32bit(IntPtr hVsprj, int itemNum, int pntNum, out VSCPINFOEX vsCpInfo);
        public static int VslibGetCtrlPntInfoEx(IntPtr hVsprj, int itemNum, int pntNum, out VSCPINFOEX vsCpInfo)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetCtrlPntInfoEx_64bit(hVsprj, itemNum, pntNum, out vsCpInfo) :
                    VslibGetCtrlPntInfoEx_32bit(hVsprj, itemNum, pntNum, out vsCpInfo);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibSetCtrlPntInfoEx")]
        static extern int VslibSetCtrlPntInfoEx_64bit(IntPtr hVsprj, int itemNum, int pntNum, in VSCPINFOEX vsCpInfo);
        [DllImport("vslib.dll", EntryPoint = "VslibSetCtrlPntInfoEx")]
        static extern int VslibSetCtrlPntInfoEx_32bit(IntPtr hVsprj, int itemNum, int pntNum, in VSCPINFOEX vsCpInfo);
        public static int VslibSetCtrlPntInfoEx(IntPtr hVsprj, int itemNum, int pntNum, in VSCPINFOEX vsCpInfo)
        {
            return (Environment.Is64BitProcess) ?
                    VslibSetCtrlPntInfoEx_64bit(hVsprj, itemNum, pntNum, in vsCpInfo) :
                    VslibSetCtrlPntInfoEx_32bit(hVsprj, itemNum, pntNum, in vsCpInfo);
        }

        /// <param name="eqNum">イコライザ番号</param>
        /// <param name="gain">ゲインの値が格納される配列変数(15要素、0.1dB単位)</param>
        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetEQGain")]
        static extern int VslibGetEQGain_64bit(IntPtr hVsprj, int itemNum, int eqNum, [Out] int[] gain);
        [DllImport("vslib.dll", EntryPoint = "VslibGetEQGain")]
        static extern int VslibGetEQGain_32bit(IntPtr hVsprj, int itemNum, int eqNum, [Out] int[] gain);
        public static int VslibGetEQGain(IntPtr hVsprj, int itemNum, int eqNum, [Out] int[] gain)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetEQGain_64bit(hVsprj, itemNum, eqNum, gain) :
                    VslibGetEQGain_32bit(hVsprj, itemNum, eqNum, gain);
        }

        /// <param name="eqNum">イコライザ番号</param>
        /// <param name="gain">ゲインの値が格納される配列変数(15要素、0.1dB単位)</param>
        [DllImport("vslib_x64.dll", EntryPoint = "VslibSetEQGain")]
        static extern int VslibSetEQGain_64bit(IntPtr hVsprj, int itemNum, int eqNum, [In] int[] gain);
        [DllImport("vslib.dll", EntryPoint = "VslibSetEQGain")]
        static extern int VslibSetEQGain_32bit(IntPtr hVsprj, int itemNum, int eqNum, [In] int[] gain);
        public static int VslibSetEQGain(IntPtr hVsprj, int itemNum, int eqNum, [In] int[] gain)
        {
            return (Environment.Is64BitProcess) ?
                    VslibSetEQGain_64bit(hVsprj, itemNum, eqNum, gain) :
                    VslibSetEQGain_32bit(hVsprj, itemNum, eqNum, gain);
        }


        /**
         * 
         * 　TIME関連
         * 
         */

        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetTimeCtrlPntNum")]
        static extern int VslibGetTimeCtrlPntNum_64bit(IntPtr hVsprj, int itemNum, out int timeCtrlPntNum);
        [DllImport("vslib.dll", EntryPoint = "VslibGetTimeCtrlPntNum")]
        static extern int VslibGetTimeCtrlPntNum_32bit(IntPtr hVsprj, int itemNum, out int timeCtrlPntNum);
        public static int VslibGetTimeCtrlPntNum(IntPtr hVsprj, int itemNum, out int timeCtrlPntNum)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetTimeCtrlPntNum_64bit(hVsprj, itemNum, out timeCtrlPntNum) :
                    VslibGetTimeCtrlPntNum_32bit(hVsprj, itemNum, out timeCtrlPntNum);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetTimeCtrlPnt")]
        static extern int VslibGetTimeCtrlPnt_64bit(IntPtr hVsprj, int itemNum, int pntNum, out int time1, out int time2);
        [DllImport("vslib.dll", EntryPoint = "VslibGetTimeCtrlPnt")]
        static extern int VslibGetTimeCtrlPnt_32bit(IntPtr hVsprj, int itemNum, int pntNum, out int time1, out int time2);
        public static int VslibGetTimeCtrlPnt(IntPtr hVsprj, int itemNum, int pntNum, out int time1, out int time2)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetTimeCtrlPnt_64bit(hVsprj, itemNum, pntNum, out time1, out time2) :
                    VslibGetTimeCtrlPnt_32bit(hVsprj, itemNum, pntNum, out time1, out time2);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibSetTimeCtrlPnt")]
        static extern int VslibSetTimeCtrlPnt_64bit(IntPtr hVsprj, int itemNum, int pntNum, int time1, int time2);
        [DllImport("vslib.dll", EntryPoint = "VslibSetTimeCtrlPnt")]
        static extern int VslibSetTimeCtrlPnt_32bit(IntPtr hVsprj, int itemNum, int pntNum, int time1, int time2);
        public static int VslibSetTimeCtrlPnt(IntPtr hVsprj, int itemNum, int pntNum, int time1, int time2)
        {
            return (Environment.Is64BitProcess) ?
                    VslibSetTimeCtrlPnt_64bit(hVsprj, itemNum, pntNum, time1, time2) :
                    VslibSetTimeCtrlPnt_32bit(hVsprj, itemNum, pntNum, time1, time2);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibAddTimeCtrlPnt")]
        static extern int VslibAddTimeCtrlPnt_64bit(IntPtr hVsprj, int itemNum, int time1, int time2);
        [DllImport("vslib.dll", EntryPoint = "VslibAddTimeCtrlPnt")]
        static extern int VslibAddTimeCtrlPnt_32bit(IntPtr hVsprj, int itemNum, int time1, int time2);
        public static int VslibAddTimeCtrlPnt(IntPtr hVsprj, int itemNum, int time1, int time2)
        {
            return (Environment.Is64BitProcess) ?
                    VslibAddTimeCtrlPnt_64bit(hVsprj, itemNum, time1, time2) :
                    VslibAddTimeCtrlPnt_32bit(hVsprj, itemNum, time1, time2);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibDeleteTimeCtrlPnt")]
        static extern int VslibDeleteTimeCtrlPnt_64bit(IntPtr hVsprj, int itemNum, int pntNum);
        [DllImport("vslib.dll", EntryPoint = "VslibDeleteTimeCtrlPnt")]
        static extern int VslibDeleteTimeCtrlPnt_32bit(IntPtr hVsprj, int itemNum, int pntNum);
        public static int VslibDeleteTimeCtrlPnt(IntPtr hVsprj, int itemNum, int pntNum)
        {
            return (Environment.Is64BitProcess) ?
                    VslibDeleteTimeCtrlPnt_64bit(hVsprj, itemNum, pntNum) :
                    VslibDeleteTimeCtrlPnt_32bit(hVsprj, itemNum, pntNum);
        }

        /// <summary> 時間の単位は秒 </summary>
        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetStretchOrgSec")]
        static extern int VslibGetStretchOrgSec_64bit(IntPtr hVsprj, int itemNum, double time_edt, out double time_org);
        [DllImport("vslib.dll", EntryPoint = "VslibGetStretchOrgSec")]
        static extern int VslibGetStretchOrgSec_32bit(IntPtr hVsprj, int itemNum, double time_edt, out double time_org);
        public static int VslibGetStretchOrgSec(IntPtr hVsprj, int itemNum, double time_edt, out double time_org)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetStretchOrgSec_64bit(hVsprj, itemNum, time_edt, out time_org) :
                    VslibGetStretchOrgSec_32bit(hVsprj, itemNum, time_edt, out time_org);
        }

        /// <summary> 時間の単位は秒 </summary>
        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetStretchEditSec")]
        static extern int VslibGetStretchEditSec_64bit(IntPtr hVsprj, int itemNum, double time_org, out double time_edt);
        [DllImport("vslib.dll", EntryPoint = "VslibGetStretchEditSec")]
        static extern int VslibGetStretchEditSec_32bit(IntPtr hVsprj, int itemNum, double time_org, out double time_edt);
        public static int VslibGetStretchEditSec(IntPtr hVsprj, int itemNum, double time_org, out double time_edt)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetStretchEditSec_64bit(hVsprj, itemNum, time_org, out time_edt) :
                    VslibGetStretchEditSec_32bit(hVsprj, itemNum, time_org, out time_edt);
        }

        /// <summary> 時間の単位はサンプル数 </summary>
        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetStretchOrgSample")]
        static extern int VslibGetStretchOrgSample_64bit(IntPtr hVsprj, int itemNum, double time_edt, out double time_org);
        [DllImport("vslib.dll", EntryPoint = "VslibGetStretchOrgSample")]
        static extern int VslibGetStretchOrgSample_32bit(IntPtr hVsprj, int itemNum, double time_edt, out double time_org);
        public static int VslibGetStretchOrgSample(IntPtr hVsprj, int itemNum, double time_edt, out double time_org)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetStretchOrgSample_64bit(hVsprj, itemNum, time_edt, out time_org) :
                    VslibGetStretchOrgSample_32bit(hVsprj, itemNum, time_edt, out time_org);
        }

        /// <summary> 時間の単位はサンプル数 </summary>
        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetStretchEditSample")]
        static extern int VslibGetStretchEditSample_64bit(IntPtr hVsprj, int itemNum, double time_org, out double time_edt);
        [DllImport("vslib.dll", EntryPoint = "VslibGetStretchEditSample")]
        static extern int VslibGetStretchEditSample_32bit(IntPtr hVsprj, int itemNum, double time_org, out double time_edt);
        public static int VslibGetStretchEditSample(IntPtr hVsprj, int itemNum, double time_org, out double time_edt)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetStretchEditSample_64bit(hVsprj, itemNum, time_org, out time_edt) :
                    VslibGetStretchEditSample_32bit(hVsprj, itemNum, time_org, out time_edt);
        }


        /**
         * 
         * 　ミキサー関連
         * 
         */

        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetMixSample")]
        static extern int VslibGetMixSample_64bit(IntPtr hVsprj, out int mixSample);
        [DllImport("vslib.dll", EntryPoint = "VslibGetMixSample")]
        static extern int VslibGetMixSample_32bit(IntPtr hVsprj, out int mixSample);
        public static int VslibGetMixSample(IntPtr hVsprj, out int mixSample)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetMixSample_64bit(hVsprj, out mixSample) :
                    VslibGetMixSample_32bit(hVsprj, out mixSample);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibGetMixData")]
        static extern int VslibGetMixData_64bit(IntPtr hVsprj, [Out] byte[] waveData, int bit, int channel, int index, int size);
        [DllImport("vslib.dll", EntryPoint = "VslibGetMixData")]
        static extern int VslibGetMixData_32bit(IntPtr hVsprj, [Out] byte[] waveData, int bit, int channel, int index, int size);
        public static int VslibGetMixData(IntPtr hVsprj, [Out] byte[] waveData, int bit, int channel, int index, int size)
        {
            return (Environment.Is64BitProcess) ?
                    VslibGetMixData_64bit(hVsprj, waveData, bit, channel, index, size) :
                    VslibGetMixData_32bit(hVsprj, waveData, bit, channel, index, size);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibExportWaveFile")]
        static extern int VslibExportWaveFile_64bit(IntPtr hVsprj, [In] string fileName, int bit, int channel);
        [DllImport("vslib.dll", EntryPoint = "VslibExportWaveFile")]
        static extern int VslibExportWaveFile_32bit(IntPtr hVsprj, [In] string fileName, int bit, int channel);
        public static int VslibExportWaveFile(IntPtr hVsprj, [In] string fileName, int bit, int channel)
        {
            return (Environment.Is64BitProcess) ?
                    VslibExportWaveFile_64bit(hVsprj, fileName, bit, channel) :
                    VslibExportWaveFile_32bit(hVsprj, fileName, bit, channel);
        }


        /**
         * 
         * 　単位変換関連
         * 
         */

        [DllImport("vslib_x64.dll", EntryPoint = "VslibCent2Freq")]
        static extern double VslibCent2Freq_64bit(int cent);
        [DllImport("vslib.dll", EntryPoint = "VslibCent2Freq")]
        static extern double VslibCent2Freq_32bit(int cent);
        public static double VslibCent2Freq(int cent)
        {
            return (Environment.Is64BitProcess) ?
                    VslibCent2Freq_64bit(cent) :
                    VslibCent2Freq_32bit(cent);
        }

        [DllImport("vslib_x64.dll", EntryPoint = "VslibFreq2Cent")]
        static extern int VslibFreq2Cent_64bit(double freq);
        [DllImport("vslib.dll", EntryPoint = "VslibFreq2Cent")]
        static extern int VslibFreq2Cent_32bit(double freq);
        public static int VslibFreq2Cent(double freq)
        {
            return (Environment.Is64BitProcess) ?
                    VslibFreq2Cent_64bit(freq) :
                    VslibFreq2Cent_32bit(freq);
        }


    }
}
