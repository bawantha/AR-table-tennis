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
* Demo02 class
* This class handles "Demo02 (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

public class Demo02 : MonoBehaviour
{
	
	#region Variables

	// Canvas
	public Canvas m_Canvas;
	
	// GEAnim objects of Title text
	public GEAnim m_Title1;
	public GEAnim m_Title2;
	
	// GEAnim objects of Top and bottom
	public GEAnim m_TopBar;
	public GEAnim m_BottomBar;
	
	// GEAnim object of Dialog
	public GEAnim m_Dialog;
	
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
		
		// MoveIn m_Dialog
		StartCoroutine(ShowDialog());
	}
	
	// MoveIn m_Dialog
	IEnumerator ShowDialog()
	{
		yield return new WaitForSeconds(1.0f);
		
		// MoveIn m_Dialog
		m_Dialog.MoveIn(eGUIMove.SelfAndChildren);
		
		// Enable all scene switch buttons
		StartCoroutine(EnableAllDemoButtons());
	}
	
	// MoveOut m_Dialog
	public void HideAllGUIs()
	{
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
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
	IEnumerator DisableAllButtonsForSeconds(float DisableTime)
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableAllButtons(false);
		
		yield return new WaitForSeconds(DisableTime);
		
		// Enable all buttons
		GEAnimSystem.Instance.EnableAllButtons(true);
	}
	
	#endregion
	
	// ######################################################################
	// Button handler functions
	// ######################################################################
	
	#region Button Handler

	public void OnButton_UpperEdge()
	{
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);

		// MoveIn m_Dialog from top
		StartCoroutine(DialogMoveIn(ePosMove.UpperScreenEdge));
	}
	
	public void OnButton_LeftEdge()
	{
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// MoveIn m_Dialog from left
		StartCoroutine(DialogMoveIn(ePosMove.LeftScreenEdge));
	}
	
	public void OnButton_RightEdge()
	{
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from right
		StartCoroutine(DialogMoveIn(ePosMove.RightScreenEdge));
	}
	
	public void OnButton_BottomEdge()
	{
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from bottom
		StartCoroutine(DialogMoveIn(ePosMove.BottomScreenEdge));
	}
	
	public void OnButton_UpperLeft()
	{
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from upper left
		StartCoroutine(DialogMoveIn(ePosMove.UpperLeft));
	}
	
	public void OnButton_UpperRight()
	{
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from upper right
		StartCoroutine(DialogMoveIn(ePosMove.UpperRight));
	}
	
	public void OnButton_BottomLeft()
	{
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from bottom left
		StartCoroutine(DialogMoveIn(ePosMove.BottomLeft));
	}
	
	public void OnButton_BottomRight()
	{
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from bottom right
		StartCoroutine(DialogMoveIn(ePosMove.BottomRight));
	}
	
	public void OnButton_Center()
	{
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from center of screen
		StartCoroutine(DialogMoveIn(ePosMove.MiddleCenter));
	}
	
	#endregion
	
	// ######################################################################
	// Move dialog functions
	// ######################################################################
	
	#region Move Dialog

	// MoveIn m_Dialog by position
	IEnumerator DialogMoveIn(ePosMove PosMoveIn)
	{
		yield return new WaitForSeconds(1.5f);
		
		//Debug.Log("PosMoveIn="+PosMoveIn);
		switch(PosMoveIn)
		{
			// Set m_Dialog to move in from upper
			case ePosMove.UpperScreenEdge:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.UpperScreenEdge;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from left
			case ePosMove.LeftScreenEdge:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.LeftScreenEdge;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from right
			case ePosMove.RightScreenEdge:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.RightScreenEdge;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from bottom
			case ePosMove.BottomScreenEdge:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.BottomScreenEdge;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from upper left
			case ePosMove.UpperLeft:	
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.UpperLeft;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from upper right
			case ePosMove.UpperRight:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.UpperRight;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from bottom left
			case ePosMove.BottomLeft:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.BottomLeft;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from bottom right
			case ePosMove.BottomRight:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.BottomRight;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from center
			case ePosMove.MiddleCenter:
			default:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.MiddleCenter;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
		}

		// Reset m_Dialog
		m_Dialog.Reset();

		// MoveIn m_Dialog by position
		m_Dialog.MoveIn(eGUIMove.SelfAndChildren);
	}
	
	#endregion
}