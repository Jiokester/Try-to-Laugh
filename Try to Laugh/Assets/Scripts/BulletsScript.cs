using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera MainCam;
    private Rigidbody bulletRb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();    
        bulletRb = GetComponent<Rigidbody>();
        mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        bulletRb.velocity = new Vector2 (direction.x, direction.y).normalized * force; 
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
