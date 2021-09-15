using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Ichi.Common.Extensions
{
    public static class LongPress
    {
        public static IObservable<long> OnLongPressAsObservable(this Button button, double delay, double interval) {
            return button.OnPointerDownAsObservable()
                .SelectMany(
                    Observable.Return(0L).Concat(
                        Observable.Timer(
                            TimeSpan.FromSeconds(delay),
                            TimeSpan.FromMilliseconds(interval)
                        )
                    )
                )
                .TakeUntil(button.OnPointerUpAsObservable())
                .RepeatUntilDestroy(button);
        }
    }
}
