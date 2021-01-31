using UnityEngine;
using UnityEngine.Events;

// * Refactor for generality
public class LockableDoor : MonoBehaviour
{
    [SerializeField] UnityEvent OnOpen;
    [SerializeField] UnityEvent OnClose;
    [SerializeField] UnityEvent OnLock;
    [SerializeField] UnityEvent OnUnlock;
    
    public bool locked;
    public bool open;
    
    void Start() { SetLock(locked); }

    public void SetLock(bool value)
    {
        locked = value;
        if (value) OnLock.Invoke();
        else OnUnlock.Invoke();
    }
    
    public void RequestSetOpen(bool value)
    {
        if (locked) return;
        open = value;
        if (open) OnOpen.Invoke();
        else OnClose.Invoke();
    }
}
