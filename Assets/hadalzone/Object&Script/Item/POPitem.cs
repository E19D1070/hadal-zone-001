using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//アイテムが実際にポップした時の処理
//アイテムの取得、アニメーション処理等を行う。

public class POPitem : MonoBehaviour
{
    [SerializeField] private GameObject ParticleEffect;
    [SerializeField] private GameObject GetItemText;
    [SerializeField] private GameObject Appearance1;
    [SerializeField] private GameObject Appearance2;
    [SerializeField] private string ThisItemName;

    private List<SpriteRenderer> spriterend = new List<SpriteRenderer>();

    private Rigidbody2D ItemRigidbody2D;

    void Start()
    {
        ItemRigidbody2D = this.GetComponent<Rigidbody2D>();
        spriterend.Add(this.GetComponent<SpriteRenderer>());
        if (Appearance1 != null && Appearance2 != null) {
            spriterend.Add(Appearance1.GetComponent<SpriteRenderer>());
            spriterend.Add(Appearance2.GetComponent<SpriteRenderer>());
        }
    }

    private float a = 0.4f;
    private void Update() {//アイテムの減衰処理
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }

        if (ItemRigidbody2D.velocity.x < 0) {
            ItemRigidbody2D.AddForce(Vector2.right * a);
        }
        if (ItemRigidbody2D.velocity.x > 0) {
            ItemRigidbody2D.AddForce(Vector2.left * a);
        }
        if (ItemRigidbody2D.velocity.y < 0) {
            ItemRigidbody2D.AddForce(Vector2.up * a);
        }
        if (ItemRigidbody2D.velocity.y > 0) {
            ItemRigidbody2D.AddForce(Vector2.down * a);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        var PlayerItem = collision.gameObject.GetComponent<BridgeItemName>();  //衝突物の橋渡しコンポーネント取得している
        if (PlayerItem != null) {
            PlayerItem.Item(ThisItemName);  //自身のアイテム名を受け渡して、その後触れられないオブジェクトにレイヤー（と一応タグも）を変更する
            this.gameObject.layer = 8;
            this.gameObject.tag = "ReferenceObject";

            if (ThisItemName != "アビス") {//アビス習得時は｛｝内のエフェクトは行わない
                foreach (SpriteRenderer renderer in spriterend) {  //Playerに触れたら透明度を徐々に０にする(付属のAppearanceも透明にしなければいけないのでForEachで回している)。
                    DOTween.ToAlpha(
                        () => renderer.color,
                        x => renderer.color = x,
                        0f,
                        1f
                    );
                }
                transform.DOMoveY(transform.position.y+0.4f,2f);  //Playerに触れたら上昇する。

                GetItemText.GetComponentInChildren<Text>().text = ThisItemName;  //Playerに触れたらアイテム名を表示する
                GameObject GITclone = Instantiate(GetItemText, transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
                Destroy(GITclone, 3f);
            }
            else {//アビスの場合パーティクルが終了し、自身がDestroyされるまで非アクティブにしておく
                this.gameObject.SetActive(false);
            }

            GameObject PEobject  = Instantiate(ParticleEffect,transform.position,transform.rotation);  //パーティクルを発生
            Destroy(PEobject, 2f);
            Destroy(this.gameObject,1.5f);
        }
    }
}
