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
    /// NumericUpDownButton.xaml の相互作用ロジック
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        #region UserControlプロパティ
        /// <summary>
        /// TextBoxの値
        /// </summary>
        public static readonly DependencyProperty NumericValueProperty =
            DependencyProperty.Register(
                "NumericValue",
                typeof(int),
                typeof(NumericUpDown),
                new PropertyMetadata(
                    0,
                    (DependencyObject d, DependencyPropertyChangedEventArgs e) =>
                    {
                        ((NumericUpDown)d).NumericValue = (int)e.NewValue;
                    }));
        private int _numericValue;
        public int NumericValue
        {
            get { return _numericValue; }
            set
            {
                /// 定義域に収まっているか判定
                if      (value > this.MaxValue) { _numericValue = this.MaxValue; }
                else if (value < this.MinValue) { _numericValue = this.MinValue; }
                else                            { _numericValue = value; }

                /// 見た目に反映
                ValueTextBox.Text = _numericValue.ToString();
            }
        }

        /// <summary>
        /// TextBoxの最大値
        /// </summary>
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register(
                "MaxValue",
                typeof(int),
                typeof(NumericUpDown),
                new PropertyMetadata(
                    int.MaxValue,
                    (DependencyObject sender, DependencyPropertyChangedEventArgs e) =>
                    {
                        ((NumericUpDown)sender).MaxValue = (int)e.NewValue;
                    }));
        private int _maxValue = int.MaxValue;
        public int MaxValue
        {
            get { return _maxValue; }
            set
            {
                /// 最小値と比較
                if (value < this.MinValue) { _maxValue = this.MinValue; }
                else                       { _maxValue = value; }

                /// 新しい定義域から外れていたら修正
                if (this.NumericValue > this._maxValue) { this.NumericValue = this._maxValue; }
            }
        }

        /// <summary>
        /// TextBoxの最小値
        /// </summary>
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register(
                "MinValue",
                typeof(int),
                typeof(NumericUpDown),
                new PropertyMetadata(
                    int.MinValue,
                    (DependencyObject sender, DependencyPropertyChangedEventArgs e) =>
                    {
                        ((NumericUpDown)sender).MinValue = (int)e.NewValue;
                    }));
        private int _minValue = int.MinValue;
        public int MinValue
        {
            get { return _minValue; }
            set
            {
                /// 最大値と比較
                if (value > this.MaxValue) { _minValue = this.MaxValue; }
                else                       { _minValue = value; }
                _minValue = value;

                /// 新しい定義域から外れていたら修正
                if (this.NumericValue < this._minValue) { this.NumericValue = this._minValue; }
            }
        }
        #endregion

        /// <summary>
        /// コンストラクタ。
        /// ・コントロール初期化
        /// </summary>
        public NumericUpDown()
        {
            InitializeComponent();

            InitializeControls();
        }

        /// <summary>
        /// 各コントロールの初期化
        /// </summary>
        private void InitializeControls()
        {
            /// 上ボタンクリック時の処理
            UpButton.Click += (object sender, RoutedEventArgs e) =>
            {
                this.NumericValue++;
            };

            /// 下ボタンクリック時の処理
            DownButton.Click += (object sender, RoutedEventArgs e) =>
            {
                this.NumericValue--;
            };

            /// テキスト直編集時の処理
            ValueTextBox.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                TextBox tb = sender as TextBox;
                int newValue;
                if (int.TryParse(tb.Text, out newValue))
                {
                    this.NumericValue = newValue;
                }
                else
                {
                    MessageBox.Show(
                        string.Format("Invalid value \"{0}\".\r\nValue must be integer.", tb.Text),
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            };

            /// 値設定
            ValueTextBox.Text = NumericValue.ToString();
        }
    }
}
