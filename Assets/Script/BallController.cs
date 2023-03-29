using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    public float speed = 30;
    
    private Rigidbody rb;
    
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * speed;
    }
    
    void FixedUpdate () {
        if (rb.velocity.magnitude < speed) {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
    
    void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag == "Block") {
            Destroy(col.gameObject);
        }
    }
}

public class PaddleController : MonoBehaviour {
    public float speed = 30;
    
    private Rigidbody rb;
    
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        
        rb.velocity = movement * speed;
    }
}

public class GameController : MonoBehaviour {
    public GameObject ballPrefab;
    public Transform paddle;
    public int rows = 5;
    public int cols = 8;
    
    private bool ballInPlay = false;
    
    void Update () {
        if (!ballInPlay && Input.GetButtonDown("Fire1")) {
            SpawnBall();
        }
    }
    
    void SpawnBall () {
        ballInPlay = true;
        GameObject ball = Instantiate(ballPrefab, paddle.position + new Vector3(0, 0.75f, 0), Quaternion.identity) as GameObject;
    }
    
    void OnGUI () {
        GUI.Label(new Rect(10, 10, 100, 20), "Press left mouse button to start");
    }
}
