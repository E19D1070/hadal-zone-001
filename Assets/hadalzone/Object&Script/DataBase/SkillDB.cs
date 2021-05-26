using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//全てのスキル情報が記録されているデータベース的なクラス

public class SkillDB : MonoBehaviour
{
    //SkillDataをもとに作成するスキルのリスト
    public List<SkillData> SkillDataList = new List<SkillData>();
    private string SkillIconAddress = "DataBaseSkillIcon/";
    private string SkillObjectAddress = "DataBaseSkillObject/";

    //スキルの全情報を作成
    private void Awake() {
        SkillDataList.Add(new SkillData(Resources.Load(SkillIconAddress + "AirShotIcon", typeof(Sprite)) as Sprite,
                                        "空砲",
                                        "前方から直線に飛ぶ弾を発射する",
                                        10,
                                        new List<string>() {"鮭の皮"},
                                        new List<int>() {1},
                                        Resources.Load(SkillObjectAddress + "OrganAirShot", typeof(GameObject)) as GameObject
                                        )
                          );
        SkillDataList.Add(new SkillData(Resources.Load(SkillIconAddress + "AirShot3wayIcon", typeof(Sprite)) as Sprite,
                                        "空砲3way",
                                        "前方から3方向に弾を3発発射する",
                                        20,
                                        new List<string>() { "鮭の皮", "鮭の鰭" },
                                        new List<int>() {1,2},
                                        Resources.Load(SkillObjectAddress + "OrganAirShot", typeof(GameObject)) as GameObject
                                        )
                          );
        SkillDataList.Add(new SkillData(Resources.Load(SkillIconAddress + "AirShotHomingIcon", typeof(Sprite)) as Sprite,
                                        "空砲ホーミング",
                                        "前方から敵を追尾する弾を発射する",
                                        20,
                                        new List<string>() { "鮭の皮", "鮭の鰭" },
                                        new List<int>() { 2, 1 },
                                        Resources.Load(SkillObjectAddress + "OrganAirShot", typeof(GameObject)) as GameObject
                                        )
                          );
        SkillDataList.Add(new SkillData(Resources.Load(SkillIconAddress + "HPUP1Icon", typeof(Sprite)) as Sprite,
                                        "HPUP小",
                                        "自身の最大HPを20上昇させる",
                                        15,
                                        new List<string>(),
                                        new List<int>(),
                                        Resources.Load(SkillObjectAddress + "OrganAirShot", typeof(GameObject)) as GameObject
                                        )
                          );
        SkillDataList.Add(new SkillData(Resources.Load(SkillIconAddress + "OffensivePowerUP1Icon", typeof(Sprite)) as Sprite,
                                        "攻撃力UP小",
                                        "自身の最大攻撃力を1上昇させる",
                                        15,
                                        new List<string>(),
                                        new List<int>(),
                                        Resources.Load(SkillObjectAddress + "OrganAirShot", typeof(GameObject)) as GameObject
                                        )
                          );
    }

    //全スキルデータを渡す
    public List<SkillData> GetSkillDataList {
        get { return SkillDataList; }
    }

    //個々のスキルデータを渡す
    public SkillData GetSkillData(string SkillName) {
        foreach (SkillData Skill in SkillDataList) {
            if (Skill.GetSkillName == SkillName) {
                return Skill;
            }
        }
        return null;
    }
}
