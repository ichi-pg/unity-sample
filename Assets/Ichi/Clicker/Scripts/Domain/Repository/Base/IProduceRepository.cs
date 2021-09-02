using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IProduceRepository
    {
        void ClickProduce();
        void TimeProduce();
        void CheatMode(bool enable);
    }
}
