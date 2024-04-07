using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private Rigidbody2D rb;
     public static bool ifGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        rb.gravityScale = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D col){
        ifGrounded = false;
        if(col.gameObject.tag == "Floor"){
            ifGrounded = true;
            animator.SetBool("Grounded", true);}
}
public static bool ifFallen(){
    return ifGrounded;
}
}
