using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanelManger : MonoBehaviour
{

    public Button AgainButton;
    public Button GameOverButton;

    public int LevelNum = 1;

    // Start is called before the first frame update
    void Start()
    {

        AgainButton.onClick.AddListener(AgainButtonLis);
        GameOverButton.onClick.AddListener(GameOverButtonClickListener);
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AgainButtonLis()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(LevelNum);
    }

    void GameOverButtonClickListener()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }

}
