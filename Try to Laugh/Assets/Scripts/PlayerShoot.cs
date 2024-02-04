using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Ihejirika, Chijioke]
 * Last Updated: [02/02/2024]
 * [Controls the player's ability to aim and shoot]
 */
public class PlayerShoot : MonoBehaviour
{
    private Camera MainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    // Start is called before the first frame update
    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Aim();

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }


        if (Input.GetMouseButton(0) && canFire) 
        {
            canFire = false;    
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        
        }

    }

    /// <summary>
    /// Player will aim based on the movement of the mouse
    /// </summary>
    private void Aim()
    {
        mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ + 270);
    }

    private void Shoot()
    {

    }
}
