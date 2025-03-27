using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed Negotiator Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("player components and Axis")]
    private Rigidbody2D rb;
    private float HorizontalInput;
    private float VerticalInput;

    private float CharacterPos;
    public GameObject[] GamObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -7.0f);
    }

    void Update()
    {
        CharacterPos = this.transform.position.y;
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 Direction = new Vector2(HorizontalInput, VerticalInput).normalized;
        rb.velocity = Direction * moveSpeed;

        GamObject = GameObject.FindGameObjectsWithTag("object");

        foreach (GameObject Obj in GamObject)
        {
            float ObjectY = Obj.transform.position.y;

            if (CharacterPos < ObjectY)
            {
                Obj.transform.position = new Vector3(Obj.transform.position.x, Obj.transform.position.y, -6.0f);
            }
            else
            {
                Obj.transform.position = new Vector3(Obj.transform.position.x, Obj.transform.position.y, -8.0f);
            }
        }
    }
}