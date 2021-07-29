using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private Button btnNext;
    [SerializeField] private GameObject[] steps;
    [SerializeField] private int index = 0;

    private void Awake()
    {
        btnNext.onClick.AddListener(new UnityAction(Next));
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
            index = 0;
        }

        Refresh();
    }

    public void Refresh()
    {
        for (int i = 0; i < steps.Length; i++)
        {
            steps[i].SetActive(i == index);
        }
    }
}
