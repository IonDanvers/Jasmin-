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
	public class INTRO : MONOBEHAVIOUR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public UITEXTURE IonDanversTexture = "Blaster/Intro/Texture/IonDanversTexture";
		TEXTURE IONBigTexture = "Blaster/Intro/Texture/IonBigTexture";
		TEXTURE IONBig2Texture = "Blaster/Intro/Texture/IonBig2Texture";
		//-----------------------------------------------------------------------------------------------------
		float LogoRotation = 0.5f;
		float2 LogoPosition;
		float LogoFlash = 0;
		float LogoFlash2 = 0;
		float LogoFlashSpeed = 1;
		//---------------------------------------------------------------------------------------------
		float TextFlash = 0;
		float TextFlashSpeed = 1;
		//---------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
			StartCoroutine(Go());
		}
		//====================================================================================================
		// ■ GO
		//====================================================================================================
		IEnumerator Go()
		{
			//Wait
			yield return new UnityEngine.WaitForSeconds(1.0f);

			//Text Up
			while (TextFlash < 1)
			{
				TextFlash += TextFlashSpeed * TIME.deltaTime;
				yield return null;
			}

			//Text Wait
			yield return new UnityEngine.WaitForSeconds(1.5f);

			//Text Down
			while (TextFlash > 0)
			{
				TextFlash -= TextFlashSpeed * TIME.deltaTime;
				yield return null;
			}

			//Audio Play
			GameObject.AudioSource.Play();

			//Logo Front Up
			while (LogoFlash2 < 1)
			{
				LogoFlash2 += 2 * LogoFlashSpeed * TIME.deltaTime;
				yield return null;
			}

			//Logo Up
			while (LogoFlash < 1 || LogoRotation < 1)
			{
				LogoFlash += 2 * LogoFlashSpeed * TIME.deltaTime;
				LogoRotation += 0.09f * TIME.deltaTime;
				LogoFlash = math.min(1, LogoFlash);
				LogoRotation = math.min(1, LogoRotation);

				yield return null;
			}

			//Logo Down
			while (LogoFlash > 0)
			{
				LogoFlash -= LogoFlashSpeed * TIME.deltaTime;
				LogoFlash2 -= LogoFlashSpeed * TIME.deltaTime;
				yield return null;
			}

			//Wait
			yield return new UnityEngine.WaitForSeconds(1.0f);

			//Game Scene Load
			SCENEMANAGER.LoadScene("Menu Scene");

			yield return null;
		}
		//====================================================================================================
		// ■ GUI
		//====================================================================================================
		void OnGUI()
		{
			UI.depth = 0;

			DrawLogo();

			UI.Color = new COLOR(1, 1, 1, TextFlash);
			UI.DrawTexture(IonDanversTexture);

			UI.Color = COLOR.white;
		}
		//====================================================================================================
		void DrawLogo()
		{
			float center = SCREEN.height * 0.5f;
			float size = 0.5f;
			float logoHeight = SCREEN.height * size;
			float logoWidth = IONBigTexture.width * (logoHeight / (IONBigTexture.height + 0.0001f));

			var oldMatrix = UnityEngine.GUI.matrix;
			UnityEngine.GUI.BeginGroup(new RECTANGLE(0, 0, SCREEN.width, SCREEN.height));
			UnityEngine.GUI.color = new COLOR(1, 1, 1, 0.2f * LogoFlash);
			UnityEngine.GUIUtility.RotateAroundPivot(LogoRotation * 360, oldMatrix * new float4(SCREEN.width * 0.5f, center + LogoPosition.y, 0, 1));
			UnityEngine.GUI.DrawTexture(new RECTANGLE(SCREEN.width * 0.5f - logoWidth / 2, center - logoHeight / 2 + LogoPosition.y, logoWidth, logoHeight), IONBig2Texture);
			UnityEngine.GUI.EndGroup();
			UnityEngine.GUI.matrix = oldMatrix;

			UnityEngine.GUI.color = new COLOR(1, 1, 1, LogoFlash2);

			UnityEngine.GUI.DrawTexture(new RECTANGLE(SCREEN.width * 0.5f - logoWidth / 2 + LogoPosition.x, center - logoHeight / 2 + LogoPosition.y, logoWidth, logoHeight), IONBigTexture);
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
