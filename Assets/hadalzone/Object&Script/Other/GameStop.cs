using UnityEngine;

//ゲームを停止する機能

public class GameStop : MonoBehaviour
{
    [SerializeField] private GameObject AllMenu;
    [SerializeField] private GameObject MainMenu;
    void Update()
    {
        if (Input.GetKeyDown("m")) {
            if (AllMenu.activeSelf == true && MainMenu.activeSelf == true) {
                //動きだす
                Time.timeScale = 1f;
                AllMenu.SetActive(false);
            }
            else{
                //止まりだす
                Time.timeScale = 0f;
                AllMenu.SetActive(true);
            }
        }
    }
}
