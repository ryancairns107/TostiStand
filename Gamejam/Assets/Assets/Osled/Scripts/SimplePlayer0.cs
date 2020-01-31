using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SimplePlayer0 : MonoBehaviour {
	public bool isDead;  // incase if we will add death and live in game
	public GameObject restartText;   // reset the game if shit hits the fan

	//Lives
	public int lives; // life for player
	public bool isImmune; // making the player immortal
	
	public float immuneTime; // for puffs

	public bool outsideForce; // push back

	
	public Animator anim;  // preset for animation so not fow now dont bother about it
		public Rigidbody2D rb; 
	
		
	//SpeedVariables

	float speed = 5f;   // speed of the player 
	public float BaseSpeed;// variable for speed 
	
	//JumpVariables
	public bool grounded; // variable for being grounded 
	public Transform point1;  // transformation incase the player transforms into different forms
	public Transform point2;  // same here
	public LayerMask onlyGroundMask;  //  for ground mask
	public float jumpForce; // variable for jimp force
    public string leftkeyname = "left";  // set up variable for for all keys 
    public string rightkeyname = "right";
    public string upkeyname = "up";

    public float timer; // set for timer not implemented yet though
	bool canJump;   // ifplayer can jump true of false
	public float maxTime = 0.1f;   //max time
	

		float previousAxispos; // for change player positioning facing a direction 
	

	public GameObject jumpsParticles; // if we want to add partical effects

	
	
	
	void Start () {
		anim = GetComponent<Animator> (); //add animation once we have one
		rb = GetComponent<Rigidbody2D> (); // physics set up for movement
	}
	
		IEnumerator ImmuneTime() //timer set for aimmunity incase we use it
		{
				yield return new WaitForSeconds (immuneTime); 
				isImmune=false;

				anim.SetBool("Immune",false);
		}


    void Update()
    {




        // code for player dying not important now

        if (isDead == true)
        {

            if (Input.GetButtonDown("Restart"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


            return;

        }
        // movement set if player is on the ground

        if (!grounded && Input.GetAxisRaw("Horizontal") != previousAxispos)
        {
            BaseSpeed = 0;
            outsideForce = false;
        }
        previousAxispos = Input.GetAxisRaw("Horizontal");



        //MOVING CODE

        anim.SetFloat("velocityY", rb.velocity.y); // speed set for player velocity
        if (!outsideForce)
        { // if the player get hit by any object

            if (Input.GetAxisRaw("Horizontal") != 0)
            { // movement using arrow or A D
                anim.SetBool("Moving", true); // animation for movement
                rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed + BaseSpeed, rb.velocity.y); // making the player move
                transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal") * 1, 1, 1);
            }
            else
            { //for moving in the other direction
                anim.SetBool("Moving", false);
                rb.velocity = new Vector2(BaseSpeed, rb.velocity.y);
            }
        }
        //JUMPCODE arrow key to make the player jump using arrow you can change it in unity 
        grounded = Physics2D.OverlapArea(point1.position, point2.position, onlyGroundMask);




        anim.SetBool("Grounded", grounded);

        if (grounded && Input.GetKeyDown("up"))
        {
            timer = 0;
            canJump = true;
            rb.AddForce(new Vector2(0, jumpForce * 3));
        }
    }


        // dont bother this is just a death and alive mechanics

        void OnTriggerStay2D(Collider2D other)
	{
				if (other.tag == "deadly" && !isDead && lives <=1 && !isImmune) {
						rb.velocity = Vector2.zero;
			lives=0;
						StartCoroutine ("ImmuneTime");
						anim.SetBool ("Dies", true);
						rb.AddForce (new Vector2 (0, 500));
						isDead = true;
			
			
				} else if (other.tag == "deadly" && lives > 1 && !isImmune) {
			lives--;
			anim.SetBool("Immune",true);
						StartCoroutine ("ImmuneTime");
			isImmune=true;
				}

	}


	
	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "deadly" && !isDead && lives <=1 && !isImmune) {
			rb.velocity = Vector2.zero;
			lives=0;
			anim.SetBool ("Dies", true);
			rb.AddForce (new Vector2 (0, 500));
			isDead = true;
			
			
		} else if (other.gameObject.tag == "deadly" && lives > 1 && !isImmune) {
			lives--;
			anim.SetBool("Immune",true);
			isImmune=true;
		}
		
	}



    // set up a speed change if not collidding

	void OnCollisionEnter2D(Collision2D other)
	{
				outsideForce = false;


		if (other.gameObject.tag == "Platform")
						BaseSpeed = other.gameObject.GetComponent<Rigidbody2D>().velocity.x;
      


    }
 // draw on screen text  

    void OnGUI(){
		GUILayout.Label ("  Lives: " + lives); // txt on screen

	}

}
