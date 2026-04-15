using UnityEngine;

public class EventChannelManager : PersistentSingleton<EventChannelManager>
{
    public VoidEventChannel jumpEvent;
    public VoidEventChannel killEvent;
    public VoidEventChannel stickEvent;
    public VoidEventChannel reloadEvent;
}
