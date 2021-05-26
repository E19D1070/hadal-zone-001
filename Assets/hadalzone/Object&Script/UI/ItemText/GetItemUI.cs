using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//アイテムを取得した際に取得したアイテム名を表示する処理

public class GetItemUI : MonoBehaviour {
    private Text GetItemText;
    private float FadeSpeed = 4f;
    private float waitcount = 0;
    private float waittime = 1f;
    void Start() {
        GetItemText = GetComponentInChildren<Text>();
    }

    void Update() {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        waitcount += Time.deltaTime;
        if (waitcount >= waittime) {
            GetItemText.color = Color.Lerp(GetItemText.color, new Color(1f, 1f, 1f, 0f), FadeSpeed * Time.deltaTime);
        }

    }
}
