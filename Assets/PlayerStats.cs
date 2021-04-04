using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   public static PlayerStats instance;
   [SerializeField] private int lvl;
   [SerializeField] private int xpToNextLvl;
   [SerializeField] private int currentHP;
   [SerializeField] private int maxHP;
   [SerializeField] private int currentMP;
   [SerializeField] private int maxMP;
   [SerializeField] private int agility;
   [SerializeField] private int intellect;
   [SerializeField] private int vitality;

   private void Awake()
   {
      instance = this;
   }

   public int GetAttack()
   {
      return 10;
   }

   public void TakeDamage(int attack)
   {
      currentHP -= attack;
   }
}
