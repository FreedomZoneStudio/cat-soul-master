using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIPaperBoat uiPaperBoat;
    [SerializeField] private UIPaperMan uiPaperMan;
    [SerializeField] private Animator aniMask;

    [SerializeField] private Button btnExit;
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnBoat;
    [SerializeField] private Button btnMan;

    private void Start()
    {
        btnExit.onClick.AddListener(new UnityAction(Exit));
        btnBack.onClick.AddListener(new UnityAction(AniBack));
        btnBoat.onClick.AddListener(new UnityAction(AniShowUIPaperBoat));
        btnMan.onClick.AddListener(new UnityAction(AniShowUIPaperMan));

        Back();
    }

    public void Back()
    {
        uiPaperBoat.gameObject.SetActive(false);
        uiPaperMan.gameObject.SetActive(false);

        btnExit.gameObject.SetActive(true);
        btnBack.gameObject.SetActive(false);
        btnBoat.gameObject.SetActive(true);
        btnMan.gameObject.SetActive(true);
    }
    public void ShowUIPaperBoat()
    {
        uiPaperBoat.gameObject.SetActive(true);
        uiPaperMan.gameObject.SetActive(false);

        btnExit.gameObject.SetActive(false);
        btnBack.gameObject.SetActive(true);
        btnBoat.gameObject.SetActive(false);
        btnMan.gameObject.SetActive(false);
    }
    public void ShowUIPaperMan()
    {
        uiPaperBoat.gameObject.SetActive(false);
        uiPaperMan.gameObject.SetActive(true);

        btnExit.gameObject.SetActive(false);
        btnBack.gameObject.SetActive(true);
        btnBoat.gameObject.SetActive(false);
        btnMan.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowMask()
    {
        aniMask.SetTrigger("Show");
    }
    public void HideMask()
    {
        aniMask.SetTrigger("Hide");
    }

    public void AniBack()
    {
        CancelInvoke();
        ShowMask();
        Invoke(nameof(HideMask), 1);
        Invoke(nameof(Back), 1);
    }
    public void AniShowUIPaperBoat()
    {
        CancelInvoke();
        ShowMask();
        Invoke(nameof(HideMask), 1);
        Invoke(nameof(ShowUIPaperBoat), 1);
    }
    public void AniShowUIPaperMan()
    {
        CancelInvoke();
        ShowMask();
        Invoke(nameof(HideMask), 1);
        Invoke(nameof(ShowUIPaperMan), 1);
    }
}
