using AnalogClock.Resource;
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
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// コンストラクタ。
        /// ・コントロール初期化
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Initialize();
        }

        /// <summary>
        /// ウィンドウの初期化設定
        /// ・Window幅設定
        /// ・Window高さ設定
        /// ・自在にドラッグ＆ドロップできるように設定
        /// </summary>
        private void Initialize()
        {
            this.Width = ConstantData.ORIGINAL_CLOCK_LENGTH + ConstantData.ORIGINAL_SHADOW_SIZE * 2;
            this.Height = ConstantData.ORIGINAL_CLOCK_LENGTH + ConstantData.ORIGINAL_SHADOW_SIZE * 2;

            this.MouseLeftButtonDown += (object sender, MouseButtonEventArgs e) => this.DragMove();
        }
    }
}
