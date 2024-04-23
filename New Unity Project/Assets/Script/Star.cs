using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Star : MonoBehaviour
{
    public float outerRadius = 1f; // 큰 원의 반지름
    public float innerRadius = 0.5f; // 작은 원의 반지름
    public int numPoints = 5; // 각 원의 버텍스 수

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        int numVertices = numPoints * 2; // 큰 원과 작은 원의 총 버텍스 수
        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices * 3];

        // 큰 원의 버텍스 생성
        for (int i = 0; i < numPoints; i++)
        {
            float ratio = (float)i / numPoints;
            float angle = Mathf.PI * 2 * ratio;
            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);
            vertices[i] = new Vector3(x * outerRadius, y * outerRadius, 0f);
        }

        // 작은 원의 버텍스 생성
        for (int i = 0; i < numPoints; i++)
        {
            float ratio = (float)i / numPoints;
            float angle = Mathf.PI * 2 * ratio;
            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);
            vertices[i + numPoints] = new Vector3(x * innerRadius, y * innerRadius, 0f);
        }

        // 삼각형 생성
        for (int i = 0; i < numPoints; i++)
        {
            int triIndex = i * 3;
            triangles[triIndex] = i;
            triangles[triIndex + 1] = (i + 1) % numPoints;
            triangles[triIndex + 2] = (i + numPoints - 1) % numPoints + numPoints;

            triIndex = (i + numPoints) * 3;
            triangles[triIndex] = i + numPoints;
            triangles[triIndex + 1] = (i + numPoints - 1) % numPoints + numPoints;
            triangles[triIndex + 2] = (i + 1) % numPoints + numPoints;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}

