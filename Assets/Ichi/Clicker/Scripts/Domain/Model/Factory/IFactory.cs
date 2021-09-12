using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

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
        event Action AlterHandler;

        //TODO モンスター娘を餌付けして仲間にしようクリッカー。
        //TODO クリックで料理を投げてコインと好感度ゲージがたまる。
        //TODO コインで料理を強化する。
        //TODO 料理の好みでたまり方が変わる（マイナスもあり）。
        //TODO 好感度ゲージは放置すると下がる。
        //TODO 時間切れで逃げる（レアモンスターはシビアにする）。
        //TODO ゲージMAXでモンスター捕獲。
        //TODO 次のモンスターが現在のレベル（料理レベルの合計）に合わせてランダムに出現。
        //TODO 捕まえたモンスター娘はコインのオート生産やバフを発揮する。
        //TODO モンスターもコインで強化する。
        //TODO レアリティによるハクスラ。
        //TODO 珍しいモンスター種類によるハクスラ。
        //TODO 同じモンスターは1体まで所持できる（レアリティ上書き）。
        //TODO それぞれモンスター娘のシナリオ開放まで実装できたら熱いけど、シナリオ用意するのがしんどいので保留。
        //TODO 広告は「フィーバー回復」「放置2倍」「レアリティ上昇」「逃亡時間延長」
        //TODO 同じモンスター同じレアリティを捕まえたときは何をインセンティブにする？経験値？シナリオ開放？
        //TODO 料理を覚えていないと捕まえられないのはストレスすぎる？動機付けとして機能するけど？
    }
}
