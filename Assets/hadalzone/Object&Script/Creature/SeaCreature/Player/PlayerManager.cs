using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

//プレイヤーが属するクラス。移動受付や所持スキル等を記述する

class PlayerManager : SeaCreature
{
    public float Velocity;             //速度用変数
    public float Decelerate;           //減速用変数
    public float InitialVelocity;      //初速用変数
    public float InitialVelocityRange; //初速範囲用変数
    public float MaxSpeed;             //最高速度用変数

    private float HPCheck;            //SeaCreatureのHPと比較してHPの減少タイミングをこちらでも確認できるようにするための変数

    Skill skill = new Skill();

    GameObject HitPointManager;
    HPManager hpManager;

    Transform Prey;
    Prey PreyMouth;

    [SerializeField] Animator animator;

    void Start()
    {
        creaturetype = "TypePlayer";
        hp = maxhp;
        HPCheck = maxhp;

        Prey = transform.Find("PlayerPreyMouth");
        PreyMouth = Prey.GetComponent<Prey>();

        HitPointManager = GameObject.Find("PlayerHPGauge");
        hpManager = HitPointManager.GetComponent<HPManager>();
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        if (hp != HPCheck) {
            hpManager.CauseHPGauge(damage);
            HPCheck = hp;
        }

        DieCheck();

        if (alive == true) {

            animator.SetFloat("AnimDying",hp/maxhp);

            myposition = transform.localPosition;
            myrotation = transform.localRotation;
            myangle = transform.localEulerAngles;
            mymouthposition = PreyMouth.MouthPosition;

            //移動入力受付呼び出し
            PlayerMove();

            //方向入力受付
            var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
            transform.localRotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);

            //敵のCoreに自身のMouthが触れた時に「捕食」を呼び出す
            if (PreyMouth.MouthTouchingCore == true) {
                skill.prey(offensivePower, offensiveSpeed,PreyMouth.MouthCollider,PreyMouth.MouthPosition,myrotation);
            }
        }
    }

        //移動入力受付用関数
        private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //右移動と減速
        if (Input.GetKey(KeyCode.D))
        {
            if (CreatureRigidbody2D.velocity.x<InitialVelocityRange && CreatureRigidbody2D.velocity.x > 0) 
            {
                CreatureRigidbody2D.AddForce(Vector2.right * InitialVelocity * x);
            }
            else 
            {
                CreatureRigidbody2D.AddForce(Vector2.right * Velocity * x);
            }
        }
        if (!Input.GetKey(KeyCode.D) && CreatureRigidbody2D.velocity.x > 0)
        {
            CreatureRigidbody2D.AddForce(Vector2.left * Decelerate);
        }
        //左移動と減速
        if (Input.GetKey(KeyCode.A))
        {
            if (CreatureRigidbody2D.velocity.x > -InitialVelocityRange && CreatureRigidbody2D.velocity.x < 0)
            {
                CreatureRigidbody2D.AddForce(Vector2.left * InitialVelocity * -x);
            }
            else
            {
                CreatureRigidbody2D.AddForce(Vector2.left * Velocity * -x);
            }
        }
        if (!Input.GetKey(KeyCode.A) && CreatureRigidbody2D.velocity.x < 0)
        {
            CreatureRigidbody2D.AddForce(Vector2.right * Decelerate);
        }
        //上移動と減速
        if (Input.GetKey(KeyCode.W))
        {
            if (CreatureRigidbody2D.velocity.y < InitialVelocityRange && CreatureRigidbody2D.velocity.y > 0)
            {
                CreatureRigidbody2D.AddForce(Vector2.up * InitialVelocity * y);
            }
            else
            {
                CreatureRigidbody2D.AddForce(Vector2.up * Velocity * y);
            }
        }
        if (!Input.GetKey(KeyCode.W) && CreatureRigidbody2D.velocity.y > 0)
        {
            CreatureRigidbody2D.AddForce(Vector2.down * Decelerate);
        }
        //下移動と減速
        if (Input.GetKey(KeyCode.S))
        {
            if (CreatureRigidbody2D.velocity.y > -InitialVelocityRange && CreatureRigidbody2D.velocity.y < 0)
            {
                CreatureRigidbody2D.AddForce(Vector2.down * InitialVelocity * -y);
            }
            else
            {
            CreatureRigidbody2D.AddForce(Vector2.down * Velocity * -y);
            }
        }
        if (!Input.GetKey(KeyCode.S) && CreatureRigidbody2D.velocity.y < 0)
        {
            CreatureRigidbody2D.AddForce(Vector2.up * Decelerate);
        }
        //最高速度を超過しない
        if (CreatureRigidbody2D.velocity.x > MaxSpeed) {
            CreatureRigidbody2D.velocity = new Vector2(MaxSpeed, CreatureRigidbody2D.velocity.y);
        }
        if (CreatureRigidbody2D.velocity.x < -MaxSpeed)
        {
            CreatureRigidbody2D.velocity = new Vector2(-MaxSpeed, CreatureRigidbody2D.velocity.y);
        }
        if (CreatureRigidbody2D.velocity.y > MaxSpeed)
        {
            CreatureRigidbody2D.velocity = new Vector2(CreatureRigidbody2D.velocity.x, MaxSpeed);
        }
        if (CreatureRigidbody2D.velocity.y < -MaxSpeed)
        {
            CreatureRigidbody2D.velocity = new Vector2(CreatureRigidbody2D.velocity.x, -MaxSpeed);
        }
    }
}
