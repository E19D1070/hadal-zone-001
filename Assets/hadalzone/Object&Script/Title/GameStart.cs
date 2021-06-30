using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//クリックすればゲームを開始する処理。タイトル画面で使用
public class GameStart : MonoBehaviour
{
    public void StartClick() {
        SceneManager.LoadScene("SampleScene");
    }
}
