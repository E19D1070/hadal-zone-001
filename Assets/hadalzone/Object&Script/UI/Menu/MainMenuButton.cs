using UnityEngine;
using UnityEngine.EventSystems;

//�}�E�X�J�[�\�����G��Ă��邩�G��Ă��Ȃ����{�N���b�N�����ꂽ���𔻒肷��N���X
//�{�^���ɂ��̃N���X���g�p���āAAppearance�̕��ɒl��n���B

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] private GameObject RotateAppearance;
    Rotate rotate;

    [SerializeField] private GameObject ChildMenu;
    [SerializeField] private GameObject ParentMenu;

    void Start()
    {
        rotate = RotateAppearance.GetComponent<Rotate>();
    }

    //�N���b�N���ꂽ��
    public void OnClick() {
        ChildMenu.SetActive(true);
        ParentMenu.SetActive(false);
    }

    //�}�E�X�J�[�\�����{�^���͈͓̔��ɓ�������
    public void OnPointerEnter(PointerEventData eventData) {
        rotate.mouthPoint = true;
    }

    //�}�E�X�J�[�\�����{�^���͈̔͊O�ɂȂ�����
    public void OnPointerExit(PointerEventData eventData) {
        rotate.mouthPoint = false;
    }
}
