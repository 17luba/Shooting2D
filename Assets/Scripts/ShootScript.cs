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

    public AudioSource BackgroundAudio;
    public AudioSource GunShootAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (BackgroundAudio != null)
        {
            BackgroundAudio.Play();
        }
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
        // Calculez l'angle entre l'arme et la souris
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Limitez l'angle à une plage spécifique (exemple : entre -60 et 60 degrés)
        angle = Mathf.Clamp(angle, -10f, 30f);

        // Appliquez la rotation
        Gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        //Gun.transform.right = direction;
    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
        GunAnimator.SetTrigger("Shoot");
        CameraShaker.Instance.ShakeOnce(1.2f, 0.8f, 0.1f, 0.15f);
        Destroy(BulletIns, 1.5f);

        if (GunShootAudio != null)
        {
            GunShootAudio.Play();
        }
    }
}