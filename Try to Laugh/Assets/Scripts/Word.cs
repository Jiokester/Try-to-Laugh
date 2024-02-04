using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monaghan, Devin
/// 02/04/2024
/// bounces the word randomly against objects
/// collects word into word storage
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

    private bool collected = false;

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
        // only move if the word is not already collected
        if (!collected)
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
    }

    // destroy word and tell word spawner there is one less word
    private void RemoveWord()
    {
        Destroy(this.gameObject);
        wordSpawner.GetComponent<WordSpawner>().wordCount--;
    }

    // set word inactive and add it to the word storage
    public void CollectWord()
    {
        // stop word from moving
        collected = true;
        // remove collected word from spanwer's word count
        wordSpawner.GetComponent<WordSpawner>().wordCount--;
        // scale word down to fit better
        transform.localScale *= .75f;

        // if a word's type's storage list is not full add it to the list and move it to storage position
        if (adj && !verb && !storageScript.adjsFull)
        {
            // add word to storage list
            storageScript.adjectives.Add(this.gameObject);
            // move word to position in storage based on number of words in list
            switch (storageScript.adjCount)
            {
                case 0:
                    transform.position = storageScript.adjPos0.transform.position;
                    print("added adj 1");
                    break;
                case 1:
                    transform.position = storageScript.adjPos1.transform.position;
                    print("added adj 2");
                    break;
                case 2:
                    transform.position = storageScript.adjPos2.transform.position;
                    print("added adj 3");
                    break;
                case 3:
                    transform.position = storageScript.adjPos3.transform.position;
                    print("added adj 4");
                    break;
                case 4:
                    transform.position = storageScript.adjPos4.transform.position;
                    print("added adj 5");
                    break;
                case 5:
                    transform.position = storageScript.adjPos5.transform.position;
                    print("added adj 6");
                    break;
                default:
                    print("added no adj");
                    break;
            }
            // increment count of words in list
            storageScript.adjCount++;
        }
        else if (verb && !adj && !storageScript.adjsFull)
        {
            // add word to storage list
            storageScript.verbs.Add(this.gameObject);
            // move word to position in storage based on number of words in list
            switch (storageScript.verbCount)
            {
                case 0:
                    transform.position = storageScript.verbPos0.transform.position;
                    print("added verb 1");
                    break;
                case 1:
                    transform.position = storageScript.verbPos1.transform.position;
                    print("added verb 2");
                    break;
                case 2:
                    transform.position = storageScript.verbPos2.transform.position;
                    print("added verb 3");
                    break;
                case 3:
                    transform.position = storageScript.verbPos3.transform.position;
                    print("added verb 4");
                    break;
                case 4:
                    transform.position = storageScript.verbPos4.transform.position;
                    print("added verb 5");
                    break;
                case 5:
                    transform.position = storageScript.verbPos5.transform.position;
                    print("added verb 6");
                    break;
                default:
                    print("added no verb");
                    break;
            }
            // increment count of words in list
            storageScript.verbCount++;
        }
        else if (!adj && !verb && !storageScript.nounsFull)
        {
            // add word to storage list
            storageScript.nouns.Add(this.gameObject);
            // move word to position in storage based on number of words in list
            switch (storageScript.nounCount)
            {
                case 0:
                    transform.position = storageScript.nounPos0.transform.position;
                    print("added noun 1");
                    break;
                case 1:
                    transform.position = storageScript.nounPos1.transform.position;
                    print("added noun 2");
                    break;
                case 2:
                    transform.position = storageScript.nounPos2.transform.position;
                    print("added noun 3");
                    break;
                case 3:
                    transform.position = storageScript.nounPos3.transform.position;
                    print("added noun 4");
                    break;
                case 4:
                    transform.position = storageScript.nounPos4.transform.position;
                    print("added noun 5");
                    break;
                case 5:
                    transform.position = storageScript.nounPos5.transform.position;
                    print("added noun 6");
                    break;
                default:
                    print("added no noun");
                    break;
            }
            // increment count of words in list
            storageScript.nounCount++;
        }
        else
        {
            print("all lists were full");
            Destroy(this.gameObject);
        }
    }
}