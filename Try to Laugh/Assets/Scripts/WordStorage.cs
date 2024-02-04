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
    /// 
    /// </summary>
    

    // Start is called before the first frame update
    void Start()
    {

    }

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