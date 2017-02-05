using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSequence : MonoBehaviour
{
    //フェード
    [SerializeField]
    private GameObject FadeObj;
    private Fade _Fade;

    //シーケンススイッチ
    private int titleSwicth;
    //フェードスピード
    [SerializeField]
    private float fadespeed;

    //初期化
    void Awake()
    {
        //フェード準備
        _Fade = FadeObj.GetComponent<Fade>();

        titleSwicth = 0;
    }

    //画面更新
    void Update()
    {

        Debug.Log(titleSwicth);

        switch (titleSwicth)
        {
            case 0:
                //初期化
                StartCoroutine(_Fade.reset(0, 0, 0, 1));
                //終わったら次のスイッチ
                titleSwicth = 1;
                break;
            case 1:
                _Fade.Fadein(fadespeed);
                //フェード終了
                if (_Fade.alpha <= 0)
                {
                    //FadeObj.SetActive(false);
                    ++titleSwicth;
                }
                break;
            case 2:

                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        //FadeObj.SetActive(true);
                        ++titleSwicth;
                    }
                }

                break;
            case 3:
                _Fade.Fadeout(fadespeed);
                if (_Fade.alpha >= 1)
                {
                    ++titleSwicth;
                }
                break;
            case 4:
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
