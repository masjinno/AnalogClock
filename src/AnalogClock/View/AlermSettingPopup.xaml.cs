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
            set { _}
        }
        #endregion
        public AlermSettingPopup()
        {
            InitializeComponent();
        }
    }
}
