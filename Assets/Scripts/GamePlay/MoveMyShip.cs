using UnityEngine;

public class MoveMyShip : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float move_speed, rotate_speed;
    private float MoveInout, RotateInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        MoveInout = Input.GetAxis("Vertical");
        RotateInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.AddForce(this.transform.up * move_speed * MoveInout); 
        rb.AddTorque(-RotateInput * rotate_speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Iceberg")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
