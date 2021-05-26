using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�J���Ă����ʂ���A�w�肵����ʂ��J���N���X

public class Exit : MonoBehaviour
{
    [SerializeField] GameObject CloseObject;
    [SerializeField] GameObject SubCloseObject;
    [SerializeField] GameObject OpenObject;

    public void ExitButton() {
        if (SubCloseObject != null) {
            SubCloseObject.SetActive(false);
        }
        CloseObject.SetActive(false);
        OpenObject.SetActive(true);
    }
}
