using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipDetection : MonoBehaviour
{
    public GameObject newShip;
    public GameObject[] astreoids;

    private Color[] colors = new Color[] { Color.black, Color.blue, Color.cyan, Color.gray, Color.green, Color.red, Color.white, Color.yellow, Color.magenta };

    float maxValue = 10;
    float minValue = -10;

    public LineRenderer lineRenderer;

    public GameObject SparksParticle; //
    private GameObject SparksParticleInstance;

    public GameObject ExplosionMobileParticle;//
    private GameObject ExplosionMobileParticleInstance;

    public float secToDeath = 3f;

    int numAstr = 0;
    float xPos = -5f;
    void Start()
    {
        SpawnSpaceShip(newShip);
    }

    void Update()
    {       
        if(numAstr != astreoids.Length)
        {
            RaycastFunc();
        }
        else
        {
            transform.GetComponentInChildren<LineRenderer>().material.color = Color.blue;
            SparksParticleInstance.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            newShip.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void SpawnSpaceShip(GameObject shipPrefab)
    {
        shipPrefab.transform.position = new Vector3(Random.Range(minValue, maxValue), Random.Range(1, 6), Random.Range(minValue, maxValue));
    }

    void RaycastFunc()
    {
        Transform camera = Camera.main.transform;

        Ray ray = new Ray(camera.position, camera.transform.forward);
        RaycastHit spaceshipPos;

        Debug.DrawRay(ray.origin, ray.direction, Color.green);//THIS SHOWS WHERE THE RAY IS.       

        if (Physics.Raycast(ray, out spaceshipPos, Mathf.Infinity) && spaceshipPos.collider.tag == "SpaceShip")
        {

            Debug.DrawRay(ray.origin, ray.direction, Color.red);//THIS SHOW IF THE SPACESHIP HAS BEEN COLLIDED

            Destruction();

            if (SparksParticleInstance == null)
            {
                SparksParticleInstance = Instantiate(SparksParticle, spaceshipPos.point, Quaternion.identity);

            }

            if (!SparksParticleInstance.GetComponent<ParticleSystem>().isPlaying)
            {
                SparksParticleInstance.GetComponent<ParticleSystem>().Play();
            }

            SparksParticleInstance.transform.position = spaceshipPos.point;
            transform.GetComponentInChildren<LineRenderer>().material.color = Color.yellow;
            newShip.GetComponent<Renderer>().material.color = new Color(1, 0.92f, 0.016f, 1);
            //secToDeath -= Time.deltaTime;
        }

        else
        {
            if (SparksParticleInstance != null && SparksParticleInstance.GetComponent<ParticleSystem>().isPlaying)
            {
                SparksParticleInstance.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }

            transform.GetComponentInChildren<LineRenderer>().material.color = Color.blue;
            newShip.GetComponent<Renderer>().material.color = Color.white;
        }
    }
    void Destruction()
    {
        Vector3 newPosition = new Vector3(Random.Range(minValue, maxValue), Random.Range(1, 6), Random.Range(minValue, maxValue));
        
        secToDeath -= Time.deltaTime;

        if (secToDeath <= 0)
        {
            Instantiate(ExplosionMobileParticle, newShip.transform.position, Quaternion.identity);
            newShip.transform.position = newPosition;           
            secToDeath = 3f;
            numAstr++;
            AstreoidsPosition();

        }
       
    }

    void AstreoidsPosition()
    {
        xPos++;

        Instantiate(astreoids[Random.Range(0, 4)], new Vector3(xPos, 0f, 2f), Quaternion.identity);
        /*
        if (gameObject.tag == "astreoids")
        {
            GetComponent<MeshRenderer>().material.color = colors[Mathf.FloorToInt(Random.Range(0, colors.Length))];
        }
        */
    }
}
