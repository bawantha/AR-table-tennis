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
using System.Collections;

#endregion

/**************
* Demo01 class
* This class handles "Demo00 (960x600px)" scene.
* It loads Demo01 scene.
**************/

public class Demo00 : MonoBehaviour
{
	
	// ######################################################################
	// MonoBehaviour Functions
	// ######################################################################
	
	#region MonoBehaviour
	
	// Use this for initialization
	void Awake ()
	{
		//////////////////////////////////////////////////////////////////////
		// If you want to control all GEAnim elements in the scene via scripts, you have to call these line in Awake function.
		// Otherwise, GEAnimSystem will run all GEAnim elements automatically.
		//
		// If you disable this component by uncheck it from the GameObject that it is attached,
		// the GEAnimSystem will control all animations in the scene according to selected animations in Auto Animation of GEAnimSystem.
		//////////////////////////////////////////////////////////////////////
		if(enabled)
		{
			GEAnimSystem.Instance.m_AutoAnimation = false;
		}
	}

	// Use this for initialization
	void Start ()
	{
		Application.LoadLevel("Demo01 (960x600px)");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	#endregion
}