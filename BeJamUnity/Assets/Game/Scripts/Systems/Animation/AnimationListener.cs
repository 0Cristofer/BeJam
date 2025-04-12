using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationListener : MonoBehaviour, IAnimationCompleted
{
	#region Animator Move
	public UnityEvent onAnimatorMoveEvent = new UnityEvent();

	public void addAnimatorMoveListener(UnityAction callback)
	{
		onAnimatorMoveEvent.AddListener(callback);
	}

	public void removeAnimatorMoveListener(UnityAction callback)
	{
		onAnimatorMoveEvent.RemoveListener(callback);
	}

	private void OnAnimatorMove()
	{
		onAnimatorMoveEvent.Invoke();
	}
	#endregion

	[System.Serializable]
	public class IntUnityEvent : UnityEvent<int> { }
	private Dictionary<int, IntUnityEvent> animationCompletedCallback = new Dictionary<int, IntUnityEvent>();

	public void animationCompleted(int shortHashName)
	{
		IntUnityEvent eventCallback;
		if (animationCompletedCallback.TryGetValue(shortHashName, out eventCallback))
		{
			eventCallback.Invoke(shortHashName);
		}
	}

	public void addAnimationCompletedCallback(int shortHashName, UnityAction<int> callback)
	{
		IntUnityEvent eventCallback;
		if (animationCompletedCallback.TryGetValue(shortHashName, out eventCallback))
		{
			eventCallback.AddListener(callback);
		}
		else
		{
			eventCallback = new IntUnityEvent();
			eventCallback.AddListener(callback);
			animationCompletedCallback.Add(shortHashName, eventCallback);
		}
	}

	public void removeAnimationCompletedCallback(int shortHashName, UnityAction<int> callback)
	{
		IntUnityEvent eventCallback;
		if (animationCompletedCallback.TryGetValue(shortHashName, out eventCallback))
		{
			eventCallback.RemoveListener(callback);
		}
	}
}
