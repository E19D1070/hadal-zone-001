using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//全ての生物情報が記録されているデータベース的なクラス

public class SeaCreatureDB : MonoBehaviour
{
    //SeaCreatureDataを元に作成する生物のリスト。
    public List<SeaCreatureData> SCdataList = new List<SeaCreatureData>();

    //生物の全情報を作成
    private void Awake() {
        SCdataList.Add(new SeaCreatureData(Resources.Load("魚", typeof(Sprite)) as Sprite,
                                           "魚",
                                           "何の魚かわからない。\n取り敢えず魚。",
                                           new List<string>() {"AirShot","AirShot3way","AirShotHoming","HPUP1","OffensivePowerUP1"})
        );
        SCdataList.Add(new SeaCreatureData(Resources.Load("鮭", typeof(Sprite)) as Sprite,
                                           "鮭",
                                           "激流を下った鮭。そろそろ帰郷する時期だがまだ帰らない模様。\nサーモンでは無いのでしっかり加熱して食べましょう。",
                                           new List<string>() { "AirShot", "AirShot3way", "AirShotHoming", "HPUP1", "HPUP2" })
        );
    }

    //全生物データを渡す
    public List<SeaCreatureData> GetSeaCreatureDataList {
        get { return SCdataList; }
    }

    //個々の生物データを渡す
    public SeaCreatureData GetSeaCreatureData(string CreatureName) {
        foreach (SeaCreatureData Creature in SCdataList) {
            if (Creature.GetCreatureName == CreatureName) {
                return Creature;
            }
        }
        return null;
    }
}
