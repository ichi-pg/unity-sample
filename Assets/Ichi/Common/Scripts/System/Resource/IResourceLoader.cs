using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public interface IResourceLoader
    {
        T Load<T>(string name) where T : Object;
    }
}
