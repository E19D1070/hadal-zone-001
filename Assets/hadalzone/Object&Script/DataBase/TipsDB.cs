using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//全てのTips情報が記録されているデータベース的なクラス

public class TipsDB : MonoBehaviour {
    //TipsDataをもとに作成するTipsのリスト
    public List<TipsData> TipsDataList = new List<TipsData>();

    //スキルの全情報を作成
    private void Awake() {
        TipsDataList.Add(new TipsData("攻撃方法",
                                      "魚を攻撃する方法は二種類あります。一つは魚に直接近づいて行う捕食。もう一つは探求によって修得したスキルによる攻撃があげられます。探求を深めれば多彩なスキルを修得することが出来るようになります。"
                                      )
                         );
        TipsDataList.Add(new TipsData("探求",
                                      "深海を目指し、真理へと到達するために探求は不可欠な要素です。探求を行うことで、深い海の脅威から身を守る術であるスキルを修得できます。探求に必要な素材とアビスを集め真理を深めましょう。"
                                      )
                         );
        TipsDataList.Add(new TipsData("アナグラ",
                                      "海の底へとたどり着くのが本懐ですが、時には左右の絶壁を確認してみるのもいいでしょう。まれに絶壁に存在する小さな穴は深海同様未知の世界。変わった探求が出来るようになるかもしれません。"
                                      )
                         );

    }

    //全スキルデータを渡す
    public List<TipsData> GetTipsDataList {
        get { return TipsDataList; }
    }

    //個々のスキルデータを渡す
    public TipsData GetTipsData(string TipsName) {
        foreach (TipsData Tips in TipsDataList) {
            if (Tips.GetTipsName == TipsName) {
                return Tips;
            }
        }
        return null;
    }
}
