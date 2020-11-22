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
	public class EXPLOSION : MONOBEHAVIOUR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		float3[] PointArray;
		//-----------------------------------------------------------------------------------------------------
		int PointCount = 100;
		//-----------------------------------------------------------------------------------------------------
		MESH ExplosionMesh;
		//-----------------------------------------------------------------------------------------------------
		float ExplosionSize = 0;
		float ExplosionWidth = 0;
		float MaxExplosionSize = 0.2f;
		float MaxExplosionWidth = 0.3f;
		//-----------------------------------------------------------------------------------------------------
		COLOR Color = new COLOR(1, 1, 1, 1);
		//-----------------------------------------------------------------------------------------------------
		float PlanetRadius = 0.68f;
		//-----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
			PointArray = new float3[PointCount];

			for (int i = 0; i < PointCount; i++)
			{
				var angle = 2 * math.PI * i / PointCount;
				var p = new float3(math.sin(angle), math.cos(angle), 0);
				PointArray[i] = p;
			}

			GameObject.AudioSource.Play();
		}
		//====================================================================================================
		// ■ UPDATE
		//====================================================================================================
		void Update()
		{
			ExplosionSize = math.lerp(MaxExplosionSize, ExplosionSize, 0.98f);
			ExplosionWidth = math.lerp(MaxExplosionWidth, ExplosionWidth, 0.98f);
			Color.a = math.lerp(0, Color.a, 0.99f);

			var collider = GetComponent<UnityEngine.SphereCollider>();
			collider.radius = ExplosionSize;

			var center = new float3(0, 0, PlanetRadius);
			collider.center = center;

			CreateMesh();

			//Set Color
			var material = GameObject.Renderer.material;
			material.SetColor("_Color", Color);
		}
		//====================================================================================================
		// ■ CREATE MESH
		//====================================================================================================
		void CreateMesh()
		{
			if (ExplosionMesh == null) ExplosionMesh = new MESH();
			else ExplosionMesh.Clear();

			var vertexArray = new float3[PointCount * 2];
			var indexArray = new int[(PointCount + 1) * 6];

			//Vertex
			for (int i = 0; i < PointCount; i++)
			{
				var p1 = ExplosionSize * PointArray[i];
				p1.z = PlanetRadius;
				p1 = math.normalize(p1) * PlanetRadius;

				var p2 = ExplosionSize * (1 + ExplosionWidth) * PointArray[i];
				p2.z = PlanetRadius;
				p2 = math.normalize(p2) * PlanetRadius;

				vertexArray[2 * i + 0] = p1;
				vertexArray[2 * i + 1] = p2;
			}

			//Index
			for (int i = 0; i < PointCount; i++)
			{
				var p0 = i * 2 + 0;
				var p1 = i * 2 + 1;

				var p2 = ((i + 1) % PointCount) * 2 + 0;
				var p3 = ((i + 1) % PointCount) * 2 + 1;

				indexArray[i * 6 + 0] = p0;
				indexArray[i * 6 + 1] = p1;
				indexArray[i * 6 + 2] = p3;
				indexArray[i * 6 + 3] = p3;
				indexArray[i * 6 + 4] = p2;
				indexArray[i * 6 + 5] = p0;
			}

			ExplosionMesh.vertices = vertexArray;
			ExplosionMesh.SetTriangleIndices(indexArray);

			GameObject.MeshFilter.sharedMesh = ExplosionMesh;

		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
