using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

    public bool HasItem { get; set; }

    void Start()
    {
        HasItem = false;
    }
}
