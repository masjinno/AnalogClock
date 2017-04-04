using AnalogClock.Resource;
using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnalogClock.ViewModel
{
    class MainViewModel : BindableBase
    {
        /// <summary>
        /// 【Binding用プロパティ】
        /// ウィンドウ上下長
        /// </summary>
        public double WindowLength
        {
            get
            {
                return this.Radius * 2 + ShadowSize;
            }
        }

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
        public double ShadowSize
        {
            get { return ConstantData.ORIGINAL_SHADOW_SIZE * controlSizeRate; }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 時計半径
        /// </summary>
        public double Radius
        {
            get { return ConstantData.ORIGINAL_CLOCK_LENGTH / 2 * controlSizeRate; }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 秒針の長さ
        /// </summary>
        public double SecondHandLength
        {
            get { return ConstantData.ORIGINAL_SECOND_HAND_LENGTH * controlSizeRate; }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 秒針の幅
        /// </summary>
        public double SecondHandWidth
        {
            get { return ConstantData.ORIGINAL_SECOND_HAND_WIDTH * controlSizeRate; }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 分針の長さ
        /// </summary>
        public double MinuteHandLength
        {
            get { return ConstantData.ORIGINAL_MINUTE_HAND_LENGTH * controlSizeRate; }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 分針の幅
        /// </summary>
        public double MinuteHandWidth
        {
            get { return ConstantData.ORIGINAL_MINUTE_HAND_WIDTH * controlSizeRate; }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 時針の長さ
        /// </summary>
        public double HourHandLength
        {
            get { return ConstantData.ORIGINAL_HOUR_HAND_LENGTH * controlSizeRate; }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 時針の幅
        /// </summary>
        public double HourHandWidth
        {
            get { return ConstantData.ORIGINAL_HOUR_HAND_WIDTH * controlSizeRate; }
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

        /// <summary>
        /// 基本サイズに対するコントロールの大きさ比
        /// </summary>
        private double _controlSizeRate = 1.0;
        private double controlSizeRate
        {
            get { return _controlSizeRate; }
            set { _controlSizeRate = value; }
        }
        
        /// <summary>
        /// コンストラクタ
        /// ・プロパティ初期化
        /// </summary>
        public MainViewModel()
        {
            NumberPositionOffsetArray = new Point[12];
            
            LocateControls();
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
            const double POSITION_RATE = 1.14;

            /// 文字盤の数字を示すテキストブロックの位置を調整する。初期位置は文字盤の中心になっている。
            for (int i = 0; i < 12; i++)
            {
                NumberPositionOffsetArray[i].X = Math.Sin((i + 1) * PI_OVER_6) * (this.Radius - ConstantData.ORIGINAL_NUMBER_FONT_SIZE * controlSizeRate) * POSITION_RATE;
                NumberPositionOffsetArray[i].Y = -Math.Cos((i + 1) * PI_OVER_6) * (this.Radius - ConstantData.ORIGINAL_NUMBER_FONT_SIZE * controlSizeRate) * POSITION_RATE;
            }
        }
        
    }
}
