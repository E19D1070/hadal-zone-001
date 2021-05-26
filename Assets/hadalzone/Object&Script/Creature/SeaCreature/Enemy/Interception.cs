using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵の中でも迎撃タイプが属する継承クラス。相手が害を加えてくればアクションを起こす。

abstract class Interception : Enemy
{

    public abstract void Caution();
    //Playerが警戒範囲内に侵入すると呼び出される関数
    public abstract void Intercept();
    //Playerが攻撃、迎撃範囲内に侵入等の害のある行為をすると呼び出される関数
}
