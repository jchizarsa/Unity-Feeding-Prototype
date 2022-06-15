using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int lives = 3;
    [SerializeField] private float horizontalInput;
    [SerializeField] Vector3 moveVector;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float xRange = 10.0f;
    [SerializeField] private float zLimit = 15.0f;
    [SerializeField] private GameObject projectilePrefab;
    private Rigidbody rb; // Used for velocity based movement
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Used for velocity based movement
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input
        moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        // Velocity based movement application
        transform.Translate(moveVector * speed * Time.deltaTime);
        

        /// <summary> -- Clamp the position of the player within the xRange -- </summary>
        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z < -2){
            transform.position = new Vector3(transform.position.x, transform.position.y, -2);
        }
        if(transform.position.z > zLimit){
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }
        //----------------------------------------------------------------------------------

        if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
        
    }

    /// <summary> -- Fire a projectile -- </summary>
    void Shoot(){
        // Launch a projectile from the player's position
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
