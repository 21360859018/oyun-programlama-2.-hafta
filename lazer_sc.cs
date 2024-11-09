using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_sc : MonoBehaviour
{


[SerializeField]
private float _speed=8.0f;

    void Start()
    {
        
    }

    void Update()
    {
       transform.Translate(Vector3.up*Time.deltaTime*_speed);

       if(transform.position.y>7f)
       { 
        if(transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        Destroy(this.gameObject);
       }

    }




}
