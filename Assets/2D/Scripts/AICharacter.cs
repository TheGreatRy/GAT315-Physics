using Mono.Cecil;
using System.Collections;
using UnityEngine;

public class AICharacter : MonoBehaviour
{
	public enum State
	{
		Idle,
		Patrol,
		Chase,
		Attack,
		Death,
		Any
	}

	[SerializeField] CharacterController2D characterController;
	[SerializeField] AnimationEventRouter animationEventRouter;
	[SerializeField] RaycastInteractor2D raycastInteractor;

	public CharacterController2D CharacterController => characterController;

	GameObject target = null;
	State state = State.Idle;
	public State CurrentState => state;
	
	private void Awake()
	{
		characterController.OnMove(new Vector2(1, 0));
		state = State.Patrol;
	}

	void Update()
	{
		if (target != null)
		{
			if (target.transform.position.x < transform.position.x) SetDirection(-1);
			else SetDirection(1);

			Vector2 direction = target.transform.position - transform.position;
			if (direction.magnitude < 1)
			{
				characterController.OnAttack();
			}
		}
		raycastInteractor.Direction = characterController.Facing;
	}

	public void Idle(float time)
	{
		StartCoroutine(WaitIdle(time));
	}

	public void SetDirection(int direction)
	{
		characterController.OnMove(new Vector2(direction, 0));
	}

	public void FlipDirection()
	{
		characterController.OnMove(new Vector2(characterController.Facing * -1, 0));
	}

	public void RandomDirection()
	{
		characterController.OnMove(new Vector2(characterController.Facing * ((Random.value <= 0.5f) ? 1 : -1), 0));
	}
	
	public void Jump()
	{
		characterController.OnJump();
	}

	public void SetTargetGameObject(GameObject go)
	{
		target = go;
	}

	public void OnDeath()
	{
		state = State.Death;	
	}
	public void OnDamage()
	{
		print("damaged!");
	}
	IEnumerator WaitIdle(float time)
	{
		state = State.Idle;
		characterController.OnMove(new Vector2(0, 0));
		yield return new WaitForSeconds(time);
		characterController.OnMove(new Vector2(((Random.value <= 0.5f) ? CharacterController2D.FACE_LEFT : CharacterController2D.FACE_RIGHT), 0));
		state = State.Patrol;
	}
}
