using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSequence : MonoBehaviour
{
    //フェード
    private float alpha;

    //フェードスピード
    [SerializeField]
    private float fadespeed;

    //遷移先シーン
    [SerializeField]
    private string NextScene = "Menu";

    //初期化
    void Awake()
    {
        //フェード準備
        alpha = 1;
    }

    //画面更新
    void Update()
    {
        //色を当てはめる
        GetComponent<Image>().color =
            new Color(0, 0, 0, alpha);
        if (alpha <= 0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    FadeManager.Instance.LoadScene(NextScene, 1.0f);
                }
            }
        }
        else
        {
            //フェードインする
            alpha -= fadespeed;
        }
    }
}
