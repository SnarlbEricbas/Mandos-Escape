using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float hitRange = 100f;
    [SerializeField] AudioSource pew;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject impactFlash;
    [SerializeField] Text life;
    Pause pause;
    int damage = 50;
    int health = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    
    void Awake()
    {
        pause = GameObject.FindGameObjectWithTag("pause").GetComponent<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
        life.text = health.ToString();
        if (Input.GetButtonDown("Fire1"))
        {
            muzzleflash.Play();
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!pause.weapon)
        {
            Debug.Log("no");
        }
        else
        {
            pew.Play();
            RaycastHit hit;
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, hitRange))
            {
                GameObject impact = Instantiate(impactFlash, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, .1f);
                enemy eh = hit.transform.gameObject.GetComponent<enemy>();
                eh.TakeDamage(damage);
            }
        }
    }
    public void TakeHit(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(3);
        }
    }
}
