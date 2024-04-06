using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainMovement : MonoBehaviour
{
    [SerializeField]private float speed = .5f;
    // Start is called before the first frame update
    void Start()
    {
         transform.position += new Vector3(0, -15, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
