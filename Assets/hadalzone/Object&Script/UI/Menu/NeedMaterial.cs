using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�X�L���C���ɕK�v�ȑf�ނ�\�����邽�߂̃N���X

public class NeedMaterial : MonoBehaviour
{
    [SerializeField] private GameObject materialImage;      //�f�ނ̉摜�I�u�W�F�N�g
    [SerializeField] private GameObject materialName;       //�f�ނ̖��O�I�u�W�F�N�g
    [SerializeField] private GameObject materialNeedCount;  //�f�ނ̕K�v���I�u�W�F�N�g
    [SerializeField] private GameObject materialHaveCount;  //�f�ނ̏������I�u�W�F�N�g

    private Image MaterialImage;
    private Text MaterialName;
    private Text MaterialNeedCount;
    private Text MaterialHaveCount;

    //�R���X�g���N�^�I�Ȗ����ō쐬�B�e�X�̍��ڂ�DB���瓖�Ă͂߂�B�ڂ����͐����������ɁB
    public void Initial(Sprite image , string name , string needCount , string haveCount) {
        MaterialImage = materialImage.GetComponent<Image>();
        MaterialName = materialName.GetComponent<Text>();
        MaterialNeedCount = materialNeedCount.GetComponent<Text>();
        MaterialHaveCount = materialHaveCount.GetComponent<Text>();
        MaterialImage.sprite = image;
        MaterialName.text = name;
        MaterialNeedCount.text = needCount;
        MaterialHaveCount.text = haveCount;
    }
}
