using System.Drawing;
using UnityEngine;

//��]����N���X
//���j���[�̉�]�A�j���[�V�����Ɏg�p����B�}�E�X�J�[�\�������킹�����ɃX�s�[�h�A�b�v����@�\���{�^���ƘA�����ĕt�����Ă���B

public class Rotate : MonoBehaviour{
    [SerializeField] private float RotateX;
    [SerializeField] private float RotateY;
    [SerializeField] private float RotateZ = 0.05f;

    private bool MouthPoint = false;  //�}�E�X�J�[�\�����{�^���ɐG��Ă��邩���肵�Ă���B

    private void OnEnable() {
        MouthPoint = false;
    }
    private void Update() {
        if (MouthPoint == false) {
            this.transform.Rotate(RotateX, RotateY, RotateZ);
        }
        if (MouthPoint == true) {
            this.transform.Rotate(RotateX, RotateY, RotateZ * 4f);
        }
    }

    public bool mouthPoint{
        set {this.MouthPoint = value; }
    }
}
