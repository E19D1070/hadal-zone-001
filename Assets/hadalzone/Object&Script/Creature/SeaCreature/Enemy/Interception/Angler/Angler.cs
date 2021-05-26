using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�G�L�����N�^�[�A��߂̃N���X�B

class Angler : Interception {
    private bool ItemDropCheck = false;  //�A�C�e���h���b�v�͈�񂾂��ł����I����𔻒肷�邽�߂�Bool
    private int HavaAbyss = 7;           //�h���b�v����A�r�X�̗�

    public float TerritoryRange;      //�G�̈ړ��͈�
    public float LookSpeed;           //�w��n�_�Ɍ������x
    public float NormalSpeed;         //�ʏ펞�̑��x
    public float HostileStateSpeed;   //�G�Ύ��̃X�s�[�h

    public float RemaindCautionTime;  //�x����Ԏ��A�ǂꂾ���̎��ԂŌx�����������邩�p
    float RemaindCautionCount = 0;    //�x����Ԏ��A��莞�Ԍo�߂Ōx�����������邽�߂̎��Ԍv���p

    public float RemaindHostileTime;  //�퓬��Ԏ��AVisbleArea����Player������Ă��i���Ԏw��j�̊Ԃ͐퓬��Ԃ𑱂���p
    float RemaindHostileCount = 0;    //�퓬��Ԏ��A��莞�Ԍo�߂Ő퓬���������邽�߂̎��Ԍv���p

    public float WaitRandomMoveTime;  //�����_���ړ����̖ڕW�n�_�ɓ��B���Ă��玟�̖ڕW�n�_�ɍs���܂ł̑ҋ@����
    float RandomMoveDistance;         //�����_���ړ����̎��g�̒n�_����ڕW�n�_�܂ł̋���
    float WaitRandomMove;             //�����_���ړ����̖ڕW�n�_�ɓ��B���Ă��玟�̖ڕW�n�_�ɍs���܂ł̑ҋ@���Ԃ̎��Ԍv���p
    Vector3 randomposition;           //�����_���ړ����̖ڕW�n�_

    EnemyView enemyView = new EnemyView();
    NormalStateMove normalmove = new NormalStateMove();

    private void Start() {
        RandomMoveDistance = 0;
        WaitRandomMove = 0;
        randomposition = generatePoint;
        goreCheck = 0.75f;
        for (int a = 1; a <= HavaAbyss; a++) {
            HaveItem.Add(Resources.Load(itemAddress + "Abyss", typeof(GameObject)) as GameObject);
        }
    }
    private void Update() {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        DieCheck();

        //HP�����ȉ��ɂȂ�Ɨ����������Ăяo��
        if (hp / maxhp <= goreCheck) {
            if (hp > 0) {
                GoreEffect();
                goreCheck -= 0.25f;
            }
            else {
                GoreAnActive();
                //���S������A�C�e�����h���b�v����
                if (ItemDropCheck == false) {
                    ItemDrop(2f, 3f);
                    ItemDropCheck = true;
                }
            }
        }

        if (alive == true) {
            myposition = transform.localPosition;
            myrotation = transform.localRotation;
            myangle = transform.localEulerAngles;

            //Player���F���͈͂ɓ��������ɔF����Ԃɂ��A�o������F����Ԃɂ���
            if (playerRecognizeSpace == true && cautionState == false && hostileState == false) {
                recognizeState = true;
            }
            if (playerRecognizeSpace == false) {
                recognizeState = false;
            }

            //Player��F�����Ă��Ȃ��Ƃ��̏���
            if (recognizeState == false && cautionState == false && hostileState == false) {
                NormalMove();
            }

            //�F����Ԃ̎��̏���
            if (recognizeState == true) {
                NormalMove();
                if (playerVisibleSpace == true || playerAttackPersonalSpace == true) {//Player�����E�͈́A�܂���Player�̍U�����͈̔͂ɓ���Όx����Ԃ�
                    cautionState = true;
                    recognizeState = false;
                }
                if (coreTouch == true) {//�U����������ΓG�Ώ�Ԃ�
                    hostileState = true;
                    recognizeState = false;
                }
            }

            //�x����Ԃ̎��̏���
            if (cautionState == true) {
                RemaindCautionCount += Time.deltaTime;
                if (RemaindCautionCount > RemaindCautionTime) {//Player����莞�ԍU�����Ȃ����NormalMove���s��
                    NormalMove();
                }
                if (RemaindCautionCount <= RemaindCautionTime) {
                    Caution();
                }
                if (playerPersonalSpace == true || playerAttackVisibleSpace == true) {//Player���͈̔́A�܂���Player�̍U�������E�͈͂ɓ���ΓG�Ώ�Ԃ�
                    hostileState = true;
                    cautionState = false;
                    RemaindCautionCount = 0;
                }
                if (playerRecognizeSpace == false) {//Player���F���͈͂���o���Ȃ�x������
                    cautionState = false;
                    RemaindCautionCount = 0;
                }
            }

            //�G�Ώ�Ԃ̎�
            if (hostileState == true) {
                Intercept();
                if (playerVisibleSpace == false && playerAttackVisibleSpace == false) {//Player��Player�̍U�������o�͈͂ɓ���Ȃ���Ԃ���莞�ԑ����ƓG�Ώ�Ԃ���������F����ԂɈڍs����
                    RemaindHostileCount += Time.deltaTime;
                    if (RemaindHostileCount >= RemaindHostileTime) {
                        hostileState = false;
                        recognizeState = true;
                        RemaindHostileCount = 0;
                    }
                }
                if (playerVisibleSpace == true || playerAttackVisibleSpace == true) {
                    RemaindHostileCount = 0;
                }
            }

            //Enemy�̕ߐH�Ăяo���֐����Ăяo��
            EnemyPrey(offensivePower, offensiveSpeed);

            EmotionIcon();

            coreTouch = false;
        }
    }



    //�x����ԂɂȂ�ƌĂяo�����֐��B��������Ƃ���������Ă���B
    public override void Caution() {
        transform.localRotation = enemyView.LookPlayer(player, myposition, myrotation, LookSpeed);
        transform.localScale = enemyView.Reversi(myrotation);
    }

    //�G�Ώ�ԂɂȂ�ƌĂяo�����֐��B���̋�����ۂ��Ă�������U�����Ă���
    public override void Intercept() {
        transform.localRotation = enemyView.LookPlayer(player, myposition, myrotation, LookSpeed * 1.5f);//Player������
        transform.localScale = enemyView.Reversi(myrotation);

        SKILL.flashCoolTimeCount += Time.deltaTime;//�e�̔���
        if (SKILL.flashCoolTimeCount > SKILL.flashIntervalTime * offensiveSpeed) {
            SKILL.flash(offensivePower, offensiveRange, creaturetype, myangle.z + 95, preyMouth.MouthPosition, myrotation);
        }

        float dis = Vector2.Distance(transform.position, player.transform.position);//���g��Player�̋������v�����ċ����ɂ���ċ߂Â����藣�ꂽ�肷��
        if (dis >= 2) {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, player.transform.position, HostileStateSpeed * 0.005f);
        }
        if (dis <= 1) {
            var direction = new Vector3(Mathf.Cos((myangle.z + 90) * Mathf.Deg2Rad), Mathf.Sin((myangle.z + 90) * Mathf.Deg2Rad), 0);
            transform.localPosition -= direction * (HostileStateSpeed * 0.0025f);
        }
    }

    //���͈͓̔��������_���ňړ�����
    public void NormalMove() {
        if (RandomMoveDistance == 0) {
            WaitRandomMove += Time.deltaTime;
            if (WaitRandomMove >= WaitRandomMoveTime) {
                randomposition = normalmove.RandomMoveInTheTerritory(generatePoint, TerritoryRange);
                Debug.Log(randomposition);
                WaitRandomMove = 0;
            }
        }
        if (RandomMoveDistance != 0) {
            transform.localRotation = enemyView.LookPoint(randomposition, myposition, myrotation, LookSpeed);
            transform.localScale = enemyView.Reversi(myrotation);
        }
        RandomMoveDistance = Vector2.Distance(transform.localPosition, randomposition);
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, randomposition, 0.01f * NormalSpeed);
    }
}
