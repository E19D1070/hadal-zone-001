using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//�N���b�N����΃Q�[�����J�n���鏈���B�^�C�g����ʂŎg�p
public class GameStart : MonoBehaviour
{
    public void StartClick() {
        SceneManager.LoadScene("SampleScene");
    }
}
