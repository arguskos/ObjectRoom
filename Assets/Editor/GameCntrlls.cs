using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameCntrlls : EditorWindow
{
	string myString = "Hello World";
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;

	// Add menu item named "My Window" to the Window menu
	[MenuItem("Window/My Window")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(GameControlls));
	}

	void OnGUI()
	{
		//GUILayout.Label("Base Settings", EditorStyles.boldLabel);
		//myString = EditorGUILayout.TextField("Text Field", myString);

		//groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
		//myBool = EditorGUILayout.Toggle("Toggle", myBool);
		//myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
		//EditorGUILayout.EndToggleGroup();


		GUILayout.BeginHorizontal();
		GUILayout.Button("0,0");
		GUILayout.Button("0,1");
		GUILayout.Button("0,2");
		GUILayout.Button("0,3");
		GUILayout.Button("0,4");
		GUILayout.Button("0,5");
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Button("1,0");
		GUILayout.Button("1,1");
		GUILayout.Button("1,2");
		GUILayout.Button("1,3");
		GUILayout.Button("1,4");
		GUILayout.Button("1,5");
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Button("2,0");
		GUILayout.Button("2,1");
		GUILayout.Button("2,2");
		GUILayout.Button("2,3");
		GUILayout.Button("2,4");
		GUILayout.Button("2,5");
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Button("3,0");
		GUILayout.Button("3,1");
		GUILayout.Button("3,2");
		GUILayout.Button("3,3");
		GUILayout.Button("3,4");
		GUILayout.Button("3,5");
		GUILayout.EndHorizontal();

	}
}
