
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

namespace Ichi.Common
{
    public interface IAds
    {
        event Action RewardHandler;
        void Play();
    }
}
