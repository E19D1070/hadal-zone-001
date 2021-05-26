using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�S�Ă̐�����񂪋L�^����Ă���f�[�^�x�[�X�I�ȃN���X

public class SeaCreatureDB : MonoBehaviour
{
    //SeaCreatureData�����ɍ쐬���鐶���̃��X�g�B
    public List<SeaCreatureData> SCdataList = new List<SeaCreatureData>();

    //�����̑S�����쐬
    private void Awake() {
        SCdataList.Add(new SeaCreatureData(Resources.Load("��", typeof(Sprite)) as Sprite,
                                           "��",
                                           "���̋����킩��Ȃ��B\n��芸�������B",
                                           new List<string>() {"AirShot","AirShot3way","AirShotHoming","HPUP1","OffensivePowerUP1"})
        );
        SCdataList.Add(new SeaCreatureData(Resources.Load("��", typeof(Sprite)) as Sprite,
                                           "��",
                                           "���������������B���낻��A�����鎞�������܂��A��Ȃ��͗l�B\n�T�[�����ł͖����̂ł���������M���ĐH�ׂ܂��傤�B",
                                           new List<string>() { "AirShot", "AirShot3way", "AirShotHoming", "HPUP1", "HPUP2" })
        );
    }

    //�S�����f�[�^��n��
    public List<SeaCreatureData> GetSeaCreatureDataList {
        get { return SCdataList; }
    }

    //�X�̐����f�[�^��n��
    public SeaCreatureData GetSeaCreatureData(string CreatureName) {
        foreach (SeaCreatureData Creature in SCdataList) {
            if (Creature.GetCreatureName == CreatureName) {
                return Creature;
            }
        }
        return null;
    }
}
