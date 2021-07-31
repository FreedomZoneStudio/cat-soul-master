using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Animator aniMask;
    [SerializeField] private string nextScene;

    private void Start()
    {
        HideMask();
    }


    public void Quit()
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

    public void AniGoToNextScene()
    {
        CancelInvoke();
        ShowMask();
        Invoke(nameof(GoToNextScene), 1);
    }

    public void GoToNextScene()
    {
        if (string.IsNullOrEmpty(nextScene))
        {
            Debug.LogError("未设置下个场景");
        }
        else
        {
            Debug.Log("前往下个场景：" + nextScene);
            SceneManager.LoadScene(nextScene);
        }
    }
}
