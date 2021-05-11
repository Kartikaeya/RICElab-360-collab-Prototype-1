using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
public class PlayerMovement : NetworkBehaviour
{
    private GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        if (IsLocalPlayer)
        {
            sphere = GameObject.Find("Sphere");
            transform.parent = sphere.transform;
        }
        //transform.parent = sphere.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
