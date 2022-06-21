using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IBonus : Player
{
    public Bonus bonus;
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;

    public void InitializeBonus(Bonus bonusData) 
    {
        icon.overrideSprite = bonusData.m_icon;
        title.text = bonusData.m_title;
        description.text = bonusData.m_description;
        bonus = bonusData;
    }

    public void ChooseBonus()
    {
        Debug.Log("Button pressed");
        
        switch (bonus.m_currentBonusType)
        {
            case bonusType.Attack:
                playerData.baseAttack += bonus.m_bonusValue;
                break;
            case bonusType.Defense:
                playerData.baseDefence += bonus.m_bonusValue;

                break;
            case bonusType.Weapon:
                if (bonus.weapon != null)
                {
                    if (PlayerShoot.currentWeapon == bonus.weapon)
                    {
                        if (PlayerShoot.weaponLevel < PlayerShoot.weaponLevelMax - 1)
                        {
                            PlayerShoot.weaponLevel += 1;
                        }
                    }
                    else
                    {
                        PlayerShoot.ChangeWeapon(bonus.weapon);
                    }
                }
                break;
            case bonusType.Speed:
                playerData.speed += bonus.m_bonusValue;

                break;
            default:
                break;
        }
    }
}
