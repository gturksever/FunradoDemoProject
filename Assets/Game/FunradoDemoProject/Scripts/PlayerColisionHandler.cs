using UnityEngine;

public class PlayerColisionHandler : MonoBehaviour
{
    private GameObject _enemy;  
    private void OnTriggerEnter(UnityEngine.Collider other)
    {        
        if (other.gameObject.CompareTag("Enemy"))
        {
            _enemy = other.gameObject;

            if (UIController.enemyLevel <= UIController.playerLevel)
            {
                AttackInteraction(true);
                Destroy(other.gameObject,1.5f);
            }
                

            else
                AttackInteraction(false);

            Invoke("DoesInteractionEnemyFalse", 1f);
        }

        if (other.gameObject.CompareTag("Upgrader"))
        {
            GameManager.Instance.HasUpgraded = true;
            Destroy(other.gameObject,.2f);
        }

        if (other.gameObject.CompareTag("BlueKey"))
        {
            GameManager.Instance.BlueDoorBlocker.SetActive(false);
            GameManager.Instance.BlueKey.SetActive(false);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.Instance.LevelDone = true;
        }
    }
  
    public void DoesInteractionEnemyFalse()
    {        
        GameManager.Instance.InteractionEnemy = false;
    }

    public void AttackInteraction(bool i)
    {
        GameManager.Instance.InteractionEnemy = true;
        GameManager.Instance.CanKill = i;
        
    }
 
}
