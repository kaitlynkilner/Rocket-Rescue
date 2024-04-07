using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject rain;
    [SerializeField] private GameObject player;
    private float timer = 10f;
    [SerializeField] private float health;
    private float maxHealth = 100f;
    private bool ifExited = false;
    private bool ifRaining = false;
    private bool inWater = false;
    [SerializeField]public Image healthBar;
    [SerializeField]public GameObject GameOver;
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
        if((col.gameObject.name == "UnderPlatformTrigger" || col.gameObject.name == "UnderPlatformTrigger(1)") && ifRaining){
            ifExited = false;
        }
        if(col.gameObject.name == "Acid_rainTrigger"){
        rain.SetActive(true);
        ifExited = true;
        ifRaining = true;
        col.gameObject.SetActive(false);
        }
        if(col.gameObject.name == "AcidWater" || col.gameObject.name == "AcidWater(1)"){
            Debug.Log("In Water");
            inWater = true;
        }
    }
     private void OnTriggerExit2D(Collider2D col){
        Debug.Log("Exited");
        ifExited = true;
        inWater = false;
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
