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
	public class INTERFACE : MONOBEHAVIOUR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public UITEXTURE ScoreTexture = "Blaster/Game/Interface/Texture/ScoreTexture";
		public UITEXTURE ScoreSpaceTexture = "Blaster/Game/Interface/Texture/ScoreSpaceTexture";
		public UITEXTURE PowerTexture = "Blaster/Game/Interface/Texture/PowerTexture";
		public UITEXTURE PowerSpaceTexture = "Blaster/Game/Interface/Texture/PowerSpaceTexture";
		public UITEXTURE ShieldTexture = "Blaster/Game/Interface/Texture/ShieldTexture";
		public UITEXTURE ShieldSpaceTexture = "Blaster/Game/Interface/Texture/ShieldSpaceTexture";
		public UITEXTURE BombTexture = "Blaster/Game/Interface/Texture/BombTexture";
		public UITEXTURE BombIconTexture = "Blaster/Game/Interface/Texture/BombIconTexture";
		public UITEXTURE BombSpaceTexture = "Blaster/Game/Interface/Texture/BombSpaceTexture";
		//----------------------------------------------------------------------------------------------------
		public UITEXTURE GameOverTexture = "Blaster/Game/Interface/Texture/GameOverTexture";
		public UITEXTURE PressSpaceTexture = "Blaster/Game/Interface/Texture/PressSpaceTexture";
		//----------------------------------------------------------------------------------------------------
		public UITEXTURE HelpTexture = "Blaster/Game/Interface/Texture/HelpTexture";
		//----------------------------------------------------------------------------------------------------
		TEXTURE PowerLineTexture = "Blaster/Game/Interface/Texture/PowerLineTexture";
		TEXTURE ShieldLineTexture = "Blaster/Game/Interface/Texture/ShieldLineTexture";
		//----------------------------------------------------------------------------------------------------
		static TEXTURE NumbersTexture = "Blaster/Game/Interface/Texture/NumbersTexture";
		//----------------------------------------------------------------------------------------------------
		INTERPOLATOR PressSpaceFlash = new INTERPOLATOR();
		//----------------------------------------------------------------------------------------------------
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
			PressSpaceFlash.Update(1);
		}
		//====================================================================================================
		// ■ GUI
		//====================================================================================================
		void OnGUI()
		{
			///////////////////////////////////
			/// SCORE
			//////////////////////////////////

			//Draw Score
			UI.DrawTexture(ScoreTexture);

			UI.Color = new COLOR(1, 1, 1, 0);
			var rectangle = UI.DrawTexture(ScoreSpaceTexture);
			rectangle.x -= rectangle.width * 4;

			//Score Number
			UI.Color = new COLOR(1, 1, 1, 1);
			DrawNumber(PLAYER.Score, 9, rectangle);

			///////////////////////////////////
			/// POWER
			//////////////////////////////////

			UI.DrawTexture(PowerTexture);

			UI.Color = new COLOR(1, 1, 1, 0);
			rectangle = UI.DrawTexture(PowerSpaceTexture);

			UI.Color = new COLOR(1, 1, 1, 0.2f);
			rectangle.width = rectangle.width * 8;
			UI.DrawTexture(rectangle, PowerLineTexture);

			UI.Color = new COLOR(1, 1, 1, 1);
			rectangle.width = rectangle.width * PLAYER.Power * 0.01f;
			UI.DrawTexture(rectangle, PowerLineTexture);

			///////////////////////////////////
			/// SHIELD
			//////////////////////////////////

			UI.DrawTexture(ShieldTexture);

			UI.Color = new COLOR(1, 1, 1, 0);
			rectangle = UI.DrawTexture(ShieldSpaceTexture);

			rectangle.width = rectangle.width * 8;
			UI.Color = new COLOR(1, 1, 1, 0.2f);
			UI.DrawTexture(rectangle, ShieldLineTexture);

			UI.Color = new COLOR(1, 1, 1, 1);
			rectangle.width = rectangle.width * PLAYER.Shield * 0.01f;
			UI.DrawTexture(rectangle, ShieldLineTexture);

			///////////////////////////////////
			/// BOMB
			//////////////////////////////////

			//Draw Bomb
			UI.DrawTexture(BombTexture);
			UI.DrawTexture(BombIconTexture);

			UI.Color = new COLOR(1, 1, 1, 0);
			rectangle = UI.DrawTexture(BombSpaceTexture);

			//Bomb Number
			UI.Color = new COLOR(1, 1, 1, 1);
			DrawNumber(PLAYER.Bomb, rectangle);

			///////////////////////////////////
			/// GAME OVER
			//////////////////////////////////

			//Game Over
			if (PLAYER.GameOver)
			{
				UI.DrawTexture(GameOverTexture);

				UI.DrawTexture(GameOverTexture);

				UI.Color = new COLOR(1, 1, 1, PressSpaceFlash.Value);

				//Press Space Button
				if (UI.DrawButton(PressSpaceTexture))
				{
					DEBUG.Log("Press Space Button to Menu, in Interface");
				}

				UI.Color = COLOR.white;
			}

			//Help
			UI.DrawTexture(HelpTexture);
		}
		//====================================================================================================
		// ■ DRAW NUMBER
		//====================================================================================================
		static public void DrawNumber(int number, RECTANGLE area)
		{
			int n = number;
			int count = 0;
			do
			{
				n = n / 10;
				count++;
			}
			while (n > 0);

			for (int i = count; i > 0; i--)
			{
				n = number % 10;
				number = number / 10;
				UI.DrawTextureWithTexCoords(new RECTANGLE((area.x + i * area.width), area.y, area.width, area.height), NumbersTexture, new RECTANGLE(0.1f * n, 0, 0.1f, 1.0f));
			}
		}
		//====================================================================================================
		public void DrawNumber(int number, int digitCount, RECTANGLE area)
		{
			int n = number;
			int count = 0;
			do
			{
				n = n / 10;
				count++;
			}
			while (n > 0);

			for (int i = 0; i < digitCount - count; i++)
			{
				UI.DrawTextureWithTexCoords(new RECTANGLE(area.x + i * area.width, area.y, area.width, area.height), NumbersTexture, new RECTANGLE(0.0f, 0, 0.1f, 1.0f));
			}

			for (int i = count; i > 0; i--)
			{
				n = number % 10;
				number = number / 10;
				UI.DrawTextureWithTexCoords(new RECTANGLE(area.x + (i + digitCount - count - 1) * area.width, area.y, area.width, area.height), NumbersTexture, new RECTANGLE(0.1f * n, 0, 0.1f, 1.0f));
			}
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
