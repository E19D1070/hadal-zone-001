using UnityEngine;
using UnityEngine.EventSystems;

//マウスカーソルが触れているか触れていないか＋クリックがされたかを判定するクラス
//ボタンにこのクラスを使用して、Appearanceの方に値を渡す。

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] private GameObject RotateAppearance;
    Rotate rotate;

    [SerializeField] private GameObject ChildMenu;
    [SerializeField] private GameObject ParentMenu;

    void Start()
    {
        rotate = RotateAppearance.GetComponent<Rotate>();
    }

    //クリックされた時
    public void OnClick() {
        ChildMenu.SetActive(true);
        ParentMenu.SetActive(false);
    }

    //マウスカーソルがボタンの範囲内に入った時
    public void OnPointerEnter(PointerEventData eventData) {
        rotate.mouthPoint = true;
    }

    //マウスカーソルがボタンの範囲外になった時
    public void OnPointerExit(PointerEventData eventData) {
        rotate.mouthPoint = false;
    }
}
