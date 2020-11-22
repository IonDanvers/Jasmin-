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
using UNITY = UnityEngine;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Blaster
{
	public class MAINSHIP : MONOBEHAVIOUR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public float ShipHeight = 100;
		//----------------------------------------------------------------------------------------------------
		float RotationSpeed = 100;
		//----------------------------------------------------------------------------------------------------
		public float Speed = 10;
		float SpeedAcceleration = 0.3f;
		float SpeedSlowdown = 0.97f;
		float MaximalSpeed = 50.0f;
		//----------------------------------------------------------------------------------------------------
		GAMEOBJECT LaserInstancesObject;
		GAMEOBJECT LeftLaserObject;
		GAMEOBJECT RightLaserObject;
		GAMEOBJECT FrontLeftLaserObject;
		GAMEOBJECT FrontRightLaserObject;
		float LaserLifeTime = 1.0f;
		float LaserRepeatTime = 0.2f;
		float LaserLastShotTime;
		int LastLaser = 0;
		//----------------------------------------------------------------------------------------------------
		COLOR OriginalColor = new COLOR(82f / 255, 82f / 255, 82f / 255);
		COLOR Color;
		//-----------------------------------------------------------------------------------------------------
		GAMEOBJECT WallInstances;
		GAMEOBJECT WallObject;
		//----------------------------------------------------------------------------------------------------
		GAMEOBJECT BombInstances;
		GAMEOBJECT BombObject;
		//----------------------------------------------------------------------------------------------------
		WALL CurrentWall;
		//----------------------------------------------------------------------------------------------------
		float3 OldPosition;
		public float WallUpdateDistance = 0.01f;
		//----------------------------------------------------------------------------------------------------
		float PowerLoadTime;
		float PowerLoadSpeed = 3;
		//----------------------------------------------------------------------------------------------------
		float ShieldLoadTime;
		float ShieldLoadSpeed = 0.05f;
		//----------------------------------------------------------------------------------------------------
		float GridDistance = 0.02f;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
			//Laser Init
			LaserInstancesObject = GAMEOBJECT.Find("Instances/Laser Instances");
			LeftLaserObject = GAMEOBJECT.Find("MainShip/Laser Left");
			RightLaserObject = GAMEOBJECT.Find("MainShip/Laser Right");
			FrontLeftLaserObject = GAMEOBJECT.Find("MainShip/Laser Front Left");
			FrontRightLaserObject = GAMEOBJECT.Find("MainShip/Laser Front Right");

			WallInstances = GAMEOBJECT.Find("Instances/Wall Instances");
			WallObject = GAMEOBJECT.Find("Instances/Wall Instances/WallObject");

			BombInstances = GAMEOBJECT.Find("Instances/Bomb Instances");
			BombObject = GAMEOBJECT.Find("Instances/Bomb Instances/BombObject");

			LeftLaserObject.SetActive(false);
			RightLaserObject.SetActive(false);
			FrontLeftLaserObject.SetActive(false);
			FrontRightLaserObject.SetActive(false);

			WallObject.SetActive(false);

			BombObject.SetActive(false);

			LaserLastShotTime = LaserRepeatTime;

			Color = OriginalColor;

			PowerLoadTime = TIME.realtimeSinceStartup;
			ShieldLoadTime = TIME.realtimeSinceStartup;
		}
		//====================================================================================================
		// ■ UPDATE
		//====================================================================================================
		void Update()
		{
			var center = GAMEOBJECT.Find("Center").GetComponent<CENTER>();

			var position = center.transform.position;
			var rotation = center.transform.rotation;

			transform.position = math.lerp(transform.position, position, 5.0f * TIME.deltaTime);
			transform.rotation = math.slerp(transform.rotation, rotation, 5.0f * TIME.deltaTime);

			//Flash
			Color.r = math.lerp(Color.r, OriginalColor.r, 0.03f);
			Color.g = math.lerp(Color.g, OriginalColor.g, 0.03f);
			Color.b = math.lerp(Color.b, OriginalColor.b, 0.03f);
			var ship = Transform.Find("Body/Ship");
			var renderer = ship.GameObject.Renderer;
			var material = renderer.material;
			material.SetColor("_EmissionColor", Color);


			//Set Height
			//			transform.position = Vector3.Normalize(transform.position - center) * ShipHeight;


			////////////////////////////////
			/// WALL UPDATE
			////////////////////////////////

			if (PLAYER.Shield > 0)
			{
				if (CurrentWall != null)
				{
					var p = transform.position;

					if (math.distance(p, OldPosition) > WallUpdateDistance)
					{
						CurrentWall.AddPoint(p);
						OldPosition = p;

						PLAYER.SubShield(1);
					}
				}
			}
			else
			{
				StopWall();
			}


			////////////////////////////////
			/// ITEM LOAD
			////////////////////////////////

			if (PLAYER.GameOver == false)
			{
				//Power Load
				if (TIME.realtimeSinceStartup - PowerLoadTime > PowerLoadSpeed)
				{
					PLAYER.AddPower(1);
					PowerLoadTime = TIME.realtimeSinceStartup;
				}

				//Shield Load
				if (TIME.realtimeSinceStartup - ShieldLoadTime > ShieldLoadSpeed)
				{
					PLAYER.AddShield(1);
					ShieldLoadTime = TIME.realtimeSinceStartup;
				}
			}

		}
		//====================================================================================================
		// ■ ACTIVATE
		//====================================================================================================
		public void Activate() { gameObject.SetActive(true); }
		//====================================================================================================
		// ■ INACTIVATE
		//====================================================================================================
		public void Inactivate() { gameObject.SetActive(false); }
		//====================================================================================================
		// ■ TURN LEFT
		//====================================================================================================
		public void TurnLeft()
		{
			Transform.Rotate(new float3(0, 0, 1), RotationSpeed * TIME.deltaTime);
		}
		//====================================================================================================
		// ■ TURN RIGHT
		//====================================================================================================
		public void TurnRight()
		{
			Transform.Rotate(new float3(0, 0, 1), -RotationSpeed * TIME.deltaTime);
		}
		//====================================================================================================
		// ■ BOMB
		//====================================================================================================
		public void Bomb()
		{
			if (PLAYER.GetBomb())
			{
				var obj = (GAMEOBJECT)Instantiate(BombObject);
				obj.SetActive(true);
				obj.Tag = "Bomb";

				var p = Transform.Position;
				
				obj.Transform.Parent = BombInstances.Transform;

				var bomb = obj.Transform.Find("Bomb");
				bomb.Position = p - math.normalize(p) * GridDistance;
				bomb.Transform.LookAt(p);
			}
		}
		//====================================================================================================
		// ■ START WALL
		//====================================================================================================
		public void StartWall()
		{
			if (CurrentWall == null)
			{
				var obj = (GAMEOBJECT)Instantiate(WallObject);
				obj.SetActive(true);
				obj.Tag = "Wall";
				obj.Transform.Parent = WallInstances.Transform;
				//obj.Transform.Position = laserObject.Transform.Position;
				//obj.Transform.Rotation = laserObject.Transform.Rotation;
				//obj.Transform.LocalScale = laserObject.Transform.LossyScale;

				CurrentWall = obj.GetComponent<WALL>();
			}
		}
		//====================================================================================================
		// ■ STOP WALL
		//====================================================================================================
		public void StopWall()
		{
			if (CurrentWall != null) CurrentWall.Finish();
			CurrentWall = null;
		}
		//====================================================================================================
		// ■ SPEED UP
		//====================================================================================================
		public void SpeedUp()
		{
			if (Speed < MaximalSpeed)
			{
				Speed = Speed + SpeedAcceleration;
				//		rigidbody.AddForce(transform.forward * 10, ForceMode.Acceleration); 
				//		transform.RotateAround(Vector2.zero, transform.right, (1.0f - (Speed/MaximalSpeed)) * -10 * Time.deltaTime);
			}
		}
		//====================================================================================================
		// ■ SPEED DOWN
		//====================================================================================================
		public void SpeedDown()
		{
			Speed = Speed * SpeedSlowdown;
			if (Speed > 0.01f)
			{
				//			rigidbody.AddForce(-transform.forward * 10, ForceMode.Acceleration);
				//			transform.RotateAround(Vector2.zero, transform.right, (Speed / MaximalSpeed) * 20 * Time.deltaTime);
			}
		}
		//====================================================================================================
		// ■ LASER SHOT
		//====================================================================================================
		public void LaserShot()
		{
			LaserLastShotTime += TIME.deltaTime;
			if (LaserLastShotTime > LaserRepeatTime)
			{
				LaserLastShotTime = 0;
				if (LastLaser == 1)
				{
					LastLaser = 0;

					LaserShotCreate(LeftLaserObject);
					LaserShotCreate(RightLaserObject);
				}
				else if (LastLaser == 0)
				{
					LastLaser = 1;
					LaserShotCreate(FrontLeftLaserObject);
					LaserShotCreate(FrontRightLaserObject);
				}
			}
		}
		//====================================================================================================
		// ■ LASER SHOT CREATE
		//====================================================================================================
		void LaserShotCreate(GAMEOBJECT laserObject)
		{
			var obj = (GAMEOBJECT)Instantiate(laserObject);
			obj.SetActive(true);
			obj.Tag = "Laser";
			obj.Transform.Parent = LaserInstancesObject.Transform;
			obj.Transform.Position = laserObject.Transform.Position;
			obj.Transform.Rotation = laserObject.Transform.Rotation;
			obj.Transform.LocalScale = laserObject.Transform.LossyScale;

			LASER laser = obj.GetComponent<LASER>();
			laser.SetLaserObject(obj);
			Destroy(obj, LaserLifeTime);
		}
		//====================================================================================================
		void OnCollisionEnter(UNITY.Collision other)
		{
			if (other.gameObject.tag == "Alien")
			{
				var alien = other.gameObject.GetComponent<ALIEN>();

				alien.Hit();

				PLAYER.SubPower(5);
				
				Color = COLOR.white;

				GameObject.AudioSource.Play();

			}

		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
