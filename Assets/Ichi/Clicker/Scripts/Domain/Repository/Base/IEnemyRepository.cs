using System.Collections;
using System.Collections.Generic;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public interface IEnemyRepository
    {
        IEnemy Enemy { get; }
        IObservable<IEnemy> OnEncount { get; }
        void Encount();
    }
}
