using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//メニューが表示された際に現在所持しているアビスの数を更新する処理

public class AbyssCountDisplay : MonoBehaviour
{
    [SerializeField] private GameObject ItemBoxObject;
    [SerializeField] private GameObject AbyssCountObject;

    private PlayerItemBox ItemBox;
    private Text AbyssCount;

    private bool init = true;

    private void OnEnable() {
        if (init == true) {
            ItemBox = ItemBoxObject.GetComponent<PlayerItemBox>();
            AbyssCount = AbyssCountObject.GetComponent<Text>();
            init = false;
        }
        AbyssCount.text = ItemBox.GetPlayerItem("アビス").SetGetPlayerItemCount.ToString();
    }
}
