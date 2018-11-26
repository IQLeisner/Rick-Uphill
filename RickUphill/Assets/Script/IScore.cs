using System.Collections;
using UnityEngine.EventSystems;

public interface IScore : IEventSystemHandler
{
    IEnumerable AddToScore();

    int? GetScore();
}
