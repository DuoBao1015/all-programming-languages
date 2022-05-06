using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player01 : MonoBehaviour
{

    public static Player01 instance;

    public GameObject[] icons;
    public int life = 5;

    public bool IsRun = false;

    public GameObject HPtx;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

     
    }

    // Update is called once per frame
    void Update()
    {
  
        
    }

    public void OnDamage(int hp)
    {
     
        life--;
        UpdateLife(life);
        IsRun = false;
        HPtx.SetActive(true);

        if (life <= 0)
        {
            GameManger.Instance.LoseLis();
        }
        else
        {
            StartCoroutine(hpScene_(1.0f));
        }
    }

    IEnumerator hpScene_(float sec)
    {
        yield return new WaitForSeconds(sec);
        HPtx.SetActive(false);
        yield return new WaitForSeconds(2);
        IsRun = true;
    }

    public void UpdateLife(int life_)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i < life_) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }


}
