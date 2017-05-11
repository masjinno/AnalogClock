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
    /// AlermSetting.xaml の相互作用ロジック
    /// </summary>
    public partial class AlermSetting : UserControl
    {
        #region UserControlイベント

        /// <summary>
        /// 【UserControl】【Event】
        /// OKボタンクリックイベント
        /// </summary>
        public static RoutedEvent OKButtonClickEvent = EventManager.RegisterRoutedEvent(
            "OKButtonClick",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler),
            typeof(AlermSetting));
        public event RoutedEventHandler OKButtonClick
        {
            add { this.AddHandler(OKButtonClickEvent, value); }
            remove { this.RemoveHandler(OKButtonClickEvent, value); }
        }

        /// <summary>
        /// 【UserControl】【Event】
        /// Cancelボタンクリックイベント
        /// </summary>
        public static RoutedEvent CancelButtonClickEvent = EventManager.RegisterRoutedEvent(
            "CancelButtonClick",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler),
            typeof(AlermSetting));
        public event RoutedEventHandler CancelButtonClick
        {
            add { this.AddHandler(CancelButtonClickEvent, value); }
            remove { this.RemoveHandler(CancelButtonClickEvent, value); }
        }
        #endregion

        /// <summary>
        /// コンストラクタ。
        /// WPF規定の処理の他に、イベント登録処理を行う。
        /// </summary>
        public AlermSetting()
        {
            /// デフォルトの処理
            InitializeComponent();
            
            /// イベント登録処理
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            /// OKボタンクリックイベント登録処理
            OKButton.Click += (object sender, RoutedEventArgs e) =>
            {
                RoutedEventArgs newEventArgs = new RoutedEventArgs(AlermSetting.OKButtonClickEvent);
                RaiseEvent(newEventArgs);
            };

            /// Cancelボタンクリックイベント登録処理
            CancelButton.Click += (object sender, RoutedEventArgs e) =>
            {
                RoutedEventArgs newEventArgs = new RoutedEventArgs(AlermSetting.CancelButtonClickEvent);
                RaiseEvent(newEventArgs);
            };
        }

        /// <summary>
        /// アラーム設定関数。
        /// UI設定を、設定対象アラームにセットする。
        /// </summary>
        /// <param name="targetAlerm">設定対象アラーム</param>
        public void SetAlerm(Model.AlermModel targetAlerm)
        {
            targetAlerm.Hour = this.HourNumericUpDown.NumericValue;
            targetAlerm.Minute = this.MinuteNumericUpDown.NumericValue;
            targetAlerm.IsAlermOn = true;
        }
    }
}
