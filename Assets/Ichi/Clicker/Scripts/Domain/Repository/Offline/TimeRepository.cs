using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.Offline
{
    public class TimeRepository : ITimeRepository
    {
        public DateTime Now { get => DateTime.Now; }
        //NOTE サーバーから
    }
}
