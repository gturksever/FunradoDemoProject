using UnityEngine;

public class JoystickPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Rigidbody _rb;

    
    

    public void FixedUpdate()
    {
        if(!GameManager.Instance.InteractionEnemy && !GameManager.Instance.GameOver && !GameManager.Instance.LevelDone)
            PlayerMove();
    }


    protected void PlayerMove() 
    {
        Vector3 moveDirection = Vector3.forward * _floatingJoystick.Vertical + Vector3.right * _floatingJoystick.Horizontal;        
        Vector3 targetVelocity = moveDirection * _speed;        
        _rb.velocity = new Vector3(targetVelocity.x, _rb.velocity.y, targetVelocity.z);

        // Rotate the character towards the movement direction
        if (moveDirection != Vector3.zero)
        {
            GameManager.Instance.DoesMove = true;            
            Vector3 lookDirection = moveDirection.normalized;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            _rb.MoveRotation(targetRotation);
        }
        else
        {
            GameManager.Instance.DoesMove = false;
            

        }

    }
}
