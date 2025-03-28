using System.Xml.Serialization;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    float shoottime;
    public GameObject projectile;
    public float movespeed;
    bool shooting;

    void Update()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);

        if(shoottime < Time.time)
        {
            shoottime += 5f;
            shoot();
            shooting = true ;
        }

        if (!shooting)
        {
            MoveTowardsPlayer();
        }

    }

    void shoot()
    {
        GameObject projectilepre = Instantiate(projectile, this.transform.position, Quaternion.identity);
        Vector2 direction = player.position - this.transform.position;
        projectilepre.GetComponent<Rigidbody2D>().AddForce(direction * movespeed);
        Destroy(projectilepre, 5f);
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void FindPlayer()
    {
        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "sword")
        {
            Destroy(this.gameObject);
        }
    }


}