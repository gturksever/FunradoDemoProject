using UnityEngine;

public class JoystickPlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private Rigidbody rb;

    
    

    public void FixedUpdate()
    {
        if(!GameManager.Instance.InteractionEnemy && !GameManager.Instance.GameOver && !GameManager.Instance.LevelDone)
            PlayerMovement();
    }


    protected void PlayerMovement() 
    {
        Vector3 moveDirection = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;        
        Vector3 targetVelocity = moveDirection * speed;        
        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z);

        // Rotate the character towards the movement direction
        if (moveDirection != Vector3.zero)
        {
            GameManager.Instance.DoesMove = true;            
            Vector3 lookDirection = moveDirection.normalized;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            rb.MoveRotation(targetRotation);
        }
        else
        {
            GameManager.Instance.DoesMove = false;
            

        }

    }
}
