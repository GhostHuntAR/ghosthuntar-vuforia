using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIService : MonoBehaviour {

	private Enums.UIStates state;
	private Enums.Difficulty difficulty;
	private Dictionary<Enums.UIStates, GameObject> views;

	void Start(){
		this.views = new Dictionary<Enums.UIStates,GameObject>();

		Enums.UIStates enumState;
		string viewName;
		Transform viewComponent = transform.Find("Canvas/Views");

		foreach (Transform child in viewComponent) {

			viewName = child.name.ToLower(); // Lowercase the name. All enumerators are defined in lowercase.

			try{
				enumState = (Enums.UIStates) System.Enum.Parse( typeof( Enums.UIStates ), viewName ); // Convert name to enumerator.
				if(!enumState.Equals(Enums.UIStates.play)){
					views.Add(enumState, child.gameObject);
					views[enumState].SetActive(false); // Deactivate view.
				}

			} catch (System.ArgumentException){
				print(viewName + "doesn't match any defined state enumerator."); // Print error if name doesn't match any defined enumarators.
			}
		}
			
		try {
			views[Enums.UIStates.start].SetActive(true);
		} catch (System.ArgumentException){
			print ("Couldn't activate the start view. Maybe it's missing?");
		}
	}
		
	public void SetState(Enums.UIStates state){
		this.state = state;

		foreach (KeyValuePair<Enums.UIStates, GameObject> view in views) {
			view.Value.SetActive (false);
		}

		switch (state) {
		case Enums.UIStates.start:
		case Enums.UIStates.difficulty:
		case Enums.UIStates.highscore:
		case Enums.UIStates.gameover:
		case Enums.UIStates.gamewin:
			try{
				views [state].SetActive (true);
			} catch (KeyNotFoundException){
				print ("Couldn't activate the " + state + " view. Maybe it's missing?");
			}
			break;
		case Enums.UIStates.play:
			break;
		default:
			break;
		}

	}

	public void SetDifficulty(Enums.Difficulty difficulty){
		this.difficulty = difficulty;
	}

}
