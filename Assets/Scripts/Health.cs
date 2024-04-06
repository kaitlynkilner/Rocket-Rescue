using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject rain;
    private float timer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(rain.activeSelf == true){
            timer -= Time.deltaTime;}
        if(timer <= 0f){
            rain.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col){
        Debug.Log("Collision Detected");
        rain.SetActive(true);
    }
}
