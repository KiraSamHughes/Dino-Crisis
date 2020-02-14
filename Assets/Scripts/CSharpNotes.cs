using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpNotes : MonoBehaviour
{
          //Kira Hughes
    //Double forward slash not read
    //Top of script generally has variables. Such as numbers, references to other scripts, or object references
    //Variables have three parts, public/private, type of variable, and name of variable

          //NUMBER VARIABLES
    //Two common types of number variables, float and ints
    public float number; //floating point number, number has a decimal point
   public int wholenumber; //1, 2, 3, etc: intergers
    private float myhiddennumber; // a private variable that is not visible inside the inspector

         //BOOLS (True/False statements)
    public bool yesorno; //binary, on or off, no in between

        //Other common variables
   public GameObject mygameObject; //reference any object held in scene.
    //All objects in script are considered game objects
  public CSharpNotes CSN; //reference any of our public scripts
   public Rigidbody2D myRB2D; //Used for anything that is affected by physics, such as player and enemies
  public BoxCollider2D myboxcollider; //Used as reference for colliders
   public CircleCollider2D mycirclecollider;

    // Start is called before the first frame update
    //Anything that happens before game starts goes there
    void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>(); //This will get the rigid body but only if it's on the same object as out script
        myRB2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //Be careful not to have Game be plural unless you're calling multiple objects!
        //This finds the object marked player and gives it physics (RigidBody)

        myRB2D = GameObject.FindObjectOfType<RigidBody2D>();
        //This only works if there's only one RigidBody

        //when out game starts we may want to look at the properties of our game objects,
        //transform, position, rotation, scale
        transform.position = new Vector2(0, 0);
        //transform position is location on x and y
        //transform is read by unity as a Vector (2 or 3)
        //x is horizontal, y is vertical

        //This is used for scale as well
        transform.localScale = new Vector2(0, 0);
        //Vector3 is 3D, has three variables (0, 0, 0)

        //Rotation is more complex, using quaternion and EULER (oiler)
        transform.rotation = Quaternion.Euler(0, 0, 0); 


    }

    // Update is called once per frame (speed changes with framrate)
    //Gets called constantly
    //Anything that happens while the game is running goes here
    //Spawning items or enemies, changing characters, using script to automatically find objects
    void Update()
    {
        //IF STATEMENTS
        if (yesorno == true)
        {
            //if yes,
            //player lives
        }

        if (yesorno == false)
        {
            //if no,
            //player dies
        }
        //one way BOOLs work, true means one thing, false means another. Does not have to be opposites
        //if statement needs double equal sign. Single means it IS true or false. Double checks to see IF it's true or false

        if(number >= 10)
        {
            //we do something
        }

        //We can also use if statements to control the player
        if(Input.GetAxis("Horizontal") > 0)
        {
            //we move the player
            myRB2D.velocity = new Vector2(25, 0);
        }

        if(Input.GetAxis("Horizontal") == 0)
            //we stop the player
            myRB2D.velocity = new Vector2(0, 0); //zeroed velocity

        //To see all the different RigidBody options we type myRB2D. (period)
        myRB2D.gravityScale = .5f; //gives half gravity
        myRB2D.simulated = false; //rigid body no longer affected by physics
        myRB2D.isKinematic = true; //Kinimatic rigidbody only moves if the code tells it to
        myRB2D.isKinematic = false; //non kinimatic is the same dynamic so it is not affected by physics

             //IF ELSE STATEMENTS
        //IF statements get read one after the other
        //can somethimes cause weird behaviour
        //IF ELSE statements helps us avoid this

        if (yesorno == true)
        {
            //we say no
            //the player dies
            //if above statement is not true we will read this else statement
        }

        //because this code is in the update loop changes can happen quicklt and we can
        //cycle thro multiple if statements faster than we want. This is why we use else

        public void FixedUpdate()
    {
      //regular update is based on framerate, better computer could be too fast or older could be too slow
      //not ideal
      //graphic elements can live in the update loop without issue
      //the fixed update loop is used for physics calculation, so all computers run game at same speed.
      //fixed update calls update at fixed intervals
    }

}
}
