//Kristopher Prince #301462555
//Natashya Peddle  301487275

using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] private PlayerShooter shooter;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI InventoryAmmo;
    [SerializeField] private GameObject InventoryPanel;
  

    void Update()
    {
        if (shooter != null && ammoText != null)
        {
            ammoText.text = "Ammo: " + shooter.ammo + " / " + shooter.maxAmmo;
        }

        if (InventoryPanel != null && InventoryPanel.activeSelf)
        {
            if (shooter != null && InventoryAmmo != null)
            {
                InventoryAmmo.text = " " + shooter.ammo;
            }
        }

        
    }
}
