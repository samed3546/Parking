using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public Transform Player;
    Vector3 Ofset;
    void Start()
    {
        Ofset = transform.position - Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position + Ofset;
    }
}
