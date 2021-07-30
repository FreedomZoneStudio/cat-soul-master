using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ȫ������ͼƬ�ȱ�����������Ӧ
/// </summary>
[ExecuteInEditMode]
public class UIBGScaler : MonoBehaviour
{
    //ͼƬԭ��С(ѹ��ǰ��)
    public Vector2 textureOriginSize = new Vector2(2048, 1024);
    // Start is called before the first frame update
    void Start()
    {
        Scaler();
    }

    //����
    void Scaler()
    {
        //��ǰ�����ߴ�
        Vector2 canvasSize = gameObject.GetComponentInParent<Canvas>().GetComponent<RectTransform>().sizeDelta;
        //��ǰ�����ߴ糤���
        float screenxyRate = canvasSize.x / canvasSize.y;

        //ͼƬ�ߴ� ����õ��Ľ���� (0,0) ?
        //Vector2 bgSize = bg.mainTexture.texelSize;
        Vector2 bgSize = textureOriginSize;
        //��Ƶ�ߴ糤���
        float texturexyRate = bgSize.x / bgSize.y;

        RectTransform rt = (RectTransform)transform;
        //��Ƶxƫ��,��Ҫ����y��������ж� '>' ��Ϊ '<' ������Ƶ����������Ƶ��ʽ��
        if (texturexyRate > screenxyRate)
        {
            int newSizeY = Mathf.CeilToInt(canvasSize.y);
            int newSizeX = Mathf.CeilToInt((float)newSizeY / bgSize.y * bgSize.x);
            rt.sizeDelta = new Vector2(newSizeX, newSizeY);
        }
        else
        {
            int newVideoSizeX = Mathf.CeilToInt(canvasSize.x);
            int newVideoSizeY = Mathf.CeilToInt((float)newVideoSizeX / bgSize.x * bgSize.y);
            rt.sizeDelta = new Vector2(newVideoSizeX, newVideoSizeY);
        }
    }

    public void Update()
    {
#if UNITY_EDITOR
        //editorģʽ�²�����
        Scaler();
#endif
    }

}