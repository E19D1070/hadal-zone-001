using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player���ۗL���Ă���A�C�e�������L�^���邽�߂̘g�g�݃N���X
//�����Œ�`���ꂽ�g�g�݂��ʃN���X��List�ۑ������B

public class PlayerItemManager : MonoBehaviour {
    private string PlayerItemName;  //�A�C�e���̖��O
    private int PlayerItemCount;    //���g�̃A�C�e���ۗ̕L��

    public PlayerItemManager(string ItemName , int ItemCount) {
        this.PlayerItemName = ItemName;
        this.PlayerItemCount = ItemCount;
    }

    public string GetPlayerItemName {
        get { return PlayerItemName; }
    }
    public int SetGetPlayerItemCount {
        set { PlayerItemCount = value; }
        get { return PlayerItemCount; }
    }
}
