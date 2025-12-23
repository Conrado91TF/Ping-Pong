using JetBrains.Annotations;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.5f;
    [SerializeField]
    Vector3 direction;

    Vector3 BallOrigin;
    [SerializeField]
    float maxSpeed = 10;
    [SerializeField]
    float speedIncrement = 0.5f;
    [SerializeField]
    public GameObject effectsGoal;
    [SerializeField]
    public Rigidbody rb;
    public TrailRenderer tr;
    public float maxTrailTime = 15f;



    float originalSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BallOrigin = transform.position;
        originalSpeed = speed;
        setBallDirection();
        TrailRenderer3();
    }
    void TrailRenderer3()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        if (tr == null)
        {
            tr = GetComponent<TrailRenderer>();
        }

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
        MaxTrailTime();
    }
    private void OnCollisionEnter(Collision other)
    {
       if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
       {
            direction.x = -direction.x;
       }
       if (other.gameObject.CompareTag("Wall"))
       {
            direction.z = -direction.z;
       }
       
       if (speed < maxSpeed)
       {
           speed += speedIncrement;
       }
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = BallOrigin;
        originalSpeed = speed;
        tr.Clear();
        setBallDirection();

        if (other.gameObject.CompareTag("Goal 1"))
        {
            ScoreManager.instance.Player2Scored();

        }
        else 
        {
            Instantiate(effectsGoal, transform.position, Quaternion.identity);
        }


        if (other.gameObject.CompareTag("Goal 2"))
        {
            ScoreManager.instance.Player1Scored();

        }
        else 
        {
            Instantiate(effectsGoal, transform.position, Quaternion.identity);
        }
        
        
    }
    public void MaxTrailTime()
    {
       if (speed >= maxTrailTime)
       {
           tr.emitting = true;
       }
       else
       {
           tr.emitting = false;
       }
    }
}
