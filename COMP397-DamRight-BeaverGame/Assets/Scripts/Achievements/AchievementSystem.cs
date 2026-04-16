using System.Runtime.CompilerServices;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    [SerializeField] private VoidEventChannel jumpEvent;
    [SerializeField] private VoidEventChannel killEvent;
    [SerializeField] private VoidEventChannel stickEvent;
    [SerializeField] private VoidEventChannel reloadEvent;
    [SerializeField] private AchievementUI achievementUI;

    //Jump Achievement
    private int achievementJumps = 10;
    private int currentJumps = 0;

    //Stick Achievement
    private int achievementSticks = 6;
    private int currentSticks = 0;

    //Kill Achievement
    private int achievementKills = 5;
    private int currentKills = 0;

    //Reload Achievement
    private int achievementReloads = 1;
    private int currentReloads = 0;

    private bool jumpUnlocked = false;
    private bool killUnlocked = false;
    private bool stickUnlocked = false;
    private bool reloadUnlocked = false;

    private void OnEnable()
    {
        jumpEvent.OnEventRaised += JumpEventCalled;
        killEvent.OnEventRaised += KillEventCalled;
        stickEvent.OnEventRaised += StickEventCalled;
        reloadEvent.OnEventRaised += ReloadEventCalled;
    }

    private void OnDisable()
    {
        jumpEvent.OnEventRaised -= JumpEventCalled;
        killEvent.OnEventRaised -= KillEventCalled;
        stickEvent.OnEventRaised -= StickEventCalled;
        reloadEvent.OnEventRaised -= ReloadEventCalled;
    }

    private void JumpEventCalled()
    {
        currentJumps++;

        if (!jumpUnlocked && currentJumps >= achievementJumps)
        {
            Debug.Log("Achievement Unlocked: Hoppers");
            jumpUnlocked = true;
            UnlockAchievement("Hoppers", "Jumped 10 Times!");
        }
        
    }

    private void KillEventCalled()
    {
        currentKills++;

        if (!killUnlocked && currentKills >= achievementKills)
        {
            Debug.Log("Achievement Unlocked: Killer Instinct");
            killUnlocked = true;
            UnlockAchievement("Killer Instinct", "Defeated 5 Enemies!");
        }

    }

    private void StickEventCalled()
    {
        currentSticks++;

        if (!stickUnlocked && currentSticks >= achievementSticks)
        {
            Debug.Log("Achievement Unlocked: Sticky Situation");
            stickUnlocked = true;
            UnlockAchievement("Sticky Situation", "Collected 6 Branches!");
        }
        
    }

    private void ReloadEventCalled()
    {
        currentReloads++;

        if (!reloadUnlocked && currentReloads >= achievementReloads)
        {
            Debug.Log("Achievement Unlocked: Locked & Loaded");

            reloadUnlocked = true;
            UnlockAchievement("Tree Hugger", "Reloaded!");
        }

    }


    private void UnlockAchievement(string title, string description)
    {
        Debug.Log($"Achievement Unlocked {title}");

        if (achievementUI != null)
        {
            achievementUI.ShowAchievement(title, description);
        }
    }


//     if (shooter != null && ammoText != null)
//        {
//            ammoText.text = "Ammo: " + shooter.ammo + " / " + shooter.maxAmmo;
//        }

//if (InventoryPanel != null && InventoryPanel.activeSelf)
//{
//    if (shooter != null && InventoryAmmo != null)
//    {
//        InventoryAmmo.text = " " + shooter.ammo;
//    }
//}
}
