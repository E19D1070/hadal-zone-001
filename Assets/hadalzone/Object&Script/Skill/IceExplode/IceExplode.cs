using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スキルIceExplodeのオブジェクトにつけられるスクリプト

public class IceExplode : MonoBehaviour {
    [SerializeField] GameObject HitIceExplode;
    [SerializeField] SpriteRenderer IEspriteRenderer;
    [SerializeField] ParticleSystem IEparticleSystem;

    private Vector3 Velocity;
    public float Power;

    SkillConvenience Sconvenience = new SkillConvenience();

    private void Start() {
    }

    void Update() {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        //弾の移動
        transform.localPosition += Velocity;
        transform.Rotate(0,0,0.5f);
        if (this.gameObject.tag != "ReferenceObject") {
            transform.localScale += new Vector3(0.01f, 0.01f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != "EnemySense") {
            Sconvenience.BasicBridgingDamage(collision, Power * 1, transform.position, gameObject.layer);
            GameObject HIEclone = Instantiate(HitIceExplode, transform.position, transform.rotation) as GameObject;
            Destroy(HIEclone, 1.3f);
            Destroy(IEspriteRenderer);
            Destroy(this);
        }
    }

    public void Init(float angle, float speed, string Type) {
        //発射した存在のタイプによってレイヤーを変更する
        gameObject.layer = Sconvenience.LayerChange(Type);
        //発射した存在のタイプによってタグを変更する
        gameObject.tag = Sconvenience.TagChange(Type);

        //発射角度をベクトルに変換
        var direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
        //ベクトルと速さから速度を算出
        Velocity = direction * speed;

        //弾が進行方向を向く
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

    }
}
