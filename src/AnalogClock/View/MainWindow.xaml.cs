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
        public MainWindow()
        {
            InitializeComponent();

            Initialize();
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            this.Width = ConstantData.ORIGINAL_CLOCK_LENGTH * 1.25;
            this.Height = ConstantData.ORIGINAL_CLOCK_LENGTH * 1.25;
            this.MouseLeftButtonDown += (object sender, MouseButtonEventArgs e) => this.DragMove();
        }
    }
}
