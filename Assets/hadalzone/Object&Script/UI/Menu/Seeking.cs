using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//èäà‡ã≠âªÅBÉ{É^ÉìÇâüÇπÇŒã≠âªÇ≥ÇÍÇÈÇ∫

public class Seeking : MonoBehaviour
{
    [SerializeField] GameObject Player;

    private GameObject AddSkill;
    private bool ClickCheck = false;

    public void SeekingButton() {
        GameObject Skill = Instantiate(AddSkill,Player.transform.position,new Quaternion(0,0,0,0),Player.transform)as GameObject;
        Button button = this.GetComponent<Button>();
        button.interactable = false;
        ClickCheck = true;
    }

    public GameObject addSkill {
        set { AddSkill = value; }
    }

    public bool clickCheck {
        set { ClickCheck = value; }
        get { return ClickCheck; }
    }
}
