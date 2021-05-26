using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//サブメニューでのスキル等の情報の詳細が表示されている時画面をクリックすると詳細が閉じるクラス
//RayCastTargetのオンオフを意識しなければうまく作動しないので注意

public class CloseDetails : MonoBehaviour {

    [SerializeField] GameObject Details;
    void Update() {
        //RayCastTargetが有効な部分だけTrueになる模様（詳しくは知らんけど）。
        //Trueを返すとここで処理を終了する
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        //GetMouseButtonDown(0)で画面全てがクリック判定になっている。
        if (Input.GetMouseButtonDown(0)) {
            if (Details.activeSelf == true) {
                Details.SetActive(false);
            }
        }
    }
}