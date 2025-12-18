using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.5f;
    [SerializeField]
    Vector3 direction;

    Vector3 BallOrigin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BallOrigin = transform.position;
        setBallDirection();
    }
    void setBallDirection()
    {
        direction.x = Random.Range(-1, 2);
        direction.z = Random.Range(-1, 2);

        while (direction.x == 0)
        {
            direction.x = Random.Range(-1, 2);
        }
        direction.z = Random.Range(-1, 2);

        while (direction.z == 0)
        {
            direction.z = Random.Range(-1, 2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * Time.deltaTime * speed;
    }
    private void OnCollisionEnter(Collision other)
    {
       if (other.gameObject.CompareTag("Player"))
       {
            direction.x = -direction.x;
       }
       if (other.gameObject.CompareTag("Wall"))
       {
            direction.z = -direction.z;
       }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = BallOrigin;
        setBallDirection();

        if (other.gameObject.CompareTag("Goal 1"))
        {
            ScoreManager.instance.Player2Scored();
            
        }
        if (other.gameObject.CompareTag("Goal 2"))
        {
            ScoreManager.instance.Player1Scored();
           
        }
    }
}
