using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//メニューが開かれるたびに自身のステータスを更新する処理

public class StatusDisplay : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject TextObject;

    PlayerManager PlayerManager;
    Text Text;

    private bool init = true;

    private void OnEnable() {                               //最初だけデータを取ってきてほしい。Startでするとこのオブジェクトが非アクティブ状態でスタートするためNullExeptionが出る
        if (true) {
            PlayerManager = Player.GetComponent<PlayerManager>();
            Text = TextObject.GetComponent<Text>();
            init = false;
        }
        Text.text = PlayerManager.maxhp + "\n" +
                    PlayerManager.offensivePower + "\n" +
                    PlayerManager.offensiveSpeed + "\n" +
                    PlayerManager.offensiveRange + "\n";
    }
}
