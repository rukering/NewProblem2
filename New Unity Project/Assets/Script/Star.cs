using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Star : MonoBehaviour
{
    public float outerRadius = 1f; // ū ���� ������
    public float innerRadius = 0.5f; // ���� ���� ������
    public int numPoints = 5; // �� ���� ���ؽ� ��

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        int numVertices = numPoints * 2; // ū ���� ���� ���� �� ���ؽ� ��
        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices * 3];

        // ū ���� ���ؽ� ����
        for (int i = 0; i < numPoints; i++)
        {
            float ratio = (float)i / numPoints;
            float angle = Mathf.PI * 2 * ratio;
            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);
            vertices[i] = new Vector3(x * outerRadius, y * outerRadius, 0f);
        }

        // ���� ���� ���ؽ� ����
        for (int i = 0; i < numPoints; i++)
        {
            float ratio = (float)i / numPoints;
            float angle = Mathf.PI * 2 * ratio;
            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);
            vertices[i + numPoints] = new Vector3(x * innerRadius, y * innerRadius, 0f);
        }

        // �ﰢ�� ����
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

