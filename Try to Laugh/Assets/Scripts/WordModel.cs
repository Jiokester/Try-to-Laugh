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
    public GameObject parent;

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Inverse(parent.transform.localRotation);
    }
}