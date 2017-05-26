using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Grid))]
[CanEditMultipleObjects]
public class MyBlockDrawer : Editor
{
	SerializedProperty Info;
	Grid _grid;
	PrebsList _prefabs;

	private GameObject _selection;
	private int _indexWidth;
	private int _indexHeight;
	//PrefabsPool _pool;
	void OnEnable()
	{
		Info = serializedObject.FindProperty("BlockI");

		//_pool = GameObject.FindObjectOfType<PrefabsPool>();
		_grid = GameObject.FindObjectOfType<Grid>();
		_prefabs = GameObject.FindObjectOfType<PrebsList>();
		
		_selection = GameObject.FindObjectOfType<Selected>().gameObject; // GameObject.CreatePrimitive(PrimitiveType.Cube);
	}
	void OnDrawGizmosSelected()
	{
		// Display the explosion radius when selected
		Gizmos.color = new Color(1, 1, 0, 0.75F);
		Gizmos.DrawSphere(Vector3.zero,10);
	}
	public override void OnInspectorGUI()
	{
		///DrawDefaultInspector();
		///
		DrawDefaultInspector();
		var t = (target as Grid);

		if (GUILayout.Button("Save"))
		{
			t.UpdateVaribles();
		}
		if (!Application.isPlaying)
		{
			GUILayout.BeginHorizontal();
			_indexWidth = int.Parse(GUILayout.TextField(_indexWidth.ToString()));
			_indexHeight = int.Parse(GUILayout.TextField(_indexHeight.ToString()));
			GUILayout.EndHorizontal();
			_selection.transform.position = new Vector3(1.1f * _indexWidth, 0, 1.1f * _indexHeight);
			if (GUILayout.Button("Cicle"))
			{
				//if (_grid.Objects.Count == 0)
				//{
				//	_grid.InitGrid();
				//}
				//var t = (target as Grid);
				//Vector3 pos = t.Objects[_indexWidth][_indexHeight].Value.transform.position;
				//Transform parent = t.Objects[_indexWidth][_indexHeight].Value.transform.parent;
				//GameObject.DestroyImmediate(t.Objects[_indexWidth][_indexHeight].Value);
				//int temp = t.Objects[_indexWidth][_indexHeight].Key;
				//temp++;
				//temp %= _prefabs.GetPrefabs().Length;
				////t.Objects2[_indexWidth] = new KeyValuePair<int, GameObject>(temp,
				////	Instantiate(_prefabs.GetPrefabs()[temp]
				////		, pos, Quaternion.identity));
				//t.Objects[_indexWidth][_indexHeight].Value.transform.parent = parent;

			}
		
		}
		//if (GUILayout.Button("Cicle"))
		//{

		//	var t = (target as BlockID);

		//	if ((_grid.Blocks[t.IndexWidth][t.IndexHeight] as EmptyBlock) != null)
		//	{
		//		var obj = Instantiate(_pool.Block, t.transform.position, t.transform.rotation);
		//		//DestroyImmediate(_grid.Blocks[t.IndexWidth][t.IndexHeight].Represent);
		//		obj.transform.parent = t.transform.parent;
		//		obj.name = "Block";
		//		t.name = "unused";
		//		obj.AddComponent<BlockID>().IndexWidth = t.IndexWidth;
		//		obj.AddComponent<BlockID>().IndexHeight = t.IndexHeight;

		//		_grid.Blocks[t.IndexWidth][t.IndexHeight] = new Block(t.IndexWidth, t.IndexHeight, obj);
		//	}
		//	else if ((_grid.Blocks[t.IndexWidth][t.IndexHeight] as Block) != null)
		//	{
		//		var obj = Instantiate(_pool.EmptyBlock, t.transform.position, t.transform.rotation);
		//		//DestroyImmediate(_grid.Blocks[t.IndexWidth][t.IndexHeight].Represent);
		//		obj.transform.parent = t.transform.parent;
		//		obj.name = "Empty";
		//		t.name = "unused";
		//		t.GetComponent<Renderer>().enabled = false;
		//		obj.AddComponent<BlockID>().IndexWidth = t.IndexWidth;
		//		obj.AddComponent<BlockID>().IndexHeight = t.IndexHeight;

		//		_grid.Blocks[t.IndexWidth][t.IndexHeight] = new EmptyBlock(t.IndexWidth, t.IndexHeight, obj);
		//	}

		//	_grid.SaveLevel(_grid.level);
		//	//{
		//	//	t.MomentInfo2.Clear();
		//	//	foreach (var temp in Parameters.Names)
		//	//	{
		//	//		t.MomentInfo2.Add(new MomentInfo(temp));
		//	//	}
		//}


		this.Repaint();

	}
}
