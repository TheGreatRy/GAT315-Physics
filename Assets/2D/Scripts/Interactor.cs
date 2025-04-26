
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
	public UnityEvent<GameObject> onInteractorStart;
	public UnityEvent<GameObject> onInteractorActive;
	public UnityEvent<GameObject> onInteractorEnd;
}
