using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�S�ẴX�L����񂪋L�^����Ă���f�[�^�x�[�X�I�ȃN���X

public class SkillDB : MonoBehaviour
{
    //SkillData�����Ƃɍ쐬����X�L���̃��X�g
    public List<SkillData> SkillDataList = new List<SkillData>();
    private string SkillIconAddress = "DataBaseSkillIcon/";
    private string SkillObjectAddress = "DataBaseSkillObject/";

    //�X�L���̑S�����쐬
    private void Awake() {
        SkillDataList.Add(new SkillData(Resources.Load(SkillIconAddress + "AirShotIcon", typeof(Sprite)) as Sprite,
                                        "��C",
                                        "�O�����璼���ɔ�Ԓe�𔭎˂���",
                                        10,
                                        new List<string>() {"���̔�"},
                                        new List<int>() {1},
                                        Resources.Load(SkillObjectAddress + "OrganAirShot", typeof(GameObject)) as GameObject
                                        )
                          );
        SkillDataList.Add(new SkillData(Resources.Load(SkillIconAddress + "AirShot3wayIcon", typeof(Sprite)) as Sprite,
                                        "��C3way",
                                        "�O������3�����ɒe��3�����˂���",
                                        20,
                                        new List<string>() { "���̔�", "���̕h" },
                                        new List<int>() {1,2},
                                        Resources.Load(SkillObjectAddress + "OrganAirShot", typeof(GameObject)) as GameObject
                                        )
                          );
        SkillDataList.Add(new SkillData(Resources.Load(SkillIconAddress + "AirShotHomingIcon", typeof(Sprite)) as Sprite,
                                        "��C�z�[�~���O",
                                        "�O������G��ǔ�����e�𔭎˂���",
                                        20,
                                        new List<string>() { "���̔�", "���̕h" },
                                        new List<int>() { 2, 1 },
                                        Resources.Load(SkillObjectAddress + "OrganAirShot", typeof(GameObject)) as GameObject
                                        )
                          );
        SkillDataList.Add(new SkillData(Resources.Load(SkillIconAddress + "HPUP1Icon", typeof(Sprite)) as Sprite,
                                        "HPUP��",
                                        "���g�̍ő�HP��20�㏸������",
                                        15,
                                        new List<string>(),
                                        new List<int>(),
                                        Resources.Load(SkillObjectAddress + "OrganAirShot", typeof(GameObject)) as GameObject
                                        )
                          );
        SkillDataList.Add(new SkillData(Resources.Load(SkillIconAddress + "OffensivePowerUP1Icon", typeof(Sprite)) as Sprite,
                                        "�U����UP��",
                                        "���g�̍ő�U���͂�1�㏸������",
                                        15,
                                        new List<string>(),
                                        new List<int>(),
                                        Resources.Load(SkillObjectAddress + "OrganAirShot", typeof(GameObject)) as GameObject
                                        )
                          );
    }

    //�S�X�L���f�[�^��n��
    public List<SkillData> GetSkillDataList {
        get { return SkillDataList; }
    }

    //�X�̃X�L���f�[�^��n��
    public SkillData GetSkillData(string SkillName) {
        foreach (SkillData Skill in SkillDataList) {
            if (Skill.GetSkillName == SkillName) {
                return Skill;
            }
        }
        return null;
    }
}
