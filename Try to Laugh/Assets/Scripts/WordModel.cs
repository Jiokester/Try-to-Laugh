using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monaghan, Devin
/// 02/03/2024
/// lock the model's rotation without changing its parent rotation
/// </summary>

public class WordModel : MonoBehaviour
{
    // references parent empty
    public GameObject parent;
    public Word parentScript;

    private void Start()
    {
        parentScript = parent.GetComponent<Word>();
    }

    // Update is called once per frame
    void Update()
    {
        // set the model's rotation to invers of the parent empty's
        transform.localRotation = Quaternion.Inverse(parent.transform.localRotation);
    }


    // handles trigger collisions
    private void OnTriggerEnter(Collider other)
    {
        print("collided");


        // when word touches a bullet subtract one health, destroy the bullet
        if (other.gameObject.tag == "Bullet")
        {
            print("collided with bullet");



            parentScript.health--;
            Destroy(other.gameObject);

            // if health reaches 0 collect the word
            if (parentScript.health <= 0)
            {
                parentScript.CollectWord();
            }
        }
    }
}