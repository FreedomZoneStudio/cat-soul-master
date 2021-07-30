using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStep : MonoBehaviour
{
    public void Show()
    {
        GetComponent<Animator>().SetTrigger("Show");
    }


    public void Hide()
    {
        GetComponent<Animator>().SetTrigger("Hide");
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
