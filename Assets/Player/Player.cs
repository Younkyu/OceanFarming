using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    /*CENTRALLIZED USER INPUT CONSOLE*/

    [SerializeField]
    private float movementSpeed = 2.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Global.mapToggled = false;
    }

    // Update is called once per frame
    // For Player key inputs
    void Update()
    {
        if (Input.GetKeyDown("m"))
            ToggleMap();
    }
}
