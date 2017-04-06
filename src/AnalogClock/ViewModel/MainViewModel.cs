using AnalogClock.Resource;
using AnalogClock.Model;
using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace AnalogClock.ViewModel
{
    class MainViewModel : BindableBase
    {
        /// <summary>
        /// 【Binding用プロパティ】
        /// 数時位置オフセット
        /// 配列インデックス[0～11]は、数字の1～12に対応する。
        /// </summary>
        private Point[] _numberPositionOffsetArray;
        public Point[] NumberPositionOffsetArray
        {
            get { return _numberPositionOffsetArray; }
            set { SetProperty(ref _numberPositionOffsetArray, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 影の長さ
        /// </summary>
        private double _shadowSize = ConstantData.ORIGINAL_SHADOW_SIZE;
        public double ShadowSize
        {
            get { return _shadowSize; }
            set { SetProperty(ref _shadowSize, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 時計半径
        /// </summary>
        private double _radius = ConstantData.ORIGINAL_CLOCK_LENGTH / 2;
        public double Radius
        {
            get { return _radius; }
            set { SetProperty(ref _radius, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 秒針のサイズ
        /// </summary>
        private Size _secondHandSize = new Size(ConstantData.ORIGINAL_SECOND_HAND_WIDTH, ConstantData.ORIGINAL_SECOND_HAND_LENGTH);
        public Size SecondHandSize
        {
            get { return _secondHandSize; }
            set { SetProperty(ref _secondHandSize, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 分針の長さ
        /// </summary>
        private Size _minuteHandSize = new Size(ConstantData.ORIGINAL_MINUTE_HAND_WIDTH, ConstantData.ORIGINAL_MINUTE_HAND_LENGTH);
        public Size MinuteHandSize
        {
            get { return _minuteHandSize; }
            set { SetProperty(ref _minuteHandSize, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 時針の長さ
        /// </summary>
        private Size _hourHandSize = new Size(ConstantData.ORIGINAL_HOUR_HAND_WIDTH, ConstantData.ORIGINAL_HOUR_HAND_LENGTH);
        public Size HourHandSize
        {
            get { return _hourHandSize; }
            set { SetProperty(ref _hourHandSize, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 秒針の角度
        /// </summary>
        private double _secondHandAngle = 0.0;
        public double SecondHandAngle
        {
            get { return TimeUtility.GetSecondAngle(); }
            //set { SetProperty(ref _secondHandAngle, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 分針の角度
        /// </summary>
        private double _minuteHandAngle = 58.0;
        public double MinuteHandAngle
        {
            get { return TimeUtility.GetMinuteAngle(); }
            //set { SetProperty(ref _minuteHandAngle, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 時針の角度
        /// </summary>
        private double _hourHandAngle = 305.0;
        public double HourHandAngle
        {
            get { return TimeUtility.GetHourAngle(); }
            //set { SetProperty(ref _hourHandAngle, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 秒針の縦位置オフセット
        /// </summary>
        //private double _secondHandYOffset = -36.5;
        public double SecondHandYOffset
        {
            get { return -this.SecondHandSize.Height * 0.4; }
            //set { SetProperty(ref _secondHandYOffset, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 分針の縦位置オフセット
        /// </summary>
        //private double _minuteHandYOffset = -31.5;
        public double MinuteHandYOffset
        {
            get { return -this.MinuteHandSize.Height * 0.4; }
            //set { SetProperty(ref _minuteHandYOffset, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 時針の縦位置オフセット
        /// </summary>
        //private double _hourHandYOffset = -23.8;
        public double HourHandYOffset
        {
            get { return -this.HourHandSize.Height * 0.4; }
            //set { SetProperty(ref _hourHandYOffset, value); }
        }

        /// <summary>
        /// 【Binding用コマンド】
        /// 基本サイズに対するコントロールの大きさ比
        /// </summary>
        private double _controlSizeRate = 1.0;
        public double ControlSizeRate
        {
            get { return _controlSizeRate; }
            set { SetProperty(ref _controlSizeRate, value); }
        }

        /// <summary>
        /// 【Binding用コマンド】
        /// 終了コマンド
        /// </summary>
        public ICommand ClosingCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    App.Current.MainWindow.Close();
                });
            }
        }

        // Binding用のプロパティ・コマンドは以上。

        DispatcherTimer timeUpdatingTimer;



        /// <summary>
        /// コンストラクタ
        /// ・プロパティ初期化
        /// </summary>
        public MainViewModel()
        {
            this.NumberPositionOffsetArray = new Point[12];
            this.timeUpdatingTimer = new DispatcherTimer();
            this.timeUpdatingTimer.Interval = TimeSpan.FromMilliseconds(200);
            this.timeUpdatingTimer.Tick += (object sender, EventArgs e) =>
            {
                OnPropertyChanged("HourHandAngle");
                OnPropertyChanged("MinuteHandAngle");
                OnPropertyChanged("SecondHandAngle");
            };
            this.timeUpdatingTimer.Start();
            
            LocateControls();
        }

        ~MainViewModel()
        {
            this.timeUpdatingTimer.Stop();
        }
        
        /// <summary>
        /// 固定位置のコントロールのサイズ・配置関係の設定を行う。
        /// 対象のコントロール：
        ///   ・文字盤
        ///   ・縁
        ///   など
        /// </summary>
        private void LocateControls()
        {
            /// 定数 π÷6
            const double PI_OVER_6 = Math.PI / 6.0;

            /// 半径設定
            const double POSITION_RATE = 1.12;

            /// 文字盤の数字を示すテキストブロックの位置を調整する。初期位置は文字盤の中心になっている。
            for (int i = 0; i < 12; i++)
            {
                NumberPositionOffsetArray[i].X =  Math.Sin((i + 1) * PI_OVER_6) * (this.Radius - ConstantData.ORIGINAL_NUMBER_FONT_SIZE) * POSITION_RATE;
                NumberPositionOffsetArray[i].Y = -Math.Cos((i + 1) * PI_OVER_6) * (this.Radius - ConstantData.ORIGINAL_NUMBER_FONT_SIZE) * POSITION_RATE;
            }
        }
    }
}
