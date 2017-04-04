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
        public static readonly double ORIGINAL_SECOND_HAND_LENGTH = ORIGINAL_CLOCK_LENGTH / 2 * 0.9;

        /// <summary>
        /// 秒針の基本幅
        /// </summary>
        public static readonly double ORIGINAL_SECOND_HAND_WIDTH = 1;

        /// <summary>
        /// 分針の基本長さ
        /// </summary>
        public static readonly double ORIGINAL_MINUTE_HAND_LENGTH = ORIGINAL_CLOCK_LENGTH / 2 * 0.75;

        /// <summary>
        /// 分針の基本幅
        /// </summary>
        public static readonly double ORIGINAL_MINUTE_HAND_WIDTH = 3;

        /// <summary>
        /// 時針の基本長さ
        /// </summary>
        public static readonly double ORIGINAL_HOUR_HAND_LENGTH = ORIGINAL_CLOCK_LENGTH / 2 * 0.6;

        /// <summary>
        /// 時針の基本幅
        /// </summary>
        public static readonly double ORIGINAL_HOUR_HAND_WIDTH = 6;
    }
}
