using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラのズームイン・アウトに合わせて、HPバーのParticalSystemのサイズを変更する処理

public class ScalingFitCamera : MonoBehaviour {

    [SerializeField] CinemachineVirtualCamera CMvcam;

    [SerializeField] ParticleSystem SFCameraParticleSystem;
    ParticleSystem.ShapeModule PSshape;
    ParticleSystem.EmissionModule PSemission;

    void Start()
    {
        PSshape = SFCameraParticleSystem.shape;
        PSemission = SFCameraParticleSystem.emission;
    }
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        if (CMvcam.m_Lens.OrthographicSize >= 10) {
            PSshape.scale = new Vector3(10, 0, 0);
            PSemission.rateOverTime = 1000;
        }
    }
}
