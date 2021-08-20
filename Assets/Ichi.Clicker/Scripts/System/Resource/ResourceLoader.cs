using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class ResourceLoader
    {
        public static Ichi.Common.IResourceLoader Instance { get; private set; } = new Ichi.Common.ResourceLoader();
    }
}
