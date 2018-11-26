using System.Collections;
using UnityEngine.EventSystems;

public interface IInvincibility : IEventSystemHandler
{
    IEnumerable isInvincible();
    IEnumerable isNotInvincible();
    IEnumerable setInvincible();

    bool GetInvincible();
}
