using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tips�����L�^���邽�߂̘g�g�݃N���X
//�����Œ�`���ꂽ�X�L�����ʃN���X�ŕۑ������B

public class TipsData : MonoBehaviour {
    private string TipsName;               //Tips��
    private string TipsText;               //Tips�̕���

    //�R���X�g���N�^�BTips�������ۂɍ쐬����ꍇ�Ɏg�p
    public TipsData(string Name, string Text) {
        this.TipsName = Name;
        this.TipsText = Text;
    }

    //���n���Q�b�^�[�ꗗ
    public string GetTipsName {
        get { return TipsName; }
    }
    public string GetTipsText {
        get { return TipsText; }
    }
}


