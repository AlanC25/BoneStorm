using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //time between shots fired
    [SerializeField]
    [Range(0.1f, 1f)]
    private float fireRate = .5f;

    //damage given to anyone using Health script
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    private AudioSource audioSource;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>= fireRate)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        //play muzzle flash on shot fired
        muzzleParticle.Play();

        //Play laser sound on shot fired
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

        // debugging line of sight, retreive mesh info
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 500))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
                health.TakeDamage(damage);
        }
    }
}
