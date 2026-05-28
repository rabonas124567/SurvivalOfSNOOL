using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int HP=100;
    public GameObject bloodyScreen;
    public TextMeshProUGUI playerHealthUI;
    public GameObject gameOverUI;

    public bool isDead;

     private void Start()
    {
        playerHealthUI.text=$"Health: {HP}";
    
    }

    public void TakeDamage(int damageAmount)
     {
    HP-=damageAmount;
    if(HP<=0)
    {
        print("Player Dead");
        PlayerDead();
        isDead=true;
        
    }
    else
    {
         print("Player Hit");
         StartCoroutine(BloodyScreenEffect());
         playerHealthUI.text=$"Health: {HP}";
        
    }
}

private void PlayerDead()
{
        playerHealthUI.gameObject.SetActive(false);
        StartCoroutine(ShowGameOverUI());


}
private IEnumerator ShowGameOverUI()
{
     yield return new WaitForSeconds(1f);
     gameOverUI.gameObject.SetActive(true);

}

private IEnumerator BloodyScreenEffect()
{
  if(bloodyScreen.activeInHierarchy==false)
  {
    bloodyScreen.SetActive(true);
  }

  yield return new WaitForSeconds(15f);

  if(bloodyScreen.activeInHierarchy)
  {
    bloodyScreen.SetActive(false);
  }
}

   private void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("ZombieHand"))
    {
        if(isDead==false)
        {
         TakeDamage(other.gameObject.GetComponent<ZombieHand>().damage);
        }
        
    }
   }
 

}
