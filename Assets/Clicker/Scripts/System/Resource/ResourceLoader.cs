using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class ResourceLoader
    {
        public static Common.IResourceLoader Instance { get; private set; } = new Common.ResourceLoader();
    }
}
