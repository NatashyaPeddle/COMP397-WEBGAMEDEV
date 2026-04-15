using System.Runtime.CompilerServices;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    [SerializeField] private VoidEventChannel jumpEvent;
    [SerializeField] private VoidEventChannel killEvent;
    [SerializeField] private VoidEventChannel stickEvent;
    [SerializeField] private VoidEventChannel reloadEvent;

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

    private void OnEnable()
    {
        jumpEvent.OnEventRaised += JumpEventCalled;
        killEvent.OnEventRaised += KillEventCalled;
        stickEvent.OnEventRaised += StickEventCalled;
        reloadEvent.OnEventRaised += ReloadEventCalled;
    }

    private void OnDisabled()
    {
        jumpEvent.OnEventRaised -= JumpEventCalled;
        killEvent.OnEventRaised -= KillEventCalled;
        stickEvent.OnEventRaised -= StickEventCalled;
        reloadEvent.OnEventRaised -= ReloadEventCalled;
    }

    private void JumpEventCalled()
    {
        currentJumps++;

        if (currentJumps == achievementJumps)
        {
            Debug.Log("Achievement Unlocked: Hoppers");
        }
        
    }

    private void KillEventCalled()
    {
        currentKills++;

        if (currentKills == achievementKills)
        {
            Debug.Log("Achievement Unlocked: Killer Instinct");
        }

    }

    private void StickEventCalled()
    {
        currentSticks++;

        if (currentSticks == achievementSticks)
        {
            Debug.Log("Achievement Unlocked: Sticky Situation");
        }
        
    }

    private void ReloadEventCalled()
    {
        currentReloads++;

        if (currentReloads == achievementReloads)
        {
            Debug.Log("Achievement Unlocked: Locked & Loaded");
        }
        
    }
}
