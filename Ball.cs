
using UnityEngine;

public class Ball : MonoBehaviour {

    //Config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //State
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached Component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Use this for initialization
    void Start ()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            launchOnMouseClick();
        }
    }

    private void launchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true; 
            GetComponent<Rigidbody2D>().velocity = new Vector2 (xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor), 
            Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
        
    }

}
