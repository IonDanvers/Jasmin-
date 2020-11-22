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
	public class USERMANAGER : MONOBEHAVIOUR
	{
		struct USER
		{
			public string Name;
			public int Power;

			public USER(string name, int power)
			{
				Name = name;
				Power = power;
			}
		}

		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		static TEXTURE UserTexture = "Blaster/Game/User/Texture/UserTexture";
		static TEXTURE PasteTexture = "Blaster/Game/User/Texture/PasteTexture";
		//----------------------------------------------------------------------------------------------------
		USER[] UserArray;
		//----------------------------------------------------------------------------------------------------
		int SelectedUser = 3;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
			UserArray = new USER[10];

			UserArray[0] = new USER("Gesturecat", 90);
			UserArray[1] = new USER("Ssexualcanoe", 80);
			UserArray[2] = new USER("Skirlnorthern", 70);
			UserArray[3] = new USER("Muttermeady", 90);
			UserArray[4] = new USER("Cheetahplum", 70);
			UserArray[5] = new USER("Rustyrampallian", 50);
			UserArray[6] = new USER("Affirmutilized", 90);
			UserArray[7] = new USER("Stointypussy", 60);
			UserArray[8] = new USER("Sickglanduin", 40);
			UserArray[9] = new USER("Merrymicy", 90);
		
		
		
		}
		//====================================================================================================
		// ■ UPDATE
		//====================================================================================================
		void Update()
		{

		}
		//====================================================================================================
		// ■ GUI
		//====================================================================================================
		void OnGUI()
		{
			for (int i = 0; i < UserArray.Length; i++)
			{
				var rectangle = new RECTANGLE(50, 100 + i * 50, 40, 40);

				if (SelectedUser == i)
				{
					UI.Color = new COLOR(0.8f, 0.8f, 0.8f, 1);
				}
				else 
				{
					UI.Color = new COLOR(0, 0.5f, 0.6f, 1);
				}

				UI.DrawTexture(rectangle, UserTexture);

				rectangle = new RECTANGLE(50 + 50, 110 + i * 50, 200, 20);
				
				UI.Label(rectangle, UserArray[i].Name);

				///////////////////////
				//PowerLine
				///////////////////////

				int power = UserArray[i].Power;
				float2 position = new float2(100, 105 + i * 50);

				UI.Color = (0, 0.4f, 0, 1);
				UI.DrawTexture(new RECTANGLE(position.x, position.y, 60, 5), TEXTURE2D.whiteTexture);

				UI.Color = (0, 0.9f, 0, 1);
				UI.DrawTexture(new RECTANGLE(position.x, position.y, 60 * power / 100, 5), TEXTURE2D.whiteTexture);


				///////////////////////
				// Chat Window
				///////////////////////

				UI.Color = new COLOR(0.8f, 0.8f, 0.8f, 1);
				UI.Label(new RECTANGLE(SCREEN.width - 350, SCREEN.height - 280, 300, 30), "Active User : " + UserArray[SelectedUser].Name);

				UI.Color = new COLOR(0, 0.2f, 0.3f, 0.4f);

				UI.DrawTexture(new RECTANGLE(SCREEN.width - 350, SCREEN.height - 250, 300, 200), TEXTURE2D.whiteTexture);

				UI.Color = COLOR.white;
				//Paste Button
				if (UI.DrawButton(new RECTANGLE(SCREEN.width - 50 - 300 * 0.5f - 40, SCREEN.height - 50, 80, 40), PasteTexture))
				{ 
				
				}

			}
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
