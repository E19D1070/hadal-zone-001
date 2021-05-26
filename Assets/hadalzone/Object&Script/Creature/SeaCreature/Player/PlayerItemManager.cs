using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Playerが保有しているアイテム情報を記録するための枠組みクラス
//ここで定義された枠組みが別クラスでList保存される。

public class PlayerItemManager : MonoBehaviour {
    private string PlayerItemName;  //アイテムの名前
    private int PlayerItemCount;    //自身のアイテムの保有数

    public PlayerItemManager(string ItemName , int ItemCount) {
        this.PlayerItemName = ItemName;
        this.PlayerItemCount = ItemCount;
    }

    public string GetPlayerItemName {
        get { return PlayerItemName; }
    }
    public int SetGetPlayerItemCount {
        set { PlayerItemCount = value; }
        get { return PlayerItemCount; }
    }
}
