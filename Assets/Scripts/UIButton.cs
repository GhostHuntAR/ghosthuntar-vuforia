using UnityEngine;
using System.Collections;

public class UIButton : MonoBehaviour {

	private UIService uiService; 

	void Start(){
		uiService = (UIService) GameObject.Find("UI").GetComponent("UIService");
	}

	public void SetState(string state){

		try{
			Enums.UIStates enumState = (Enums.UIStates) System.Enum.Parse( typeof( Enums.UIStates ), state );
			uiService.SetState (enumState);
		} catch (System.ArgumentException){

			print (state + " doesn't match any defined state enumerator.");

		}

	}

	public void SetDifficulty(string difficulty){

		try{
			Enums.Difficulty enumDifficulty = (Enums.Difficulty) System.Enum.Parse( typeof( Enums.Difficulty ), difficulty );
			uiService.SetDifficulty (enumDifficulty);
		} catch (System.ArgumentException){
			print (difficulty + " is doesn't match any defined difficulty enumerator.");
		}
	}
}
