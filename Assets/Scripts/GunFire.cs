using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{

    private AudioSource gunshot;
    private bool hasGunFired = false;
    [SerializeField] float gunFireDelay;
    private Animator gunAnim;

    private Transform mainCamera;
    [SerializeField] float range = 250;
    private int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        gunshot = GetComponent<AudioSource>();
        gunAnim = GetComponent<Animator>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (hasGunFired == false)
            {
                StartCoroutine(FireGun());
                GunshotHitCheck();
            }
        }
    }
    IEnumerator FireGun()
    {

        hasGunFired = true;
        gunshot.Play();
        yield return new WaitForSeconds(gunFireDelay);
        hasGunFired = false;

    }
    void GunshotHitCheck() 
    {
        Ray rayFrom = new Ray(mainCamera.position, mainCamera.forward);
        RaycastHit hit;

            if (Physics.Raycast(rayFrom, out hit, range))
            {

                if (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Enemy1"))
                {

                Debug.Log("HIT: " + damage);
                hit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
                }
                else {  

                Debug.Log("MISS");

                }

            }
    }

}