using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//プレイヤーがダメージを受けるとHPバーが（白色、一瞬で減る　濃い灰色、徐々に減る　薄い灰色、減らない）減少する処理。

public class HPManager : MonoBehaviour {

    [SerializeField] Image CurrentHP;
    [SerializeField] Image CauseHP;
    [SerializeField] GameObject player;

    private PlayerManager Player;
    private Tween CauseHPtween;

    public void Awake() {
        Player = player.GetComponent<PlayerManager>();
    }

    public void CauseHPGauge(float DamageValue, float time = 4f) {
        float BeforHP = ((float)Player.hp+DamageValue) / (float)Player.maxhp;
        float Damage = (float)Player.hp / (float)Player.maxhp;
        CurrentHP.fillAmount = Damage;

        if (CauseHPtween != null) {
            CauseHPtween.Kill();
        }

        CauseHPtween = DOTween.To(
            () => BeforHP,
            x => { CauseHP.fillAmount = x; },
            Damage,
            time
        );
    }
}
