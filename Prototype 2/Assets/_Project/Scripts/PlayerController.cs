using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float xRange = 10.0f;
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
        // Get the horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // Transform.translate based movement
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Velocity based movement application
        // rb.velocity = new Vector3(horizontalInput, 0, 0) * 10;

        /// <summary> -- Clamp the position of the player within the xRange -- </summary>
        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
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
