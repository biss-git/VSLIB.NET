using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VSLIB.NET;

namespace VocalShifterLibraryTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        VSProject project;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NoProjectError()
        {
            outputLabel.Content = "その操作は無効です。プロジェクトの作成または読み込みを行ってください";
        }

        private void ShowProjectStatus()
        {
            projectTextBox.Text = "プロジェクトの状態" + Environment.NewLine;
            if (project == null)
            {
                projectTextBox.Text += "プロジェクトはありません" + Environment.NewLine;
                return;
            }
            projectTextBox.Text += Environment.NewLine;
            projectTextBox.Text += "マスターボリューム：" + project.VsPrjInfo.MasterVolume + Environment.NewLine;
            projectTextBox.Text += "サンプリング周波数：" + project.VsPrjInfo.SampFreq + Environment.NewLine;
            projectTextBox.Text += Environment.NewLine;
            projectTextBox.Text += "トラック数：" + project.TrackList.Length + Environment.NewLine;
            projectTextBox.Text += "アイテム数：" + project.ItemList.Length + Environment.NewLine;
            projectTextBox.Text += "ミックス後サンプル数：" + project.MixSample + Environment.NewLine;
            projectTextBox.Text += Environment.NewLine;
            for (int i = 0; i < project.TrackList.Length; i++)
            {
                VSTRACKINFO info = project.TrackList[i].Info;
                projectTextBox.Text += "　トラック番号　" + i + Environment.NewLine;
                projectTextBox.Text += "　ボリューム　" + info.volume + Environment.NewLine;
                projectTextBox.Text += "　パン　" + info.pan + Environment.NewLine;
                projectTextBox.Text += "　逆相フラグ　" + info.invPhaseFlg + Environment.NewLine;
                projectTextBox.Text += "　ソロフラグ　" + info.soloFlg + Environment.NewLine;
                projectTextBox.Text += "　ミュートフラグ　" + info.muteFlg + Environment.NewLine;
                projectTextBox.Text += Environment.NewLine;
            }
            projectTextBox.Text += Environment.NewLine;
            for (int i = 0; i < project.ItemList.Length; i++)
            {
                VSITEMINFO info = project.ItemList[i].Info;
                projectTextBox.Text += "　アイテム番号　" + i + Environment.NewLine;
                projectTextBox.Text += "　ファイル名　" + info.fileName + Environment.NewLine;
                projectTextBox.Text += "　サンプリング周波数　" + info.sampFreq + Environment.NewLine;
                projectTextBox.Text += "　チャンネル数　" + info.channel + Environment.NewLine;
                projectTextBox.Text += "　オリジナルのサンプル数　" + info.sampleOrg + Environment.NewLine;
                projectTextBox.Text += "　編集後のサンプル数　" + info.sampleEdit + Environment.NewLine;
                projectTextBox.Text += "　１秒当たりの制御点数　" + info.ctrlPntPs + Environment.NewLine;
                projectTextBox.Text += "　全制御点数　" + info.ctrlPntNum + Environment.NewLine;
                projectTextBox.Text += "　音声合成方式　" + info.synthMode + Environment.NewLine;
                projectTextBox.Text += "　トラック番号　" + info.trackNum + Environment.NewLine;
                projectTextBox.Text += "　オフセット　" + info.offset + Environment.NewLine;
                projectTextBox.Text += "　タイミング制御点数　" + project.ItemList[i].TimeCtrlPoints.Length + Environment.NewLine;
                projectTextBox.Text += "　Eq1　" + project.ItemList[i].GetEQGain(1)[0] + Environment.NewLine;
                projectTextBox.Text += Environment.NewLine;
            }

        }

        /**
         * 
         * 　ライブラリ関連
         * 
         */

        /// <summary>
        /// バージョンの取得
        /// </summary>
        private void GetVersion(object sender, RoutedEventArgs e)
        {
            outputLabel.Content = "version " + VSFunction.VslibGetVersion();
            ShowProjectStatus();
        }

        /// <summary>
        /// プロジェクトの新規作成
        /// </summary>
        private void CreateProject(object sender, RoutedEventArgs e)
        {
            project = new VSProject();
            outputLabel.Content = "プロジェクトを作成しました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus();
        }

        /// <summary>
        /// プロジェクトを開く
        /// </summary>
        private void OpenProject(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "vsプロジェクト(.vshp)|*.vshp",
                Title = "vsプロジェクト読み込み",
            };
            if (ofd.ShowDialog() == true)
            {
                project = new VSProject(ofd.FileName);
                outputLabel.Content = "プロジェクトを読み込みました。error_code=" + project?.LastErrorCode;
            }
            ShowProjectStatus();
        }

        /// <summary>
        /// プロジェクトの保存
        /// </summary>
        private void SaveProject(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = "test_project.vshp",
                Title = "vsプロジェクトの保存",
            };
            if (sfd.ShowDialog() == true)
            {
                project.Save(sfd.FileName);
                outputLabel.Content = "プロジェクトを保存しました。error_code=" + project?.LastErrorCode;
            }
            ShowProjectStatus();
        }

        /// <summary>
        /// プロジェクトを破棄
        /// </summary>
        private void DeleteProject(object sender, RoutedEventArgs e)
        {
            project = null;
            outputLabel.Content = "プロジェクトを破棄しました。";
            ShowProjectStatus();
        }

        /// <summary>
        /// プロジェクト情報を設定
        /// </summary>
        private void SetProjectInfo(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            project.MasterVolume = 0.5;
            project.SampFreq = 80000;
            outputLabel.Content = "プロジェクト情報を設定しました。error_code=" + project?.LastErrorCode;
            project.SampFreq = 16000;
            ShowProjectStatus();
        }


        /**
         * 
         * 　トラック関連
         * 
         */

        /// <summary>
        /// トラックの追加
        /// </summary>
        private void AddTrack(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            project.TrackList.Add();
            outputLabel.Content = "トラックを追加しました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus();
        }

        /// <summary>
        /// トラックのコピー
        /// </summary>
        private void CopyTrack(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            project.TrackList.Add(project.TrackList[0]);
            outputLabel.Content = "トラックをコピーしました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus();
        }

        /// <summary>
        /// トラックを上に移動
        /// </summary>
        private void UpTrack(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            project.TrackList[1].Up();
            outputLabel.Content = "トラックを上に移動しました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus();
        }

        /// <summary>
        /// トラックを下に移動
        /// </summary>
        private void DownTrack(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            project.TrackList[0].Down();
            outputLabel.Content = "トラックを下に移動しました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus();
        }

        /// <summary>
        /// トラックを削除
        /// </summary>
        private void DeleteTrack(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            project.TrackList[0].Dispose();
            outputLabel.Content = "トラックを削除しました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus();
        }

        /// <summary>
        /// トラック情報を設定
        /// </summary>
        private void SetTrackInfo(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            project.TrackList[0].Volume = 0.5;
            project.TrackList[0].Pan = 0.6;
            project.TrackList[0].InvPhaseFlg = true;
            project.TrackList[0].SoloFlg = true;
            project.TrackList[0].MuteFlg = true;
            outputLabel.Content = "トラック情報を設定しました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus();
        }



        /**
         * 
         * 　アイテム関連
         * 
         */

        /// <summary>
        /// アイテムを追加
        /// </summary>
        private void AddItem(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "wavファイル(.wav)|*.wav",
                Title = "wavファイル読み込み",
            };
            if (ofd.ShowDialog() == true)
            {
                project.ItemList.Add(ofd.FileName);
                outputLabel.Content = "wavファイルを読み込みました。error_code=" + project?.LastErrorCode;
            }
            ShowProjectStatus();
        }

        /// <summary>
        /// アイテムをコピー
        /// </summary>
        private void CopyItem(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            project.ItemList.Add(project.ItemList[0]);
            outputLabel.Content = "アイテムをコピーしました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus();
        }

        /// <summary>
        /// アイテムを破棄
        /// </summary>
        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            project.ItemList[0].Dispose();
            outputLabel.Content = "アイテムを削除しました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus();
        }



        /**
         * 
         * 　Time関連
         * 
         */

        /// <summary>
        /// タイム制御点を追加
        /// </summary>
        private void AddTimeCtrl(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            (int time11, int time12) = project.ItemList[0].TimeCtrlPoints[0].GetInfo();
            (int time21, int time22) = project.ItemList[0].TimeCtrlPoints[1].GetInfo();
            project.ItemList[0].TimeCtrlPoints.Add((time11 + time21) / 2, (time12 + time22) / 2 + 1);
            outputLabel.Content = "タイム制御点を追加しました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus();
        }

        /// <summary>
        /// タイム制御点を破棄
        /// </summary>
        private void DeleteTimeCtrl(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            project.ItemList[0].TimeCtrlPoints[1].Dispose();
            outputLabel.Content = "タイム制御点を削除しました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus();
        }



        /**
         * 
         * 　ミキサー関連
         * 
         */

        /// <summary>
        /// ミックス後の波形を取得
        /// </summary>
        private void GetMixData(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            (int[] dataL, int[] dataR) = project.ReadMixData(1, 0, 1000000);
            outputLabel.Content = "ミックス後の波形を取得しました。error_code=" + project?.LastErrorCode;
            ShowProjectStatus(); // 配列の表示は大変なので、ここでブレークポイントを張って、data1の中身を確認する
        }

        /// <summary>
        /// 音声ファイルを保存
        /// </summary>
        private void ExportWaveFile(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = "test_wave.wav",
                Title = "音声ファイルの保存",
            };
            if (sfd.ShowDialog() == true)
            {
                project.ExportWaveFile(sfd.FileName, 1);
                outputLabel.Content = "音声ファイルを保存しました。error_code=" + project?.LastErrorCode;
            }
            ShowProjectStatus();
        }


        /**
         * 
         * 　単位変換関連
         * 
         */

        /// <summary>
        /// 単位変換　cent→Hz
        /// </summary>
        private void ConvertCentToHz(object sender, RoutedEventArgs e)
        {
            int cent = 4800;
            double freq = VSFunction.VslibCent2Freq(cent);
            outputLabel.Content = cent + " cent は " + freq.ToString("0.0") + " Hz です。";
        }

        /// <summary>
        /// 単位変換　Hz→cent
        /// </summary>
        private void ConvertHzToCent(object sender, RoutedEventArgs e)
        {
            double freq = 523.2;
            int cent = VSFunction.VslibFreq2Cent(freq);
            outputLabel.Content = freq.ToString("0.0") + " Hz は " + cent + " cent です。";
        }



        /**
         * 
         * 　プロジェクトマージ
         * 
         */


        /// <summary>
        /// １つ目のプロジェクトを選択
        /// </summary>
        private void SelectProject1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "vsプロジェクト(.vshp)|*.vshp",
                Title = "vsプロジェクト読み込み",
            };
            if (ofd.ShowDialog() == true)
            {
                ProjectName1.Content = ofd.FileName;
            }
        }

        /// <summary>
        /// ２つ目のプロジェクトを選択
        /// </summary>
        private void SelectProject2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "vsプロジェクト(.vshp)|*.vshp",
                Title = "vsプロジェクト読み込み",
            };
            if (ofd.ShowDialog() == true)
            {
                ProjectName2.Content = ofd.FileName;
            }
        }

        /// <summary>
        /// プロジェクトマージ
        /// ちょっとした応用ということでつけてみた
        /// ライブラリではプロジェクト間のトラック・アイテムのコピーが可能なので
        /// ２つのプロジェクトを１つにまとめることができる。
        /// </summary>
        private void MargeProject(object sender, RoutedEventArgs e)
        {
            VSProject project1 = new VSProject((string)ProjectName1.Content);
            if (project1.LastErrorCode != 0)
            {
                outputLabel.Content = "１つ目のプロジェクトが不正です。error_code=" + project?.LastErrorCode;
                return;
            }
            VSProject project2 = new VSProject((string)ProjectName2.Content);
            if (project2.LastErrorCode != 0)
            {
                outputLabel.Content = "２つ目のプロジェクトが不正です。error_code=" + project?.LastErrorCode;
                return;
            }
            if (project1.TrackList.Length + project2.TrackList.Length > Const.VSLIB_MAX_TRACK)
            {
                outputLabel.Content = "合計トラック数が多すぎます。";
                return;
            }
            if (project1.ItemList.Length + project2.ItemList.Length > Const.VSLIB_MAX_ITEM)
            {
                outputLabel.Content = "合計アイテム数が多すぎます。";
                return;
            }
            VSProject projectMarged = new VSProject();
            projectMarged.ItemList.Clear();
            projectMarged.TrackList.Clear();

            if (project1.SampFreq != project2.SampFreq)
            {
                outputLabel.Content = "プロジェクトのサンプリング周波数が異なります。";
                return;
            }
            projectMarged.SampFreq = project1.SampFreq;

            for (int i = 0; i < project1.TrackList.Length; i++)
            {
                projectMarged.TrackList.Add(project1.TrackList[i]);
            }

            for (int i = 0; i < project2.TrackList.Length; i++)
            {
                projectMarged.TrackList.Add(project2.TrackList[i]);
            }

            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = "test_project_marge.vshp",
                Title = "vsプロジェクトの保存",
            };
            if (sfd.ShowDialog() == true)
            {
                projectMarged.Save(sfd.FileName);
                outputLabel.Content = "プロジェクトをマージしました。error_code=" + projectMarged.LastErrorCode;
            }

        }



        /**
         * 
         * 　パラメータ操作
         * 
         */

        /// <summary>
        /// ピッチを半分にする
        /// </summary>
        private void HalfPitch(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            for (int i = 0; i < project.ItemList.Length; i++)
            {
                Item item = project.ItemList[i];
                CtrlPointList ctrlPoints = item.CtrlPoints;
                for (int j = 0; j < ctrlPoints.Length; j++)
                {
                    CtrlPoint point = item.CtrlPoints[j];
                    point.PitEdit = point.PitOrg - 1200;   // 1200cent で１オクターブ(周波数は半分)
                }
            }
            outputLabel.Content = "ピッチを半分にしました。error_code=" + project.LastErrorCode;
        }

        /// <summary>
        /// 音量を半分にする
        /// </summary>
        private void HalfDYN(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            for (int i = 0; i < project.ItemList.Length; i++)
            {
                Item item = project.ItemList[i];
                CtrlPointList ctrlPoints = item.CtrlPoints;
                for (int j = 0; j < ctrlPoints.Length; j++)
                {
                    CtrlPoint point = item.CtrlPoints[j];
                    point.DynEdit = point.DynOrg / 2;   // 音量を半分
                }
            }
            outputLabel.Content = "音量を半分にしました。error_code=" + project.LastErrorCode;
        }

        /// <summary>
        /// フォルマントを100セント下げる
        /// </summary>
        private void M100centFormant(object sender, RoutedEventArgs e)
        {
            if (project == null) { NoProjectError(); return; }
            for (int i = 0; i < project.ItemList.Length; i++)
            {
                Item item = project.ItemList[i];
                CtrlPointList ctrlPoints = item.CtrlPoints;
                for (int j = 0; j < ctrlPoints.Length; j++)
                {
                    CtrlPoint point = item.CtrlPoints[j];
                    point.Formant = -100;
                }
            }
            outputLabel.Content = "フォルマントを-100centにしました。error_code=" + project.LastErrorCode;
        }


    }
}
