using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Coliderにプレイヤーが触れたらステージを移動（シーンを移動）する処理
public class StageChange : MonoBehaviour
{
    [SerializeField] GameObject PlayerObject;    //PlayerObject取得用
    [SerializeField] string SceneName = null;    //移動したいSceneをUnityのInspectorほうで入力

    PlayerManager PlayerStatus;                  //取得したPlayerからPlayerManager取得用

    private void Start() {
        PlayerStatus = PlayerObject.GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "PlayerCore") {
            SceneManager.sceneLoaded += GameSeceneLoad;  //イベントに登録
            SceneManager.LoadScene(SceneName);
        }
    }

    private void GameSeceneLoad(Scene scene , LoadSceneMode mode) {
        var a = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        a.hp = PlayerStatus.hp;
        SceneManager.sceneLoaded -= GameSeceneLoad;  //イベントから削除
    }
}
