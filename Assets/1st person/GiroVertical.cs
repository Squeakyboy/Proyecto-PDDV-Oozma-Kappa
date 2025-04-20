using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroVertical : MonoBehaviour
{

    Vector3 ScreenPos;

    Vector3 Pos;
    public float Sensibility;

    // Start is called before the first frame update
    void Start()
    {

        Pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        float giroVertical = Input.GetAxis("Mouse Y");
        transform.Rotate(-1 * giroVertical * Sensibility, 0, 0);  
        Agacharse(); 

    }
    void Agacharse()
    {
        float Ctrl = Input.GetAxisRaw("Agachar");
        Ctrl *= 0.7f;
        transform.position = new Vector3(PlayerControl.position.x, PlayerControl.position.y + 1 - Ctrl, PlayerControl.position.z);
    }

}
