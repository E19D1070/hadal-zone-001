using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�S�Ă�Tips��񂪋L�^����Ă���f�[�^�x�[�X�I�ȃN���X

public class TipsDB : MonoBehaviour {
    //TipsData�����Ƃɍ쐬����Tips�̃��X�g
    public List<TipsData> TipsDataList = new List<TipsData>();

    //�X�L���̑S�����쐬
    private void Awake() {
        TipsDataList.Add(new TipsData("�U�����@",
                                      "�����U��������@�͓��ނ���܂��B��͋��ɒ��ڋ߂Â��čs���ߐH�B������͒T���ɂ���ďC�������X�L���ɂ��U�����������܂��B�T����[�߂�Α��ʂȃX�L�����C�����邱�Ƃ��o����悤�ɂȂ�܂��B"
                                      )
                         );
        TipsDataList.Add(new TipsData("�T��",
                                      "�[�C��ڎw���A�^���ւƓ��B���邽�߂ɒT���͕s���ȗv�f�ł��B�T�����s�����ƂŁA�[���C�̋��Ђ���g�����p�ł���X�L�����C���ł��܂��B�T���ɕK�v�ȑf�ނƃA�r�X���W�ߐ^����[�߂܂��傤�B"
                                      )
                         );
        TipsDataList.Add(new TipsData("�A�i�O��",
                                      "�C�̒�ւƂ��ǂ蒅���̂��{���ł����A���ɂ͍��E�̐�ǂ��m�F���Ă݂�̂������ł��傤�B�܂�ɐ�ǂɑ��݂��鏬���Ȍ��͐[�C���l���m�̐��E�B�ς�����T�����o����悤�ɂȂ邩������܂���B"
                                      )
                         );

    }

    //�S�X�L���f�[�^��n��
    public List<TipsData> GetTipsDataList {
        get { return TipsDataList; }
    }

    //�X�̃X�L���f�[�^��n��
    public TipsData GetTipsData(string TipsName) {
        foreach (TipsData Tips in TipsDataList) {
            if (Tips.GetTipsName == TipsName) {
                return Tips;
            }
        }
        return null;
    }
}
