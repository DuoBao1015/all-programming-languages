using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fire : MonoBehaviour
{


    public GameObject BulletPrefab;
    public Transform gunPos;


    public AudioSource audioSource; 
    public AudioClip audioClip; 

    public GameObject[] guns; 
    int selectedGun;
     
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            selectedGun++;
            if (selectedGun >= guns.Length)
            {
                selectedGun = 0;
            }
            SwitchGun();
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            selectedGun--;
            if (selectedGun < 0)
            {
                selectedGun = guns.Length - 1;
            }
            SwitchGun();
        }

        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(audioClip); 
            Instantiate(BulletPrefab, gunPos.position, gunPos.rotation);
        }


    }

    void SwitchGun()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
        guns[selectedGun].SetActive(true);
    }
}
