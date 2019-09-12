
using UnityEngine;


public class Ball : MonoBehaviour {
    [SerializeField] Paddle paddle;
    Vector2 paddleToballVector;
    [SerializeField]bool HasStarted=false;
    AudioSource myAudioSource;
    [SerializeField] AudioClip[] ballBounce;
    [SerializeField] float randomBallFactor;
    [SerializeField] float randomBallFactormin;
    Rigidbody2D myRigidbody;

    
	void Start () {
        paddleToballVector =transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (!HasStarted)
        {
          
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LaunchBallOnMouseClick()
    {
      
        if (Input.GetMouseButton(0)){
            HasStarted = true;
            //GetComponent<Rigidbody2D>().velocity=new Vector2(3,7);
            myRigidbody.velocity = new Vector2(3, 7);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToballVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
          (Random.Range(-randomBallFactormin,randomBallFactor),
          (Random.Range(-randomBallFactor, randomBallFactor)));
        if (HasStarted)
        {
            AudioClip clip = ballBounce[UnityEngine.Random.Range(0,ballBounce.Length)];
            
          
            //GetComponent<AudioSource>().PlayOneShot(clip);
            myAudioSource.PlayOneShot(clip);
            myRigidbody.velocity += velocityTweak;
          
        }

    }
}
