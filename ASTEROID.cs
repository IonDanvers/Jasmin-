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
	public class ASTEROID : MONOBEHAVIOUR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		float3 Axis;
		float RotationSpeed;
		//----------------------------------------------------------------------------------------------------
		public float PlanetRotationSpeed;
		public float3 PlanetAxis;
		//----------------------------------------------------------------------------------------------------
		float FlashValue = 0;
		//----------------------------------------------------------------------------------------------------
		int OriginalHitCount = 1;
		int HitCount;
		//----------------------------------------------------------------------------------------------------
		bool Die = false;
		//----------------------------------------------------------------------------------------------------
		bool HitFlag = false;
		float HitTime;
		//----------------------------------------------------------------------------------------------------
		float3 ScorePosition;
		//----------------------------------------------------------------------------------------------------
		float Height;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
			Axis = new float3(RANDOM.Float(-1, 1), RANDOM.Float(-1, 1), RANDOM.Float(-1, 1));
			RotationSpeed = RANDOM.Float(5, 20);

			//Planet
			PlanetAxis = new float3(RANDOM.Float(-1, 1), RANDOM.Float(-1, 1), RANDOM.Float(-1, 1));
			PlanetRotationSpeed = RANDOM.Float(5, 20);

			HitCount = RANDOM.Int(10, 100);
			OriginalHitCount = HitCount;

			var position = Transform.Position;
			Height = math.distance(position, new float3(0, 0, 0));

		}
		//====================================================================================================
		// ■ UPDATE
		//====================================================================================================
		void Update()
		{
			var position = Transform.Position;
			var targetHeight = GAMEOBJECT.Find("Center").GetComponent<CENTER>().GetHeight();

			var l = 0.1f;
			Height = math.lerp(Height, targetHeight, l);
			Transform.Position = math.normalize(position) * Height;

			Transform.Rotate(Axis, RotationSpeed * TIME.deltaTime);

			Transform.RotateAround(new float3(0, 0, 0), PlanetAxis, PlanetRotationSpeed * TIME.deltaTime);

			//Flash
			GameObject.Renderer.material.SetColor("_EmissionColor", new COLOR(FlashValue, FlashValue, FlashValue, 1));
			GameObject.Renderer.material.EnableKeyword("_EMISSION");

			FlashValue = math.lerp(0, FlashValue, 0.1f);

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

				UI.DrawTexture(new RECTANGLE(position.x, SCREEN.height - position.y - 10, 50, 5), TEXTURE2D.whiteTexture);

				UI.Color = (0, 0.9f, 0, 1);

				UI.DrawTexture(new RECTANGLE(position.x, SCREEN.height - position.y - 10, 50 * HitCount / OriginalHitCount, 5), TEXTURE2D.whiteTexture);
			}

			if (Die)
			{
				UI.Color = COLOR.white;

				ScorePosition = math.lerp(ScorePosition, new float3(SCREEN.width * 0.5f, SCREEN.height, 0), 0.01f);

				//Number
				var rectangle = new RECTANGLE(ScorePosition.x - 60, SCREEN.height - ScorePosition.y, 30, 30);
				INTERFACE.DrawNumber(1000, rectangle);
			}

		}
		//====================================================================================================
		// ■ HIT
		//====================================================================================================
		void Hit(int hit)
		{
			HitFlag = true;
			HitTime = TIME.realtimeSinceStartup;

			HitCount -= hit;
			HitCount = math.max(0, HitCount);

			if (HitCount == 0)
			{
				Destroy(GameObject, 1);

				Die = true;
			}
		}
		//====================================================================================================
		// ■ COLLISION
		//====================================================================================================
		void OnCollisionEnter(UnityEngine.Collision other)
		{
			if (other.gameObject.tag == "Laser")
			{
				FlashValue = 1;

				Hit(1);
			}

		}
		//====================================================================================================
		// ■ TRIGGER
		//====================================================================================================
		void OnTriggerEnter(UnityEngine.Collider other)
		{
			if (other.gameObject.tag == "Explosion")
			{
				FlashValue = 1;

				Hit(30);
			}
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
