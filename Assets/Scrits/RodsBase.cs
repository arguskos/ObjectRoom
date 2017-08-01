using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodsBase : MonoBehaviour
{

	private bool _blockInput;
	private Vector3 _scale;
	private bool _isHided;

	private GameObject _parent;
	// Use this for initialization
	public  void Init ()
	{

		_scale = transform.localScale;
		_parent = new GameObject("Parent of "+transform.name);
		_parent.transform.position = new Vector3(transform.position.x, transform.position.y -1 / 2.0f, transform.position.z);
		transform.parent = _parent.transform;
		//StartCoroutine(Hide());
		//Toggle();
	}

	public virtual void Toggle()
	{
		if (!_blockInput)
		{
			if (_isHided)
			{
				StartCoroutine(Show());
			}
			else
			{
				StartCoroutine(Hide());

			}
		}
	}
	public IEnumerator Show()
	{
		float time = 0;
		_blockInput = true;
		
		while (time < 1)
		{
			time += 0.1f;
			_parent.transform.localScale = Vector3.Lerp(new Vector3(1, 0, 1), new Vector3(1, 1,1), time);

			yield return null;
		}
		//transform.parent = null;
		_blockInput = false;
		_isHided = false;

	//	Destroy(temp.gameObject);
	}
	public IEnumerator Hide()
	{
		float time = 0;
		_blockInput = true;
	
		while (time<1)
		{
			time += 0.1f;
			_parent.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(1, 0, 1), time);
			yield return null;
		}
		_blockInput = false;
		_isHided = true;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
