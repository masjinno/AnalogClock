using AnalogClock.Model;
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

namespace AnalogClock.View
{
    /// <summary>
    /// AlermSettingPopup.xaml の相互作用ロジック
    /// </summary>
    public partial class AlermSettingPopup : UserControl
    {
        #region UserControlプロパティ

        /// <summary>
        /// 【UserControl】【Property】
        /// ポップアップオープン状態。
        ///   true:オープン
        ///   false:クローズ
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register(
                "IsOpen",
                typeof(bool),
                typeof(AlermSettingPopup),
                new PropertyMetadata(
                    false,
                    (DependencyObject d, DependencyPropertyChangedEventArgs e) =>
                    {
                        ((AlermSettingPopup)d).IsOpen = (bool)e.NewValue;
                    }));
        private bool _isOpen;
        public bool IsOpen
        {
            get { return this._isOpen; }
            set
            {
                this._isOpen = value;
                this.MainPopup.IsOpen = this._isOpen;
            }
        }

        #endregion

        private Model.AlermModel alerm;
        
        public AlermSettingPopup(Model.AlermModel al)
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
                this.alerm.Hour = this.MainAlermSetting.HourNumericUpDown.NumericValue;
                this.alerm.Minute = this.MainAlermSetting.MinuteNumericUpDown.NumericValue;
                this.alerm.IsAlermOn = true;
                this.IsOpen = false;
            };

            /// Cancelボタンクリックイベント時の処理を定義
            this.MainAlermSetting.CancelButtonClick += (object sender, RoutedEventArgs e) =>
            {
                this.IsOpen = false;
            };
        }
    }
}
