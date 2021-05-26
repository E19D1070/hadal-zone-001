using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���j���[���J����邽�тɎ��g�̃X�e�[�^�X���X�V���鏈��

public class StatusDisplay : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject TextObject;

    PlayerManager PlayerManager;
    Text Text;

    private bool init = true;

    private void OnEnable() {                               //�ŏ������f�[�^������Ă��Ăق����BStart�ł���Ƃ��̃I�u�W�F�N�g����A�N�e�B�u��ԂŃX�^�[�g���邽��NullExeption���o��
        if (true) {
            PlayerManager = Player.GetComponent<PlayerManager>();
            Text = TextObject.GetComponent<Text>();
            init = false;
        }
        Text.text = PlayerManager.maxhp + "\n" +
                    PlayerManager.offensivePower + "\n" +
                    PlayerManager.offensiveSpeed + "\n" +
                    PlayerManager.offensiveRange + "\n";
    }
}
