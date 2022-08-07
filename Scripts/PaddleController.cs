using System.Collections;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Ball ball;
    public Vector2 force;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ball.attach)
            Lounch();
        if (Time.timeScale != 0)
            transform.position = Vector3.right * Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -7.65f, 7.65f) + Vector3.up * transform.position.y;   
    }

    void Lounch()
    {
        ball.attach = false;
        ball.GetComponent<Rigidbody2D>().velocity = force;
    }
}
