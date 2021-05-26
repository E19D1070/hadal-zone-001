using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//視覚範囲に入っているか、出ているかを検知し、専用の変数にBoolで返すクラス
//範囲内でオブジェクトが消滅してしまうと範囲外にもかかわらず範囲内と判定されてしまうので、それを回避するために少々ややこしくなっている

public class VisibleArea : MonoBehaviour
{
    int PlayerStayCount = 0;        //Playerの消滅対応用
    int PlayerStayMatchCount = 0;   //Playerの消滅対応用
    float PlayerStayTimeCount = 0;  //Playerの消滅対応用
    int PlayerAttackStayCount = 0;        //Playerの攻撃の消滅対応用
    int PlayerAttackStayMatchCount = 0;   //Playerの攻撃の消滅対応用
    float PlayerAttackStayTimeCount = 0;  //Playerの攻撃の消滅対応用

    Enemy enemy;

    void Start() {
        enemy = gameObject.GetComponentInParent<Enemy>();
    }

    private void Update() {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        //OnTriggerStay2Dを利用した、範囲内でオブジェクトが消滅しても範囲外を出力してくれる処理
        //Stay2Dで数字をカウントさせることで、消滅した瞬間にカウントがストップするため一定時間カウントの値が同じならば消滅と判断し、Falseを返している
        if (enemy.playerVisibleSpace == true) {
            if (PlayerStayMatchCount == PlayerStayCount) {
                PlayerStayTimeCount += Time.deltaTime;
                if (PlayerStayTimeCount >= 0.1f) {
                    enemy.playerVisibleSpace = false;
                    PlayerStayTimeCount = 0;
                    PlayerStayCount = 0;
                }
            }
            else {
                PlayerStayTimeCount = 0;
            }
            PlayerStayMatchCount = PlayerStayCount;
        }

        //Playerの攻撃の消滅対応処理
        if (enemy.playerAttackVisibleSpace == true) {
            if (PlayerAttackStayMatchCount == PlayerAttackStayCount) {
                PlayerAttackStayTimeCount += Time.deltaTime;
                if (PlayerAttackStayTimeCount >= 0.1f) {
                    enemy.playerAttackVisibleSpace = false;
                    PlayerAttackStayTimeCount = 0;
                    PlayerAttackStayCount = 0;
                }
            }
            else {
                PlayerAttackStayTimeCount = 0;
            }
            PlayerAttackStayMatchCount = PlayerAttackStayCount;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            enemy.playerVisibleSpace = true;
        }
        if (collision.gameObject.tag == "PlayerAttack") {
            enemy.playerAttackVisibleSpace = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerStayCount++;
        }
        if (collision.gameObject.tag == "PlayerAttack") {
            PlayerAttackStayCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            enemy.playerVisibleSpace = false;
            PlayerStayTimeCount = 0;
            PlayerStayCount = 0;
        }
        if (collision.gameObject.tag == "PlayerAttack") {
            enemy.playerAttackVisibleSpace = false;
            PlayerAttackStayTimeCount = 0;
            PlayerAttackStayCount = 0;
        }
    }
}
