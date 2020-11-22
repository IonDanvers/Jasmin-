///////////////////////////////////////////////////////////////////////////////////////////////////////
/*
 * ██████████████████████████████████████████████████████████████████████████████
 * ██████████████████████████████████████████████████████████████████████████████
 * ███████████████████████▀█████████████████████████████▀████████████████████████
 * █████████████████████▀   '▀████████████████████████▀   '▀█████████████████████
 * ███████████████████▀        '▀███████████████████▀        '▀██████████████████
 * █████████████████▀             '▀██████████████▀             '▀███████████████
 * ███████████████▀                  '▀█████████▀                  '▀████████████
 * █████████████▀      ▄             ▄████████▀                       '▀█████████
 * ███████████▀      ▄███▄,        ▄████▀▀▀▀▀      ▄█▄,                  '▀██████
 * █████████▀      ▄████████▄,   ▄███▀           ▄██████▄,                  '▀███
 * ███████▀        '▀██████████▄████    I O N   ▐██████████▄,                ▄███
 * █████▀             '▀███████████▌     API     █████████████▄,           ▄█████
 * ███▀                  '▀████████▀	  #     ███▀ '▀██████████▄       ▄███████
 * ████▄,                   '▀███▀          ▄▄███▀      '▀██████▀      ▄█████████
 * ███████▄,                   ▀      ▄████████▀           '▀█▀      ▄███████████
 * ██████████▄,                     ▄████████▀                     ▄█████████████
 * █████████████▄,                ▄████████████▄,                ▄███████████████
 * ████████████████▄,           ▄█████████████████▄,           ▄█████████████████
 * ███████████████████▄,      ▄██████████████████████▄,      ▄███████████████████
 * ██████████████████████▄, ▄███████████████████████████▄, ▄█████████████████████
 * ██████████████████████████████████████████████████████████████████████████████
 * ██████████████████████████████████████████████████████████████████████████████
 *
 * ----------------------------------------------------------------------
 * Copyright (C) M-12 technology Incorporated - All Rights Reserved.
 * ----------------------------------------------------------------------
 *
 * NOTICE:  All information contained herein is, and remains
 * the property of M-12 technology Incorporated and its suppliers.
 * The intellectual and technical concepts contained
 * herein are proprietary to M-12 Technology Incorporated
 * and its suppliers and may be covered by U.S. and Foreign Patents,
 * patents in process, and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from M-12 technology Incorporated.
 * 
 * Website  : http://www.m12.technology
 *
 * Facebook : https://www.facebook.com/m12.technology
 * 
 * Twitter  : https://twitter.com/ION_CODE
 * 
 * Youtube  : https://www.youtube.com/user/TheVersio/
 * 
 * E-mail   : m12.software.technology@gmail.com
 * 
 * Developer : ION
 * 
 * ----------------------------------------------------------------------
 * Copyright (C) M-12 technology Incorporated - All Rights Reserved.
 * ----------------------------------------------------------------------
 */
///////////////////////////////////////////////////////////////////////////////////////////////////////
using Ion;
///////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Blaster
{
	public class MENU : MONOBEHAVIOUR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		string PlayerName = "PlayerName";
		//----------------------------------------------------------------------------------------------------
		public UITEXTURE BlasterTexture = "Blaster/Menu/Texture/SpaceBlasterTexture";
		public UITEXTURE StartGameTexture = "Blaster/Menu/Texture/StartGameTexture";
		public UITEXTURE UserNameSpaceTexture = "Blaster/Menu/Texture/UserNameSpaceTexture";
		//-----------------------------------------------------------------------------------------------------
		INTERPOLATOR StartInterpolator = new INTERPOLATOR(INTERPOLATOR.MODE.Sinus);
		//-----------------------------------------------------------------------------------------------------
		float MenuFlash = 1;
		float MenuFlashSpeed = 1;
		//-----------------------------------------------------------------------------------------------------
		public UnityEngine.GUIStyle TextFieldStyle;
		//-----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
		}
		//====================================================================================================
		// ■ UPDATE
		//====================================================================================================
		void Update()
		{
			//Flash Button
			StartInterpolator.Update(1.0f);

		}
		//====================================================================================================
		// ■ GAME
		//====================================================================================================
		IEnumerator Game()
		{
			GameObject.AudioSource.Play();

			//Wait
			//yield return new UnityEngine.WaitForSeconds(0.5f);

			//Menu Down
			while (MenuFlash > 0)
			{
				MenuFlash -= MenuFlashSpeed * TIME.deltaTime;
				yield return null;
			}

			SCENEMANAGER.LoadScene("Game Scene");

			yield return null;
		}
		//====================================================================================================
		// ■ GUI
		//====================================================================================================
		void OnGUI()
		{
			UI.depth = 10;

			UI.Color = new COLOR(1, 1, 1, MenuFlash);

			//Draw Blaster Logo
			UI.DrawTexture(BlasterTexture);

			UI.Color = new COLOR(1, 1, 1, StartInterpolator.Value * MenuFlash);

			//Draw StartGame Button
			if (UI.DrawButton(StartGameTexture))
			{
				StartCoroutine(Game());
			}

			var rectangle = UI.DrawTexture(UserNameSpaceTexture);

			UI.Color = new COLOR(1, 1, 1, MenuFlash);

			UnityEngine.GUI.skin.textField = TextFieldStyle;
			UnityEngine.GUI.skin.settings.cursorColor = COLOR.black;
			UnityEngine.GUI.skin.textField.fontSize = (int)(rectangle.height * 0.66f);
			PlayerName = UnityEngine.GUI.TextField(rectangle, PlayerName, 16);

		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
