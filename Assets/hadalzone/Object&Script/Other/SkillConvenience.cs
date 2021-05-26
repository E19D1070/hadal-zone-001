using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スキルを使用する時に使うその他の機能をメソッド化して便利にしたい

public class SkillConvenience : MonoBehaviour
{
    //自信のタイプによってレイヤーを変更するメソッド
    //引数　１自身のタイプ
    public int LayerChange(string Type) {
        int Layer = 0;
        if (Type == "TypePlayer") {
            Layer = 11;
        }
        if (Type == "TypeEnemy") {
            Layer = 21;
        }
        return Layer;
    }

    //自信のタイプによってタグを変更するメソッド
    //引数　１自身のタイプ
    public string TagChange(string Type) {
        string Tag = "";
        if (Type == "TypePlayer") {
            Tag = "PlayerAttack";
        }
        if (Type == "TypeEnemy") {
            Tag = "EnemyAttack";
        }
        return Tag;
    }

    //ダメージを与えた際の座標、量、ダメージタイプ、レイヤーの橋渡し系を短縮するメソッド
    //変数　１ダメージを与える相手の情報　２ダメージ量　３ダメージを与えた際の座標　４自身のレイヤー
    public void BasicBridgingDamage(Collider2D collision , float damage , Vector3 position , int layer) {
        var CauseDamagePosition = collision.gameObject.GetComponentInParent<DamagePosition>();
        var CauseDamageValue = collision.gameObject.GetComponentInParent<DamageValue>();
        var CauseDamageType = collision.gameObject.GetComponentInParent<DamageType>();
        var CauseDamageLayer = collision.gameObject.GetComponentInParent<DamageLayer>();
        if (CauseDamagePosition != null) {
            CauseDamagePosition.Damage(position);
        }
        if (CauseDamageValue != null) {
            CauseDamageValue.Damage(damage);
        }
        if (CauseDamageType != null) {
            CauseDamageType.Damage("直接");
        }
        if (CauseDamageLayer != null) {
            CauseDamageLayer.Damage(layer);
        }
    }
}
