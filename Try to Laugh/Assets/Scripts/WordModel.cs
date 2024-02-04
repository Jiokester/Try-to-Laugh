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

    // Update is called once per frame
    void Update()
    {
        // set the model's rotation to invers of the parent empty's
        transform.localRotation = Quaternion.Inverse(parent.transform.localRotation);
    }
}