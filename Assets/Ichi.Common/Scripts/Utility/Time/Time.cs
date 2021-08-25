using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Common
{
    public static class Time
    {
        //TODO チート対策（自前NTPと負荷対策）
        //TODO チートモード（100倍速）
        public static DateTime Now { get => DateTime.Now; }
    }
}
