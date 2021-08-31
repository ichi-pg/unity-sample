using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public interface IChildView<T>
    {
        void Initialize(T child);
    }
}
