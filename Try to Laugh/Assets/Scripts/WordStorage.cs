using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monaghan, Devin
/// 02/04/2024
/// store collected words
/// </summary>

public class WordStorage : MonoBehaviour
{
    // target number of each kind of word 
    public int adjNum = 0;
    public int verbNum = 0;
    public int nounNum = 0;
    // current count of each kind of word
    public int adjCount = 0;
    public int verbCount = 0;
    public int nounCount = 0;

    public bool adjsFull = false;
    public bool verbsFull = false;
    public bool nounsFull = false;

    // list of each type of word
    public List<GameObject> adjectives = new List<GameObject>();
    public List<GameObject> verbs = new List<GameObject>();
    public List<GameObject> nouns = new List<GameObject>();

    /// <summary>
    /// all position references
    /// </summary>
    public GameObject verbPos0;
    public GameObject verbPos1;
    public GameObject verbPos2;
    public GameObject verbPos3;
    public GameObject verbPos4;
    public GameObject verbPos5;
    public GameObject adjPos0;
    public GameObject adjPos1;
    public GameObject adjPos2;
    public GameObject adjPos3;
    public GameObject adjPos4;
    public GameObject adjPos5;
    public GameObject nounPos0;
    public GameObject nounPos1;
    public GameObject nounPos2;
    public GameObject nounPos3;
    public GameObject nounPos4;
    public GameObject nounPos5;

    // Update is called once per frame
    void Update()
    {
        if (adjCount == adjNum)
        {
            adjsFull = true;
            adjCount = 0;
        }
        if (verbCount == verbNum)
        {
            verbsFull = true;
            verbCount = 0;
        }
        if (nounCount == nounNum)
        {
            nounsFull = true;
            nounCount = 0;
        }
    }
}