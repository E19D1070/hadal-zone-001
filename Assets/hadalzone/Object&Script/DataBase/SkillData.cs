using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�X�L�������L�^���邽�߂̘g�g�݃N���X
//�����Œ�`���ꂽ�X�L�����ʃN���X�ŕۑ������B

public class SkillData : MonoBehaviour
{
    private Sprite SkillIcon;               //�X�L���̃A�C�R���摜
    private string SkillName;               //�X�L���̖��O
    private string SkillInfo;               //�X�L���̉��
    private int SkillValue;                 //�X�L���C���ɕK�v�ȃC�N���̐�
    private List<string> SkillMaterial;     //�X�L���C���ɕK�v�ȑf��
    private List<int> SkillMaterialAmount;  //�X�L���C���ɕK�v�ȑf�ނ̐�SkillMaterial�ɍ��킹���Y�����ɂ���K�v������
    private GameObject SkillObject;         //���ۂɃX�L���C�������ۂ�Player�ɒǉ������I�u�W�F�N�g

    //�R���X�g���N�^�B�X�L���������ۂɍ쐬����ꍇ�Ɏg�p
    public SkillData(Sprite Icon , string Name , string Info , int Value , List<string> Material , List<int> MaterialAmount , GameObject Object) {
        this.SkillIcon = Icon;
        this.SkillName = Name;
        this.SkillInfo = Info;
        this.SkillValue = Value;
        this.SkillMaterial = Material;
        this.SkillMaterialAmount = MaterialAmount;
        this.SkillObject = Object;
    }

    //���n���Q�b�^�[�ꗗ
    public Sprite GetSkillIcon {
        get { return SkillIcon; }
    }
    public string GetSkillName {
        get { return SkillName; }
    }
    public string GetSkillInfo {
        get { return SkillInfo; }
    }
    public int GetSkillValue {
        get { return SkillValue; }
    }
    public List<string> GetSkillMaterial {
        get { return SkillMaterial; }
    }
    public List<int> GetSkillMaterialAmount {
        get { return SkillMaterialAmount; }
    }
    public GameObject GetSkillObject {
        get { return SkillObject; }
    }
}


