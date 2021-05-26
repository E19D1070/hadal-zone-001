using System.Numerics;
using UnityEngine;

//ダメージを橋渡しするインターフェース

//受けたダメージを橋渡しするインターフェース
public interface DamageValue{
    void Damage(float value);
}

//受けた技のタイプを橋渡しするインターフェース
//現在考案している攻撃タイプ
//直接＝何らかの物体が対象に直接あたってHPを減らすタイプ。（遠距離でも近距離でも攻撃が直接当たっているため直接とみなす）
//間接＝物体が直接触れず、何らかの影響によってHPを減らすタイプ。（例えば、持続的にダメージを与える状態異常、毒や深海圧による一定ダメージがあげられる）
public interface DamageType{
    void Damage(string type);
}

//受けた技の座標を橋渡しするインターフェース
public interface DamagePosition {
    void Damage(UnityEngine.Vector3 position);
}

//受けた技のレイヤーを橋渡しするインターフェース
public interface DamageLayer {
    void Damage(int layer);
}

