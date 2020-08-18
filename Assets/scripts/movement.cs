using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    private Vector2 scrnbounds;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-1f, 1f), -speed);
        scrnbounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }



    void Update()
    {
        if (transform.position.y < -scrnbounds.y * 2)
        {
            Destroy(this.gameObject);
            DeployFoe.FoeCount--;
        }
    }
}
