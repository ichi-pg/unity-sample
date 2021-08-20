using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class ResourceLoader : IResourceLoader
    {
        public T Load<T>(string name) where T : Object {
            return Resources.Load<T>(name);
        }
    }
}
