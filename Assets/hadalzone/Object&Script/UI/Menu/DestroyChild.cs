using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//���g�̎q�����ׂĔj�󂷂�N���X

public class DestroyChild : MonoBehaviour
{
    private int count = -1;             //Count��0��1�̎��͔j�󂵂Ȃ��B�K�v�f�ނ�Panel�ɂ����Ď��g�̃I�u�W�F�N�g�Ɣj�󂵂����Ȃ�Text�����邩��ł���B
    public void DestroyChildren() {
        count = -1;
        GameObject[] childGameObjects = GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToArray();
        foreach (GameObject gameObject in childGameObjects) {
            count++;
            if (count==0 || count==1) {
                continue;
            }
            Destroy(gameObject);
        }
    }
}
