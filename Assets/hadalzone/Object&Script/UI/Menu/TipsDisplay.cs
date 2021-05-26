using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//メニュー画面が開くたびにTipsが更新される処理

public class TipsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject Tipsdb;
    [SerializeField] private GameObject TipsNameObject;
    [SerializeField] private GameObject TipsTextObject;

    private TipsDB TipsDB;
    private Text TipsName;
    private Text TipsText;

    bool init = true;

    private void OnEnable() {
        if (init == true) {                               //最初だけデータを取ってきてほしい。Startでするとこのオブジェクトが非アクティブ状態でスタートするためNullExeptionが出る
            TipsDB = Tipsdb.GetComponent<TipsDB>();
            TipsName = TipsNameObject.GetComponent<Text>();
            TipsText = TipsTextObject.GetComponent<Text>();
            init = false;
        }
        List<TipsData> TipsData = TipsDB.GetTipsDataList;
        int RandomTips = (int)Random.Range(0,TipsData.Count);
        TipsName.text = "Tips: " + TipsData[RandomTips].GetTipsName;
        TipsText.text = TipsData[RandomTips].GetTipsText;
    }

}
