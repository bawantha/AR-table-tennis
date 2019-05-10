// GUI Animator for Unity UI version: 0.9.92c (Product page: http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/)
//
// Author:			Gold Experience Team (http://www.ge-team.com/pages/)
// Products:		http://ge-team.com/pages/unity-3d/
// Support:			geteamdev@gmail.com
// Documentation:	http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/gui-animator-for-unity-ui-documentation/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

#region Namespaces

using UnityEngine;
using UnityEditor;
using System.Collections;

#endregion

/******************************************
* GEAnimSystemEditor class
* Custom editor for GEAnimSystem component
******************************************/

// http://docs.unity3d.com/ScriptReference/CustomEditor.html
// http://docs.unity3d.com/ScriptReference/CustomEditor-ctor.html
// http://unity3d.com/learn/tutorials/modules/intermediate/editor/adding-buttons-to-inspector
[CustomEditor(typeof(GEAnimSystem))]
// http://docs.unity3d.com/ScriptReference/Editor.html
public class GEAnimSystemEditor : GUIAnimSystemEditor
{
	#region Variables
	
		//private Rect m_rectArea_Move;

	#endregion

	// ######################################################################
	// Editor functions
	// ######################################################################
	
	#region Editor functions

		// This function is called when the object is loaded
		public override void OnEnable()
		{

			//*** PERFORM YOUR EDITOR SCRIPTS HERE ***//



			//****************************************//
		}

		// Implement this function to make a custom inspector
		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI();
		

			//*** PERFORM YOUR EDITOR SCRIPTS HERE ***//


		
			//****************************************//
		}
	
	#endregion
}
