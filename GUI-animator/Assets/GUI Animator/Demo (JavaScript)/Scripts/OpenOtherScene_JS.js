// GUI Animator for Unity UI version: 0.9.92c (Product page: http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/)
//
// Author:			Gold Experience Team (http://www.ge-team.com/pages/)
// Products:		http://ge-team.com/pages/unity-3d/
// Support:			geteamdev@gmail.com
// Documentation:	http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/gui-animator-for-unity-ui-documentation/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

/**************
* OpenOtherScene_JS class
* This class handles 8 buttons for changing scene.
**************/

class OpenOtherScene_JS extends MonoBehaviour {
	
	// ######################################################################
	// MonoBehaviour Functions
	// ######################################################################
		
	// Use this for initialization
	function Start () : void {
		
	}
	
	// Update is called once per frame
	function Update () : void {
		
	}
	
	// ######################################################################
	// Button handler functions
	// ######################################################################
		
	// Open Demo Scene 1
	function ButtonOpenDemoScene1 () : void {
		// Disable all buttons
		GUIAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
	    GUIAnimSystem.Instance.LoadLevel("Demo01_JS (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 2
	function ButtonOpenDemoScene2 () : void {
		// Disable all buttons
		GUIAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
	    GUIAnimSystem.Instance.LoadLevel("Demo02_JS (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 3
	function ButtonOpenDemoScene3 () : void {
		// Disable all buttons
		GUIAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
	    GUIAnimSystem.Instance.LoadLevel("Demo03_JS (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 4
	function ButtonOpenDemoScene4 () : void {
		// Disable all buttons
		GUIAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
	    GUIAnimSystem.Instance.LoadLevel("Demo04_JS (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 5
	function ButtonOpenDemoScene5 () : void {
		// Disable all buttons
		GUIAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
	    GUIAnimSystem.Instance.LoadLevel("Demo05_JS (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 6
	function ButtonOpenDemoScene6 () : void {
		// Disable all buttons
		GUIAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
	    GUIAnimSystem.Instance.LoadLevel("Demo06_JS (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 7
	function ButtonOpenDemoScene7 () : void {
		// Disable all buttons
		GUIAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
	    GUIAnimSystem.Instance.LoadLevel("Demo07_JS (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 8
	function ButtonOpenDemoScene8 () : void {
		// Disable all buttons
		GUIAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
	    GUIAnimSystem.Instance.LoadLevel("Demo08_JS (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
}
