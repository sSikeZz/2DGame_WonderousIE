using System.Collections;
using System.Collections.ObjectModel;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1Manager : MonoBehaviour
{
    public GameObject[] enemies1;
    public Transform player;
    public float movespeed;
    Vector2 direction;
    float distance;
    
    private void Awake()
    {
        enemies1 = GameObject.FindGameObjectsWithTag("enemy1");
    }

    private void Update()
    {
        foreach (GameObject enemy in enemies1)
        {
            direction = player.transform.position - enemy.transform.position;
            distance = Mathf.Abs(player.transform.position.magnitude - enemy.transform.position.magnitude);

            if (distance > 2f)
            {
                enemy.transform.Translate(direction * movespeed * Time.deltaTime);
            }
        }
    }
}