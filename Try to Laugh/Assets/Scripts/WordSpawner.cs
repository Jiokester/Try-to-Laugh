using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Monaghan, Devin
/// 02/03/2024
/// randomly spawns words
/// </summary>

public class WordSpawner : MonoBehaviour
{
    // refernce of the playable game area
    public GameObject gameArea;
    // reference of the words
    public GameObject wordPrefab;

    // how many words are on screen
    public int wordCount = 0;
    // target and limit amount of words on screen
    public int wordLimit = 20;
    /// public int wordsPerFrame = 1;
    /// use this to increase the number of words spawning every frame via a for loop

    // radius of the circle words can spawn from
    public float spawnCircleRadius = 35f;
    // radius of the circle words die from by hitting
    public float deathCircleRadius = 40f;

    // fastest possible speed of spawned words
    public float fastestSpeed = 10f;
    // slowest possible speed of spawned words
    public float slowestSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        MaintainPopulation();
    }

    // spawn words when the word limit has not been reached
    private void MaintainPopulation()
    {
        if (wordCount < wordLimit)
        {
            // select a random position for the word to spawn at
            Vector3 position = GetRandomPosition();
            // spawn a wrod at the selected position
            Word wordScript = spawnWord(position);
            // rotate the new word slightly so it moves in a more natural direction
            wordScript.transform.Rotate(Vector3.forward * Random.Range(-45f, 45f));
        }
    }

    // returns a random position for the word to spawn at
    private Vector3 GetRandomPosition()
    {
        // choose a random position along a circle
        Vector3 position = Random.insideUnitCircle.normalized;

        // transform the position onto the spawnable circle
        position *= spawnCircleRadius;
        position += gameArea.transform.position;

        return position;
    }
    
    /// <summary>
    /// spawn a word at a random position with a random speed
    /// returns the script of the spawned word
    /// </summary>
    /// <param name="position"> position the word is spawned at </param>
    /// <returns></returns>
    private Word spawnWord(Vector3 position)
    {
        // increment the count of words on screen
        wordCount++;
        // spawn a new word from outside the game area
        GameObject newWord = Instantiate(
            wordPrefab, 
            position, 
            Quaternion.FromToRotation(Vector3.up, (gameArea.transform.position - position)), 
            this.gameObject.transform);

        // reference the script of the newly spawned word
        Word wordScript = newWord.GetComponent<Word>();
        // set the spawned word's word spawner reference
        wordScript.wordSpawner = this.gameObject;
        // set the spawned word's game area reference
        wordScript.gameArea = gameArea;
        // give the word a random speed within parameters
        wordScript.speed = Random.Range(slowestSpeed, fastestSpeed);

        return wordScript;
    }
}