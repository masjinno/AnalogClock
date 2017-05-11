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
        private Model.AlermModel alerm;

        public AlermSettingWindow(Model.AlermModel al)
        {
            this.alerm = al;

            InitializeComponent();
            this.InitializeControls();
        }

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
