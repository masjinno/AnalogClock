using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalogClock.Model
{
    public static class TimeUtility
    {
        /// 360degreeに対応する秒針は何秒か
        private const int MAX_SECOND = 60;

        /// 360degreeに対応する分針は何秒か
        private const int MAX_MINUTE = MAX_SECOND * 60;

        /// 360degreeに対応する時針は何秒か
        private const int MAX_HOUR = MAX_MINUTE * 24;

        /// <summary>
        /// 現在時刻を取得する
        /// </summary>
        /// <param name="hour">[out]現在時</param>
        /// <param name="minute">[out]現在分</param>
        /// <param name="second">[out]現在秒</param>
        public static void GetNowTime(out int hour, out int minute, out int second)
        {
            DateTime nowTime = DateTime.Now;
            hour = nowTime.Hour;
            minute = nowTime.Minute;
            second = nowTime.Second;
        }

        /// <summary>
        /// 現在時刻に対応する時分秒針の角度を取得する
        /// </summary>
        /// <param name="hour">現在時</param>
        /// <param name="minute">現在分</param>
        /// <param name="second">現在秒</param>
        /// <param name="hourAngle">時針の角度</param>
        /// <param name="minuteAngle">分針の角度</param>
        /// <param name="secondAngle"></param>
        public static void GetHourMinuiteSecondAngle(int hour, int minute, int second, out double hourAngle, out double minuteAngle, out double secondAngle)
        {
            int totalMinute = second + minute * 60;
            int totalSecond = second + (minute + hour * 60) * 60;

            hourAngle = 360.0 * totalSecond / MAX_HOUR;
            minuteAngle = 360.0 * totalMinute / MAX_MINUTE;
            secondAngle = 360.0 * second / MAX_SECOND;
        }

        public static double GetHourAngle()
        {
            int h, m, s;
            TimeUtility.GetNowTime(out h, out m, out s);

            int totalSecond = s + (m + h * 60) * 60;
            double hourAngle = 360.0 * totalSecond / MAX_HOUR;
            return hourAngle;
        }

        public static double GetMinuteAngle()
        {
            int h, m, s;
            TimeUtility.GetNowTime(out h, out m, out s);

            int totalMinute = s + m * 60;
            double minuteAngle = 360.0 * totalMinute / MAX_MINUTE;
            return minuteAngle;
        }

        public static double GetSecondAngle()
        {
            int h, m, s;
            TimeUtility.GetNowTime(out h, out m, out s);

            double secondAngle = 360.0 * s / MAX_SECOND;
            return secondAngle;
        }
    }
}
