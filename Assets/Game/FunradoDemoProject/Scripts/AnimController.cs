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
        if (GameManager.Instance.InteractionEnemy == true && GameManager.Instance.CanKill == false)
        {
            _playerAnimator.SetTrigger("Death");
            _enemyAnimator.SetBool("enemyAttack", true);
        }
    }

    public void PlayerMoveAnimation()
    {
        if (GameManager.Instance.DoesMove == false)
            _playerAnimator.SetBool("Running", false);
        else
            _playerAnimator.SetBool("Running", true);
    }
   
}
