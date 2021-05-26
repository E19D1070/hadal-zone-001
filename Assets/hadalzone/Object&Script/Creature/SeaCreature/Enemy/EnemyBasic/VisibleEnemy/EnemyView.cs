using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView
{
    //自身の角度が0度以上ならばイラストは表、0度未満ならば裏返す関数。
    //引数　１自身の現在角度
    public Vector3 Reversi(Quaternion myrotation) {
        if (myrotation.z <= 0 || myrotation.w <= 0)
        {
            return new Vector3(1, 1, 1);
        }
        else
        {
            return new Vector3(-1, 1, 1);
        }
    }

    //プレイヤーの方を向く関数。向く速度はlookspeedの実引数から変更可能
    //引数　１プレイヤーの位置　２自身の現在位置　３自身の現在角度　４回転スピード
    public Quaternion LookPlayer(GameObject player , Vector3 myposition, Quaternion myrotation , float lookspeed)
    {
        Vector3 PlayerPosition = player.transform.position;
        Quaternion Rotate = Quaternion.LookRotation(Vector3.forward, PlayerPosition - myposition);
        Quaternion Rotation = Quaternion.Slerp(myrotation, Rotate, Time.deltaTime * lookspeed);
        return Rotation;
    }

    //プレイヤーの逆の方を向く関数。向く速度はlookspeedの実引数から変更可能
    //引数　１プレイヤーの位置　２自身の現在位置　３自身の現在角度　４回転スピード
    public Quaternion LookAnPlayer(GameObject player, Vector3 myposition, Quaternion myrotation, float lookspeed) {
        Vector3 PlayerPosition = player.transform.position;
        Quaternion Rotate = Quaternion.LookRotation(Vector3.forward, -PlayerPosition + myposition);
        Quaternion Rotation = Quaternion.Slerp(myrotation, Rotate, Time.deltaTime * lookspeed);
        return Rotation;
    }

    //指定された方を向く関数。向く速度はlookspeedの実引数から変更可能
    //引数　１指定された位置　２自身の現在位置　３自身の現在角度　４回転スピード
    public Quaternion LookPoint(Vector3 point, Vector3 myposition, Quaternion myrotation, float lookspeed)
    {
        Quaternion Rotate = Quaternion.LookRotation(Vector3.forward, point - myposition);
        Quaternion Rotation = Quaternion.Slerp(myrotation, Rotate, Time.deltaTime * lookspeed);
        return Rotation;
    }

}
