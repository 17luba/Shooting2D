using UnityEngine;
using EZCameraShake;

public class ShootScript : MonoBehaviour
{

    public Transform Gun;

    public Animator GunAnimator;

    Vector2 direction;

    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;

    public float fireRate;

    float ReadyForNextShot;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;

        FaceMouse();

        if (Input.GetMouseButton(0))
        {
            if (Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void FaceMouse()
    {
        Gun.transform.right = direction;
    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
        GunAnimator.SetTrigger("Shoot");
        CameraShaker.Instance.ShakeOnce(1.2f, 0.8f, 0.1f, 0.15f);
        Destroy(BulletIns, 1.5f);
    }
}
