using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalogClock.Model
{
    /// <summary>
    /// 1つの時刻を受け持つアラーム
    /// </summary>
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
                    this.SetAlerm();
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

        /// <summary>
        /// アラームを有効にする
        /// </summary>
        private void SetAlerm()
        {
            /// 設定した時刻に到達したかを監視するタスク
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
            /// タスク開始
            t.Start();
        }

        /// <summary>
        /// 時刻が一致しているかを判定する
        /// </summary>
        /// <param name="hour1">判定対象時刻1 [時]</param>
        /// <param name="minute1">判定対象時刻1 [分]</param>
        /// <param name="hour2">判定対象時刻2 [時]</param>
        /// <param name="minute2">判定対象時刻2 [分]</param>
        /// <returns>時刻が一致しているか  true:一致している  false:一致していない</returns>
        private bool isEqualedHourMinute(int hour1, int minute1, int hour2, int minute2)
        {
            return (hour1 == hour2 && minute1 == minute2);
        }
    }
}
