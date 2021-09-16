using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public interface IFactory : ICost, ILevel
    {
        int Rank { get; }
        int Rarity { get; }
        bool IsBought { get; }
        bool IsLock { get; }
        BigIntegerStatus Power { get; }
        string Unit { get; }
        FactoryCategory Category { get; }
        IObservable<int> OnLevelUp { get; }

        //NOTE IFactoryとFactoryどっちかリネーム。スキルも含まれるのでIFactoryをリネームする方が良い。成長し使うもの。道具、配下。
        //NOTE Minion, Tool, Gear, Gadget, Follower, Servant, Card, Glow, Article, Fortune, Property, Asset, Piece, Hand, Entity, Thing
    }
}
