using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�X�L��IceExplode�̃I�u�W�F�N�g�ɂ�����X�N���v�g

public class IceExplode : MonoBehaviour {
    [SerializeField] GameObject HitIceExplode;
    [SerializeField] SpriteRenderer IEspriteRenderer;
    [SerializeField] ParticleSystem IEparticleSystem;

    private Vector3 Velocity;
    public float Power;

    SkillConvenience Sconvenience = new SkillConvenience();

    private void Start() {
    }

    void Update() {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        //�e�̈ړ�
        transform.localPosition += Velocity;
        transform.Rotate(0,0,0.5f);
        if (this.gameObject.tag != "ReferenceObject") {
            transform.localScale += new Vector3(0.01f, 0.01f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != "EnemySense") {
            Sconvenience.BasicBridgingDamage(collision, Power * 1, transform.position, gameObject.layer);
            GameObject HIEclone = Instantiate(HitIceExplode, transform.position, transform.rotation) as GameObject;
            Destroy(HIEclone, 1.3f);
            Destroy(IEspriteRenderer);
            Destroy(this);
        }
    }

    public void Init(float angle, float speed, string Type) {
        //���˂������݂̃^�C�v�ɂ���ă��C���[��ύX����
        gameObject.layer = Sconvenience.LayerChange(Type);
        //���˂������݂̃^�C�v�ɂ���ă^�O��ύX����
        gameObject.tag = Sconvenience.TagChange(Type);

        //���ˊp�x���x�N�g���ɕϊ�
        var direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
        //�x�N�g���Ƒ������瑬�x���Z�o
        Velocity = direction * speed;

        //�e���i�s����������
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

    }
}
