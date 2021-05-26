using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

//スキルの貯蔵庫

public class Skill : MonoBehaviour
{
    //捕食：自身の口元に触れたら基礎攻撃力＊１倍、基礎攻撃速度＊１倍の攻撃を行う。
    //引数　１自身の基礎攻撃力　２自身の基礎攻撃速度　３口元に触れた相手の情報
    //　　　４自身の口の現在地点　５自身の現在角度（この二つの引数はエフェクトを表示する際に使用する）
    float PreyCoolTimeCount = 0;  //捕食の現在のクールダウン値
    bool PreyFirst = true;        //初めての捕食か？
    GameObject preyEffect;                  //エフェクト用
    ParticleSystem.MainModule PreyPSMain;   //エフェクト用
    public void prey(float Power , float Interval , Collider2D collider,Vector3 myMouthTransform ,Quaternion myRotation) {
        if (PreyFirst == true) {
            preyEffect = GameObject.Find("PreyEffect");
            PreyPSMain = preyEffect.GetComponent<ParticleSystem>().main;
            PreyFirst = false;
        }
        if (PreyCoolTimeCount == 0) {
            var CauseDamageValue = collider.gameObject.GetComponentInParent<DamageValue>();
            var CauseDamageType = collider.gameObject.GetComponentInParent<DamageType>();
            if (CauseDamageValue != null) {
                CauseDamageValue.Damage(Power*1);
            }
            if (CauseDamageType != null) {
                CauseDamageType.Damage("直接");
            }
            PreyPSMain.startRotation = myRotation.z * -Mathf.PI;//何故か円周率を使うと下向きがピッタリ１８０度になってくれる（そもそものRotateの問題か知らんが、真横は90度ではない、、、何故だ、、）
            GameObject PEclone = Instantiate(preyEffect, myMouthTransform, myRotation) as GameObject;
            Destroy(PEclone, 1.2f);
        }
        PreyCoolTimeCount += Time.deltaTime;
        if (PreyCoolTimeCount >= Interval * 1) {
            PreyCoolTimeCount = 0;
        }
    }


    //空砲：自身の口元から前方に、触れたら基礎攻撃力＊１倍、基礎攻撃速度＊１倍、基礎攻撃範囲＊１倍の弾を発射する。
    //引数　１自身の基礎攻撃力　２自身の基礎攻撃範囲　３自身のタイプ
    //　　　４自身の現在角度（360Ver）
    //　　　５自身の口の現在地点　６自身の現在角度
    private float AirShotIntervalTime = 1;   //空砲のクールダウン値
    private float AirShotCoolTimeCount = 0;  //空砲の現在のクールダウン値
    bool AirShotFirst = true;                //初めての空砲か？
    GameObject ObjectAS;                     //オブジェクトの空砲を呼び出す用
    AirShot ScriptAS;                        //オブジェクトの空砲を呼び出す用
    public void airShot(float Power , float Range , string Type,
                        float angleBase,
                        Vector3 myMouthTransform, Quaternion myRotation) {
        if (AirShotFirst == true) {
            ObjectAS = GameObject.Find("AirShot");
            ScriptAS = ObjectAS.GetComponent<AirShot>();
            AirShotFirst = false;
        }
        AirShot shot;
        SpriteRenderer SRshot;
        float Speed = 0.01f;    //弾速度
        int count = 1;          //一度に出る弾数
        float angleRange = 20;  //一度に複数の弾がでた場合の開角度
        // 弾を複数発射する場合
        if (1 < count) {
            // 発射する回数分ループする
            for (int i = 0; i < count; ++i) {
                var angle = angleBase + angleRange * ((float)i / (count - 1) - 0.5f);  // 弾の発射角度を計算する
                shot = Instantiate(ScriptAS, myMouthTransform, myRotation);            // 発射する弾を生成する
                shot.Power = Power;
                shot.Init(angle, Speed , Type);                                        // 弾を発射する方向と速さを設定する
                SRshot = shot.GetComponent<SpriteRenderer>();

                Destroy(SRshot, Range);
                Destroy(shot, Range);
                Destroy(shot.gameObject, Range+2);
            }
        }
        // 弾を 1 つだけ発射する場合
        else if (count == 1) {
            shot = Instantiate(ScriptAS, myMouthTransform, myRotation);  // 発射する弾を生成する
            shot.Power = Power;
            shot.Init(angleBase, Speed , Type);                          // 弾を発射する方向と速さを設定する
            SRshot = shot.GetComponent<SpriteRenderer>();

            Destroy(SRshot, Range);
            Destroy(shot, Range);
            Destroy(shot.gameObject, Range + 2);
        }
        AirShotCoolTimeCount = 0;
    }
    //空砲のクールダウン値のゲッターとセッター
    public float airShotIntervalTime {
        set {this.AirShotIntervalTime = value; }
        get {return AirShotIntervalTime; }
    }
    //空砲の現在のクールダウン値のゲッターとセッター
    public float airShotCoolTimeCount {
        set {this.AirShotCoolTimeCount = value; }
        get {return AirShotCoolTimeCount; }
    }


    //氷瀑：自身の口元から前方に、触れたら基礎攻撃力＊２倍、基礎攻撃速度＊１倍、基礎攻撃範囲＊４倍の弾を発射する。
    //引数　１自身の基礎攻撃力　２自身の基礎攻撃範囲　３自身のタイプ
    //　　　４自身の現在角度（360Ver）
    //　　　５自身の口の現在地点　６自身の現在角度
    private float IceExplodeIntervalTime = 1;   //氷瀑のクールダウン値
    private float IceExplodeCoolTimeCount = 0;  //氷瀑の現在のクールダウン値
    bool IceExplodeFirst = true;                //初めての氷瀑か？
    GameObject ObjectIE;                     //オブジェクトの氷瀑を呼び出す用
    IceExplode ScriptIE;                        //オブジェクトの氷瀑を呼び出す用
    public void iceExplode(float Power, float Range, string Type,
                        float angleBase,
                        Vector3 myMouthTransform, Quaternion myRotation) {
        if (IceExplodeFirst == true) {
            ObjectIE = GameObject.Find("IceExplode");
            ScriptIE = ObjectIE.GetComponent<IceExplode>();
            IceExplodeFirst = false;
        }
        IceExplode explode;
        SpriteRenderer SRexplode;
        float Speed = 0.015f;    //弾速度
        int count = 1;          //一度に出る弾数
        float angleRange = 20;  //一度に複数の弾がでた場合の開角度
        // 弾を複数発射する場合
        if (1 < count) {
            // 発射する回数分ループする
            for (int i = 0; i < count; ++i) {
                var angle = angleBase + angleRange * ((float)i / (count - 1) - 0.5f);  // 弾の発射角度を計算する
                explode = Instantiate(ScriptIE, myMouthTransform, myRotation);            // 発射する弾を生成する
                explode.Power = Power*2;
                explode.Init(angle, Speed, Type);                                        // 弾を発射する方向と速さを設定する
                SRexplode = explode.GetComponent<SpriteRenderer>();

                Destroy(SRexplode, Range * 4);
                Destroy(SRexplode, Range * 4);
                Destroy(SRexplode.gameObject, Range * 4 + 2);
            }
        }
        // 弾を 1 つだけ発射する場合
        else if (count == 1) {
            explode = Instantiate(ScriptIE, myMouthTransform, myRotation);  // 発射する弾を生成する
            explode.Power = Power*2;
            explode.Init(angleBase, Speed, Type);                          // 弾を発射する方向と速さを設定する
            SRexplode = explode.GetComponent<SpriteRenderer>();

            Destroy(SRexplode, Range * 4);
            Destroy(explode, Range * 4);
            Destroy(explode.gameObject, Range * 4 + 2);
        }
        IceExplodeCoolTimeCount = 0;
    }
    //空砲のクールダウン値のゲッターとセッター
    public float iceExplodeIntervalTime {
        set { this.IceExplodeIntervalTime = value; }
        get { return IceExplodeIntervalTime; }
    }
    //空砲の現在のクールダウン値のゲッターとセッター
    public float iceExplodeCoolTimeCount {
        set { this.IceExplodeCoolTimeCount = value; }
        get { return IceExplodeCoolTimeCount; }
    }


    //閃光：自身の口元から前方に、触れたら基礎攻撃力＊１倍、基礎攻撃速度＊１．５倍、基礎攻撃範囲＊４倍の弾を発射する。
    //引数　１自身の基礎攻撃力　２自身の基礎攻撃範囲　３自身のタイプ
    //　　　４自身の現在角度（360Ver）
    //　　　５自身の口の現在地点　６自身の現在角度
    private float FlashIntervalTime = 1.5f;   //空砲のクールダウン値
    private float FlashCoolTimeCount = 0;  //空砲の現在のクールダウン値
    bool FlashFirst = true;                //初めての空砲か？
    GameObject ObjectF;                     //オブジェクトの空砲を呼び出す用
    Flash ScriptF;                        //オブジェクトの空砲を呼び出す用
    public void flash(float Power, float Range, string Type,
                        float angleBase,
                        Vector3 myMouthTransform, Quaternion myRotation) {
        if (FlashFirst == true) {
            ObjectF = GameObject.Find("Flash");
            ScriptF = ObjectF.GetComponent<Flash>();
            FlashFirst = false;
        }
        Flash flash;
        SpriteRenderer SRflash;
        float Speed = 0.005f;    //弾速度
        int count = 1;          //一度に出る弾数
        float angleRange = 20;  //一度に複数の弾がでた場合の開角度
        // 弾を複数発射する場合
        if (1 < count) {
            // 発射する回数分ループする
            for (int i = 0; i < count; ++i) {
                var angle = angleBase + angleRange * ((float)i / (count - 1) - 0.5f);  // 弾の発射角度を計算する
                flash = Instantiate(ScriptF, myMouthTransform, myRotation);            // 発射する弾を生成する
                flash.Power = Power;
                flash.Init(angle, Speed, Type);                                        // 弾を発射する方向と速さを設定する
                SRflash = flash.GetComponent<SpriteRenderer>();

                Destroy(SRflash, Range*4);
                Destroy(flash, Range * 4);
                Destroy(flash.gameObject, Range * 4 + 2);
            }
        }
        // 弾を 1 つだけ発射する場合
        else if (count == 1) {
            flash = Instantiate(ScriptF, myMouthTransform, myRotation);  // 発射する弾を生成する
            flash.Power = Power;
            flash.Init(angleBase, Speed, Type);                          // 弾を発射する方向と速さを設定する
            SRflash = flash.GetComponent<SpriteRenderer>();

            Destroy(SRflash, Range * 4);
            Destroy(flash, Range * 4);
            Destroy(flash.gameObject, Range * 4 + 2);
        }
        FlashCoolTimeCount = 0;
    }
    //空砲のクールダウン値のゲッターとセッター
    public float flashIntervalTime {
        set { this.FlashIntervalTime = value; }
        get { return FlashIntervalTime; }
    }
    //空砲の現在のクールダウン値のゲッターとセッター
    public float flashCoolTimeCount {
        set { this.FlashCoolTimeCount = value; }
        get { return FlashCoolTimeCount; }
    }




}
