using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColorButton : MonoBehaviour
{
    [SerializeField] private Color color;
    private UIPaperMan uiPaperMan;

    private void Start()
    {
        uiPaperMan = GetComponentInParent<UIPaperMan>();
        GetComponent<Button>().onClick.AddListener(delegate() { uiPaperMan.SetPartColor(color);  });
    }
}
