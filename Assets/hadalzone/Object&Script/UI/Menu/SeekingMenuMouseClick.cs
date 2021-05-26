using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//探求画面でのスキルボタンクリック時の処理

public class SeekingMenuMouseClick : MonoBehaviour
{
    [SerializeField] private GameObject ParentReleaseObject;  //自身のスキルから一つ前のスキル（初手は参照が根になる）のスキル解放判定を示すオブジェクト
    [SerializeField] private GameObject OwnReleaseObject;     //自身のスキルのスキル解放判定を示したり、アクティブ非アクティブを切り替える
    [SerializeField] private GameObject MyImageIcon;          //自身のスキルアイコン押せるときと押せないときで透明度を変えるよう

    [SerializeField] private string Name;  //自身のスキル名

    [SerializeField] private GameObject SkillDataBase;  //SkillDataBaseが付加されたゲームオブジェクト
    [SerializeField] private GameObject MaterialPanel;  //必要素材のPanel情報が必要なので、また、スキル詳細を切り替える際、生成したオブジェクトを破壊するためのもの
    [SerializeField] private GameObject ItemDataBase;   //スキル修得に必要な素材の表示が必要なので
    [SerializeField] private GameObject PlayerItemBox;  //スキル修得に必要な素材の内自身が所持している数の表示が必要なので

    [SerializeField] private GameObject SkillDetail;    //スキルの詳細を表示するためのGUIが付加されたゲームオブジェクト

    [SerializeField] private GameObject ObjectIcon;   //スキル詳細のアイコン部分
    [SerializeField] private GameObject ObjectName;   //スキル詳細の名前部分
    [SerializeField] private GameObject ObjectInfo;   //スキル詳細の解説部分
    [SerializeField] private GameObject ObjectValue;  //スキル修得に必要なアビスの数部分
    [SerializeField] private GameObject ObjectMaterial;  //スキル詳細の必要素材部分

    [SerializeField] private GameObject Seeking;      //強化（探求）ボタンのオブジェクト

    private Button OwnButton;
    Image MyIcon;

    Image SkillIcon;
    Text SkillName;
    Text SkillInfo;
    Text SkillValue;

    private SkillDB skilldb;
    private ItemDB itemdb;
    private PlayerItemBox ItemBox;

    private Seeking seeking;
    private Button SeekingButton;
    private List<bool> CanSeekingCheck = new List<bool>();       //現在のアイテム数と所持数でスキルの強化が可能かチェック用
    private List<string> DecreaseItemName = new List<string>();  //強化ボタンを押した際に修得に必要な素材を消費する時の素材名
    private List<int> DecreaseItemCount = new List<int>();       //強化ボタンを押した際に修得に必要な素材を消費する時の素材数
    private int DecreaseAbyss;                                   //強化ボタンを押した際に修得に必要なアビスを消費するとき用の変数

    private DestroyChild destroyChild;

    private void Start() {
        OwnButton = this.GetComponent<Button>();
        MyIcon = MyImageIcon.GetComponent<Image>();

        skilldb = SkillDataBase.GetComponent<SkillDB>();
        itemdb = ItemDataBase.GetComponent<ItemDB>();
        ItemBox = PlayerItemBox.GetComponent<PlayerItemBox>();

        SkillIcon = ObjectIcon.GetComponent<Image>();
        SkillName = ObjectName.GetComponent<Text>();
        SkillInfo = ObjectInfo.GetComponent<Text>();
        SkillValue = ObjectValue.GetComponent<Text>();

        seeking = Seeking.GetComponent<Seeking>();
        SeekingButton = Seeking.GetComponent<Button>();

        destroyChild = MaterialPanel.GetComponent<DestroyChild>();
    }

    private void Update() {
        if (OwnReleaseObject.activeSelf == true) {          //自身のスキルが強化済みの時
            OwnButton.interactable = false;
            return;
        }
        if (ParentReleaseObject.activeSelf == true) {       //親が強化済みの時
            OwnButton.interactable = true;
            this.gameObject.SetActive(true);
            var normalColor = OwnButton.colors.normalColor;
            normalColor.a = 0;
            MyIcon.color = new Color(1, 1, 1, 1f);
        }
        else {                                              //親が強化されていない場合
            OwnButton.interactable = false;
            var normalColor = OwnButton.colors.normalColor;
            normalColor.a = 1;
            MyIcon.color = new Color(0,0,0,0.3f);
        }
        if (SkillName.text == Name) {                       //自身のスキル強化がクリックされた時
            if (seeking.clickCheck == true) {
                OwnReleaseObject.SetActive(true);
                int DIcount = 0;                                 //下のStringのForeachとDecreaseItemCountを並行して進める用
                foreach (string itemname in DecreaseItemName) {  //指定された材料分の素材・アビスを自身のバックから減らす
                    ItemBox.GetPlayerItem(itemname).SetGetPlayerItemCount = DecreaseItemCount[DIcount];
                    ItemBox.GetPlayerItem("アビス").SetGetPlayerItemCount = DecreaseAbyss;
                    DIcount++;
                    break;
                }
            }
            seeking.clickCheck = false;
        }
    }

    public void SkillClick() {
        DecreaseAbyss = 0;               //スキル詳細を切り替える際、強化に使用し、変更するはずだった所持アビスの値を初期化している
        DecreaseItemName.Clear();        //スキル詳細を切り替える際、強化に使用し、変更するはずだった所持素材のList（名前）を初期化している
        DecreaseItemCount.Clear();       //スキル詳細を切り替える際、強化に使用し、変更するはずだった所持素材のList（所持数）を初期化している
        CanSeekingCheck.Clear();         //スキル詳細を切り替える際、所持素材数と必要素材数の比較を行い、強化可能かを必要素材ごとに判断するListを初期化している
        destroyChild.DestroyChildren();  //スキル詳細を切り替える際、生成したオブジェクトを破壊するためのもの
        if (SkillDetail.activeSelf == false) {
            SkillDetail.SetActive(true);
            InputSkillData();
        }
        else {
            if (SkillName.text != Name) {
                InputSkillData();
                return;
            }
            SkillDetail.SetActive(false);
        }
    }

    //簡易にするためにメソッド化
    private void InputSkillData() {
        SkillIcon.sprite = skilldb.GetSkillData(Name).GetSkillIcon;  //スキル詳細のアイコンを表示
        SkillName.text = skilldb.GetSkillData(Name).GetSkillName;    //スキル詳細の名前を表示
        SkillInfo.text = skilldb.GetSkillData(Name).GetSkillInfo;    //スキル詳細の解説を表示
        SkillValue.text = skilldb.GetSkillData(Name).GetSkillValue.ToString();  //スキル詳細の修得必要アビス数を表示

        seeking.addSkill = skilldb.GetSkillData(Name).GetSkillObject;//スキル修得ボタンを押した際に修得するスキルをセットする

        //スキル修得に必要な素材を表示（生成）
        List<int> materialAmount = skilldb.GetSkillData(Name).GetSkillMaterialAmount;                       //各素材ごとに必要な素材の数のListをSkillDBから作成
        int MAcount = 0;                                                                                    //materialAmountのListの添え字番号用
        List<PlayerItemManager> PlayerItemList = ItemBox.GetPlayerItemList;                                 //アイテムボックス上にデータが存在するかどうかの検知用
        float BoxPosition = 0;                                                                              //ループごとに位置の調整が必要なのでそれ用

        foreach (string Materialname in skilldb.GetSkillData(Name).GetSkillMaterial) {                      //修得に必要な全ての素材が生成されるまでForEach
            int HaveMaterial = 0;                                                                           //必要素材に指定された素材の数が0個ならばそもそもアイテムボックス上に存在しないアイテムとなるので、エラーが出るためそれを防止する用の橋渡し変数
            GameObject Material = Instantiate(ObjectMaterial,                                               //素材のテンプレートBoxを作成
                                              new Vector2(MaterialPanel.transform.position.x, MaterialPanel.transform.position.y + 0.75f - BoxPosition),//テンプレートの位置
                                              Quaternion.identity,                                          //テンプレートの角度
                                              MaterialPanel.transform) as GameObject;                       //テンプレートの階層（MaterialPanelが親です）

            bool Success = false;                                                                           //所持数が必要個数以上の時に通るIfを通過したか？
            if (ItemBox.GetPlayerItem(Materialname).GetPlayerItemName != null) {                            //アイテムボックス上に指定されたアイテムが存在するか
                HaveMaterial = ItemBox.GetPlayerItem(Materialname).SetGetPlayerItemCount;                   //あればCountを代入。
                if (HaveMaterial >= materialAmount[MAcount]) {                                              //さらに必要個数と比較して必要個数以上ならTrueを返し、強化した時用に所持数から必要数を引いた値を記憶させておく
                    CanSeekingCheck.Add(true);
                    DecreaseItemName.Add(Materialname);
                    DecreaseItemCount.Add(HaveMaterial - materialAmount[MAcount]);
                    Success = true;
                }
            }
            if (Success == false) {                                                                         //必要個数以下ならばFalseを返す
                CanSeekingCheck.Add(false);
            }

            NeedMaterial needMaterial = Material.GetComponent<NeedMaterial>();                              //生成したテンプレートからスクリプトを取得
            needMaterial.Initial(itemdb.GetItemData(Materialname).GetItemIcon,                              //テンプレートに素材画像を貼る
                                 Materialname,                                                              //テンプレートに素材名を描画
                                 materialAmount[MAcount].ToString(),                                        //テンプレートに必要素材数を描画
                                 HaveMaterial.ToString());                                                  //テンプレートに所持素材数を描画
            MAcount++;
            BoxPosition += 0.35f;
        }                                                                                                   //ループごとに次の必要素材とテンプレートの位置が調整される

        bool MaterialHaveCheck = true;                                                                      //必要素材がそろっており、かつアビスも足りているなら強化（探求）ボタンを押せるようにする処理
        foreach (bool check in CanSeekingCheck) {
            if (check == false) {
                MaterialHaveCheck = false;
                break;
            }
        }
        if (MaterialHaveCheck == true && ItemBox.GetPlayerItem("アビス").SetGetPlayerItemCount >= skilldb.GetSkillData(Name).GetSkillValue) {
            DecreaseAbyss = ItemBox.GetPlayerItem("アビス").SetGetPlayerItemCount - skilldb.GetSkillData(Name).GetSkillValue;
            SeekingButton.interactable = true;
        }
        else {
            SeekingButton.interactable = false;
        }
    }
}
