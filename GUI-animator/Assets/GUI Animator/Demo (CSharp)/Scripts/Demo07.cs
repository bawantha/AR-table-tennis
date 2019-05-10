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
* Demo07 class
* This class handles "Demo07 (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

public class Demo07 : MonoBehaviour
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
	
	// GEAnim object of dialogs
	public GEAnim m_Dialog;
	public GEAnim m_DialogButtons;
	
	// GEAnim objects of buttons
	public GEAnim m_Button1;
	public GEAnim m_Button2;
	public GEAnim m_Button3;
	public GEAnim m_Button4;
	
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
		
		// MoveIn all dialogs and buttons
		StartCoroutine(MoveInPrimaryButtons());
	}
	
	// MoveIn all dialogs and buttons
	IEnumerator MoveInPrimaryButtons()
	{
		yield return new WaitForSeconds(1.0f);
		
		// MoveIn all dialogs
		m_Dialog.MoveIn(eGUIMove.SelfAndChildren);
		m_DialogButtons.MoveIn(eGUIMove.SelfAndChildren);
		
		// MoveIn all buttons
		m_Button1.MoveIn(eGUIMove.SelfAndChildren);	
		m_Button2.MoveIn(eGUIMove.SelfAndChildren);	
		m_Button3.MoveIn(eGUIMove.SelfAndChildren);	
		m_Button4.MoveIn(eGUIMove.SelfAndChildren);
		
		// Enable all scene switch buttons
		StartCoroutine(EnableAllDemoButtons());
	}
	
	// MoveOut all dialogs and buttons
	public void HideAllGUIs()
	{
		// MoveOut all dialogs
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		m_DialogButtons.MoveOut(eGUIMove.SelfAndChildren);
		
		// MoveOut all buttons
		m_Button1.MoveOut(eGUIMove.SelfAndChildren);
		m_Button2.MoveOut(eGUIMove.SelfAndChildren);
		m_Button3.MoveOut(eGUIMove.SelfAndChildren);
		m_Button4.MoveOut(eGUIMove.SelfAndChildren);
		
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
	
	#region Button handlers

	public void OnButton_1()
	{
		// MoveOut m_Button1
		MoveButtonsOut();
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));

		// Set next move in of m_Button1 to new position
		StartCoroutine(SetButtonMove(ePosMove.UpperScreenEdge, ePosMove.UpperScreenEdge));
	}
	
	public void OnButton_2()
	{
		// MoveOut m_Button2
		MoveButtonsOut();
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));
		
		// Set next move in of m_Button2 to new position
		StartCoroutine(SetButtonMove(ePosMove.LeftScreenEdge, ePosMove.LeftScreenEdge));
	}
	
	public void OnButton_3()
	{
		// MoveOut m_Button3
		MoveButtonsOut();
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));

		// Set next move in of m_Button3 to new position
		StartCoroutine(SetButtonMove(ePosMove.RightScreenEdge, ePosMove.RightScreenEdge));
	}
	
	public void OnButton_4()
	{
		// MoveOut m_Button4
		MoveButtonsOut();
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));
		
		// Set next move in of m_Button3 to new position
		StartCoroutine(SetButtonMove(ePosMove.BottomScreenEdge, ePosMove.BottomScreenEdge));
	}
	
	public void OnDialogButton()
	{
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		m_DialogButtons.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable m_DialogButtons for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_DialogButtons.gameObject, 2.0f));

		// Moves m_Dialog back to screen
		StartCoroutine(DialogMoveIn());
	}
	
	#endregion
	
	// ######################################################################
	// Move Dialog/Button functions
	// ######################################################################
	
	#region Move Dialog/Button
	
	// MoveOut all buttons
	void MoveButtonsOut()
	{
		m_Button1.MoveOut(eGUIMove.SelfAndChildren);
		m_Button2.MoveOut(eGUIMove.SelfAndChildren);
		m_Button3.MoveOut(eGUIMove.SelfAndChildren);
		m_Button4.MoveOut(eGUIMove.SelfAndChildren);
	}
	
	// Set next move in of all buttons to new position
	IEnumerator SetButtonMove(ePosMove PosMoveIn, ePosMove PosMoveOut)
	{
		yield return new WaitForSeconds(2.0f);
		
		// Set next MoveIn position of m_Button1 to PosMoveIn
		m_Button1.m_MoveIn.MoveFrom = PosMoveIn;
		// Reset m_Button1
		m_Button1.Reset();
		// MoveIn m_Button1
		m_Button1.MoveIn(eGUIMove.SelfAndChildren);
		
		// Set next MoveIn position of m_Button2 to PosMoveIn
		m_Button2.m_MoveIn.MoveFrom = PosMoveIn;
		// Reset m_Button2
		m_Button2.Reset();
		// MoveIn m_Button2
		m_Button2.MoveIn(eGUIMove.SelfAndChildren);
		
		// Set next MoveIn position of m_Button3 to PosMoveIn
		m_Button3.m_MoveIn.MoveFrom = PosMoveIn;
		// Reset m_Button3
		m_Button3.Reset();
		// MoveIn m_Button3
		m_Button3.MoveIn(eGUIMove.SelfAndChildren);
		
		// Set next MoveIn position of m_Button4 to PosMoveIn
		m_Button4.m_MoveIn.MoveFrom = PosMoveIn;
		// Reset m_Button4
		m_Button4.Reset();
		// MoveIn m_Button4
		m_Button4.MoveIn(eGUIMove.SelfAndChildren);
	}
	
	// Moves m_Dialog back to screen
	IEnumerator DialogMoveIn()
	{
		yield return new WaitForSeconds(1.5f);
		
		m_Dialog.MoveIn(eGUIMove.SelfAndChildren);
		m_DialogButtons.MoveIn(eGUIMove.SelfAndChildren);
	}
	
	#endregion
}
