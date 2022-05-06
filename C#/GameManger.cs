using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{


    public static GameManger Instance;

    public int KCNum = 0;
    public Text KCScoreText;

    public Text Timetext;
    public float TimeNum = 300;
    public bool IsRun = true;
    public AudioSource TimeSound;
    public AudioSource RightSound;

    public GameObject WinPanle;
    public GameObject LosePanle;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRun == true)
        {
            if (TimeNum > 0)
            {
                TimeNum -= Time.deltaTime;
                Timetext.text = TimeNum.ToString("0");
            }
            else
            {
                LoseLis();
            }
        }
    }

    public void AddKCScore()
    {
        KCNum = KCNum + 1;
        KCScoreText.text = KCNum.ToString("0");
        if (KCNum >= 10)
        {
            IsRun = false;
            Time.timeScale = 0;
            WinPanle.SetActive(true);
        }
    }


    public void LoseLis()
    {
        Time.timeScale = 0;

        IsRun = false;
        TimeNum = 0;
        Timetext.text = TimeNum.ToString("0");
        TimeSound.Play();
        LosePanle.SetActive(true);
    }

}
