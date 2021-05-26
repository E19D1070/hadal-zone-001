using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵キャラクター、サーモンのクラス。

class Salmon : Interception
{
    private bool ItemDropCheck = false;  //アイテムドロップは一回だけでいい！それを判定するためのBool
    private int HavaAbyss = 7;           //ドロップするアビスの量

    public float TerritoryRange;      //敵の移動範囲
    public float LookSpeed;           //指定地点に向く速度
    public float NormalSpeed;         //通常時の速度
    public float HostileStateSpeed;   //敵対時のスピード

    public float RemaindCautionTime;  //警戒状態時、どれだけの時間で警戒解除をするか用
    float RemaindCautionCount = 0;    //警戒状態時、一定時間経過で警戒解除をするための時間計測用

    public float RemaindHostileTime;  //戦闘状態時、VisbleAreaからPlayerが離れても（時間指定）の間は戦闘状態を続ける用
    float RemaindHostileCount = 0;    //戦闘状態時、一定時間経過で戦闘解除をするための時間計測用

    public float WaitRandomMoveTime;  //ランダム移動時の目標地点に到達してから次の目標地点に行くまでの待機時間
    float RandomMoveDistance;         //ランダム移動時の自身の地点から目標地点までの距離
    float WaitRandomMove;             //ランダム移動時の目標地点に到達してから次の目標地点に行くまでの待機時間の時間計測用
    Vector3 randomposition;           //ランダム移動時の目標地点

    EnemyView enemyView = new EnemyView();
    NormalStateMove normalmove = new NormalStateMove();

    private void Start()
    {
        RandomMoveDistance = 0;
        WaitRandomMove = 0;
        randomposition = generatePoint;
        goreCheck = 0.75f;
        HaveItem.Add(Resources.Load(itemAddress + "SalmonHide" , typeof(GameObject)) as GameObject);
        HaveItem.Add(Resources.Load(itemAddress + "SalmonFin", typeof(GameObject)) as GameObject);
        for (int a = 1 ; a <= HavaAbyss ; a++) {
            HaveItem.Add(Resources.Load(itemAddress + "Abyss", typeof(GameObject)) as GameObject);
        }
    }
    private void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        DieCheck();

        //HPが一定以下になると流血処理を呼び出す
        if (hp / maxhp <= goreCheck) {
            if (hp > 0) {
                GoreEffect();
                goreCheck -= 0.25f;
            }
            else {
                GoreAnActive();
                //死亡したらアイテムをドロップする
                if (ItemDropCheck == false) {
                    ItemDrop(2f,3f);
                    ItemDropCheck = true;
                }
            }
        }

        if (alive == true)
        {
            myposition = transform.localPosition;
            myrotation = transform.localRotation;
            myangle = transform.localEulerAngles;

            //Playerが認識範囲に入った時に認識状態にし、出た時非認識状態にする
            if (playerRecognizeSpace == true && cautionState == false && hostileState == false) {
                recognizeState = true;
            }
            if (playerRecognizeSpace == false) {
                recognizeState = false;
            }

            //Playerを認識していないときの処理
            if (recognizeState == false && cautionState == false && hostileState == false) {
                NormalMove();
            }

            //認識状態の時の処理
            if (recognizeState == true) {
                NormalMove();
                if (playerVisibleSpace == true || playerAttackPersonalSpace == true) {//Playerが視界範囲、またはPlayerの攻撃が個体範囲に入れば警戒状態に
                    cautionState = true;
                    recognizeState = false;
                }
                if (coreTouch == true) {//攻撃が当たれば敵対状態に
                    hostileState = true;
                    recognizeState = false;
                }
            }

            //警戒状態の時の処理
            if (cautionState == true) {
                RemaindCautionCount += Time.deltaTime;
                if (RemaindCautionCount > RemaindCautionTime) {//Playerが一定時間攻撃しなければNormalMoveを行う
                    NormalMove();
                }
                if (RemaindCautionCount <= RemaindCautionTime) {
                    Caution();
                }
                if (playerPersonalSpace == true || playerAttackVisibleSpace == true) {//Playerが個体範囲、またはPlayerの攻撃が視界範囲に入れば敵対状態に
                    hostileState = true;
                    cautionState = false;
                    RemaindCautionCount = 0;
                }
                if (playerRecognizeSpace == false) {//Playerが認識範囲から出たなら警戒解除
                    cautionState = false;
                    RemaindCautionCount = 0;
                }
            }

            //敵対状態の時
            if (hostileState == true) {
                Intercept();
                if (playerVisibleSpace == false && playerAttackVisibleSpace == false) {//PlayerとPlayerの攻撃が視覚範囲に入らない状態が一定時間続くと敵対状態が解除され認識状態に移行する
                    RemaindHostileCount += Time.deltaTime;
                    if (RemaindHostileCount >= RemaindHostileTime) {
                        hostileState = false;
                        recognizeState = true;
                        RemaindHostileCount = 0;
                    }
                }
                if (playerVisibleSpace == true || playerAttackVisibleSpace == true) {
                    RemaindHostileCount = 0;
                }
            }

            //Enemyの捕食呼び出し関数を呼び出す
            EnemyPrey(offensivePower,offensiveSpeed);

            EmotionIcon();

            coreTouch = false;
        }
    }



    //警戒状態になると呼び出される関数。ゆっくリとこちらを見てくる。
    public override void Caution()
    {
        transform.localRotation = enemyView.LookPlayer(player , myposition, myrotation, LookSpeed);
        transform.localScale = enemyView.Reversi(myrotation);
    }

    //敵対状態になると呼び出される関数。一定の距離を保ってこちらを攻撃してくる
    public override void Intercept()
    {
        transform.localRotation = enemyView.LookPlayer(player, myposition, myrotation, LookSpeed * 1.5f);//Playerを見る
        transform.localScale = enemyView.Reversi(myrotation);

        SKILL.airShotCoolTimeCount += Time.deltaTime;//弾の発射
        if (SKILL.airShotCoolTimeCount > SKILL.airShotIntervalTime * offensiveSpeed) {
            SKILL.airShot(offensivePower, offensiveRange, creaturetype, myangle.z + 90, preyMouth.MouthPosition, myrotation);
        }

        float dis = Vector2.Distance(transform.position, player.transform.position);//自身とPlayerの距離を計測して距離によって近づいたり離れたりする
        if (dis >= 2) {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, player.transform.position, HostileStateSpeed * 0.005f);
        }
        if (dis <= 1) {
            var direction = new Vector3(Mathf.Cos((myangle.z + 90) * Mathf.Deg2Rad), Mathf.Sin((myangle.z + 90) * Mathf.Deg2Rad), 0);
            transform.localPosition -= direction * (HostileStateSpeed * 0.0025f);
        }
    }

    //一定の範囲内をランダムで移動する
    public void NormalMove() {
        if (RandomMoveDistance == 0)
        {
            WaitRandomMove += Time.deltaTime;
            if (WaitRandomMove >= WaitRandomMoveTime) {
                randomposition = normalmove.RandomMoveInTheTerritory(generatePoint, TerritoryRange);
                WaitRandomMove = 0;
            }
        }
        if (RandomMoveDistance != 0) {
            transform.localRotation = enemyView.LookPoint(randomposition , myposition, myrotation, LookSpeed);
            transform.localScale = enemyView.Reversi(myrotation);
        }
        RandomMoveDistance = Vector2.Distance(transform.localPosition, randomposition);
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, randomposition, 0.01f * NormalSpeed);
    }
}
