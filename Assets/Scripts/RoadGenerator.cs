using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;
using UnityEditor;

[ExecuteAlways]
public class RoadGenerator : MonoBehaviour
{
    //[Header("Spline Reference")]
    //public SplineContainer splineContainer;

    //[Header("Road Settings")]
    //[Tooltip("Ancho de la carretera")]
    //public float roadWidth = 4f;
    //[Tooltip("Altura de la carretera")]
    //public float roadHeight = 0.1f;
    //[Tooltip("Número de segmentos por unidad de longitud")]
    //public float segmentsPerUnit = 1f;
    //[Tooltip("Material de la carretera")]
    //public Material roadMaterial;
    //[Tooltip("Material para las intersecciones")]
    //public Material intersectionMaterial;
    //[Tooltip("Escala de la textura de la carretera")]
    //public float textureTiling = 1f;
    //[Tooltip("Rotación de la textura en grados")]
    //[Range(0, 360)]
    //public float textureRotation = 0f;

    //[Header("Intersection Settings")]
    //[Tooltip("Distancia máxima para considerar una intersección")]
    //public float intersectionThreshold = 2f;
    //[Tooltip("Radio de la intersección")]
    //public float intersectionRadius = 3f;
    //[Tooltip("Distancia de truncado de carreteras cerca de intersecciones")]
    //public float roadTruncateDistance = 3f;
    //[Tooltip("Generar conexiones automáticas entre splines cercanos")]
    //public bool autoConnectSplines = true;
    //[Tooltip("Distancia máxima para auto-conectar splines")]
    //public float autoConnectDistance = 1.5f;
    //[Tooltip("Suavizado de las curvas (0-1)")]
    //[Range(0, 1)]
    //public float curveSmoothing = 0.5f;
    //[Tooltip("Número de segmentos adicionales para suavizar las transiciones")]
    //[Range(1, 10)]
    //public int transitionSegments = 3;
    //[Tooltip("Número de segmentos para las intersecciones")]
    //[Range(8, 32)]
    //public int intersectionSegments = 16;

    //private MeshFilter meshFilter;
    //private MeshRenderer meshRenderer;
    //private Mesh roadMesh;
    //private Mesh intersectionMesh;
    //private List<Vector3> intersectionPoints = new List<Vector3>();
    //private List<Vector3> intersectionNormals = new List<Vector3>();

    //private class SplineConnection
    //{
    //    public Vector3 position;
    //    public Vector3 normal;
    //    public List<SplineEndpoint> connectedEndpoints = new List<SplineEndpoint>();
    //    public float radius;
    //    public bool isIntersection;
    //}

    //private class SplineEndpoint
    //{
    //    public int splineIndex;
    //    public bool isStart; // true = inicio, false = final
    //    public Vector3 position;
    //    public Vector3 tangent;
    //}

    //private class AutoConnection
    //{
    //    public Vector3 connectionPoint;
    //    public List<SplineEndpoint> connectedEndpoints = new List<SplineEndpoint>();
    //    public List<Vector3> bridgeVertices = new List<Vector3>();
    //    public List<Vector2> bridgeUVs = new List<Vector2>();
    //    public List<int> bridgeTriangles = new List<int>();
    //}

    //private List<SplineConnection> splineConnections = new List<SplineConnection>();
    //private List<AutoConnection> autoConnections = new List<AutoConnection>();

    //void OnValidate()
    //{
    //    if (splineContainer == null)
    //        splineContainer = GetComponent<SplineContainer>();

    //    if (splineContainer == null)
    //    {
    //        Debug.LogError("[RoadGenerator] No se encontró SplineContainer. Por favor, asigna uno en el Inspector.");
    //        return;
    //    }

    //    // Asegurarse de que tenemos los componentes necesarios
    //    if (meshFilter == null)
    //        meshFilter = GetComponent<MeshFilter>();
    //    if (meshFilter == null)
    //        meshFilter = gameObject.AddComponent<MeshFilter>();

    //    if (meshRenderer == null)
    //        meshRenderer = GetComponent<MeshRenderer>();
    //    if (meshRenderer == null)
    //        meshRenderer = gameObject.AddComponent<MeshRenderer>();

    //    // Crear materiales por defecto si no hay asignados
    //    if (roadMaterial == null)
    //    {
    //        roadMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    //        roadMaterial.color = Color.gray;
    //        Debug.Log("[RoadGenerator] Se ha creado un material por defecto para la carretera.");
    //    }

    //    if (intersectionMaterial == null)
    //    {
    //        intersectionMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    //        intersectionMaterial.color = new Color(0.5f, 0.5f, 0.5f, 1f);
    //        Debug.Log("[RoadGenerator] Se ha creado un material por defecto para las intersecciones.");
    //    }

    //    meshRenderer.material = roadMaterial;
    //    GenerateRoadMesh();
    //}

    //private void FindIntersections()
    //{
    //    intersectionPoints.Clear();
    //    intersectionNormals.Clear();
    //    splineConnections.Clear();
    //    autoConnections.Clear();
    //    var splines = splineContainer.Splines;
        
    //    // Crear lista de todos los endpoints
    //    List<SplineEndpoint> endpoints = new List<SplineEndpoint>();
        
    //    for (int i = 0; i < splines.Count; i++)
    //    {
    //        var spline = splines[i];
    //        if (spline.Count < 2) continue;
            
    //        // Endpoint inicial
    //        var startKnot = spline[0];
    //        Vector3 startPos = new Vector3(startKnot.Position.x, startKnot.Position.y, startKnot.Position.z);
    //        float3 startTangent = spline.EvaluateTangent(0f);
            
    //        endpoints.Add(new SplineEndpoint
    //        {
    //            splineIndex = i,
    //            isStart = true,
    //            position = startPos,
    //            tangent = new Vector3(startTangent.x, startTangent.y, startTangent.z).normalized
    //        });
            
    //        // Endpoint final
    //        var endKnot = spline[spline.Count - 1];
    //        Vector3 endPos = new Vector3(endKnot.Position.x, endKnot.Position.y, endKnot.Position.z);
    //        float3 endTangent = spline.EvaluateTangent(1f);
            
    //        endpoints.Add(new SplineEndpoint
    //        {
    //            splineIndex = i,
    //            isStart = false,
    //            position = endPos,
    //            tangent = new Vector3(endTangent.x, endTangent.y, endTangent.z).normalized
    //        });
    //    }
        
    //    // Agrupar endpoints cercanos
    //    List<bool> processed = new List<bool>(new bool[endpoints.Count]);
        
    //    for (int i = 0; i < endpoints.Count; i++)
    //    {
    //        if (processed[i]) continue;
            
    //        List<SplineEndpoint> nearbyEndpoints = new List<SplineEndpoint>();
    //        nearbyEndpoints.Add(endpoints[i]);
    //        processed[i] = true;
            
    //        // Buscar otros endpoints cercanos
    //        for (int j = i + 1; j < endpoints.Count; j++)
    //        {
    //            if (processed[j]) continue;
    //            if (endpoints[i].splineIndex == endpoints[j].splineIndex) continue;
                
    //            float distance = Vector3.Distance(endpoints[i].position, endpoints[j].position);
    //            if (distance < intersectionThreshold)
    //            {
    //                nearbyEndpoints.Add(endpoints[j]);
    //                processed[j] = true;
    //            }
    //        }
            
    //        // Si hay más de un endpoint, crear una conexión
    //        if (nearbyEndpoints.Count > 1)
    //        {
    //            // Calcular el centro de todos los endpoints
    //            Vector3 centerPos = Vector3.zero;
    //            Vector3 averageNormal = Vector3.zero;
                
    //            foreach (var endpoint in nearbyEndpoints)
    //            {
    //                centerPos += endpoint.position;
    //                averageNormal += endpoint.tangent;
    //            }
                
    //            centerPos /= nearbyEndpoints.Count;
    //            centerPos.y = roadHeight;
    //            averageNormal = averageNormal.normalized;
                
    //            // Crear una nueva conexión
    //            SplineConnection connection = new SplineConnection
    //            {
    //                position = centerPos,
    //                normal = averageNormal,
    //                radius = intersectionRadius,
    //                isIntersection = true
    //            };
                
    //            // Añadir todos los endpoints conectados
    //            connection.connectedEndpoints.AddRange(nearbyEndpoints);
                
    //            splineConnections.Add(connection);
                
    //            // Añadir a las listas de intersección para compatibilidad
    //            intersectionPoints.Add(centerPos);
    //            intersectionNormals.Add(averageNormal);
                
    //            Debug.Log($"[RoadGenerator] Intersección creada conectando {nearbyEndpoints.Count} endpoints en posición {centerPos}");
    //        }
    //    }
        
    //    // Generar conexiones automáticas si está habilitado
    //    if (autoConnectSplines)
    //    {
    //        GenerateAutoConnections();
    //    }
    //}

    //private bool IsEndpointNearConnection(Vector3 position, int splineIndex, bool isStart, out SplineConnection connection)
    //{
    //    connection = null;
        
    //    foreach (var conn in splineConnections)
    //    {
    //        foreach (var endpoint in conn.connectedEndpoints)
    //        {
    //            if (endpoint.splineIndex == splineIndex && endpoint.isStart == isStart)
    //            {
    //                float distance = Vector3.Distance(position, conn.position);
    //                if (distance < conn.radius)
    //                {
    //                    connection = conn;
    //                    return true;
    //                }
    //            }
    //        }
    //    }
        
    //    return false;
    //}

    //private Vector3 SmoothCurve(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    //{
    //    // Interpolación cuadrática de Bézier
    //    float u = 1 - t;
    //    return u * u * p0 + 2 * u * t * p1 + t * t * p2;
    //}

    //private Vector3 GetRoadPoint(Spline spline, float t, Vector3 binormal)
    //{
    //    Vector3 pos = spline.EvaluatePosition(t);
    //    float3 tangentRaw = spline.EvaluateTangent(t);
    //    Vector3 tangent = new Vector3(tangentRaw.x, tangentRaw.y, tangentRaw.z).normalized;
        
    //    // Calcular posición de los vértices
    //    Vector3 leftVertex = pos - binormal * (roadWidth * 0.5f);
    //    Vector3 rightVertex = pos + binormal * (roadWidth * 0.5f);

    //    // Ajustar altura
    //    leftVertex.y = roadHeight;
    //    rightVertex.y = roadHeight;

    //    return (leftVertex + rightVertex) * 0.5f;
    //}

    //private Vector2 RotateUV(Vector2 uv, float angle)
    //{
    //    float rad = angle * Mathf.Deg2Rad;
    //    float cos = Mathf.Cos(rad);
    //    float sin = Mathf.Sin(rad);
    //    return new Vector2(
    //        uv.x * cos - uv.y * sin,
    //        uv.x * sin + uv.y * cos
    //    );
    //}

    //private void AddTransitionSegment(List<Vector3> vertices, List<Vector2> uvs, Vector3 start, Vector3 end, float v, Vector3 tangent)
    //{
    //    float segmentLength = Vector3.Distance(start, end);
    //    float uvScale = segmentLength * textureTiling;
        
    //    for (int i = 0; i <= transitionSegments; i++)
    //    {
    //        float t = (float)i / transitionSegments;
    //        Vector3 point = Vector3.Lerp(start, end, t);
    //        vertices.Add(point);
            
    //        // Calcular UVs basados en la dirección de la tangente
    //        Vector2 uv = new Vector2(0, v + t * uvScale);
    //        uv = RotateUV(uv, textureRotation);
    //        uvs.Add(uv);
            
    //        vertices.Add(point);
    //        uv = new Vector2(1, v + t * uvScale);
    //        uv = RotateUV(uv, textureRotation);
    //        uvs.Add(uv);
    //    }
    //}

    //private void GenerateIntersectionMesh()
    //{
    //    if (splineConnections.Count == 0) return;

    //    List<Vector3> vertices = new List<Vector3>();
    //    List<Vector2> uvs = new List<Vector2>();
    //    List<int> triangles = new List<int>();

    //    foreach (var connection in splineConnections)
    //    {
    //        if (!connection.isIntersection) continue;

    //        Vector3 center = connection.position;
    //        int baseIndex = vertices.Count;

    //        // Añadir el vértice central
    //        vertices.Add(center);
    //        uvs.Add(new Vector2(0.5f, 0.5f));

    //        // Crear un círculo simple de vértices alrededor del centro
    //        List<Vector3> circleVertices = new List<Vector3>();
    //        List<Vector2> circleUVs = new List<Vector2>();
            
    //        for (int i = 0; i < intersectionSegments; i++)
    //        {
    //            float angle = (i * 360f / intersectionSegments) * Mathf.Deg2Rad;
                
    //            Vector3 offset = new Vector3(
    //                Mathf.Cos(angle) * intersectionRadius,
    //                0,
    //                Mathf.Sin(angle) * intersectionRadius
    //            );
                
    //            Vector3 vertexPos = center + offset;
    //            vertexPos.y = roadHeight;
                
    //            circleVertices.Add(vertexPos);
                
    //            // UV en coordenadas polares
    //            circleUVs.Add(new Vector2(
    //                (Mathf.Cos(angle) + 1) * 0.5f,
    //                (Mathf.Sin(angle) + 1) * 0.5f
    //            ));
    //        }

    //        // Añadir los vértices del círculo
    //        vertices.AddRange(circleVertices);
    //        uvs.AddRange(circleUVs);

    //        // Crear triángulos en abanico desde el centro (orden correcto para normales hacia arriba)
    //        for (int i = 0; i < intersectionSegments; i++)
    //        {
    //            int current = baseIndex + 1 + i;
    //            int next = baseIndex + 1 + ((i + 1) % intersectionSegments);
                
    //            // Triángulo desde el centro (orden correcto: centro, siguiente, actual)
    //            triangles.Add(baseIndex); // centro
    //            triangles.Add(next);      // siguiente vértice
    //            triangles.Add(current);   // vértice actual
    //        }
    //    }

    //    // Crear o actualizar la mesh de intersección
    //    if (intersectionMesh == null)
    //        intersectionMesh = new Mesh();
    //    else
    //        intersectionMesh.Clear();

    //    if (vertices.Count > 0)
    //    {
    //        intersectionMesh.SetVertices(vertices);
    //        intersectionMesh.SetUVs(0, uvs);
    //        intersectionMesh.SetTriangles(triangles, 0);
    //        intersectionMesh.RecalculateNormals();
            
    //        // Forzar que las normales apunten hacia arriba
    //        ForceNormalsUpward(intersectionMesh);
            
    //        intersectionMesh.RecalculateBounds();

    //        // Crear un nuevo GameObject para la intersección si no existe
    //        GameObject intersectionObj = transform.Find("Intersections")?.gameObject;
    //        if (intersectionObj == null)
    //        {
    //            intersectionObj = new GameObject("Intersections");
    //            intersectionObj.transform.SetParent(transform);
    //            intersectionObj.transform.localPosition = Vector3.zero;
    //        }

    //        // Asegurarse de que tiene los componentes necesarios
    //        MeshFilter intersectionMeshFilter = intersectionObj.GetComponent<MeshFilter>();
    //        if (intersectionMeshFilter == null)
    //            intersectionMeshFilter = intersectionObj.AddComponent<MeshFilter>();

    //        MeshRenderer intersectionRenderer = intersectionObj.GetComponent<MeshRenderer>();
    //        if (intersectionRenderer == null)
    //            intersectionRenderer = intersectionObj.AddComponent<MeshRenderer>();

    //        // Asignar la mesh y el material
    //        intersectionMeshFilter.sharedMesh = intersectionMesh;
    //        intersectionRenderer.material = intersectionMaterial;
            
    //        // Activar el objeto si estaba desactivado
    //        intersectionObj.SetActive(true);
    //    }
    //    else
    //    {
    //        // Si no hay intersecciones, ocultar el objeto
    //        GameObject intersectionObj = transform.Find("Intersections")?.gameObject;
    //        if (intersectionObj != null)
    //        {
    //            intersectionObj.SetActive(false);
    //        }
    //    }
    //}

    //private void ModifyRoadMeshForIntersections()
    //{
    //    if (roadMesh == null || intersectionPoints.Count == 0) return;

    //    List<Vector3> vertices = new List<Vector3>();
    //    roadMesh.GetVertices(vertices);

    //    // Modificar los vértices cerca de las intersecciones
    //    for (int i = 0; i < vertices.Count; i++)
    //    {
    //        Vector3 vertex = vertices[i];
    //        foreach (var intersection in intersectionPoints)
    //        {
    //            float distance = Vector3.Distance(vertex, intersection);
    //            if (distance < intersectionRadius)
    //            {
    //                // Calcular la dirección hacia el centro de la intersección
    //                Vector3 direction = (intersection - vertex).normalized;
                    
    //                // Suavizar la transición
    //                float t = Mathf.SmoothStep(0, 1, distance / intersectionRadius);
    //                vertices[i] = Vector3.Lerp(intersection, vertex, t);
    //                break;
    //            }
    //        }
    //    }

    //    roadMesh.SetVertices(vertices);
    //    roadMesh.RecalculateNormals();
    //    roadMesh.RecalculateBounds();
    //}

    //public void GenerateRoadMesh()
    //{
    //    if (splineContainer == null || splineContainer.Splines.Count == 0)
    //    {
    //        Debug.LogError("[RoadGenerator] No hay splines configuradas. Por favor, añade puntos a las splines.");
    //        return;
    //    }

    //    FindIntersections();

    //    // Crear arrays para la mesh
    //    List<Vector3> vertices = new List<Vector3>();
    //    List<Vector2> uvs = new List<Vector2>();
    //    List<int> triangles = new List<int>();

    //    int vertexOffset = 0;

    //    // Procesar cada spline
    //    for (int splineIdx = 0; splineIdx < splineContainer.Splines.Count; splineIdx++)
    //    {
    //        var spline = splineContainer.Splines[splineIdx];
    //        float length = spline.GetLength();
            
    //        if (length <= 0)
    //        {
    //            Debug.LogWarning("[RoadGenerator] Una de las splines no tiene longitud. Será ignorada.");
    //            continue;
    //        }

    //        // Calcular número de segmentos para esta spline
    //        int numSegments = Mathf.Max(2, Mathf.CeilToInt(length * segmentsPerUnit));
    //        float segmentLength = length / (numSegments - 1);

    //        Vector3 prevBinormal = Vector3.zero;
    //        Vector3 prevSplinePos = Vector3.zero;
    //        bool isFirstPoint = true;
    //        float totalLength = 0f;
    //        Vector3 lastPos = Vector3.zero;

    //        // Lista temporal para los vértices de esta spline
    //        List<Vector3> splineVertices = new List<Vector3>();
    //        List<Vector2> splineUVs = new List<Vector2>();

    //        // Determinar si los endpoints están conectados
    //        SplineConnection startConnection = null;
    //        SplineConnection endConnection = null;
            
    //        IsEndpointNearConnection(spline.EvaluatePosition(0f), splineIdx, true, out startConnection);
    //        IsEndpointNearConnection(spline.EvaluatePosition(1f), splineIdx, false, out endConnection);

    //        // Calcular los rangos de t donde generar la carretera (evitando intersecciones)
    //        float startT = 0f;
    //        float endT = 1f;
            
    //        if (startConnection != null)
    //        {
    //            // Calcular cuánto retroceder desde el inicio
    //            float distanceToConnection = Vector3.Distance(spline.EvaluatePosition(0f), startConnection.position);
    //            float retreatDistance = Mathf.Max(roadTruncateDistance, roadWidth);
    //            startT = Mathf.Min(0.4f, retreatDistance / length);
    //        }
            
    //        if (endConnection != null)
    //        {
    //            // Calcular cuánto retroceder desde el final
    //            float distanceToConnection = Vector3.Distance(spline.EvaluatePosition(1f), endConnection.position);
    //            float retreatDistance = Mathf.Max(roadTruncateDistance, roadWidth);
    //            endT = Mathf.Max(0.6f, 1f - (retreatDistance / length));
    //        }

    //        // Generar vértices y UVs para esta spline (solo en el rango válido)
    //        for (int i = 0; i < numSegments; i++)
    //        {
    //            float t = i * segmentLength / length;
                
    //            // Saltar puntos fuera del rango válido
    //            if (t < startT || t > endT) continue;
                
    //            Vector3 pos = spline.EvaluatePosition(t);
    //            float3 tangentRaw = spline.EvaluateTangent(t);
    //            Vector3 tangent = new Vector3(tangentRaw.x, tangentRaw.y, tangentRaw.z).normalized;
    //            Vector3 normal = Vector3.up;
    //            Vector3 binormal = Vector3.Cross(tangent, normal).normalized;
                
    //            // Asegurar consistencia del binormal para evitar "twist"
    //            if (!isFirstPoint && Vector3.Dot(binormal, prevBinormal) < 0)
    //            {
    //                binormal = -binormal;
    //            }
                
    //            // Suavizar el binormal para transiciones más suaves
    //            if (!isFirstPoint)
    //            {
    //                binormal = Vector3.Slerp(prevBinormal, binormal, 0.8f).normalized;
    //            }

    //            if (!isFirstPoint)
    //            {
    //                totalLength += Vector3.Distance(pos, lastPos);
    //            }
    //            lastPos = pos;

    //            // Calcular posición de los vértices con suavizado
    //            Vector3 leftVertex = pos - binormal * (roadWidth * 0.5f);
    //            Vector3 rightVertex = pos + binormal * (roadWidth * 0.5f);

    //            // Aplicar suavizado si no es el primer o último punto del segmento válido
    //            if (splineVertices.Count > 0 && t < endT - 0.1f)
    //            {
    //                float prevT = Mathf.Max(startT, (i - 1) * segmentLength / length);
    //                float nextT = Mathf.Min(endT, (i + 1) * segmentLength / length);
                    
    //                if (prevT >= startT && nextT <= endT)
    //                {
    //                    Vector3 prevPoint = spline.EvaluatePosition(prevT);
    //                    Vector3 nextPos = spline.EvaluatePosition(nextT);
                        
    //                    leftVertex = SmoothCurve(
    //                        prevPoint - binormal * (roadWidth * 0.5f),
    //                        leftVertex,
    //                        nextPos - binormal * (roadWidth * 0.5f),
    //                        curveSmoothing
    //                    );
                        
    //                    rightVertex = SmoothCurve(
    //                        prevPoint + binormal * (roadWidth * 0.5f),
    //                        rightVertex,
    //                        nextPos + binormal * (roadWidth * 0.5f),
    //                        curveSmoothing
    //                    );
    //                }
    //            }

    //            // Ajustar altura
    //            leftVertex.y = roadHeight;
    //            rightVertex.y = roadHeight;

    //            splineVertices.Add(leftVertex);
    //            splineVertices.Add(rightVertex);

    //            float v = totalLength * textureTiling;
    //            splineUVs.Add(new Vector2(0, v));
    //            splineUVs.Add(new Vector2(1, v));

    //            prevBinormal = binormal;
    //            prevSplinePos = pos;
    //            isFirstPoint = false;
    //        }

    //        // Añadir los vértices y UVs de esta spline a las listas principales
    //        vertices.AddRange(splineVertices);
    //        uvs.AddRange(splineUVs);

    //        // Generar triángulos para esta spline
    //        for (int i = 0; i < splineVertices.Count - 2; i += 2)
    //        {
    //            if (i + 3 < splineVertices.Count)
    //            {
    //                // Primer triángulo (orden correcto para normal hacia arriba)
    //                triangles.Add(vertexOffset + i);
    //                triangles.Add(vertexOffset + i + 1);
    //                triangles.Add(vertexOffset + i + 2);

    //                // Segundo triángulo (orden correcto para normal hacia arriba)
    //                triangles.Add(vertexOffset + i + 1);
    //                triangles.Add(vertexOffset + i + 3);
    //                triangles.Add(vertexOffset + i + 2);
    //            }
    //        }

    //        vertexOffset += splineVertices.Count;
    //    }

    //    // Crear o actualizar la mesh
    //    if (roadMesh == null)
    //        roadMesh = new Mesh();
    //    else
    //        roadMesh.Clear();

    //    // Añadir geometría de conexiones automáticas
    //    foreach (var autoConn in autoConnections)
    //    {
    //        int baseIndex = vertices.Count;
    //        vertices.AddRange(autoConn.bridgeVertices);
    //        uvs.AddRange(autoConn.bridgeUVs);
            
    //        // Ajustar índices de triángulos
    //        foreach (int idx in autoConn.bridgeTriangles)
    //        {
    //            triangles.Add(baseIndex + idx);
    //        }
    //    }

    //    roadMesh.SetVertices(vertices);
    //    roadMesh.SetUVs(0, uvs);
    //    roadMesh.SetTriangles(triangles, 0);
    //    roadMesh.RecalculateNormals();
        
    //    // Forzar que las normales apunten hacia arriba
    //    ForceNormalsUpward(roadMesh);
        
    //    roadMesh.RecalculateBounds();

    //    // Asignar la mesh al MeshFilter
    //    meshFilter.sharedMesh = roadMesh;

    //    // Generar la mesh de intersecciones
    //    GenerateIntersectionMesh();
    //}

    //private void ForceNormalsUpward(Mesh mesh)
    //{
    //    Vector3[] normals = mesh.normals;
    //    for (int i = 0; i < normals.Length; i++)
    //    {
    //        // Si la normal apunta hacia abajo, invertirla
    //        if (normals[i].y < 0)
    //        {
    //            normals[i] = -normals[i];
    //        }
    //        // Asegurar que la componente Y sea dominante
    //        normals[i] = Vector3.Lerp(normals[i], Vector3.up, 0.5f).normalized;
    //    }
    //    mesh.normals = normals;
    //}

    //void OnDestroy()
    //{
    //    if (roadMesh != null)
    //    {
    //        if (Application.isPlaying)
    //            Destroy(roadMesh);
    //        else
    //            DestroyImmediate(roadMesh);
    //    }

    //    if (intersectionMesh != null)
    //    {
    //        if (Application.isPlaying)
    //            Destroy(intersectionMesh);
    //        else
    //            DestroyImmediate(intersectionMesh);
    //    }
    //}

    //void OnDrawGizmos()
    //{
    //    if (splineConnections != null)
    //    {
    //        Gizmos.color = Color.yellow;
    //        foreach (var connection in splineConnections)
    //        {
    //            if (connection.isIntersection)
    //            {
    //                Gizmos.DrawWireSphere(connection.position, intersectionRadius);
                    
    //                // Dibujar líneas hacia los endpoints conectados
    //                Gizmos.color = Color.red;
    //                foreach (var endpoint in connection.connectedEndpoints)
    //                {
    //                    Gizmos.DrawLine(connection.position, endpoint.position);
    //                }
                    
    //                // Mostrar información de la conexión
    //                Gizmos.color = Color.white;
    //                Handles.Label(connection.position + Vector3.up * 0.5f, 
    //                    $"Intersección\n{connection.connectedEndpoints.Count} endpoints");
                    
    //                Gizmos.color = Color.yellow;
    //            }
    //        }
    //    }
        
    //    // Dibujar conexiones automáticas
    //    if (autoConnections != null)
    //    {
    //        Gizmos.color = Color.cyan;
    //        foreach (var autoConn in autoConnections)
    //        {
    //            Gizmos.DrawWireSphere(autoConn.connectionPoint, 0.5f);
    //            Handles.Label(autoConn.connectionPoint + Vector3.up * 0.3f, "Auto-Conexión");
                
    //            // Dibujar los vértices del puente
    //            Gizmos.color = Color.magenta;
    //            for (int i = 0; i < autoConn.bridgeVertices.Count; i++)
    //            {
    //                Gizmos.DrawSphere(autoConn.bridgeVertices[i], 0.1f);
    //            }
    //            Gizmos.color = Color.cyan;
    //        }
    //    }
        
    //    // Dibujar los endpoints de las splines
    //    if (splineContainer != null && splineContainer.Splines != null)
    //    {
    //        Gizmos.color = Color.green;
    //        for (int i = 0; i < splineContainer.Splines.Count; i++)
    //        {
    //            var spline = splineContainer.Splines[i];
    //            if (spline.Count >= 2)
    //            {
    //                // Endpoint inicial
    //                var startKnot = spline[0];
    //                Vector3 startPos = new Vector3(startKnot.Position.x, startKnot.Position.y, startKnot.Position.z);
    //                Gizmos.DrawSphere(startPos, 0.2f);
    //                Handles.Label(startPos + Vector3.up * 0.3f, $"S{i} Start");
                    
    //                // Endpoint final
    //                var endKnot = spline[spline.Count - 1];
    //                Vector3 endPos = new Vector3(endKnot.Position.x, endKnot.Position.y, endKnot.Position.z);
    //                Gizmos.DrawSphere(endPos, 0.2f);
    //                Handles.Label(endPos + Vector3.up * 0.3f, $"S{i} End");
    //            }
    //        }
    //    }
    //}

    //private void GenerateAutoConnections()
    //{
    //    var splines = splineContainer.Splines;
    //    List<Vector3> processedConnections = new List<Vector3>();
        
    //    // Para cada spline, verificar si algún punto está cerca de otro spline
    //    for (int i = 0; i < splines.Count; i++)
    //    {
    //        var splineA = splines[i];
    //        float lengthA = splineA.GetLength();
    //        if (lengthA <= 0) continue;
            
    //        // Verificar puntos a lo largo del spline A
    //        int segments = Mathf.Max(10, Mathf.CeilToInt(lengthA * 2)); // Más puntos para mejor detección
            
    //        for (int segA = 0; segA <= segments; segA++)
    //        {
    //            float tA = (float)segA / segments;
    //            Vector3 posA = splineA.EvaluatePosition(tA);
                
    //            // Verificar contra otros splines
    //            for (int j = i + 1; j < splines.Count; j++)
    //            {
    //                var splineB = splines[j];
    //                float lengthB = splineB.GetLength();
    //                if (lengthB <= 0) continue;
                    
    //                // Encontrar el punto más cercano en spline B
    //                float closestT = FindClosestPointOnSpline(splineB, posA);
    //                Vector3 closestPos = splineB.EvaluatePosition(closestT);
                    
    //                float distance = Vector3.Distance(posA, closestPos);
                    
    //                if (distance < autoConnectDistance)
    //                {
    //                    // Crear una conexión automática
    //                    Vector3 connectionPoint = (posA + closestPos) * 0.5f;
    //                    connectionPoint.y = roadHeight;
                        
    //                    // Verificar si ya existe una conexión cercana
    //                    bool alreadyExists = false;
    //                    foreach (var existingPoint in processedConnections)
    //                    {
    //                        if (Vector3.Distance(connectionPoint, existingPoint) < autoConnectDistance * 0.5f)
    //                        {
    //                            alreadyExists = true;
    //                            break;
    //                        }
    //                    }
                        
    //                    if (!alreadyExists)
    //                    {
    //                        AutoConnection autoConn = new AutoConnection();
    //                        autoConn.connectionPoint = connectionPoint;
                            
    //                        // Generar geometría de puente
    //                        GenerateBridgeGeometry(autoConn, posA, closestPos, splineA.EvaluateTangent(tA), splineB.EvaluateTangent(closestT));
                            
    //                        autoConnections.Add(autoConn);
    //                        processedConnections.Add(connectionPoint);
                            
    //                        Debug.Log($"[RoadGenerator] Conexión automática creada entre spline {i} y {j} en {connectionPoint}");
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}

    //private float FindClosestPointOnSpline(Spline spline, Vector3 targetPoint)
    //{
    //    float closestT = 0f;
    //    float minDistance = float.MaxValue;
        
    //    // Búsqueda gruesa
    //    for (int i = 0; i <= 20; i++)
    //    {
    //        float t = (float)i / 20f;
    //        Vector3 pos = spline.EvaluatePosition(t);
    //        float distance = Vector3.Distance(pos, targetPoint);
            
    //        if (distance < minDistance)
    //        {
    //            minDistance = distance;
    //            closestT = t;
    //        }
    //    }
        
    //    // Refinamiento
    //    float step = 0.05f;
    //    for (int iter = 0; iter < 3; iter++)
    //    {
    //        float bestT = closestT;
    //        float bestDist = minDistance;
            
    //        for (float offset = -step; offset <= step; offset += step * 0.5f)
    //        {
    //            float testT = Mathf.Clamp01(closestT + offset);
    //            Vector3 pos = spline.EvaluatePosition(testT);
    //            float distance = Vector3.Distance(pos, targetPoint);
                
    //            if (distance < bestDist)
    //            {
    //                bestDist = distance;
    //                bestT = testT;
    //            }
    //        }
            
    //        closestT = bestT;
    //        minDistance = bestDist;
    //        step *= 0.5f;
    //    }
        
    //    return closestT;
    //}

    //private void GenerateBridgeGeometry(AutoConnection connection, Vector3 pointA, Vector3 pointB, float3 tangentA, float3 tangentB)
    //{
    //    Vector3 tangA = new Vector3(tangentA.x, tangentA.y, tangentA.z).normalized;
    //    Vector3 tangB = new Vector3(tangentB.x, tangentB.y, tangentB.z).normalized;
        
    //    Vector3 binormalA = Vector3.Cross(tangA, Vector3.up).normalized;
    //    Vector3 binormalB = Vector3.Cross(tangB, Vector3.up).normalized;
        
    //    // Crear vértices del puente
    //    Vector3 leftA = pointA - binormalA * (roadWidth * 0.5f);
    //    Vector3 rightA = pointA + binormalA * (roadWidth * 0.5f);
    //    Vector3 leftB = pointB - binormalB * (roadWidth * 0.5f);
    //    Vector3 rightB = pointB + binormalB * (roadWidth * 0.5f);
        
    //    leftA.y = rightA.y = leftB.y = rightB.y = roadHeight;
        
    //    connection.bridgeVertices.AddRange(new Vector3[] { leftA, rightA, leftB, rightB });
    //    connection.bridgeUVs.AddRange(new Vector2[] { 
    //        new Vector2(0, 0), new Vector2(1, 0), 
    //        new Vector2(0, 1), new Vector2(1, 1) 
    //    });
        
    //    // Crear triángulos del puente
    //    int baseIdx = 0;
    //    connection.bridgeTriangles.AddRange(new int[] {
    //        baseIdx, baseIdx + 1, baseIdx + 2,
    //        baseIdx + 1, baseIdx + 3, baseIdx + 2
    //    });
    //}
}
