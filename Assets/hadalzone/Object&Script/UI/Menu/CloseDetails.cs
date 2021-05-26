using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�T�u���j���[�ł̃X�L�����̏��̏ڍׂ��\������Ă��鎞��ʂ��N���b�N����Əڍׂ�����N���X
//RayCastTarget�̃I���I�t���ӎ����Ȃ���΂��܂��쓮���Ȃ��̂Œ���

public class CloseDetails : MonoBehaviour {

    [SerializeField] GameObject Details;
    void Update() {
        //RayCastTarget���L���ȕ�������True�ɂȂ�͗l�i�ڂ����͒m��񂯂ǁj�B
        //True��Ԃ��Ƃ����ŏ������I������
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        //GetMouseButtonDown(0)�ŉ�ʑS�Ă��N���b�N����ɂȂ��Ă���B
        if (Input.GetMouseButtonDown(0)) {
            if (Details.activeSelf == true) {
                Details.SetActive(false);
            }
        }
    }
}