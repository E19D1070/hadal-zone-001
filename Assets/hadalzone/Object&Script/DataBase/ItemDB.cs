using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//全てのアイテム情報が記録されているデータベース的なクラス

public class ItemDB : MonoBehaviour {
    //ItemDataをもとに作成するスキルのリスト
    public List<ItemData> ItemDataList = new List<ItemData>();
    private string ItemAddress = "DataBaseItem/";

    //アイテムの全情報を作成
    private void Awake() {
        ItemDataList.Add(new ItemData(Resources.Load(ItemAddress + "Abyss", typeof(Sprite)) as Sprite,
                                      "アビス",
                                      "深淵を覗き、深淵を理解する際に警戒をしておかねばならない\n深淵もまたこちらを覗いているからである"
                                      )
                         );
        ItemDataList.Add(new ItemData(Resources.Load(ItemAddress + "SalmonHide", typeof(Sprite)) as Sprite,
                                      "鮭の皮",
                                      "鮭の皮は栄養満点！！\n食べた方が鮭の色々な栄養素量30％UPのバフが得られるぞ。\n食べてくれ、、、"
                                      )
                         );
        ItemDataList.Add(new ItemData(Resources.Load(ItemAddress + "SalmonFin", typeof(Sprite)) as Sprite,
                                      "鮭の鰭",
                                      "尾びれと背びれの間のヒレを脂びれと言います。\n泳ぎに影響があると言われていますが詳しいことは分からないそうです。\nこれを水族館で復唱して川魚コーナーでイキろう"
                                      )
                         );
    }

    //全スキルデータを渡す
    public List<ItemData> GetItemDataList {
        get { return ItemDataList; }
    }

    //個々のスキルデータを渡す
    public ItemData GetItemData(string ItemName) {
        foreach (ItemData Item in ItemDataList) {
            if (Item.GetItemName == ItemName) {
                return Item;
            }
        }
        return null;
    }
}

