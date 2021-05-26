using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�S�ẴA�C�e����񂪋L�^����Ă���f�[�^�x�[�X�I�ȃN���X

public class ItemDB : MonoBehaviour {
    //ItemData�����Ƃɍ쐬����X�L���̃��X�g
    public List<ItemData> ItemDataList = new List<ItemData>();
    private string ItemAddress = "DataBaseItem/";

    //�A�C�e���̑S�����쐬
    private void Awake() {
        ItemDataList.Add(new ItemData(Resources.Load(ItemAddress + "Abyss", typeof(Sprite)) as Sprite,
                                      "�A�r�X",
                                      "�[����`���A�[���𗝉�����ۂɌx�������Ă����˂΂Ȃ�Ȃ�\n�[�����܂��������`���Ă��邩��ł���"
                                      )
                         );
        ItemDataList.Add(new ItemData(Resources.Load(ItemAddress + "SalmonHide", typeof(Sprite)) as Sprite,
                                      "���̔�",
                                      "���̔�͉h�{���_�I�I\n�H�ׂ��������̐F�X�ȉh�{�f��30��UP�̃o�t�������邼�B\n�H�ׂĂ���A�A�A"
                                      )
                         );
        ItemDataList.Add(new ItemData(Resources.Load(ItemAddress + "SalmonFin", typeof(Sprite)) as Sprite,
                                      "���̕h",
                                      "���т�Ɣw�т�̊Ԃ̃q�������т�ƌ����܂��B\n�j���ɉe��������ƌ����Ă��܂����ڂ������Ƃ͕�����Ȃ������ł��B\n����𐅑��قŕ������Đ싛�R�[�i�[�ŃC�L�낤"
                                      )
                         );
    }

    //�S�X�L���f�[�^��n��
    public List<ItemData> GetItemDataList {
        get { return ItemDataList; }
    }

    //�X�̃X�L���f�[�^��n��
    public ItemData GetItemData(string ItemName) {
        foreach (ItemData Item in ItemDataList) {
            if (Item.GetItemName == ItemName) {
                return Item;
            }
        }
        return null;
    }
}

