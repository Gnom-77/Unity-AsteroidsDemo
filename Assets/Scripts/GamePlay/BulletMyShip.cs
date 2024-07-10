using UnityEngine;

public class BulletMyShip : MonoBehaviour
{
    [SerializeField] private float bullet_speed;
    [SerializeField] private Rigidbody2D bullet;
    [SerializeField] private Transform positionBullet;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D bull;
            bull = Instantiate(bullet, positionBullet.position, positionBullet.rotation) as Rigidbody2D;
            bull.AddForce(transform.up * bullet_speed);
        }
    }
}
