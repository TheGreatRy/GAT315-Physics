using UnityEditor.Search;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	[Header("Player")]
	[SerializeField] CharacterController2D characterController;
	[SerializeField] AnimationEventRouter animationEventRouter;
	[SerializeField] GameObject meleeWeaponL;
	[SerializeField] GameObject meleeWeaponR;
	[SerializeField] ObserverExample observer;
	[SerializeField] IntDataSO scoreData;
	[SerializeField] EventChannelSO onPlayerDeath;


	private void Awake()
	{
		animationEventRouter.AddListener("MeleeAttack", OnMeleeAttack);
	}
    private void OnEnable()
    {
		observer.onFunctionStart += Observer;
    }
    private void OnDisable()
    {
		observer.onFunctionStart -= Observer;
    }
	private void Observer()
	{
		print("observer");
	}
    void OnMeleeAttack(AnimationEvent animationEvent)
	{
		if (characterController.Facing == CharacterController2D.FACE_LEFT) meleeWeaponL.SetActive((animationEvent.intParameter == 1));
		else if (characterController.Facing == CharacterController2D.FACE_RIGHT) meleeWeaponR.SetActive((animationEvent.intParameter == 1));
	}
	public void OnDeath()
	{
		onPlayerDeath?.Raise();
	}
}