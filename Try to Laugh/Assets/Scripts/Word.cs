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
    // references the word storage, controlled by word spawner
    public GameObject wordStorage;

    // references the script on wordStorage
    public WordStorage storageScript;

    // how fast the word moves, controlled by word spawner
    public float speed = 1;

    // how many bullets it takes to collect a word
    public int health = 1;

    // what kind of word each word is
    // if adj and verb are false then the word is a noun
    public bool adj = false;
    public bool verb = false;

    // Start is called before the first frame
    private void Start()
    {
        // gets the reference to WordStorage on wordStorage
        storageScript = wordStorage.GetComponent<WordStorage>();
    }

    // Update is called once per frame
    private void Update()
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

    // handles trigger collisions
    private void OnTriggerEnter(Collider other)
    {
        // when word touches a bullet subtract one health, destroy the bullet
        if (other.tag == "Bullet")
        {
            health--;
            Destroy(other.gameObject);

            // if health reaches 0 collect the word
            if (health <= 0)
            {
                CollectWord();
            }
        }
    }

    // set word inactive and add it to the word storage
    private void CollectWord()
    {
        
        if (adj && storageScript.adjsFull)
        {
            storageScript.adjectives.Add(this.gameObject);
        }
        else if (verb && storageScript.adjsFull)
        {
            storageScript.verbs.Add(this.gameObject);
        }
        else if (storageScript.nounsFull)
        {
            storageScript.nouns.Add(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        this.gameObject.SetActive(false);
    }
}