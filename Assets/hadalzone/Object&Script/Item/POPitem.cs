using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//�A�C�e�������ۂɃ|�b�v�������̏���
//�A�C�e���̎擾�A�A�j���[�V�������������s���B

public class POPitem : MonoBehaviour
{
    [SerializeField] private GameObject ParticleEffect;
    [SerializeField] private GameObject GetItemText;
    [SerializeField] private GameObject Appearance1;
    [SerializeField] private GameObject Appearance2;
    [SerializeField] private string ThisItemName;

    private List<SpriteRenderer> spriterend = new List<SpriteRenderer>();

    private Rigidbody2D ItemRigidbody2D;

    void Start()
    {
        ItemRigidbody2D = this.GetComponent<Rigidbody2D>();
        spriterend.Add(this.GetComponent<SpriteRenderer>());
        if (Appearance1 != null && Appearance2 != null) {
            spriterend.Add(Appearance1.GetComponent<SpriteRenderer>());
            spriterend.Add(Appearance2.GetComponent<SpriteRenderer>());
        }
    }

    private float a = 0.4f;
    private void Update() {//�A�C�e���̌�������
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }

        if (ItemRigidbody2D.velocity.x < 0) {
            ItemRigidbody2D.AddForce(Vector2.right * a);
        }
        if (ItemRigidbody2D.velocity.x > 0) {
            ItemRigidbody2D.AddForce(Vector2.left * a);
        }
        if (ItemRigidbody2D.velocity.y < 0) {
            ItemRigidbody2D.AddForce(Vector2.up * a);
        }
        if (ItemRigidbody2D.velocity.y > 0) {
            ItemRigidbody2D.AddForce(Vector2.down * a);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        var PlayerItem = collision.gameObject.GetComponent<BridgeItemName>();  //�Փ˕��̋��n���R���|�[�l���g�擾���Ă���
        if (PlayerItem != null) {
            PlayerItem.Item(ThisItemName);  //���g�̃A�C�e�������󂯓n���āA���̌�G����Ȃ��I�u�W�F�N�g�Ƀ��C���[�i�ƈꉞ�^�O���j��ύX����
            this.gameObject.layer = 8;
            this.gameObject.tag = "ReferenceObject";

            if (ThisItemName != "�A�r�X") {//�A�r�X�K�����́o�p���̃G�t�F�N�g�͍s��Ȃ�
                foreach (SpriteRenderer renderer in spriterend) {  //Player�ɐG�ꂽ�瓧���x�����X�ɂO�ɂ���(�t����Appearance�������ɂ��Ȃ���΂����Ȃ��̂�ForEach�ŉ񂵂Ă���)�B
                    DOTween.ToAlpha(
                        () => renderer.color,
                        x => renderer.color = x,
                        0f,
                        1f
                    );
                }
                transform.DOMoveY(transform.position.y+0.4f,2f);  //Player�ɐG�ꂽ��㏸����B

                GetItemText.GetComponentInChildren<Text>().text = ThisItemName;  //Player�ɐG�ꂽ��A�C�e������\������
                GameObject GITclone = Instantiate(GetItemText, transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
                Destroy(GITclone, 3f);
            }
            else {//�A�r�X�̏ꍇ�p�[�e�B�N�����I�����A���g��Destroy�����܂Ŕ�A�N�e�B�u�ɂ��Ă���
                this.gameObject.SetActive(false);
            }

            GameObject PEobject  = Instantiate(ParticleEffect,transform.position,transform.rotation);  //�p�[�e�B�N���𔭐�
            Destroy(PEobject, 2f);
            Destroy(this.gameObject,1.5f);
        }
    }
}
