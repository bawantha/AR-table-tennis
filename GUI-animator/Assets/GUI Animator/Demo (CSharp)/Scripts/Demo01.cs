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
* This class handles "Demo01 (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

public class Demo01 : MonoBehaviour
{
	
	#region Variables

	// Canvas
	public Canvas m_Canvas;

	// GEAnim objects of title text
	public GEAnim m_Title1;
	public GEAnim m_Title2;
	
	// GEAnim objects of top and bottom bars
	public GEAnim m_TopBar;
	public GEAnim m_BottomBar;
	
	// GEAnim objects of TopLeft buttons
	public GEAnim m_TopLeft_A;
	public GEAnim m_TopLeft_B;
	
	// GEAnim objects of BottomLeft buttons
	public GEAnim m_BottomLeft_A;
	public GEAnim m_BottomLeft_B;
	
	// GEAnim objects of RightBar buttons
	public GEAnim m_RightBar_A;
	public GEAnim m_RightBar_B;
	public GEAnim m_RightBar_C;

	// Toggle state of TopLeft, BottomLeft and BottomLeft buttons
	bool m_TopLeft_IsOn = false;
	bool m_BottomLeft_IsOn = false;
	bool m_RightBar_IsOn = false;
	
	#endregion
	
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
			// Use this script to control all animations in the scene instead of GEAnimSystem auto test.
			GEAnimSystem.Instance.m_AutoAnimation = false;
		}
	}

	// Use this for initialization
	void Start ()
	{
		// MoveIn m_TopBar and m_BottomBar
		m_TopBar.MoveIn(eGUIMove.SelfAndChildren);
		m_BottomBar.MoveIn(eGUIMove.SelfAndChildren);

		// MoveIn m_Title1 and m_Title2
		StartCoroutine(MoveInTitleGameObjects());

		// Disable all scene switch buttons
		GEAnimSystem.Instance.SetGraphicRaycasterEnable(m_Canvas, false);

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	#endregion
	
	// ######################################################################
	// MoveIn/MoveOut functions
	// ######################################################################
	
	#region MoveIn/MoveOut

	// MoveIn m_Title1 and m_Title2
	IEnumerator MoveInTitleGameObjects()
	{
		yield return new WaitForSeconds(1.0f);

		// MoveIn m_Title1 and m_Title2
		m_Title1.MoveIn(eGUIMove.Self);
		m_Title2.MoveIn(eGUIMove.Self);
		
		// MoveIn all primary buttons
		StartCoroutine(MoveInPrimaryButtons());
	}
	
	// MoveIn all primary buttons
	IEnumerator MoveInPrimaryButtons()
	{
		yield return new WaitForSeconds(1.0f);

		// MoveIn all primary buttons
		m_TopLeft_A.MoveIn(eGUIMove.Self);
		m_BottomLeft_A.MoveIn(eGUIMove.Self);
		m_RightBar_A.MoveIn(eGUIMove.Self);

		// Enable all scene switch buttons
		StartCoroutine(EnableAllDemoButtons());
	}

	// MoveOut all primary buttons
	public void HideAllGUIs()
	{
		m_TopLeft_A.MoveOut(eGUIMove.SelfAndChildren);
		m_BottomLeft_A.MoveOut(eGUIMove.SelfAndChildren);
		m_RightBar_A.MoveOut(eGUIMove.Self);
		
		if(m_TopLeft_IsOn == true)
			m_TopLeft_B.MoveOut(eGUIMove.SelfAndChildren);
		if(m_BottomLeft_IsOn == true)
			m_BottomLeft_B.MoveOut(eGUIMove.SelfAndChildren);
		if(m_RightBar_IsOn == true)
			m_RightBar_B.MoveOut(eGUIMove.SelfAndChildren);
		
		// MoveOut m_Title1 and m_Title2
		StartCoroutine(HideTitleTextMeshes());
	}
	
	// MoveOut m_Title1 and m_Title2
	IEnumerator HideTitleTextMeshes()
	{
		yield return new WaitForSeconds(1.0f);

		// MoveOut m_Title1 and m_Title2
		m_Title1.MoveOut(eGUIMove.Self);
		m_Title2.MoveOut(eGUIMove.Self);
		
		// MoveOut m_TopBar and m_BottomBar
		m_TopBar.MoveOut(eGUIMove.SelfAndChildren);
		m_BottomBar.MoveOut(eGUIMove.SelfAndChildren);
	}
	
	#endregion
	
	// ######################################################################
	// Enable/Disable button functions
	// ######################################################################
	
	#region Enable/Disable buttons

	// Enable/Disable all scene switch Coroutine
	IEnumerator EnableAllDemoButtons()
	{
		yield return new WaitForSeconds(1.0f);
		
		// Enable all scene switch buttons
		GEAnimSystem.Instance.SetGraphicRaycasterEnable(m_Canvas, true);
	}
	
	// Disable all buttons for a few seconds
	IEnumerator DisableButtonForSeconds(GameObject GO, float DisableTime)
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableButton(GO.transform, false);
		
		yield return new WaitForSeconds(DisableTime);
		
		// Enable all buttons
		GEAnimSystem.Instance.EnableButton(GO.transform, true);
	}
	
	#endregion
	
	// ######################################################################
	// Button handler functions
	// ######################################################################
	
	#region Button Handler

	public void OnButton_TopLeft()
	{
		// Disable m_TopLeft_A, m_RightBar_A, m_RightBar_C, m_BottomLeft_A for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_TopLeft_A.gameObject, 0.3f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_A.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_C.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_BottomLeft_A.gameObject, 0.3f));

		// Toggle m_TopLeft
		ToggleTopLeft();

		// Toggle other buttons
		if(m_BottomLeft_IsOn==true)
		{
			ToggleBottomLeft();
		}
		if(m_RightBar_IsOn==true)
		{
			ToggleRightBar();
		}
	}

	public void OnButton_BottomLeft()
	{
		// Disable m_TopLeft_A, m_RightBar_A, m_RightBar_C, m_BottomLeft_A for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_TopLeft_A.gameObject, 0.3f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_A.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_C.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_BottomLeft_A.gameObject, 0.3f));

		// Toggle m_BottomLeft
		ToggleBottomLeft();
		
		// Toggle other buttons
		if(m_TopLeft_IsOn==true)
		{
			ToggleTopLeft();
		}
		if(m_RightBar_IsOn==true)
		{
			ToggleRightBar();
		}
		
	}
	
	public void OnButton_RightBar()
	{
		// Disable m_TopLeft_A, m_RightBar_A, m_RightBar_C, m_BottomLeft_A for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_TopLeft_A.gameObject, 0.3f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_A.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_C.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_BottomLeft_A.gameObject, 0.3f));

		// Toggle m_RightBar
		ToggleRightBar();
		
		// Toggle other buttons
		if(m_TopLeft_IsOn==true)
		{
			ToggleTopLeft();
		}
		if(m_BottomLeft_IsOn==true)
		{
			ToggleBottomLeft();
		}

	}
	
	#endregion
	
	// ######################################################################
	// Toggle button functions
	// ######################################################################
	
	#region Toggle Button

	// Toggle TopLeft buttons
	void ToggleTopLeft()
	{
		m_TopLeft_IsOn = !m_TopLeft_IsOn;
		if(m_TopLeft_IsOn==true)
		{
			// m_TopLeft_B moves in
			m_TopLeft_B.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// m_TopLeft_B moves out
			m_TopLeft_B.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	// Toggle BottomLeft buttons
	void ToggleBottomLeft()
	{
		m_BottomLeft_IsOn = !m_BottomLeft_IsOn;
		if(m_BottomLeft_IsOn==true)
		{
			// m_BottomLeft_B moves in
			m_BottomLeft_B.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// m_BottomLeft_B moves out
			m_BottomLeft_B.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	// Toggle RightBar buttons
	void ToggleRightBar()
	{
		m_RightBar_IsOn = !m_RightBar_IsOn;
		if(m_RightBar_IsOn==true)
		{
			// m_RightBar_A moves out
			m_RightBar_A.MoveOut(eGUIMove.SelfAndChildren);
			// m_RightBar_B moves in
			m_RightBar_B.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// m_RightBar_A moves in
			m_RightBar_A.MoveIn(eGUIMove.SelfAndChildren);
			// m_RightBar_B moves out
			m_RightBar_B.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	#endregion
}