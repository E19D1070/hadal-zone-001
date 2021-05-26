using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

//AirShotを打つためのクラス

public class OrganAirShot : MonoBehaviour
{
    Skill skill = new Skill();
    SeaCreature Status;        //親のSeaCreatureにアクセスして基本ステータスを取る

    void Start()
    {
        Status = this.gameObject.GetComponentInParent<SeaCreature>();
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        // 弾の発射タイミングを管理するタイマーを更新する
        skill.airShotCoolTimeCount += Time.deltaTime;
        if (skill.airShotCoolTimeCount > skill.airShotIntervalTime * Status.offensiveSpeed) {
            if (Input.GetMouseButton(0)) {
                // 弾を発射する
                skill.airShot(Status.offensivePower, Status.offensiveRange, Status.creaturetype, Status.myangle.z + 90, Status.mymouthposition , Status.myrotation);
            }
        }
    }
}
