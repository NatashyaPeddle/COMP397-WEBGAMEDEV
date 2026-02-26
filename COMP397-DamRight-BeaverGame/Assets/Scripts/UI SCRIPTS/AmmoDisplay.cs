//Kristopher Prince #301462555

using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] private PlayerShooter shooter;
    [SerializeField] private TextMeshProUGUI ammoText;

    void Update()
    {
        if (shooter != null && ammoText != null)
        {
            ammoText.text = "Ammo: " + shooter.ammo + " / " + shooter.maxAmmo;
        }
    }
}
