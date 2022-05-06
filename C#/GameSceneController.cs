using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameSceneController : MonoBehaviour
{

    public AudioSource ASClick;
    public Button ButtonBack;
    public Button ButtonExit;

    public int LevelNum = 0;

    // Start is called before the first frame update
    void Start()
    {

        ButtonBack.onClick.AddListener(ButtonBackLis);
        ButtonExit.onClick.AddListener(ButtonExitLis);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonBackLis()
    {
        ASClick.Play();
        StartCoroutine(LoadScene_(1.0f, LevelNum));
    }

    IEnumerator LoadScene_(float sec, int Scene)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(Scene);
    }

    void ButtonExitLis()
    {
        ASClick.Play();
        StartCoroutine(ExitScene_(1.0f));
    }


    IEnumerator ExitScene_(float sec)
    {
        yield return new WaitForSeconds(sec);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }

}
