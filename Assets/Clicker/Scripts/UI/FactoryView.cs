using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class FactoryView : Common.PropertyInjector
    {
        private Factory Factory { get => this.Data as Factory; }

        //TODO レベルアップ
    }
}
