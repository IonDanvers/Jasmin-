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
using System;
using System.Collections.Generic;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Blaster
{
	public class BOMB : MONOBEHAVIOUR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		int BombCountDown = 9;
		//----------------------------------------------------------------------------------------------------
		float Time;
		//----------------------------------------------------------------------------------------------------
		bool Explosion = false;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
			Time = TIME.realtimeSinceStartup;

			//Timer Sound
			Transform.Find("Timer").GameObject.AudioSource.Play();

			Transform.Find("Explosion").SetActive(false);
		}
		//====================================================================================================
		// ■ UPDATE
		//====================================================================================================
		void Update()
		{
			//Explosion
			if (BombCountDown == 0)
			{
				if (Explosion == false)
				{
					Destroy(GameObject, 2);
					var explosion = Transform.Find("Explosion");
					explosion.SetActive(true);
					explosion.LookAt(Transform.Find("Bomb").Position);

					Transform.Find("Timer").SetActive(false);
					Transform.Find("Bomb").SetActive(false);

					Explosion = true;
				}
			}
			else
			{
				if (TIME.realtimeSinceStartup - Time > 1)
				{
					BombCountDown--;

					Time = TIME.realtimeSinceStartup;

					//Timer Sound
					Transform.Find("Timer").GameObject.AudioSource.Play();
				}
			}
		}
		//====================================================================================================
		// ■ GUI
		//====================================================================================================
		void OnGUI()
		{
			if (Explosion == false)
			{
				UI.Color = COLOR.white;

				var camera = GAMEOBJECT.Find("Main Camera").Camera;
				var position = camera.WorldToScreenPoint(Transform.Find("Bomb").Position);

				//Name
				UI.DrawLabel(new RECTANGLE(position.x, SCREEN.height - position.y, 200, 30), "" + BombCountDown, 20, true);

				//Energy
				/*			var eline = 100;

							UI.Color = (0, 0.4f, 0, 1);

							UI.DrawTexture(new RECTANGLE(position.x, SCREEN.height - position.y - 70, 100, 5), TEXTURE2D.whiteTexture);

							UI.Color = (0, 0.9f, 0, 1);

							UI.DrawTexture(new RECTANGLE(position.x, SCREEN.height - position.y - 70, eline, 5), TEXTURE2D.whiteTexture);
				*/
			}
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
