using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //lets you use UI buttons
using UnityEngine.SceneManagement; //lets you call scene manager which loads levels
using UnityEngine.Audio; //calls audio mixer

public class CSharpNotes2 : MonoBehaviour

{
    //Kira Hughes
    public CSharpNotes2 n2;
    public GameObject GO;
    public Image myimage; //called from using (above)
    public Button mybutton;
    public float timer;
    public GameObject money;

    //ARRAY
    //an array is a collection of gameObjects.
    //arrays allow us to affect large groups of objects

    public GameObject[] alltheenemies; //straight brackets signify a collection of GameObjects

    //PLAYER PREFS
    //these are values that will save even after the player leaves the game
    //this is good for unlockible content or overall progress, and character skins (!)

    public int GreenBird; //this is not a player pref just a normal int

    // Start is called before the first frame update
    //AI
    //MOVE TOWARDS (moves object towards another) such as flying enemy
    public Vector3 start; //the start location
    public Vector3 finish; //the end location/target
    public float speed; //how fast the object moves from start to finish

    void Start()
    {

        PlayerPrefs.SetInt("GreenBird", 2);
        //this unlocks the green bird when played second time, unlocked forever unless game is uninstalled

        if(PlayerPrefs.HasKey("GreenBird"))
        {
            GreenBird = PlayerPrefs.GetInt("GreenBird");
            //if game was previously beaten it is 2, if not it is 1
        }

        if(GreenBird == 2)
        {
            //I can select green bird
        }

        //ENABLED VS SET ACTIVE
        //we enable and disable components attatched to gameObjects
        //we set active true or false to entire gameObjects

        n2.enabled = true; //enabled the notes2 script (box collider, scripts, components)
        GO.SetActive(true); //enabled the entire gameObject
        StartCoroutine(StarPower()); //this line calls the IEnumerator (don NOT do this in update)
    }

    // Update is called once per frame
    void Update()
    {
        //TIMERS
        //we can create timers using command Time.deltaTime
        //This is the time that has past since the last frame (so a constant timer)
        //we can take a float and add or subtract Time.deltaTime that counts up or down
        timer -= Time.deltaTime; //-= subtracts time from timer, += adds time to timer

        if (timer >= 0)
        {
            mybutton.interactable = true; //allows button to be pressed
        }

        if (timer < 0)
        {
            mybutton.interactable = false; //this grays out button and it cannot be pressed
        }

        Vector3.MoveTowards(start, finish, speed); //this line will move the object
        //start position set to movers position
        //target position gets set to another GameObject (such as the player)
        //speed is constant


        //INSTANTIATE is a way to make objects appear in our scene, this could be enemies, loot, power ups

        GameObject loot = Instantiate(money, transform.position, transform.rotation);
        //Above code creates money at our currant location
        //we say GameObject loot to create a new GameObject in the hierarchy called loot
        //Money is usually a prefab that we can call over and over again
        //this means money won't be in the heirarchy but inside the game's asset folder
        Destroy(money, 5f); //destroys the money we don't pick up fast enough

        //AUTOPOOLING
        //we are using a plugin called Mob FArm Auto Pooler
        GameObject loot2 = MF_AutoPool.Spawn(money, transform.position, transform.rotation);
        //mobile friendly version
        MF_AutoPool.Despawn(this.gameObject, 5f); //this would take the money away and add it back to the pool
                                                  //line is on money itself

        //ARRAY
        //How to go thro your list and affect each object one at a time
        //FOR LOOP
        for (int i = 0; i<alltheenemies.Length; i++)
        {
            alltheenemies[i].SetActive(true); //we set all the enemies as active
        }
// int i = 0 means we start at the top of the list
// i < allenemies, means as long as the number we're on isn't larger than the list i++
//we move down the list by 1, starting at 0 (list is 10 long, we add 1 until we get to 10)
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this statement is used to trigger something when a player walks to a specific location
        //Such as a cutscene, animation, enemy appearing, etc
        //Event triggered when player passes thro collider marked as trigger
        //player and/or trigger must have rigidbody to register
        //enter=activates when entered, exit activates when exited

        if(collision.tag == "Player")
        {
            //this will make it so only the player will cause the event, so enemies or other objects cannot
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //unlike triggers, collisions happen when two colliders bump into each other
        //such as a falling platform, hit/hurtboxes, etc
    }

    //CO-ROUTINE which is what Unity calls IEnumerator
    //normal functions in unity are read top to bottom all at once.
    //sometimes we want to pause before finishing the function which is when we use the IEnumerator
    //Its like the star power in SMB, getting the start is time based and changes music, sprite, and player is invinsible
    //eventually wears off

    public IEnumerator StarPower()
    {
        //give Mario star power
        //change music
        //change sprite
        //then we wait
        yield return new WaitForSeconds(5f); //Unity waits 5 seconds
        //star power wears out
        //change music back
        //change sprite back
        yield return new WaitForSeconds(5f);
    }

    //to call an IEnumerator we use the word Co-Routine (see Start loop)
}
