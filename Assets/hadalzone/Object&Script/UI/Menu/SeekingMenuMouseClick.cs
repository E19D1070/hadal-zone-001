using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�T����ʂł̃X�L���{�^���N���b�N���̏���

public class SeekingMenuMouseClick : MonoBehaviour
{
    [SerializeField] private GameObject ParentReleaseObject;  //���g�̃X�L�������O�̃X�L���i����͎Q�Ƃ����ɂȂ�j�̃X�L���������������I�u�W�F�N�g
    [SerializeField] private GameObject OwnReleaseObject;     //���g�̃X�L���̃X�L������������������A�A�N�e�B�u��A�N�e�B�u��؂�ւ���
    [SerializeField] private GameObject MyImageIcon;          //���g�̃X�L���A�C�R��������Ƃ��Ɖ����Ȃ��Ƃ��œ����x��ς���悤

    [SerializeField] private string Name;  //���g�̃X�L����

    [SerializeField] private GameObject SkillDataBase;  //SkillDataBase���t�����ꂽ�Q�[���I�u�W�F�N�g
    [SerializeField] private GameObject MaterialPanel;  //�K�v�f�ނ�Panel��񂪕K�v�Ȃ̂ŁA�܂��A�X�L���ڍׂ�؂�ւ���ہA���������I�u�W�F�N�g��j�󂷂邽�߂̂���
    [SerializeField] private GameObject ItemDataBase;   //�X�L���C���ɕK�v�ȑf�ނ̕\�����K�v�Ȃ̂�
    [SerializeField] private GameObject PlayerItemBox;  //�X�L���C���ɕK�v�ȑf�ނ̓����g���������Ă��鐔�̕\�����K�v�Ȃ̂�

    [SerializeField] private GameObject SkillDetail;    //�X�L���̏ڍׂ�\�����邽�߂�GUI���t�����ꂽ�Q�[���I�u�W�F�N�g

    [SerializeField] private GameObject ObjectIcon;   //�X�L���ڍׂ̃A�C�R������
    [SerializeField] private GameObject ObjectName;   //�X�L���ڍׂ̖��O����
    [SerializeField] private GameObject ObjectInfo;   //�X�L���ڍׂ̉������
    [SerializeField] private GameObject ObjectValue;  //�X�L���C���ɕK�v�ȃA�r�X�̐�����
    [SerializeField] private GameObject ObjectMaterial;  //�X�L���ڍׂ̕K�v�f�ޕ���

    [SerializeField] private GameObject Seeking;      //�����i�T���j�{�^���̃I�u�W�F�N�g

    private Button OwnButton;
    Image MyIcon;

    Image SkillIcon;
    Text SkillName;
    Text SkillInfo;
    Text SkillValue;

    private SkillDB skilldb;
    private ItemDB itemdb;
    private PlayerItemBox ItemBox;

    private Seeking seeking;
    private Button SeekingButton;
    private List<bool> CanSeekingCheck = new List<bool>();       //���݂̃A�C�e�����Ə������ŃX�L���̋������\���`�F�b�N�p
    private List<string> DecreaseItemName = new List<string>();  //�����{�^�����������ۂɏC���ɕK�v�ȑf�ނ�����鎞�̑f�ޖ�
    private List<int> DecreaseItemCount = new List<int>();       //�����{�^�����������ۂɏC���ɕK�v�ȑf�ނ�����鎞�̑f�ސ�
    private int DecreaseAbyss;                                   //�����{�^�����������ۂɏC���ɕK�v�ȃA�r�X�������Ƃ��p�̕ϐ�

    private DestroyChild destroyChild;

    private void Start() {
        OwnButton = this.GetComponent<Button>();
        MyIcon = MyImageIcon.GetComponent<Image>();

        skilldb = SkillDataBase.GetComponent<SkillDB>();
        itemdb = ItemDataBase.GetComponent<ItemDB>();
        ItemBox = PlayerItemBox.GetComponent<PlayerItemBox>();

        SkillIcon = ObjectIcon.GetComponent<Image>();
        SkillName = ObjectName.GetComponent<Text>();
        SkillInfo = ObjectInfo.GetComponent<Text>();
        SkillValue = ObjectValue.GetComponent<Text>();

        seeking = Seeking.GetComponent<Seeking>();
        SeekingButton = Seeking.GetComponent<Button>();

        destroyChild = MaterialPanel.GetComponent<DestroyChild>();
    }

    private void Update() {
        if (OwnReleaseObject.activeSelf == true) {          //���g�̃X�L���������ς݂̎�
            OwnButton.interactable = false;
            return;
        }
        if (ParentReleaseObject.activeSelf == true) {       //�e�������ς݂̎�
            OwnButton.interactable = true;
            this.gameObject.SetActive(true);
            var normalColor = OwnButton.colors.normalColor;
            normalColor.a = 0;
            MyIcon.color = new Color(1, 1, 1, 1f);
        }
        else {                                              //�e����������Ă��Ȃ��ꍇ
            OwnButton.interactable = false;
            var normalColor = OwnButton.colors.normalColor;
            normalColor.a = 1;
            MyIcon.color = new Color(0,0,0,0.3f);
        }
        if (SkillName.text == Name) {                       //���g�̃X�L���������N���b�N���ꂽ��
            if (seeking.clickCheck == true) {
                OwnReleaseObject.SetActive(true);
                int DIcount = 0;                                 //����String��Foreach��DecreaseItemCount����s���Đi�߂�p
                foreach (string itemname in DecreaseItemName) {  //�w�肳�ꂽ�ޗ����̑f�ށE�A�r�X�����g�̃o�b�N���猸�炷
                    ItemBox.GetPlayerItem(itemname).SetGetPlayerItemCount = DecreaseItemCount[DIcount];
                    ItemBox.GetPlayerItem("�A�r�X").SetGetPlayerItemCount = DecreaseAbyss;
                    DIcount++;
                    break;
                }
            }
            seeking.clickCheck = false;
        }
    }

    public void SkillClick() {
        DecreaseAbyss = 0;               //�X�L���ڍׂ�؂�ւ���ہA�����Ɏg�p���A�ύX����͂������������A�r�X�̒l�����������Ă���
        DecreaseItemName.Clear();        //�X�L���ڍׂ�؂�ւ���ہA�����Ɏg�p���A�ύX����͂������������f�ނ�List�i���O�j�����������Ă���
        DecreaseItemCount.Clear();       //�X�L���ڍׂ�؂�ւ���ہA�����Ɏg�p���A�ύX����͂������������f�ނ�List�i�������j�����������Ă���
        CanSeekingCheck.Clear();         //�X�L���ڍׂ�؂�ւ���ہA�����f�ސ��ƕK�v�f�ސ��̔�r���s���A�����\����K�v�f�ނ��Ƃɔ��f����List�����������Ă���
        destroyChild.DestroyChildren();  //�X�L���ڍׂ�؂�ւ���ہA���������I�u�W�F�N�g��j�󂷂邽�߂̂���
        if (SkillDetail.activeSelf == false) {
            SkillDetail.SetActive(true);
            InputSkillData();
        }
        else {
            if (SkillName.text != Name) {
                InputSkillData();
                return;
            }
            SkillDetail.SetActive(false);
        }
    }

    //�ȈՂɂ��邽�߂Ƀ��\�b�h��
    private void InputSkillData() {
        SkillIcon.sprite = skilldb.GetSkillData(Name).GetSkillIcon;  //�X�L���ڍׂ̃A�C�R����\��
        SkillName.text = skilldb.GetSkillData(Name).GetSkillName;    //�X�L���ڍׂ̖��O��\��
        SkillInfo.text = skilldb.GetSkillData(Name).GetSkillInfo;    //�X�L���ڍׂ̉����\��
        SkillValue.text = skilldb.GetSkillData(Name).GetSkillValue.ToString();  //�X�L���ڍׂ̏C���K�v�A�r�X����\��

        seeking.addSkill = skilldb.GetSkillData(Name).GetSkillObject;//�X�L���C���{�^�����������ۂɏC������X�L�����Z�b�g����

        //�X�L���C���ɕK�v�ȑf�ނ�\���i�����j
        List<int> materialAmount = skilldb.GetSkillData(Name).GetSkillMaterialAmount;                       //�e�f�ނ��ƂɕK�v�ȑf�ނ̐���List��SkillDB����쐬
        int MAcount = 0;                                                                                    //materialAmount��List�̓Y�����ԍ��p
        List<PlayerItemManager> PlayerItemList = ItemBox.GetPlayerItemList;                                 //�A�C�e���{�b�N�X��Ƀf�[�^�����݂��邩�ǂ����̌��m�p
        float BoxPosition = 0;                                                                              //���[�v���ƂɈʒu�̒������K�v�Ȃ̂ł���p

        foreach (string Materialname in skilldb.GetSkillData(Name).GetSkillMaterial) {                      //�C���ɕK�v�ȑS�Ă̑f�ނ����������܂�ForEach
            int HaveMaterial = 0;                                                                           //�K�v�f�ނɎw�肳�ꂽ�f�ނ̐���0�Ȃ�΂��������A�C�e���{�b�N�X��ɑ��݂��Ȃ��A�C�e���ƂȂ�̂ŁA�G���[���o�邽�߂����h�~����p�̋��n���ϐ�
            GameObject Material = Instantiate(ObjectMaterial,                                               //�f�ނ̃e���v���[�gBox���쐬
                                              new Vector2(MaterialPanel.transform.position.x, MaterialPanel.transform.position.y + 0.75f - BoxPosition),//�e���v���[�g�̈ʒu
                                              Quaternion.identity,                                          //�e���v���[�g�̊p�x
                                              MaterialPanel.transform) as GameObject;                       //�e���v���[�g�̊K�w�iMaterialPanel���e�ł��j

            bool Success = false;                                                                           //���������K�v���ȏ�̎��ɒʂ�If��ʉ߂������H
            if (ItemBox.GetPlayerItem(Materialname).GetPlayerItemName != null) {                            //�A�C�e���{�b�N�X��Ɏw�肳�ꂽ�A�C�e�������݂��邩
                HaveMaterial = ItemBox.GetPlayerItem(Materialname).SetGetPlayerItemCount;                   //�����Count�����B
                if (HaveMaterial >= materialAmount[MAcount]) {                                              //����ɕK�v���Ɣ�r���ĕK�v���ȏ�Ȃ�True��Ԃ��A�����������p�ɏ���������K�v�����������l���L�������Ă���
                    CanSeekingCheck.Add(true);
                    DecreaseItemName.Add(Materialname);
                    DecreaseItemCount.Add(HaveMaterial - materialAmount[MAcount]);
                    Success = true;
                }
            }
            if (Success == false) {                                                                         //�K�v���ȉ��Ȃ��False��Ԃ�
                CanSeekingCheck.Add(false);
            }

            NeedMaterial needMaterial = Material.GetComponent<NeedMaterial>();                              //���������e���v���[�g����X�N���v�g���擾
            needMaterial.Initial(itemdb.GetItemData(Materialname).GetItemIcon,                              //�e���v���[�g�ɑf�މ摜��\��
                                 Materialname,                                                              //�e���v���[�g�ɑf�ޖ���`��
                                 materialAmount[MAcount].ToString(),                                        //�e���v���[�g�ɕK�v�f�ސ���`��
                                 HaveMaterial.ToString());                                                  //�e���v���[�g�ɏ����f�ސ���`��
            MAcount++;
            BoxPosition += 0.35f;
        }                                                                                                   //���[�v���ƂɎ��̕K�v�f�ނƃe���v���[�g�̈ʒu�����������

        bool MaterialHaveCheck = true;                                                                      //�K�v�f�ނ�������Ă���A���A�r�X������Ă���Ȃ狭���i�T���j�{�^����������悤�ɂ��鏈��
        foreach (bool check in CanSeekingCheck) {
            if (check == false) {
                MaterialHaveCheck = false;
                break;
            }
        }
        if (MaterialHaveCheck == true && ItemBox.GetPlayerItem("�A�r�X").SetGetPlayerItemCount >= skilldb.GetSkillData(Name).GetSkillValue) {
            DecreaseAbyss = ItemBox.GetPlayerItem("�A�r�X").SetGetPlayerItemCount - skilldb.GetSkillData(Name).GetSkillValue;
            SeekingButton.interactable = true;
        }
        else {
            SeekingButton.interactable = false;
        }
    }
}
