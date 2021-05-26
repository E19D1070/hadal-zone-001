using System.Drawing;
using UnityEngine;

//回転するクラス
//メニューの回転アニメーションに使用する。マウスカーソルを合わせた時にスピードアップする機能がボタンと連動して付属している。

public class Rotate : MonoBehaviour{
    [SerializeField] private float RotateX;
    [SerializeField] private float RotateY;
    [SerializeField] private float RotateZ = 0.05f;

    private bool MouthPoint = false;  //マウスカーソルがボタンに触れているか判定している。

    private void OnEnable() {
        MouthPoint = false;
    }
    private void Update() {
        if (MouthPoint == false) {
            this.transform.Rotate(RotateX, RotateY, RotateZ);
        }
        if (MouthPoint == true) {
            this.transform.Rotate(RotateX, RotateY, RotateZ * 4f);
        }
    }

    public bool mouthPoint{
        set {this.MouthPoint = value; }
    }
}
