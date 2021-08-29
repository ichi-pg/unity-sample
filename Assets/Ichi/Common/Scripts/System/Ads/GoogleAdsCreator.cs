using System.Collections;
using System.Collections.Generic;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

namespace Ichi.Common
{
    public class GoogleAdsCreator :  IAdsCreator
    {
        public GoogleAdsCreator() {
            //TODO 呼ぶとエラーになるが、呼ばなくてもダミー広告出る。
            // MobileAds.Initialize(initStatus => { });
        }

        public IAds Create() {
            return new GoogleAds();
        }
    }
}
