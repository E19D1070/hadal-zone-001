using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//自身の子をすべて破壊するクラス

public class DestroyChild : MonoBehaviour
{
    private int count = -1;             //Countが0と1の時は破壊しない。必要素材のPanelにおいて自身のオブジェクトと破壊したくないTextが入るからである。
    public void DestroyChildren() {
        count = -1;
        GameObject[] childGameObjects = GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToArray();
        foreach (GameObject gameObject in childGameObjects) {
            count++;
            if (count==0 || count==1) {
                continue;
            }
            Destroy(gameObject);
        }
    }
}
