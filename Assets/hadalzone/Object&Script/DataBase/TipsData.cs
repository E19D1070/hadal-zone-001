using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tips情報を記録するための枠組みクラス
//ここで定義されたスキルが別クラスで保存される。

public class TipsData : MonoBehaviour {
    private string TipsName;               //Tips名
    private string TipsText;               //Tipsの文章

    //コンストラクタ。Tips情報を実際に作成する場合に使用
    public TipsData(string Name, string Text) {
        this.TipsName = Name;
        this.TipsText = Text;
    }

    //橋渡しゲッター一覧
    public string GetTipsName {
        get { return TipsName; }
    }
    public string GetTipsText {
        get { return TipsText; }
    }
}


