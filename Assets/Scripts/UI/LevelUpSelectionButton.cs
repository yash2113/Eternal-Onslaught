using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSelectionButton : MonoBehaviour
{
    public TMP_Text upgradeDescText;
    public TMP_Text nameLevelText;

    public Image weaponIcon;

    private Weapon assignedWeapon;

    public void UpgradeButtonDisplay(Weapon theWeapon)
    {
        if (theWeapon.gameObject.activeSelf)
        {
            upgradeDescText.text = theWeapon.stats[theWeapon.weaponLevel].upgradeText;
            weaponIcon.sprite = theWeapon.icon;

            nameLevelText.text = theWeapon.name + " - Lvl " + theWeapon.weaponLevel;
        }
        else
        {
            upgradeDescText.text = "Unlock " + theWeapon.name;
            weaponIcon.sprite = theWeapon.icon;

            nameLevelText.text = theWeapon.name;
        }
        assignedWeapon = theWeapon;
    }

    public void SelectUpgrade()
    {
        if(assignedWeapon != null)
        {
            if(assignedWeapon.gameObject.activeSelf)
            {
                assignedWeapon.LevelUp();
            }
            else
            {
                PlayerController.instance.AddWeapon(assignedWeapon);
            }

            UIController.instance.levelUpPanel.SetActive(false);

            Time.timeScale = 1f;
        }
    }

}
