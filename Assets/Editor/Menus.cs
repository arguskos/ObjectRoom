using UnityEngine;
using UnityEditor;
public static class Menus
{
	
	[MenuItem("My Commands/First Command _o")]
	static void Second()
	{
		Debug.Log("You used the shortcut O");
		var script = GameObject.FindGameObjectWithTag("DeleteOnKey");
		Grid script2 = GameObject.FindObjectOfType<Grid>();
		script2.ClearObjectList();
		GameObject.DestroyImmediate(script);
	}
	[MenuItem("My Commands/Special Command %g")]
	static void SpecialCommand()
	{
		Debug.Log("You used the shortcut Cmd+G (Mac)  Ctrl+G (Win)");
		var script = GameObject.FindObjectOfType<Grid>();
		script.CreateSaved();
	}

	[MenuItem("My Commands/Special Command ")]
	static void SpecialCommand1()
	{
		Debug.Log("You used the shortcut Cmd+G (Mac)  Ctrl+G (Win)");
		var script = GameObject.FindObjectOfType<Grid>();
		script.CreateGrid();
		script.Save();
	}
}