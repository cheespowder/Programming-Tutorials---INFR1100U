using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayers;
    

    private bool isGrounded;
    private Vector3 _moveDirection;

    //Camera
    [SerializeField,Range(1,20)] private float mouseSensX;
    [SerializeField, Range(1,20)] private float mouseSensY;
    
    [SerializeField, Range(-90,0)] private float minViewAngle;
    [SerializeField, Range(0,90)] private float maxViewAngle;
    
    
    [SerializeField] private Transform followTarget;

    //shooting
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float projectileForce;

   
    
    private Vector2 currentAngle;

    private Rigidbody rb;
    private float depth;
    
    // Start is called before the first frame update
    void Start()
    {
        InputManager.init(this);
        InputManager.SetGameControls();

        rb = GetComponent<Rigidbody>();
        depth = GetComponent<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.rotation * (speed * Time.deltaTime * _moveDirection);
    }

    public void SetMovementDirection(Vector3 currentDirection)
    {
        _moveDirection = currentDirection;
        CheckGround();
    }

   public void Jump()
    {
        Debug.LogFormat("Jump Called");
        if (isGrounded)
        {
            Debug.Log("I jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

   private void CheckGround()
   {
       isGrounded = Physics.Raycast(transform.position, Vector3.down, depth, groundLayers);
       Debug.DrawRay(transform.position, Vector3.down * depth, Color.green, duration:0, depthTest:false);
   }

   public void Shoot()
   {
      Rigidbody currentProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
      
      currentProjectile.AddForce(followTarget.forward * projectileForce, ForceMode.Impulse);
      
      Destroy(currentProjectile.gameObject, 4);
   }

   public void SetLookRotation(Vector2 readValue)
   {
       currentAngle.x += readValue.x * Time.deltaTime * mouseSensX;
       currentAngle.y += readValue.y * Time.deltaTime * mouseSensY;

       currentAngle.y = Mathf.Clamp(currentAngle.y, minViewAngle, maxViewAngle);
       
       transform.rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up);
       followTarget.localRotation = Quaternion.AngleAxis(currentAngle.y, Vector3.right);
   }
}
