using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    //1. access level: public and private
    //2. type: int, float
    //3. name
    //4. optional: give it an initial value

    private float horizontalInput;
    private float verticalInput;
    private float speed;
    private int lives;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Shooting();
    }

    void Moving()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        // if my x/y position is too big
        if (transform.position.x > 11.5f || transform.position.x <= -11.5f)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y <= -5f)
        {
            transform.position = new Vector3(transform.position.x, -5f, 0);
        }
        if (transform.position.y >= 0.6f)
        {
            transform.position = new Vector3(transform.position.x, 0.6f, 0);
        }
    }
    void Shooting()
    {
        //if SPACE key is pressed create a bullet; what is a bullet?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //create a bullet at my position with my rotation
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
