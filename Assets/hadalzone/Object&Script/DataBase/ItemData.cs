using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテム情報を記録するための枠組みクラス
//ここで定義されたアイテムが別クラスで保存される。

public class ItemData : MonoBehaviour {
    private Sprite ItemIcon;               //アイテムのアイコン画像
    private string ItemName;               //アイテムの名前
    private string ItemInfo;               //アイテムの解説

    //コンストラクタ。アイテム情報を実際に作成する場合に使用
    public ItemData(Sprite Icon, string Name, string Info) {
        this.ItemIcon = Icon;
        this.ItemName = Name;
        this.ItemInfo = Info;
    }

    //橋渡しゲッター一覧
    public Sprite GetItemIcon {
        get { return ItemIcon; }
    }
    public string GetItemName {
        get { return ItemName; }
    }
    public string GetItemInfo {
        get { return ItemInfo; }
    }
}


