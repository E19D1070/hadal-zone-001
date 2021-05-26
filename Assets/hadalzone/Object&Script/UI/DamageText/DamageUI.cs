using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ダメージの数値を表示する処理

public class DamageUI : MonoBehaviour
{
    private Text DamageText;
    private float FadeSpeed = 4f;
    private float MoveSpeed = 1f;
    private float waitcount = 0;
    private float waittime = 1f;
    void Start()
    {
        DamageText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        waitcount += Time.deltaTime;
        transform.position += Vector3.up * MoveSpeed * Time.deltaTime;
        if (waitcount >= waittime) {
            DamageText.color = Color.Lerp(DamageText.color, new Color(1f, 1f, 1f, 0f), FadeSpeed * Time.deltaTime);
        }

    }
}
