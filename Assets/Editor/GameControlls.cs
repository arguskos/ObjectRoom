using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameControlls : EditorWindow
{


	private Grid _grid;
	//	private string _id = "";
	private int _selected = -1;

	private bool _saveButtonPrssed = false;
	private bool _isLoaded = false;
	private bool _loadButton = false;
	private int _row;
	private int _col;
	private bool _edit;

	readonly private int MaxCols=12;
	readonly private int MaxRow=4;
	
	// Add menu item named "My Window" to the Window menu
	[MenuItem("Window/My Window")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(GameControlls));
	}

	void OnEnable()
	{
		Debug.Log("enable");
		_grid = GameObject.FindGameObjectWithTag("MainGrid").GetComponent<Grid>();


	}

	public void MoveSelectedEditor(int i)
	{
		//TODO   POSSBILE BUG IN PLAY MODE 
		GameObject selcted = FindObjectOfType<Selected>().gameObject;
		selcted.transform.position = _grid.Objects2[i].GetPos();

	}
	void Awake()
	{
		Debug.Log("awake menu");
		_grid = GameObject.FindGameObjectWithTag("MainGrid").GetComponent<Grid>();

	}
	void OnInspectorUpdate()
	{
		// Call Repaint on OnInspectorUpdate as it repaints the windows
		// less times as if it was OnGUI/Update
		Repaint();
	}

	void Update()
	{
		if (_loadButton )
		{
			_isLoaded = true;
			Debug.Log("update gui");
			_grid = GameObject.FindGameObjectWithTag("MainGrid").GetComponent<Grid>();
			_grid.EditorLoad();
		}
		if (_selected != -1)
		{
			_grid = GameObject.FindGameObjectWithTag("MainGrid").GetComponent<Grid>();
			//Debug.Log(_selected+"____"+(_col*MaxRow+_row));
			if (Application.isPlaying)
			{
				if (_edit)
				{
					_grid.CicleEditor(_selected);
				}
				else
				{
					_grid.OnButtonPress(_selected);
				}
			}
			MoveSelectedEditor(_selected);
		}
		if (_saveButtonPrssed)
		{

			_grid = GameObject.FindGameObjectWithTag("MainGrid").GetComponent<Grid>();
			_grid.Save();
		}
	}
	void OnGUI()
	{
		//if (_grid == null)
		//{
		//	Debug.Log("no grid ");
		//	return;

		//}
		_selected = -1;
		_loadButton = (GUILayout.Button("Load"));



		_edit = GUILayout.Toggle(_edit, "Edit");
		//TODO unhardcode 
		for (int i = 0; i < MaxRow; i++)
		{
			GUILayout.BeginHorizontal();

			for (int j = 0; j < MaxCols; j++)
			{
				int index = (j * MaxRow + i);
			
				if (GUILayout.Button((index).ToString()))
				{

					_row=j;
					_col=i;
					_selected = index;


				}
			}
			GUILayout.EndHorizontal();

		}
		GUILayout.BeginHorizontal();

		EditorGUI.BeginChangeCheck();
		//_id = GUILayout.TextField(_id);
		EditorGUI.EndChangeCheck();
		//if (GUILayout.Button("Cicle"))
		//{

		//}
		GUILayout.EndHorizontal();
		_saveButtonPrssed = GUILayout.Button("Save");

		//int pressed = -1;

		//GUILayout.BeginHorizontal();
		//if (GUILayout.Button("3"))
		//{
		//	pressed = 3;
		//}
		//if (GUILayout.Button("7"))
		//	pressed = 7;
		//if (GUILayout.Button("11"))
		//	pressed = 11;
		//if (GUILayout.Button("15"))
		//	pressed = 15;
		//if (GUILayout.Button("19"))
		//	pressed = 19;
		//if (GUILayout.Button("23"))
		//	pressed = 23;

		//GUILayout.EndHorizontal();
		//GUILayout.BeginHorizontal();
		//if (GUILayout.Button("2"))
		//	pressed = 2;

		//if (GUILayout.Button("6"))
		//	pressed = 6;

		//if (GUILayout.Button("10"))
		//	pressed = 10;

		//if (GUILayout.Button("14"))
		//	pressed = 14;

		//if (GUILayout.Button("18"))
		//	pressed = 18;

		//if (GUILayout.Button("22"))
		//	pressed = 22;

		//GUILayout.EndHorizontal();
		//GUILayout.BeginHorizontal();
		//if (GUILayout.Button("1"))
		//	pressed = 1;

		//if (GUILayout.Button("5"))
		//	pressed = 5;

		//if (GUILayout.Button("9"))
		//	pressed = 9;

		//if (GUILayout.Button("11"))
		//	pressed = 11;

		//if (GUILayout.Button("15"))
		//	pressed = 15;

		//if (GUILayout.Button("19"))
		//	pressed = 19;

		//GUILayout.EndHorizontal();
		//GUILayout.BeginHorizontal();
		//if (GUILayout.Button("0"))
		//	pressed = 0;

		//if (GUILayout.Button("4"))
		//	pressed = 4;

		//if (GUILayout.Button("8"))
		//	pressed = 8;

		//if (GUILayout.Button("12"))
		//	pressed = 12;

		//if (GUILayout.Button("16"))
		//	pressed = 16;

		//if (GUILayout.Button("20"))

		//	pressed = 20;

		//GUILayout.EndHorizontal();
		//if (pressed != -1)
		//{
		//	_grid = GameObject.FindGameObjectWithTag("MainGrid").GetComponent<Grid>();
		//	_grid.OnButtonPress(pressed);
		//}
	}
}
