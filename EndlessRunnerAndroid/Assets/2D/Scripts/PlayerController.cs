using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;

	public float speedIncreaseMinestone;
	private float speedIncreaseMinestoneStore;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;


	public float jumpForce;

	public float jumpTime;
	private float jumpTimeCounter;

	private bool stoppedJumping;

	private Rigidbody2D myRigidbody;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform GroundCheck;
	public float groundCheckRadius;

	public GameManager TheGameManager;



	//private Collider2D myCollider;

	private Animator myAnimator;

//	Added By ME
//	public AudioClip Jumpaud;
//	public Transform audiopos;

	// Use this for initialization
	void Start () {

		TheGameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		myRigidbody = GetComponent<Rigidbody2D> ();

		//myCollider = GetComponent<Collider2D> ();

		myAnimator = GetComponent<Animator> ();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMinestone;

		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMinestoneStore = speedIncreaseMinestone;

		stoppedJumping = true;
	}
	
	// Update is called once per frame
	void Update () {

		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		grounded = Physics2D.OverlapCircle (GroundCheck.position, groundCheckRadius, whatIsGround);

		if (transform.position.x > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMinestone;

			speedIncreaseMinestone = speedIncreaseMinestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		
		}

		myRigidbody.velocity = new Vector2 (moveSpeed,myRigidbody.velocity.y);
	
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
		{
			if(grounded)
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x,jumpForce);
				stoppedJumping = false;
				//Added By ME
				GetComponent<AudioSource>().Play();

			}
		}

		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) && !stoppedJumping) {
		
			if(jumpTimeCounter > 0)
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x,jumpForce);
				jumpTimeCounter-= Time.deltaTime;


			}
		
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {

			jumpTimeCounter = 0;
			stoppedJumping = true;
		
		}
		if (grounded) {
		
			jumpTimeCounter = jumpTime;
		
		}

		myAnimator.SetFloat ("Speed",myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	
	}



	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "killbox") 
		{
			
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMinestone = speedIncreaseMinestoneStore;
			TheGameManager.Death();
		}
	}
}
