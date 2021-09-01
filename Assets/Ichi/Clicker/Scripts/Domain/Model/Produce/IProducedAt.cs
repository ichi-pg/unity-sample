using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IProducedAt
    {
        Common.TicksTime ProducedAt { get; set; }
    }
}
