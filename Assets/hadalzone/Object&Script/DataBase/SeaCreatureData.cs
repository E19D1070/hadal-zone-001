using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���������L�^���邽�߂̘g�g�݃N���X
//�����Œ�`���ꂽ��񂪕ʃN���X�ŕۑ������B

public class SeaCreatureData : MonoBehaviour
{
    private Sprite CreatureImage;        //�����̉摜
    private string CreatureName;         //�����̖��O
    private string CreatureInfo;         //�����̏��i�}�ӂɏ����悤�Ȃ��Ɓj
    private List<string> CreatureSkill;  //�����̃X�L��
    //��X�Ƀh���b�v����C�N���̐��ƃA�C�e��������悤�ɂȂ邩��

    //�R���X�g���N�^�B�����������ۂɍ쐬����ꍇ�Ɏg�p
    public SeaCreatureData(Sprite Image , string Name , string Info , List<string> Skill) {
        this.CreatureImage = Image;
        this.CreatureName = Name;
        this.CreatureInfo = Info;
        this.CreatureSkill = Skill;
    }

    //�l�n���̃Q�b�^�[�ꗗ
    public Sprite GetCreatureImage {
        get { return CreatureImage; }
    }
    public string GetCreatureName {
        get { return CreatureName; }
    }
    public string GetCreatureInfo {
        get { return CreatureInfo; }
    }
    public List<string> GetCreatureSkill {
        get { return CreatureSkill; }
    }
}
