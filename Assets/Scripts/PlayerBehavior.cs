using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //1. access (public or private)
    //2. type (int, float, bool)
    //3. Name (naming conventions) tehy always start with a letter that is not capitalized, but you can have multiple words with no spaces and following words could be capitalized
    //4. OPTIONAL: You can give it a value 
    //Borders on screen (x) 14.5 (y) 6.5

    public float speed;
    public float horizontalInput;
    public float verticalInput;
    public float horizontalScreenLimit;
    public float floorScreenLimit;
    public float ceilingScreenLimit;
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        speed = 4f;
        horizontalScreenLimit = 14.5f;
        ceilingScreenLimit = 0f;
        floorScreenLimit = -6.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            //I am outside the screen from the right
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        }
        else if (transform.position.x < -horizontalScreenLimit)
        {  //I am outside the screen limit from the left
            transform.position = new Vector3(horizontalScreenLimit * -1, transform.position.y, 0);
        }
        if (transform.position.y > ceilingScreenLimit || transform.position.y < floorScreenLimit)
        { //I am outside the screen limit from the top
            transform.position = new Vector3(transform.position.x,
                                  Mathf.Clamp(transform.position.y + Time.deltaTime * speed, -6.0f, 0f),
                                  transform.position.z);
        }
        
    }

    void Shooting()
    {
        //if I press SPACE create a bullet
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //create a bullet
            Instantiate(bulletPrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
        }
    }
    }