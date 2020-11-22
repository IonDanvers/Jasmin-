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
	public class ALIEN : MONOBEHAVIOUR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		int OriginalHitCount = 1;
		int HitCount = 1;
		float Height;
		//-----------------------------------------------------------------------------------------------------
		COLOR OriginalColor = new COLOR(1, 178f / 255, 62f / 255, 1);
		COLOR Color;
		//-----------------------------------------------------------------------------------------------------
		float Scale = 1;
		float OriginalScale = 1;
		//-----------------------------------------------------------------------------------------------------
		bool Die = false;
		bool HitFlag = false;
		float HitTime;
		//-----------------------------------------------------------------------------------------------------
		float3 ScorePosition;
		//-----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
			var position = Transform.Position;
			Height = math.distance(position, new float3(0, 0, 0));

			HitCount = RANDOM.Int(1, 20);
			OriginalHitCount = HitCount;

			Color = OriginalColor;
		}
		//====================================================================================================
		// ■ UPDATE
		//====================================================================================================
		void Update()
		{
			var position = Transform.Position;
			var targetHeight = GAMEOBJECT.Find("Center").GetComponent<CENTER>().GetHeight();
			var l = 0.1f;

			if (Die)
			{
				targetHeight = 1;
				l = 0.03f;
				OriginalColor.a = 0;
			}

			Height = math.lerp(Height, targetHeight, l);
			Transform.Position = math.normalize(position) * Height;

			//Flash
			Color.r = math.lerp(Color.r, OriginalColor.r, 0.03f);
			Color.g = math.lerp(Color.g, OriginalColor.g, 0.03f);
			Color.b = math.lerp(Color.b, OriginalColor.b, 0.03f);
			Color.a = math.lerp(Color.a, OriginalColor.a, 0.03f);
			var alien = Transform.Find("Alien");
			var renderer = alien.GameObject.Renderer;
			var material = renderer.material;
			material.SetColor("_Color", Color);

			Scale = math.lerp(Scale, OriginalScale, 0.03f);
			alien.Transform.localScale = new float3(Scale);

			//Hit Line
			if (TIME.realtimeSinceStartup - HitTime > 3)
			{
				HitFlag = false;
			}

		}
		//====================================================================================================
		// ■ GUI
		//====================================================================================================
		void OnGUI()
		{
			if (HitFlag)
			{
				UI.Color = COLOR.white;

				var camera = GAMEOBJECT.Find("Main Camera").Camera;
				var position = camera.WorldToScreenPoint(transform.position);

				//Energy

				UI.Color = (0, 0.4f, 0, 1);

				UI.DrawTexture(new RECTANGLE(position.x, SCREEN.height - position.y - 10, 30, 5), TEXTURE2D.whiteTexture);

				UI.Color = (0, 0.9f, 0, 1);

				UI.DrawTexture(new RECTANGLE(position.x, SCREEN.height - position.y - 10, 30 * HitCount / OriginalHitCount, 5), TEXTURE2D.whiteTexture);
			}

			if (Die)
			{
				UI.Color = COLOR.white;

				ScorePosition = math.lerp(ScorePosition, new float3(SCREEN.width * 0.5f, SCREEN.height, 0), 0.01f);

				//Number
				var rectangle = new RECTANGLE(ScorePosition.x - 60, SCREEN.height - ScorePosition.y, 30, 30);
				INTERFACE.DrawNumber(100, rectangle);
			}

		}
		//====================================================================================================
		// ■ HIT
		//====================================================================================================
		public void Hit(int hit = 1)
		{
			HitFlag = true;
			HitTime = TIME.realtimeSinceStartup;

			HitCount -= hit;
			HitCount = math.max(0, HitCount);

			if (HitCount == 0)
			{
				PLAYER.AddScore(100);

				Destroy(GameObject, 1.0f);
				Die = true;

				var camera = GAMEOBJECT.Find("Main Camera").Camera;
				ScorePosition = camera.WorldToScreenPoint(transform.position);
			}

			Color = COLOR.white;
			Scale = 1.5f;

			GameObject.AudioSource.Play();

		}
		//====================================================================================================
		void OnTriggerEnter(UnityEngine.Collider other)
		{
			if (other.gameObject.tag == "Explosion")
			{
				Hit(10);

			}

		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
