using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//海の生物が属する継承クラス。海の生物の基本ステータスを記述

abstract class SeaCreature : MonoBehaviour,DamageValue,DamageType,DamagePosition,DamageLayer
{

    public Rigidbody2D CreatureRigidbody2D;
    public SpriteRenderer spriteRenderer;
    public GameObject BloodEffect;
    public GameObject BloodDeathEffect;
    public GameObject DamageUI;
    public Sprite Corpse;

    [SerializeField] float MaxHP;               //最大体力
    [SerializeField] float OffensivePower;      //基礎攻撃力
    [SerializeField] float OffensiveSpeed;    //基礎攻撃速度
    [SerializeField] float OffensiveRange;    //基礎攻撃範囲

    private float HP;                           //現在体力
    private float Damage;                       //攻撃を受けた時のダメージ
    private bool Alive = true;                  //生きてる(true)か死んでる(false)か

    [SerializeField] float FadeSpeed;       //フェードアウトするスピード
    [SerializeField] float DieRotateSpeed;  //死亡時の仰向けになるスピード
    [SerializeField] float DieRise;         //死亡時の浮き上昇値
    private float DieTimer = 0;             //死亡関数の時間計測用変数

    private string CreatureType;  //自身のタイプ。詳細は以下に
    //TypeEnemy   プレイヤーを攻撃する敵を表す
    //TypePlayer  プレイヤーを表す

    private Vector3 MyPosition;           //今現在の自身の座標
    private Quaternion MyRotation;        //今現在の自身の角度
    private Vector3 MyAngle;              //今現在の自身の角度(360Ver)
    private Vector3 MyMouthPsition;       //自身の口の位置
    private Vector3 AttackTouchPosition;  //ダメージを与えるオブジェクトがダメージを与えた時のそのオブジェクト座標用
    private int AttackLayer;              //ダメージを与えるオブジェクトがダメージを与えた時のそのオブジェクトのレイヤー

    ParticleSystem.MinMaxGradient color = new ParticleSystem.MinMaxGradient(); //ParticalSystemを定義

    //ダメージを与えるオブジェクトがダメージを与えた時、そのオブジェクト座標を記憶する
    void DamagePosition.Damage(Vector3 damage) {
        AttackTouchPosition = damage;
    }

    //ダメージを与えるオブジェクトがダメージを与えた時、そのオブジェクトレイヤーを記憶する
    void DamageLayer.Damage(int damage) {
        AttackLayer = damage;
    }

    //ダメージを受ければHPが減り、ダメージ値を出力する処理
    void DamageValue.Damage(float damage) {
        if (Alive == true) {
            HP -= damage;
            Damage = damage;

            DamageUI.GetComponentInChildren<Text>().text = damage.ToString();
            GameObject DUIclone = Instantiate(DamageUI, AttackTouchPosition, new Quaternion(0, 0, 0, 0)) as GameObject;
            Destroy(DUIclone, 3f);
        }
    }

    //ダメージを受けた際にダメージエフェクトを出す処理
    void DamageType.Damage(string damage) {
        if (Alive == true) {
            if (damage == "直接") {
                color.mode = ParticleSystemGradientMode.TwoColors;
                ParticleSystem.MainModule main = BloodEffect.GetComponent<ParticleSystem>().main;
                if (CreatureType == "TypePlayer") {
                    color.colorMin = new Vector4(0.3f, 0.3f, 0.3f, 1);
                    color.colorMax = new Vector4(1, 1, 1, 1);
                }
                if (CreatureType == "TypeEnemy") {
                    color.colorMin = new Vector4(0.3f, 0f, 0f, 1);
                    color.colorMax = new Vector4(0.8f, 0f, 0f, 1);
                }
                main.startColor = color;
                GameObject BEclone = Instantiate(BloodEffect, AttackTouchPosition, MyRotation) as GameObject;
                Destroy(BEclone, 2.5f);
            }
        }
    }

    //死亡時アニメーション
    public void DieCheck()
    {
        if (HP <= 0) {
            Color CreatureColor = spriteRenderer.color;
            DieTimer += Time.deltaTime;
            CreatureRigidbody2D.velocity = Vector2.up * DieRise;
            if (transform.localScale.x == 1) {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 90f), Time.deltaTime * 100f * DieRotateSpeed);
            }
            if (transform.localScale.x == -1)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 270f), Time.deltaTime * 100f * DieRotateSpeed);
            }
            CreatureColor.a -= Time.deltaTime/FadeSpeed;
            spriteRenderer.color = CreatureColor;
            if (CreatureColor.a < 0) {
                Destroy(this.gameObject);
            }
            if (Alive == true) {
                if (creaturetype == "TypeEnemy") {
                    spriteRenderer.sprite = Corpse;
                    GameObject BDEclone = Instantiate(BloodDeathEffect, MyPosition, new Quaternion(0, 0, 0, 0));
                    Destroy(BDEclone, 4.1f);
                }
                Alive = false;
            }
        }
    }


    //タイプのゲッターとセッター
    public string creaturetype {
        set { this.CreatureType = value; }
        get { return this.CreatureType; }
    }

    //最大ヒットポイントのゲッターとセッター
    public float maxhp {
        set { this.MaxHP = value; }
        get { return this.MaxHP; }
    }

    //ヒットポイントのゲッターとセッター
    public float hp {
        set { this.HP = value; }
        get { return this.HP; }
    }

    //攻撃を受けた時のダメージのゲッター
    public float damage {
        get { return this.Damage; }
    }

    //基礎攻撃力のゲッターとセッター
    public float offensivePower {
        set { this.OffensivePower = value; }
        get { return this.OffensivePower; }
    }

    //基礎攻撃速度のゲッターとセッター
    public float offensiveSpeed {
        set { this.OffensiveSpeed = value; }
        get { return this.OffensiveSpeed; }
    }

    //基礎攻撃範囲のゲッターとセッター
    public float offensiveRange {
        set { this.OffensiveRange = value; }
        get { return this.OffensiveRange; }
    }

    //生命判定のゲッター
    public bool alive {
        get {return this.Alive; }
    }

    //自身の現在位置のゲッターとセッター
    public Vector3 myposition {
        set { this.MyPosition = value; }
        get { return this.MyPosition; }
    }

    //自身の現在角度のゲッターとセッター
    public Quaternion myrotation {
        set { this.MyRotation = value; }
        get { return this.MyRotation; }
    }

    //自身の現在角度のゲッターとセッター（360Ver）
    public Vector3 myangle {
        set { this.MyAngle = value; }
        get { return this.MyAngle; }
    }

    //自身の現在の口の位置のゲッターとセッター
    public Vector3 mymouthposition {
        set { this.MyMouthPsition = value; }
        get { return this.MyMouthPsition; }
    }

    //ダメージを与えるオブジェクトがダメージを与えた時のそのオブジェクトのレイヤーのゲッター
    public int attackLayer {
        get { return this.AttackLayer; }
    }
}







