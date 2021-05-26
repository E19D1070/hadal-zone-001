using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//口元の当たり判定処理

public class Prey : MonoBehaviour {
    public Collider2D MouthCollider;
    public Vector3 MouthPosition;
    public bool MouthTouchingCore = false;

    private void Update() {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        MouthPosition = transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision) {//MouthがCoreに触れている間
        if (collision.gameObject.tag != "EnemySense") {
            MouthTouchingCore = true;
            MouthCollider = collision;
            var CauseDamagePosition = collision.gameObject.GetComponentInParent<DamagePosition>();
            if (CauseDamagePosition != null) {
                CauseDamagePosition.Damage(transform.position);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {//MouthがCoreから離れた時
        if (collision.gameObject.tag != "EnemySense") {
            MouthTouchingCore = false;
        }
    }
}
