using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
This code is based on:
    Bracekys (https://www.youtube.com/watch?v=THnivyG0Mvo&t=660s) 

*/

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public float fireRate = 50f;
    // public ParticleSystem muzzleFlash;

    public Animator controlador;
    /*
    [SerializeField]
    GameObject Door;*/

    private float nextTimeToFire = 0f;

    [SerializeField] AudioSource sound;

    /*
    [SerializeField]
    GameObject bullet;
    */
    /*
    [SerializeField]
    GameObject impactEffect;*/

    public Button other;

    public Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {

            nextTimeToFire = Time.time + 1f / fireRate;
            controlador.SetTrigger("Disparo");
            Invoke("FireGun", 0.5f);
            sound.Play();
        }
    }

    void FireGun()
    {
        //muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("hit");
            /*
            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1f);
            */
            if (hit.collider.gameObject.CompareTag("Btn"))
            {
                Debug.Log("hitBtn");
                other.OnRayHit();
            }
        }



    }
}
