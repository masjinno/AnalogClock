using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalogClock.Resource
{
    class ConstantData
    {
        /// <summary>
        /// 時計の基本長さ
        /// </summary>
        public static readonly double ORIGINAL_CLOCK_LENGTH = 200;

        /// <summary>
        /// 文字盤の基本フォントサイズ
        /// </summary>
        public static readonly double ORIGINAL_NUMBER_FONT_SIZE = 24;

        /// <summary>
        /// 影の基本長さ
        /// </summary>
        public static readonly double ORIGINAL_SHADOW_SIZE = 8;

        /// <summary>
        /// 秒針の基本長さ
        /// </summary>
        public static readonly double ORIGINAL_SECOND_HAND_LENGTH = ORIGINAL_CLOCK_LENGTH / 2 * 0.94;

        /// <summary>
        /// 秒針の基本幅
        /// </summary>
        public static readonly double ORIGINAL_SECOND_HAND_WIDTH = 1;

        /// <summary>
        /// 分針の基本長さ
        /// </summary>
        public static readonly double ORIGINAL_MINUTE_HAND_LENGTH = ORIGINAL_CLOCK_LENGTH / 2 * 0.78;

        /// <summary>
        /// 分針の基本幅
        /// </summary>
        public static readonly double ORIGINAL_MINUTE_HAND_WIDTH = 3;

        /// <summary>
        /// 時針の基本長さ
        /// </summary>
        public static readonly double ORIGINAL_HOUR_HAND_LENGTH = ORIGINAL_CLOCK_LENGTH / 2 * 0.45;

        /// <summary>
        /// 時針の基本幅
        /// </summary>
        public static readonly double ORIGINAL_HOUR_HAND_WIDTH = 6;

        /// <summary>
        /// 秒目盛りの基本長さ
        /// </summary>
        public static readonly double ORIGINAL_SECOND_SCALE_LENGTH = 5;

        /// <summary>
        /// 秒目盛りの基本幅
        /// </summary>
        public static readonly double ORIGINAL_SECOND_SCALE_WIDTH = 0.6;

        /// <summary>
        /// 5の倍数の秒目盛りのサイズ比率
        /// </summary>
        public static readonly double ORIGINAL_5SECOND_SCALE_SIZE_RATE = 1.6;
    }
}
