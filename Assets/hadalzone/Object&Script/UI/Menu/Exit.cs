using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//開いている画面を閉じ、指定した画面を開くクラス

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
