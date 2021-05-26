using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スキル情報を記録するための枠組みクラス
//ここで定義されたスキルが別クラスで保存される。

public class SkillData : MonoBehaviour
{
    private Sprite SkillIcon;               //スキルのアイコン画像
    private string SkillName;               //スキルの名前
    private string SkillInfo;               //スキルの解説
    private int SkillValue;                 //スキル修得に必要なイクラの数
    private List<string> SkillMaterial;     //スキル修得に必要な素材
    private List<int> SkillMaterialAmount;  //スキル修得に必要な素材の数SkillMaterialに合わせた添え字にする必要がある
    private GameObject SkillObject;         //実際にスキル修得した際にPlayerに追加されるオブジェクト

    //コンストラクタ。スキル情報を実際に作成する場合に使用
    public SkillData(Sprite Icon , string Name , string Info , int Value , List<string> Material , List<int> MaterialAmount , GameObject Object) {
        this.SkillIcon = Icon;
        this.SkillName = Name;
        this.SkillInfo = Info;
        this.SkillValue = Value;
        this.SkillMaterial = Material;
        this.SkillMaterialAmount = MaterialAmount;
        this.SkillObject = Object;
    }

    //橋渡しゲッター一覧
    public Sprite GetSkillIcon {
        get { return SkillIcon; }
    }
    public string GetSkillName {
        get { return SkillName; }
    }
    public string GetSkillInfo {
        get { return SkillInfo; }
    }
    public int GetSkillValue {
        get { return SkillValue; }
    }
    public List<string> GetSkillMaterial {
        get { return SkillMaterial; }
    }
    public List<int> GetSkillMaterialAmount {
        get { return SkillMaterialAmount; }
    }
    public GameObject GetSkillObject {
        get { return SkillObject; }
    }
}


