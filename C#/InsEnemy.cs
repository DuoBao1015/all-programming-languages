using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsEnemy : MonoBehaviour
{

    public static InsEnemy instance;

    public GameObject[] m_Ellipse;

    protected Transform m_transform1;

    public int AddCude = 50;

    public bool pause = false;

    void Start()
    {
        instance = this;

        m_transform1 = this.transform;

        StartCoroutine(CloseScene_(1.0f));
    }

    void Update()
    {

    }

    public void InsEllipseLis()
    {
        int CudeNum = Random.Range(4, 7);

        for (int n = 0; n < CudeNum; n++)
        {
            CreateEnemy();
        }
        pause = false;
    }

    public void AddEnemyLis()
    {
        CreateEnemy();
    }

   IEnumerator CloseScene_(float sec)
    {
        yield return new WaitForSeconds(sec);
        InsEllipseLis();

        yield break;
    }

    public void CreateEnemy()
    {
        float Pos_X = Random.Range(-10, 10);
        float Pos_Y = 0;//Random.Range(0, 0);
        float Pos_Z = Random.Range(-10, 10);
        Vector3 CudePos = m_transform1.position + new Vector3(Pos_X, Pos_Y, Pos_Z);

        GameObject newEllipse = Instantiate(m_Ellipse[Random.Range(0, m_Ellipse.Length)], CudePos, Quaternion.identity);
        newEllipse.SetActive(true);
        newEllipse.transform.parent = this.transform;
    }

}
