using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの所持物を管理するクラス

public class PlayerItemBox : MonoBehaviour,BridgeItemName
{
    [SerializeField] GameObject ItemDB;
    private ItemDB itemdb;

    private bool DataExistance = false;  //取得したアイテムがボックス内に一つでも入っているかの判定用

    public List<PlayerItemManager> ItemManagerList = new List<PlayerItemManager>();

    private void Start() {
        itemdb = ItemDB.GetComponent<ItemDB>();
        ItemManagerList.Add(new PlayerItemManager("アビス",40));  //アビスだけは最初に用意しておく
    }

    void BridgeItemName.Item(string Item) {
        DataExistance = false;
        foreach (PlayerItemManager itemManager in ItemManagerList) {  //アイテムボックスを全探索して、既に所持しているのであれば所持数を増やす
            if (itemManager.GetPlayerItemName == Item) {
                itemManager.SetGetPlayerItemCount++;
                DataExistance = true;
                break;
            }
        }
        if (DataExistance == false) {  //全探索した結果、該当アイテムを一つも所持していなければ新しくボックスアイテムを増やす
            ItemManagerList.Add(new PlayerItemManager(Item, 1));
        }
        foreach (PlayerItemManager playerItemManager in ItemManagerList) {
            Debug.Log(playerItemManager.GetPlayerItemName);
            Debug.Log(playerItemManager.SetGetPlayerItemCount);
        }
    }

    //全所持アイテムデータを渡す
    public List<PlayerItemManager> GetPlayerItemList {
        get { return ItemManagerList; }
    }

    //個々の所持アイテムデータを渡す
    public PlayerItemManager GetPlayerItem(string ItemName) {
        foreach (PlayerItemManager Item in ItemManagerList) {
            if (Item.GetPlayerItemName == ItemName) {
                return Item;
            }
        }
        PlayerItemManager NullItemManager = new PlayerItemManager(null,-1);//アイテムが存在しない場合、Nullを返すのだが、アイテムが存在してもItemだけをReturnするとNullが返るため
        return NullItemManager;                                            //状況によってはNullしか返らない場合がある。それでは意味が無いので、Null用の変数を作成して返している。
    }
}
