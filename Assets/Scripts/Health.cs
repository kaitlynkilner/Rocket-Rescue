using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject rain;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rock;
    private float timer = 10f;
    [SerializeField] private float health;
    private float maxHealth = 100f;
    private bool ifExited = false;
    private bool ifRaining = false;
    private bool inWater = false;
    [SerializeField]public Image healthBar;
    [SerializeField]public GameObject GameOver;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rain.SetActive(false);
        GameOver.SetActive(false);
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
            ifExited = true;
            ifRaining = false;
        }
        if(ifExited && timer < 9f && ifRaining){
            TakeDamage(.1f);
        }
        if(inWater){
            TakeDamage(1f);
        }

    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Platform" && ifRaining){
            ifExited = false;
        }
        if(col.gameObject.tag == "Rain_Trigger"){
        rain.SetActive(true);
        ifExited = true;
        ifRaining = true;
        col.gameObject.SetActive(false);
        }
        if(col.gameObject.tag == "Water"){
            Debug.Log("In Water");
            inWater = true;
        }
        if(col.gameObject.tag == "Rock_Trigger"){
            rock.gravityScale = 1f;
        }
    }
     private void OnTriggerExit2D(Collider2D col){
        Debug.Log("Exited");
        ifExited = true;
        inWater = false;
    }

    private void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Platform" && ifRaining){
            ifExited = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Rock" && FallingRock.ifFallen() == false){
            health = 0f;
            player.SetActive(false);
            GameOver.SetActive(true);
        }

    }

    private void TakeDamage(float ammount){
        health -= ammount;
        healthBar.fillAmount = health / maxHealth;
        if(health <= 0f){
            player.SetActive(false);
            GameOver.SetActive(true);
        }
        }
    }
