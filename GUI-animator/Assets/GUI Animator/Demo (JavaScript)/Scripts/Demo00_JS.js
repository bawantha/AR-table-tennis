// GUI Animator for Unity UI version: 0.9.92c (Product page: http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/)
//
// Author:			Gold Experience Team (http://www.ge-team.com/pages/)
// Products:		http://ge-team.com/pages/unity-3d/
// Support:			geteamdev@gmail.com
// Documentation:	http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/gui-animator-for-unity-ui-documentation/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

/**************
* Demo01_JS class
* This class handles "Demo00_JS (960x600px)" scene.
* It loads Demo01 scene.
**************/

class Demo00_JS extends MonoBehaviour {
	
	// ######################################################################
	// MonoBehaviour Functions
	// ######################################################################

	// Use this for initialization
	function Awake () : void {
		//////////////////////////////////////////////////////////////////////
		// If you want to control all GUIAnim elements in the scene via scripts, you have to call these line in Awake function.
		// Otherwise, GUIAnimSystem will run all GUIAnim elements automatically.
		//
		// If you disable this component by uncheck it from the GameObject that it is attached,
		// the GUIAnimSystem will control all animations in the scene according to selected animations in Auto Animation of GUIAnimSystem.
		//////////////////////////////////////////////////////////////////////
		if(enabled)
		{
			GUIAnimSystem.Instance.m_AutoAnimation = false;
		}
	}

	// Use this for initialization
	function Start () : void {
	    Application.LoadLevel("Demo01_JS (960x600px)");
	}
	
	// Update is called once per frame
	function Update () : void {
		
	}
}