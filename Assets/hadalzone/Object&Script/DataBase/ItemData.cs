using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�A�C�e�������L�^���邽�߂̘g�g�݃N���X
//�����Œ�`���ꂽ�A�C�e�����ʃN���X�ŕۑ������B

public class ItemData : MonoBehaviour {
    private Sprite ItemIcon;               //�A�C�e���̃A�C�R���摜
    private string ItemName;               //�A�C�e���̖��O
    private string ItemInfo;               //�A�C�e���̉��

    //�R���X�g���N�^�B�A�C�e���������ۂɍ쐬����ꍇ�Ɏg�p
    public ItemData(Sprite Icon, string Name, string Info) {
        this.ItemIcon = Icon;
        this.ItemName = Name;
        this.ItemInfo = Info;
    }

    //���n���Q�b�^�[�ꗗ
    public Sprite GetItemIcon {
        get { return ItemIcon; }
    }
    public string GetItemName {
        get { return ItemName; }
    }
    public string GetItemInfo {
        get { return ItemInfo; }
    }
}


