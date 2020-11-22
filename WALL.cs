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
	public class WALL : MONOBEHAVIOUR
	{
		struct POINT
		{
			public float3 Position;
			public float Height;

			public POINT(float3 position, float height)
			{
				Position = position;
				Height = height;
			}
		}

		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		List<POINT> PointList;
		//-----------------------------------------------------------------------------------------------------
		bool Change = false;
		//-----------------------------------------------------------------------------------------------------
		MESH WallMesh;
		//-----------------------------------------------------------------------------------------------------
		public float WallWidth = 0.01f;
		public float WallHeight = 0.02f;
		public float GridDistance = 0.02f;
		//-----------------------------------------------------------------------------------------------------
		public int PointCount = 0;
		//-----------------------------------------------------------------------------------------------------
		bool FinishFlag = false;
		float FinishTime;
		public float FinishStartTime = 3;
		//-----------------------------------------------------------------------------------------------------
		COLOR Color = new COLOR(1, 1, 1, 0.9f);
		//-----------------------------------------------------------------------------------------------------
		GAMEOBJECT WallCollider;
		//-----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
			PointList = new List<POINT>();
			
			WallCollider = Transform.Find("WallCollider").GameObject;
			WallCollider.SetActive(false);
		}
		//====================================================================================================
		// ■ UPDATE
		//====================================================================================================
		void Update()
		{
			if (Change)
			{
				CreateMesh();

				Change = false;
			}

			PointCount = PointList.Count;

			//Finish
			if (FinishFlag)
			{
				if (TIME.realtimeSinceStartup - FinishTime > FinishStartTime)
				{
					WallHeight = math.lerp(0, WallHeight, 0.95f);
					Color.a = math.lerp(0, Color.a, 0.95f);

					Change = true;

					//Destroy
					if (WallHeight < 0.001f) Destroy(GameObject);
				}
			}

			//Set Color
			var material = GameObject.Renderer.material;
			material.SetColor("_Color", Color);
		}
		//====================================================================================================
		// ■ ADD
		//====================================================================================================
		public void AddPoint(float3 position)
		{
			PointList.Add(new POINT(position, WallHeight));
			Change = true;

			///////////////////////////
			//Add WallCollider
			//////////////////////////

			var obj = GAMEOBJECT.Instantiate(WallCollider);
			obj.SetActive(true);
			obj.Transform.Parent = Transform;
			obj.Transform.LookAt(position);
			obj.Transform.Position = position;
		}
		//====================================================================================================
		// ■ FINISH
		//====================================================================================================
		public void Finish()
		{
			FinishFlag = true;
			FinishTime = TIME.realtimeSinceStartup;
		}
		//====================================================================================================
		// ■ CREATE MESH
		//====================================================================================================
		void CreateMesh()
		{
			if (PointList.Count >= 2)
			{
				if (WallMesh == null) WallMesh = new MESH();
				else WallMesh.Clear();

				int count = PointList.Count;

				var vertexArray = new float3[count * 4];
				var indexArray = new int[(count - 1) * 18 + 12];

				//Vertex
				for (int i = 0; i < count; i++)
				{
					var p = PointList[i];
					float3 tangent;

					if (i - 1 >= 0)
					{
						var t = PointList[i - 1].Position;
						tangent = math.normalize(p.Position - t);
					}
					else
					{
						var t = PointList[i + 1].Position;
						tangent = math.normalize(t - p.Position);
					}
					
					var center = math.normalize(p.Position);

					var normal = math.normalize(math.cross(tangent, center));

					var gridPosition = p.Position - center * GridDistance;

					vertexArray[4 * i + 0] = gridPosition - normal * WallWidth;
					vertexArray[4 * i + 1] = gridPosition + center * WallHeight - normal * WallWidth;
					vertexArray[4 * i + 2] = gridPosition + center * WallHeight + normal * WallWidth;
					vertexArray[4 * i + 3] = gridPosition + normal * WallWidth;
				}

				//Index
				for (int i = 0; i < count - 1; i++)
				{
					var p0 = i * 4 + 0;
					var p1 = i * 4 + 1;
					var p2 = i * 4 + 2;
					var p3 = i * 4 + 3;

					var p4 = (i + 1) * 4 + 0;
					var p5 = (i + 1) * 4 + 1;
					var p6 = (i + 1) * 4 + 2;
					var p7 = (i + 1) * 4 + 3;

					indexArray[i * 18 + 0] = p4;
					indexArray[i * 18 + 1] = p5;
					indexArray[i * 18 + 2] = p1;
					indexArray[i * 18 + 3] = p1;
					indexArray[i * 18 + 4] = p0;
					indexArray[i * 18 + 5] = p4;

					indexArray[i * 18 + 6] = p1;
					indexArray[i * 18 + 7] = p5;
					indexArray[i * 18 + 8] = p6;
					indexArray[i * 18 + 9] = p6;
					indexArray[i * 18 + 10] = p2;
					indexArray[i * 18 + 11] = p1;

					indexArray[i * 18 + 12] = p3;
					indexArray[i * 18 + 13] = p2;
					indexArray[i * 18 + 14] = p6;
					indexArray[i * 18 + 15] = p6;
					indexArray[i * 18 + 16] = p7;
					indexArray[i * 18 + 17] = p3;
				}

				//begin, end close
				var v0 = 0 * 4 + 0;
				var v1 = 0 * 4 + 1;
				var v2 = 0 * 4 + 2;
				var v3 = 0 * 4 + 3;

				var v4 = (count - 1) * 4 + 0;
				var v5 = (count - 1) * 4 + 1;
				var v6 = (count - 1) * 4 + 2;
				var v7 = (count - 1) * 4 + 3;

				int j = count - 1;
				indexArray[j * 18 + 0] = v0;
				indexArray[j * 18 + 1] = v1;
				indexArray[j * 18 + 2] = v2;
				indexArray[j * 18 + 3] = v2;
				indexArray[j * 18 + 4] = v3;
				indexArray[j * 18 + 5] = v0;

				indexArray[j * 18 + 6] = v7;
				indexArray[j * 18 + 7] = v6;
				indexArray[j * 18 + 8] = v5;
				indexArray[j * 18 + 9] = v5;
				indexArray[j * 18 + 10] = v4;
				indexArray[j * 18 + 11] = v7;

				WallMesh.vertices = vertexArray;
				WallMesh.SetTriangleIndices(indexArray);

				GameObject.MeshFilter.sharedMesh = WallMesh;
			}

		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
