using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIPaperBoat : MonoBehaviour
{
    [SerializeField] private Button btnNext;
    [SerializeField] private Button btnApply;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private List<UIStep> steps;
    [SerializeField] private int index = 0;

    private void Awake()
    {
        btnNext.onClick.AddListener(new UnityAction(Next));
        btnApply.onClick.AddListener(delegate () {
            GetComponentInParent<UIManager>().AniGoToNextScene();
        });

        btnNext.gameObject.SetActive(true);
        btnApply.gameObject.SetActive(false);

        steps = GetComponentsInChildren<UIStep>(true).ToList();
    }
    private void Start()
    {
        for (int i = 0; i < steps.Count; i++)
        {
            steps[i].Disable();
        }

        Invoke(nameof(EnableCurrent), 1);
    }

    public void Next()
    {
        if (index + 1 < steps.Count)
        {
            steps[index].Hide();
            index++;
            steps[index].Enable();
            audioSource.Play();
        }

        if (index + 1 >= steps.Count)
        {
            btnNext.gameObject.SetActive(false);
            btnApply.gameObject.SetActive(true);
        }
    }

    private void EnableCurrent()
    {
        steps[index].Enable();
        //audioSource.Play();
    }
    private void DisableCurrent()
    {
        steps[index].Disable();
    }
}
