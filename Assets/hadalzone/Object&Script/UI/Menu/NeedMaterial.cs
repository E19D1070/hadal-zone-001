using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//スキル修得に必要な素材を表示するためのクラス

public class NeedMaterial : MonoBehaviour
{
    [SerializeField] private GameObject materialImage;      //素材の画像オブジェクト
    [SerializeField] private GameObject materialName;       //素材の名前オブジェクト
    [SerializeField] private GameObject materialNeedCount;  //素材の必要個数オブジェクト
    [SerializeField] private GameObject materialHaveCount;  //素材の所持個数オブジェクト

    private Image MaterialImage;
    private Text MaterialName;
    private Text MaterialNeedCount;
    private Text MaterialHaveCount;

    //コンストラクタ的な役割で作成。各々の項目にDBから当てはめる。詳しくは生成した時に。
    public void Initial(Sprite image , string name , string needCount , string haveCount) {
        MaterialImage = materialImage.GetComponent<Image>();
        MaterialName = materialName.GetComponent<Text>();
        MaterialNeedCount = materialNeedCount.GetComponent<Text>();
        MaterialHaveCount = materialHaveCount.GetComponent<Text>();
        MaterialImage.sprite = image;
        MaterialName.text = name;
        MaterialNeedCount.text = needCount;
        MaterialHaveCount.text = haveCount;
    }
}
