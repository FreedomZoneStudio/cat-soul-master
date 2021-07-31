using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPaperMan : MonoBehaviour
{
    [SerializeField] private Button btnApply;

    [SerializeField] private Button btnBody;
    [SerializeField] private Button btnHeart;
    [SerializeField] private Button btnLHand;
    [SerializeField] private Button btnRHand;
    [SerializeField] private Button btnLFoot;
    [SerializeField] private Button btnRFoot;

    [SerializeField] private Text txtTip;
    private string[] parts = new string[]{ "身体", "中心", "左手", "右手", "左脚", "右脚" };
    private bool[] finish = new bool[] { false, false, false, false, false, false };

    public int part = 0;

    private void Start()
    {
        txtTip.gameObject.SetActive(true);
        btnApply.gameObject.SetActive(false);
        btnApply.onClick.AddListener(delegate () {
            GetComponentInParent<UIManager>().AniGoToNextScene();
        });

        btnBody.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        btnHeart.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        btnLHand.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        btnRHand.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        btnLFoot.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        btnRFoot.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;

        btnBody.onClick.AddListener(delegate(){ SetPart(0); });
        btnHeart.onClick.AddListener(delegate () { SetPart(1); });
        btnLHand.onClick.AddListener(delegate () { SetPart(2); });
        btnRHand.onClick.AddListener(delegate () { SetPart(3); });
        btnLFoot.onClick.AddListener(delegate () { SetPart(4); });
        btnRFoot.onClick.AddListener(delegate () { SetPart(5); });
    }

    private void OnEnable()
    {
    }

    public void SetPart(int id)
    {
        part = id;

        txtTip.text = "当前选中：" + parts[id];
    }

    public void SetPartColor(Color color)
    {
        switch (part)
        {
            case 0:
                btnBody.GetComponent<Image>().color = color;
                break;
            case 1:
                btnHeart.GetComponent<Image>().color = color;
                break;
            case 2:
                btnLHand.GetComponent<Image>().color = color;
                break;
            case 3:
                btnRHand.GetComponent<Image>().color = color;
                break;
            case 4:
                btnLFoot.GetComponent<Image>().color = color;
                break;
            case 5:
                btnRFoot.GetComponent<Image>().color = color;
                break;
            default:
                break;
        }

        finish[part] = true;
        bool allFinish = true;
        foreach (bool item in finish)
        {
            if (item == false)
            {
                allFinish = false;
                break;
            }
        }
        if (allFinish)
        {
            btnApply.gameObject.SetActive(true);
            txtTip.gameObject.SetActive(false);
        }
    }
}
