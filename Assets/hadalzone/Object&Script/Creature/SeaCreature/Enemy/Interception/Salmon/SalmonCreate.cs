using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalmonCreate : MonoBehaviour
{
    public GameObject Salmon;
    void Start()
    {
        GameObject cloneSalmon = Instantiate(Salmon, new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
        cloneSalmon.name = "Salmon";
    }
}
