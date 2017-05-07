using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalogClock.Model
{
    public class AlermModel
    {
        /// <summary>
        /// アラームが有効か否か
        /// true:有効  false:無効
        /// </summary>
        private bool _isAlermOn = false;
        public bool IsAlermOn
        {
            get { return _isAlermOn; }
            set
            {
                _isAlermOn = value;
                if (_isAlermOn)
                {
                    /// 設定時の処理
                    this.AlermStart();
                }
            }
        }

        /// <summary>
        /// アラームに設定されている時刻[時]
        /// </summary>
        private int _hour = 0;
        public int Hour
        {
            get { return _hour; }
            set
            {
                if (value < 0)        _hour = 0;
                else if (value >= 24) _hour = 23;
                else                  _hour = value;
            }
        }

        /// <summary>
        /// アラームに設定されている時刻[分]
        /// </summary>
        private int _minute = 0;
        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value < 0)        _minute = 0;
                else if (value >= 60) _minute = 59;
                else                  _minute = value;
            }
        }

        /// <summary>
        /// コンストラクタ。
        /// ・メンバを初期化する。
        /// </summary>
        public AlermModel()
        {
            _isAlermOn = false;
            _hour = 0;
            _minute = 0;
        }

        private void AlermStart()
        {
            Task t = new Task(()=>
            {
                bool isOnTime = false;
                while (IsAlermOn)
                {
                    int hour, minute, second;
                    TimeUtility.GetNowTime(out hour, out minute, out second);
                    if (isEqualedHourMinute(this.Hour, this.Minute, hour, minute))
                    {
                        isOnTime = true;
                        this.IsAlermOn = false;
                    }
                    System.Threading.Thread.Sleep(500); //500ms間隔で監視する
                }

                if (isOnTime)
                {
                    System.Windows.MessageBox.Show(
                        "It's a set time.",
                        "Alerm",
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Information,
                        System.Windows.MessageBoxResult.OK,
                        System.Windows.MessageBoxOptions.ServiceNotification);
                }
            });
            t.Start();
        }

        private bool isEqualedHourMinute(int hour1, int minute1, int hour2, int minute2)
        {
            bool ret = false;

            if (hour1 == hour2 && minute1 == minute2) ret = true;

            return ret;
        }
    }
}
