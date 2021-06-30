using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵が属する継承クラス。敵の基本ステータスを記述

abstract class Enemy : SeaCreature {

    public List<GameObject> HaveItem = new List<GameObject>();
    private string ItemAddressName = "ItemObject/";

    Transform Wound;
    private float GoreCheck;    //流血する数値
    private int GoreCount = 0;  //流血する子オブジェクトナンバー

    private bool CoreTouch;             //自身のCoreに攻撃が接触したか？用変数
    private bool PlayerRecognizeSpace;  //Playerが認識範囲に入っているか？用変数
    private bool PlayerVisibleSpace;    //Playerが視覚範囲に入っているか？用変数
    private bool PlayerPersonalSpace;   //Playerが個体範囲に入っているか？用変数
    private bool PlayerAttackRecognizeSpace;  //Playerの攻撃が認識範囲に入っているか？用変数
    private bool PlayerAttackVisibleSpace;    //Playerの攻撃が視覚範囲に入っているか？用変数
    private bool PlayerAttackPersonalSpace;   //Playerの攻撃が個体範囲に入っているか？用変数

    private bool RecognizeState;  //認識状態用変数
    private bool CautionState;    //警戒状態用変数
    private bool HostileState;    //敵対状態用変数

    Skill skill = new Skill();

    Vector2 GeneratePoint;          //自身の生成地点
    GameObject Player;

    Transform Prey;
    Prey PreyMouth;

    Transform Emotion;
    Animator animator;

    public void Awake() {
        hp = maxhp;
        creaturetype = "TypeEnemy";
        GeneratePoint = transform.localPosition;
        Player = GameObject.Find("Player");
        Wound = transform.Find("Wound");
        Prey = transform.Find("EnemyPreyMouth");
        PreyMouth = Prey.GetComponent<Prey>();
        CoreTouch = false;
        RecognizeState = false;
        CautionState = false;
        HostileState = false;
        Emotion = transform.Find("EmotionPosition");
        animator = Emotion.GetComponent<Animator>();
    }

    //倒された時にアイテムがドロップする処理
    //引数　１ランダムで決まるドロップ時にとんでいく力の上限値　２ランダムで決まるドロップ時にとんでいく力の下限値
    public void ItemDrop(float Maxforce  , float Minforce) {
        foreach (GameObject item in HaveItem) {
            //ドロップアイテムを生成
            GameObject ItemClone = Instantiate(item,transform.position,new Quaternion(0,0,0,0)) as GameObject;
            Rigidbody2D ItemPhysics = ItemClone.GetComponent<Rigidbody2D>();
            //ドロップ時にアイテムがランダム位置に離散する処理
            int angle = UnityEngine.Random.Range(1, 360);
            float force = UnityEngine.Random.Range(Minforce, Maxforce);
            ItemPhysics.AddForce(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * force, ForceMode2D.Impulse);
        }
    }

    //PlayerのCoreに自身のMouthが触れた時に「捕食」を呼び出す
    public void EnemyPrey(float Power, float speed) {
        if (PreyMouth.MouthTouchingCore == true) {
            skill.prey(Power, speed, PreyMouth.MouthCollider, PreyMouth.MouthPosition, myrotation);
        }
    }

    //ダメージが一定以下になると指定したポイントから流血する処理
    public void GoreEffect() {
        Wound.transform.GetChild(GoreCount).gameObject.SetActive(true);
        GoreCount++;
    }

    //流血処理をオフにする機能。死亡時に流血処理をオフにするために使用
    public void GoreAnActive() {
        foreach (Transform GoreObject in Wound.transform) {
            GoreObject.gameObject.SetActive(false);
        }
    }

    //自身の認識状態によってEmotoアイコンを表示する処理
    public void EmotionIcon() {
        if(recognizeState == true) {
            animator.SetInteger("Emotion", 1);
        }
        if (CautionState == true) {
            animator.SetInteger("Emotion", 2);
        }
        if (HostileState == true) {
            animator.SetInteger("Emotion", 3);
        }
    }

    //ItemAddressNameのゲッター
    public string itemAddress {
        get { return ItemAddressName; }
    }

    //Playerのゲッターとセッター
    public GameObject player {
        set { this.Player = value; }
        get { return Player; }
    }

    //skillのゲッター
    public Skill SKILL {
        get { return skill; }
    }

    //PreyMouthのゲッター
    public Prey preyMouth {
        get { return PreyMouth; }
    }

    //流血する数値のゲッターとセッター
    public float goreCheck{
        set { this.GoreCheck = value; }
        get { return GoreCheck; }
    }

    //生成地点のゲッターとセッター
    public Vector2 generatePoint {
        set { this.GeneratePoint = value; }
        get { return GeneratePoint; }
    }

    //コア接触用のゲッターとセッター
    public bool coreTouch {
        set { this.CoreTouch = value; }
        get { return CoreTouch; }
    }

    //認識範囲（Player）のゲッターとセッター
    public bool playerRecognizeSpace {
        set { this.PlayerRecognizeSpace = value; }
        get { return PlayerRecognizeSpace; }
    }

    //視覚範囲（Player）のゲッターとセッター
    public bool playerVisibleSpace {
        set { this.PlayerVisibleSpace = value; }
        get { return PlayerVisibleSpace; }
    }

    //個体範囲（Player）のゲッターとセッター
    public bool playerPersonalSpace {
        set { this.PlayerPersonalSpace = value; }
        get { return PlayerPersonalSpace; }
    }

    //認識範囲（Playerの攻撃）のゲッターとセッター
    public bool playerAttackRecognizeSpace {
        set { this.PlayerAttackRecognizeSpace = value; }
        get { return PlayerAttackRecognizeSpace; }
    }

    //視覚範囲（Playerの攻撃）のゲッターとセッター
    public bool playerAttackVisibleSpace {
        set { this.PlayerAttackVisibleSpace = value; }
        get { return PlayerAttackVisibleSpace; }
    }

    //個体範囲（Playerの攻撃）のゲッターとセッター
    public bool playerAttackPersonalSpace {
        set { this.PlayerAttackPersonalSpace = value; }
        get { return PlayerAttackPersonalSpace; }
    }

    //認識状態のゲッターとセッター
    public bool recognizeState {
        set { this.RecognizeState = value; }
        get { return RecognizeState; }
    }

    //警戒状態のゲッターとセッター
    public bool cautionState {
        set { this.CautionState = value; }
        get { return CautionState; }
    }

    //敵対状態のゲッターとセッター
    public bool hostileState {
        set { this.HostileState = value; }
        get { return HostileState; }
    }
}
