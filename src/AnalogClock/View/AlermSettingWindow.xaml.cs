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
using System.Windows.Shapes;

namespace AnalogClock.View
{
    /// <summary>
    /// AlermSetting.xaml の相互作用ロジック
    /// </summary>
    public partial class AlermSettingWindow : Window
    {
        /// <summary>
        /// アラーム本体。
        /// クラス外でnewされたオブジェクトを割り当てる。
        /// </summary>
        private Model.AlermModel alerm;

        /// <summary>
        /// コンストラクタ。
        /// ・UI設定対象を代入する
        /// ・各種コントロール初期化
        /// </summary>
        /// <param name="al">UI設定対象のアラーム</param>
        public AlermSettingWindow(Model.AlermModel al)
        {
            this.alerm = al;

            InitializeComponent();
            this.InitializeControls();
        }

        /// <summary>
        /// コントロール初期化
        /// ・OKボタン押下イベント処理を定義
        /// ・Cancelボタン押下イベント処理を定義
        /// </summary>
        private void InitializeControls()
        {
            /// OKボタンクリックイベント時の処理を定義
            this.MainAlermSetting.OKButtonClick += (object sender, RoutedEventArgs e) =>
            {
                this.MainAlermSetting.SetAlerm(this.alerm);
                this.Close();
            };

            /// Cancelボタンクリックイベント時の処理を定義
            this.MainAlermSetting.CancelButtonClick += (object sender, RoutedEventArgs e) =>
            {
                this.Close();
            };

            if (this.alerm.IsAlermOn)
            {
                this.MainAlermSetting.HourNumericUpDown.NumericValue = this.alerm.Hour;
                this.MainAlermSetting.MinuteNumericUpDown.NumericValue = this.alerm.Minute;
            }
        }
    }
}
