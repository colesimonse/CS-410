using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private int number_of_jumps;
    private int jump_count;
   


   
    
    private float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        number_of_jumps = 0;
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        jump_count = 0;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;


    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winTextObject.SetActive(true);

        }
    }
    
        
    
    
    
   void secound_j()
   {
    if(Input.GetKeyDown("space") && number_of_jumps ==1)
    {
        Vector3 jump = new Vector3 (0.0f,250.0f,0.0f);
        rb.AddForce(jump);
        Debug.Log("jump");
        number_of_jumps = 0;


    }


   }
   void FixedUpdate()
    {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
    rb.AddForce(movement * speed);

        if(Input.GetKeyDown("space") && rb.transform.position.y <= 1.5f)
        {
            Vector3 jump = new Vector3 (0.0f,250.0f,0.0f);
            rb.AddForce(jump);
            Debug.Log("jump");
            number_of_jumps = 1;
            
            
            
        }
        else if(Input.GetKeyDown("space") && number_of_jumps == 1)
        {
            Vector3 jump = new Vector3 (0.0f,250.0f,0.0f);
            rb.AddForce(jump);
            number_of_jumps = 0;

        }
    }
    
    
   
   private void OnTriggerEnter(Collider other)
   {    if(other.gameObject.CompareTag("PickUp"))
        {

        other.gameObject.SetActive(false);
        count += 1;
        SetCountText();
        }

   }
  
}