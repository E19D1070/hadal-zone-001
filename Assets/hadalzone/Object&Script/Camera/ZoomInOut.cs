using Cinemachine;
using UnityEngine;
using DG.Tweening;

//カメラをズームイン・アウトする処理
public class ZoomInOut : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera CMvcam;
    float[] Diameter = {2,4,6};
    float waitTime = 0.5f;
    float Zoom;
    int count = 1;

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        if (Input.GetKeyDown(KeyCode.G)){
            if (count == 0) {
                Zoom = Diameter[count];
            }
            if (count == 1) {
                Zoom = Diameter[count];
            }
            if (count == 2) {
                Zoom = Diameter[count];
            }

            DOTween.To(
                () => CMvcam.m_Lens.OrthographicSize,
                x => CMvcam.m_Lens.OrthographicSize = x,
                Zoom,
                waitTime
                );

            count++;
            if (count >= 3) {
                count=0;
            }
        }
    }
}
