using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalogClock.Model
{
    class AlermModel
    {
        /// <summary>
        /// アラームが有効か否か
        /// true:有効  false:無効
        /// </summary>
        public bool IsAlermOn;

        /// <summary>
        /// アラームに設定されている時刻
        /// </summary>
        public int Hour;
        public int Minute;
        public int Second;

        /// <summary>
        /// コンストラクタ。
        /// ・メンバを初期化する。
        /// </summary>
        public AlermModel()
        {
            IsAlermOn = false;
            Hour = 0;
            Minute = 0;
            Second = 0;
        }
    }
}
