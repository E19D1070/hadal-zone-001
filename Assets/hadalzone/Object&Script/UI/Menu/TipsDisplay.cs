using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���j���[��ʂ��J�����т�Tips���X�V����鏈��

public class TipsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject Tipsdb;
    [SerializeField] private GameObject TipsNameObject;
    [SerializeField] private GameObject TipsTextObject;

    private TipsDB TipsDB;
    private Text TipsName;
    private Text TipsText;

    bool init = true;

    private void OnEnable() {
        if (init == true) {                               //�ŏ������f�[�^������Ă��Ăق����BStart�ł���Ƃ��̃I�u�W�F�N�g����A�N�e�B�u��ԂŃX�^�[�g���邽��NullExeption���o��
            TipsDB = Tipsdb.GetComponent<TipsDB>();
            TipsName = TipsNameObject.GetComponent<Text>();
            TipsText = TipsTextObject.GetComponent<Text>();
            init = false;
        }
        List<TipsData> TipsData = TipsDB.GetTipsDataList;
        int RandomTips = (int)Random.Range(0,TipsData.Count);
        TipsName.text = "Tips: " + TipsData[RandomTips].GetTipsName;
        TipsText.text = TipsData[RandomTips].GetTipsText;
    }

}
