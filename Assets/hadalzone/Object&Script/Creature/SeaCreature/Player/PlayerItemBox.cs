using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�̏��������Ǘ�����N���X

public class PlayerItemBox : MonoBehaviour,BridgeItemName
{
    [SerializeField] GameObject ItemDB;
    private ItemDB itemdb;

    private bool DataExistance = false;  //�擾�����A�C�e�����{�b�N�X���Ɉ�ł������Ă��邩�̔���p

    public List<PlayerItemManager> ItemManagerList = new List<PlayerItemManager>();

    private void Start() {
        itemdb = ItemDB.GetComponent<ItemDB>();
        ItemManagerList.Add(new PlayerItemManager("�A�r�X",40));  //�A�r�X�����͍ŏ��ɗp�ӂ��Ă���
    }

    void BridgeItemName.Item(string Item) {
        DataExistance = false;
        foreach (PlayerItemManager itemManager in ItemManagerList) {  //�A�C�e���{�b�N�X��S�T�����āA���ɏ������Ă���̂ł���Ώ������𑝂₷
            if (itemManager.GetPlayerItemName == Item) {
                itemManager.SetGetPlayerItemCount++;
                DataExistance = true;
                break;
            }
        }
        if (DataExistance == false) {  //�S�T���������ʁA�Y���A�C�e��������������Ă��Ȃ���ΐV�����{�b�N�X�A�C�e���𑝂₷
            ItemManagerList.Add(new PlayerItemManager(Item, 1));
        }
        foreach (PlayerItemManager playerItemManager in ItemManagerList) {
            Debug.Log(playerItemManager.GetPlayerItemName);
            Debug.Log(playerItemManager.SetGetPlayerItemCount);
        }
    }

    //�S�����A�C�e���f�[�^��n��
    public List<PlayerItemManager> GetPlayerItemList {
        get { return ItemManagerList; }
    }

    //�X�̏����A�C�e���f�[�^��n��
    public PlayerItemManager GetPlayerItem(string ItemName) {
        foreach (PlayerItemManager Item in ItemManagerList) {
            if (Item.GetPlayerItemName == ItemName) {
                return Item;
            }
        }
        PlayerItemManager NullItemManager = new PlayerItemManager(null,-1);//�A�C�e�������݂��Ȃ��ꍇ�ANull��Ԃ��̂����A�A�C�e�������݂��Ă�Item������Return�����Null���Ԃ邽��
        return NullItemManager;                                            //�󋵂ɂ���Ă�Null�����Ԃ�Ȃ��ꍇ������B����ł͈Ӗ��������̂ŁANull�p�̕ϐ����쐬���ĕԂ��Ă���B
    }
}
