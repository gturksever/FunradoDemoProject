using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _enemyAnimator;

    private void Update()
    {
        if(_playerAnimator!=null)
        
        PlayerMoveAnimation();
        PlayerAttackAnimation();
        PlayerDeathAnimation();
    }

    public void PlayerAttackAnimation()
    {
        if (GameManager.Instance.InteractionEnemy == true && GameManager.Instance.CanKill == true)
        {
            _playerAnimator.SetTrigger("Attack");
            _enemyAnimator.SetBool("isDead", true);
            
        }
    }

    public void PlayerDeathAnimation()
    {
        if (GameManager.Instance.InteractionEnemy && !GameManager.Instance.CanKill)
        {
            _playerAnimator.SetTrigger("Death");
            _enemyAnimator.SetBool("enemyAttack", true);
        }
    }

    public void PlayerMoveAnimation()
    {
        
            _playerAnimator.SetBool("Running", !GameManager.Instance.DoesMove);
                    
    }
   
}
