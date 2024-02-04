using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monaghan, Devin
/// 02/03/2024
/// bounces the word randomly against objects
/// </summary>

public class Word : MonoBehaviour
{
    // references the word spwaner, controlled by word spawner
    public GameObject wordSpawner;
    // references the game area, controlled by word spawner
    public GameObject gameArea;
    // how fast the word moves, controlled by word spawner
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // move forward and die if the word gets too far from the game area
    private void Move()
    {
        // constantly move forward
        transform.position += transform.up * (speed * Time.deltaTime);

        // find distance between word and game area
        float distance = Vector3.Distance(transform.position, gameArea.transform.position);
        // if the distance between word and game area is too far then die
        if (distance >= wordSpawner.GetComponent<WordSpawner>().deathCircleRadius)
        {
            RemoveWord();
        }
    }

    // destroy word and tell word spawner there is one less word
    private void RemoveWord()
    {
        Destroy(this.gameObject);
        wordSpawner.GetComponent<WordSpawner>().wordCount--;
    }
}