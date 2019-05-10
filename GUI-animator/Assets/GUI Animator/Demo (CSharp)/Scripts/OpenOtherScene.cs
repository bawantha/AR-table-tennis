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
* OpenOtherScene class
* This class handles 8 buttons for changing scene.
**************/

public class OpenOtherScene : MonoBehaviour
{
	
	// ######################################################################
	// MonoBehaviour Functions
	// ######################################################################
	
	#region MonoBehaviour
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	#endregion
	
	// ######################################################################
	// Button handler functions
	// ######################################################################
	
	#region Button handlers
	
	// Open Demo Scene 1
	public void ButtonOpenDemoScene1 ()
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GEAnimSystem.Instance.LoadLevel("Demo01 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 2
	public void ButtonOpenDemoScene2 ()
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GEAnimSystem.Instance.LoadLevel("Demo02 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 3
	public void ButtonOpenDemoScene3 ()
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GEAnimSystem.Instance.LoadLevel("Demo03 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 4
	public void ButtonOpenDemoScene4 ()
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GEAnimSystem.Instance.LoadLevel("Demo04 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 5
	public void ButtonOpenDemoScene5 ()
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GEAnimSystem.Instance.LoadLevel("Demo05 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 6
	public void ButtonOpenDemoScene6 ()
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GEAnimSystem.Instance.LoadLevel("Demo06 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 7
	public void ButtonOpenDemoScene7 ()
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GEAnimSystem.Instance.LoadLevel("Demo07 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 8
	public void ButtonOpenDemoScene8 ()
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GEAnimSystem.Instance.LoadLevel("Demo08 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	#endregion
}
