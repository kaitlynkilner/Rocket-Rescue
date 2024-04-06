using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject rain;
    [SerializeField] private GameObject player;
    private float timer = 10f;
    [SerializeField] private float health;
    private float maxHealth = 10f;
    private bool ifExited = false;
    // Start is called before the first frame update
    void Start()
    {
        rain.SetActive(false);
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(rain.activeSelf == true){
            timer -= Time.deltaTime;}
        if(timer <= 0f){
            rain.SetActive(false);
            timer = 10f;
        }
        if(ifExited && timer > 1f){
            TakeDamage(.5f);
        }

    }

    private void OnTriggerEnter2D(Collider2D col){
        Debug.Log("Collision Detected");
        rain.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D col){
        Debug.Log("Exited");
        ifExited = true;
    }

    private void TakeDamage(float ammount){
        health -= ammount;
        if(health <= 0f){
            player.SetActive(false);
        }
        }
}
