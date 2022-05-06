using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{


   public float speed = 0.1f;
    public float Movespeed = 0.1f;
    public GameObject[] burstPrefab01;
    public GameObject[] burstPrefab02;
    public int Ran_n = 0;
    public float TimeRun = 3;

    public bool IsMove = false;

    void Start()
    {
        Destroy(this.gameObject,12);

        StartCoroutine(LoadScene_( ));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Movespeed);
    }
   
    private void OnCollisionEnter(Collision collision) 
    { 
        if (collision.gameObject.tag == "enemy")
        {
            GameManger.Instance.AddKCScore();
            InsEnemy.instance.AddEnemyLis();

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Ran_n = Random.Range(0, burstPrefab01.Length);
            Instantiate(burstPrefab01[Ran_n], transform.position, transform.rotation);
        }else
        {
            Destroy(this.gameObject);

            Ran_n = Random.Range(0, burstPrefab02.Length);
            Instantiate(burstPrefab02[Ran_n], transform.position, transform.rotation);
        }
    }

    IEnumerator LoadScene_( )
    {
        yield return new WaitForSeconds(TimeRun);
        IsMove = true;
        yield break;
    }

}
