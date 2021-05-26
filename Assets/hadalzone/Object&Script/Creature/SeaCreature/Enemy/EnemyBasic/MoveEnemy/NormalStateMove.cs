using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStateMove
{
    //指定された範囲内の座標をランダムで返す
    //引数　１範囲基準点　２範囲基準点からどれぐらいの距離を範囲とするか（半径）
    public Vector2 RandomMoveInTheTerritory(Vector2 generatepoint , float territoryrange)
    {
        float RandomPositionX = UnityEngine.Random.Range(generatepoint.x - territoryrange, generatepoint.x + territoryrange);
        float RandomPositionY = UnityEngine.Random.Range(generatepoint.y - territoryrange, generatepoint.y + territoryrange);
        Vector2 RandomPosition = new Vector2(RandomPositionX,RandomPositionY);
        return RandomPosition;
    }
}


