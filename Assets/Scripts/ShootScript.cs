using UnityEngine;

public class ShootScript : MonoBehaviour
{

    public Transform Gun;

    Vector2 direction;
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
    }

    void FaceMouse()
    {
        Gun.transform.right = direction;
    }
}
