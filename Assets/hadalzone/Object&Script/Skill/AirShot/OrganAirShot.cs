using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

//AirShot��ł��߂̃N���X

public class OrganAirShot : MonoBehaviour
{
    Skill skill = new Skill();
    SeaCreature Status;        //�e��SeaCreature�ɃA�N�Z�X���Ċ�{�X�e�[�^�X�����

    void Start()
    {
        Status = this.gameObject.GetComponentInParent<SeaCreature>();
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[���X�V����
        skill.airShotCoolTimeCount += Time.deltaTime;
        if (skill.airShotCoolTimeCount > skill.airShotIntervalTime * Status.offensiveSpeed) {
            if (Input.GetMouseButton(0)) {
                // �e�𔭎˂���
                skill.airShot(Status.offensivePower, Status.offensiveRange, Status.creaturetype, Status.myangle.z + 90, Status.mymouthposition , Status.myrotation);
            }
        }
    }
}
