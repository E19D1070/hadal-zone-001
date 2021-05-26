using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���j���[���\�����ꂽ�ۂɌ��ݏ������Ă���A�r�X�̐����X�V���鏈��

public class AbyssCountDisplay : MonoBehaviour
{
    [SerializeField] private GameObject ItemBoxObject;
    [SerializeField] private GameObject AbyssCountObject;

    private PlayerItemBox ItemBox;
    private Text AbyssCount;

    private bool init = true;

    private void OnEnable() {
        if (init == true) {
            ItemBox = ItemBoxObject.GetComponent<PlayerItemBox>();
            AbyssCount = AbyssCountObject.GetComponent<Text>();
            init = false;
        }
        AbyssCount.text = ItemBox.GetPlayerItem("�A�r�X").SetGetPlayerItemCount.ToString();
    }
}
