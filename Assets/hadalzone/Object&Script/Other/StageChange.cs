using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Colider�Ƀv���C���[���G�ꂽ��X�e�[�W���ړ��i�V�[�����ړ��j���鏈��
public class StageChange : MonoBehaviour
{
    [SerializeField] GameObject PlayerObject;    //PlayerObject�擾�p
    [SerializeField] string SceneName = null;    //�ړ�������Scene��Unity��Inspector�ق��œ���

    PlayerManager PlayerStatus;                  //�擾����Player����PlayerManager�擾�p

    private void Start() {
        PlayerStatus = PlayerObject.GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "PlayerCore") {
            SceneManager.sceneLoaded += GameSeceneLoad;  //�C�x���g�ɓo�^
            SceneManager.LoadScene(SceneName);
        }
    }

    private void GameSeceneLoad(Scene scene , LoadSceneMode mode) {
        var a = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        a.hp = PlayerStatus.hp;
        SceneManager.sceneLoaded -= GameSeceneLoad;  //�C�x���g����폜
    }
}
