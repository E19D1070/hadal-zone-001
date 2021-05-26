using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    Enemy enemy;

    private void Start() {
        enemy = gameObject.GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)//Playerの攻撃がCoreに触れた時。
    {
        enemy.coreTouch = true;
    }
}
