using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIPaperBoat : MonoBehaviour
{
    [SerializeField] private Button btnNext;
    [SerializeField] private Button btnRestart;
    [SerializeField] private Text txtTip;
    [SerializeField] private Animator aniSteps;

    [SerializeField] private GameObject[] steps;
    [SerializeField] private int index = 0;

    private void Awake()
    {
        btnNext.onClick.AddListener(new UnityAction(AniNext));
        btnRestart.onClick.AddListener(new UnityAction(Restart));

        btnNext.gameObject.SetActive(true);
        btnRestart.gameObject.SetActive(false);
        txtTip.gameObject.SetActive(false);
    }
    void Start()
    {
        Refresh();
    }

    public void Next()
    {
        index++;
        if (index >= steps.Length)
        {
            index--;

            btnNext.gameObject.SetActive(false);
            btnRestart.gameObject.SetActive(true);
            txtTip.gameObject.SetActive(true);
        }

        Refresh();
    }
    public void Restart()
    {
        index = 0;

        btnNext.gameObject.SetActive(true);
        btnRestart.gameObject.SetActive(false);
        txtTip.gameObject.SetActive(false);

        Refresh();
    }

    public void Refresh()
    {
        for (int i = 0; i < steps.Length; i++)
        {
            steps[i].SetActive(i == index);
        }
    }
    public void ShowSteps()
    {
        aniSteps.SetTrigger("Show");
    }
    public void HideSteps()
    {
        aniSteps.SetTrigger("Hide");
    }

    public void AniNext()
    {
        CancelInvoke();
        HideSteps();
        Invoke(nameof(ShowSteps), 1);
        Invoke(nameof(Next), 1);
    }
}
