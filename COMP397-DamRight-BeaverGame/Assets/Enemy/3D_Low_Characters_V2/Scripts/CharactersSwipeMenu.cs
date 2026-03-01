
/*XXXXXXXXXX.XXXXXXXXXX.XXXXXXXXXX.XXXXXXXXXX
 ----------.----------.----------.----------
(c)	Puxxe Studio | 2022
	16/11/2022 (13:49:55)
 ----------.----------.----------.----------
XXXXXXXXXX.XXXXXXXXXX.XXXXXXXXXX.XXXXXXXXXX*/

namespace PuxxeStudio{		

	using System;
	using UnityEngine;
	using UnityEngine.UI;

	public class CharactersSwipeMenu : MonoBehaviour{
		[SerializeField]
		public bool smoothSpeedAnimation = false;
		[SerializeField]
		Text characterInfoText;
		[Header("Buttons - Drag to Here")]
		[SerializeField]
		Button handObjectSwitchButton;
		[SerializeField]
		Button costumeSwitchButton;
		[SerializeField]
		Button previousButton;
		[SerializeField]
		Button nextButton;
		[Header("Toogles - Drag to Here")]
		[SerializeField]
		Toggle rotateToggle;
		[SerializeField]
		Toggle speedToggle;
		[SerializeField]
		Toggle hideObjectsToggle;
		[SerializeField]
		Toggle hideGroundToggle;
		bool showPersonalObjects = true;
		bool showGround = true;
		[Header("Player - Auto Find")]
		[SerializeField]
		GameObject character;
		Transform characterTransform;
		public HandObjectSwitching handObjectSwitching;
		public CostumeSwitching costumeSwitching;
		[Header("Lists - Drag to Here")]
		int characterID = 0;
		float rotationAtual = -90;
		[SerializeField]
		GameObject[] charactersList = null;
		[SerializeField]
		GameObject[] personalObjects3DList = null;
		GameObject personalObjects3D;
		[SerializeField]
		GameObject[] personalButtonActionsList = null;
		GameObject actionsButtons;
		GameObject menu2D;
		public delegate void FunctionSendComArgs(string arg1);
		public static event FunctionSendComArgs FunctionEventSendInfoWithArgs;
		public static string stringArgs = "Dispatch Event - Args do Sender :) ";
		private void Awake(){
			 if (charactersList != null){
				 if(charactersList.Length>0){
					character = charactersList[characterID];
					handObjectSwitching = charactersList[characterID].GetComponent <HandObjectSwitching>();
					costumeSwitching = charactersList[characterID].GetComponent <CostumeSwitching>();
				 }			
			 }      
	   }

				public GameObject GetPersonalActionsButtons(int _characterID=-1){
			if (_characterID<0){
				_characterID = characterID; 
			}
			if (personalButtonActionsList != null){
				if (personalButtonActionsList.Length > 0){
					actionsButtons = personalButtonActionsList[_characterID];
					return actionsButtons;
				}
			}
			return null;
		}
		public Array GetPersonalButtonActionsList(){
			if (personalButtonActionsList != null){
				return personalButtonActionsList;
			}else{
				return null;
			}
		}    

		void SendEvents(){
			if (FunctionEventSendInfoWithArgs != null){
				FunctionEventSendInfoWithArgs(stringArgs);
			}
		}
		public void SendEventWithArgsByButton(){
			SendEvents();
		}
		void ShowHideButtonsNextPrevious(){
			if (charactersList.Length<=1){
				previousButton.gameObject.SetActive(false);
				nextButton.gameObject.SetActive(false);
				return;
			}  
			if (previousButton != null){
				if (characterID > 0){           
					previousButton.interactable = true;
				}else{
					previousButton.interactable = false;
				}
			}
			if (nextButton!=null){
				if (characterID < charactersList.Length - 1){
					nextButton.interactable = true;
				}else{
					nextButton.interactable = false;
				}
			}
		}  

		public void ToogleSmoothSpeedAnimation(bool value){
			smoothSpeedAnimation = value;
		}
		public void ToogleHideObjects(bool value){
			if (personalObjects3DList != null){
				if (personalObjects3DList.Length > 0){
					personalObjects3D = personalObjects3DList[characterID];				
					personalObjects3D.SetActive(value);
					showPersonalObjects = value;
				}
			}
		}
		public void ToogleHideGround(bool value){
			GameObject ground = GameObject.Find("Floor_Cube");
			if (ground != null){
				MeshRenderer meshRenderer = ground.GetComponent<MeshRenderer>();
				meshRenderer.enabled = value;
				showGround = value;
			}
		}
		public void RotateCharacter(float rotation = -1){
			 if (charactersList != null){
				if(charactersList.Length>0){
					GameObject character = charactersList[characterID];
					if (character.activeSelf == true){ 
						if (rotation != -1){
							rotationAtual = character.transform.rotation.y;
							rotationAtual += rotation;
							character.transform.RotateAround(transform.position, transform.up, rotationAtual);
						}else{
							character.transform.RotateAround(transform.position, transform.up, Time.deltaTime * -90f);
							rotationAtual = character.transform.rotation.y;
						}
					}				 
				 }			 
			 }
		}

		public void HandObjectSwitchNext(){
			if(handObjectSwitching==null){
				Debug.LogWarning("character/handObjectSwitching NOT FOUND!");
				return;
			}
			handObjectSwitching.HandObjectSwitchNext();
		}
		public void HandObjectSwitchHideAndShow(){
			if(handObjectSwitching==null){
				Debug.LogWarning("character/handObjectSwitching NOT FOUND!");
				return;
			}
			handObjectSwitching.HandObjectSwitchHideAndShow();
		} 
		public void HandObjectShow(int handObjectID = -1){
			if(handObjectSwitching==null){
				Debug.LogWarning("character/handObjectSwitching NOT FOUND!");
				return;
			}
			handObjectSwitching.HandObjectShow(handObjectID);
		}
		public void HandObjectShowAll(){
			if(handObjectSwitching==null){
				Debug.LogWarning("character/handObjectSwitching NOT FOUND!");
				return;
			}
			handObjectSwitching.HandObjectShowAll();
		}			
		public void HandObjectHideAll(){
			if(handObjectSwitching==null){
				Debug.LogWarning("character/handObjectSwitching NOT FOUND!");
				return;
			}
			handObjectSwitching.HandObjectHideAll();
		}
		public void HandObjectHideAllAndShowAtual(){
			if(handObjectSwitching==null){
				Debug.LogWarning("character/handObjectSwitching NOT FOUND!");
				return;
			}
			handObjectSwitching.HandObjectHideAllAndShowAtual();
		}
		public void CostumeSwitchNext(){
			if(costumeSwitching==null){
				Debug.LogWarning("character/costumeSwitching NOT FOUND!");
				return;
			}
			costumeSwitching.CostumeSwitchNext();
		}
		public void CostumeSwitchHideAndShow(){
			if(costumeSwitching==null){
				Debug.LogWarning("character/costumeSwitching NOT FOUND!");
				return;
			}
			costumeSwitching.CostumeSwitchHideAndShow();
		}    
		public void CostumeShow(int costumeID = -1){
			if(costumeSwitching==null){
				Debug.LogWarning("character/costumeSwitching NOT FOUND!");
				return;
			}
			costumeSwitching.CostumeShow(costumeID);
		}
		public void CostumeShowAll(){
			if(costumeSwitching==null){
				Debug.LogWarning("character/costumeSwitching NOT FOUND!");
				return;
			}
			costumeSwitching.CostumeShowAll();
		}		
		public void CostumeHideAll(){
			if(costumeSwitching==null){
				Debug.LogWarning("character/costumeSwitching NOT FOUND!");
				return;
			}
			costumeSwitching.CostumeHideAll();
		}
		public void CostumeHideAllAndShowAtual(){
			if(costumeSwitching==null){
				Debug.LogWarning("character/costumeSwitching NOT FOUND!");
				return;
			}
			costumeSwitching.CostumeHideAllAndShowAtual();
		}
		public void CharacterSwitchHideAndShow(){
			if (character!=null){
				if (character.gameObject.activeSelf){
					character.gameObject.SetActive(false);
				}else{
					character.gameObject.SetActive(true);
				}
			}     
		}
	}
	
}


