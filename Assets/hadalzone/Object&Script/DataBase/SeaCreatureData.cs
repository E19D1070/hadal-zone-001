using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//生物情報を記録するための枠組みクラス
//ここで定義された情報が別クラスで保存される。

public class SeaCreatureData : MonoBehaviour
{
    private Sprite CreatureImage;        //生物の画像
    private string CreatureName;         //生物の名前
    private string CreatureInfo;         //生物の情報（図鑑に書くようなこと）
    private List<string> CreatureSkill;  //生物のスキル
    //後々にドロップするイクラの数とアイテムもいるようになるかも

    //コンストラクタ。生物情報を実際に作成する場合に使用
    public SeaCreatureData(Sprite Image , string Name , string Info , List<string> Skill) {
        this.CreatureImage = Image;
        this.CreatureName = Name;
        this.CreatureInfo = Info;
        this.CreatureSkill = Skill;
    }

    //値渡しのゲッター一覧
    public Sprite GetCreatureImage {
        get { return CreatureImage; }
    }
    public string GetCreatureName {
        get { return CreatureName; }
    }
    public string GetCreatureInfo {
        get { return CreatureInfo; }
    }
    public List<string> GetCreatureSkill {
        get { return CreatureSkill; }
    }
}
