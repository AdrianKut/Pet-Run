using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]   
public class NavigationBaker : MonoBehaviour
{
    private NavMeshSurface surface;
    private void Awake()
    {
        surface = GetComponent<NavMeshSurface>();
    }

    void LateUpdate()
    {
        surface.BuildNavMesh();
    }
}