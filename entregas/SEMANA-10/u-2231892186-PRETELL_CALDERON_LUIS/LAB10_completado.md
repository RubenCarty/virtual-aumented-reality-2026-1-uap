# Laboratorio 10 — App AR con Interacción Avanzada y UI
## ⚠️ VERSIÓN ESTUDIANTE

**Tiempo estimado:** 100 minutos

---

## Objetivo

Extender la app AR de colocación de objetos (Lab 03/04) con:
- Pinch to scale + rotate con 1 dedo
- UI flotante World Space con información del objeto
- Botón de eliminar objeto
- Conexión a datos externos (simulada)

---

## PASO 1 — Script GestosAR.cs (35 min)

`Assets/Scripts/GestosAR.cs`:

```csharp
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using TMPro;

[RequireComponent(typeof(ARRaycastManager))]
public class GestosAR : MonoBehaviour
{
    public GameObject prefabObjeto;
    public GameObject panelInfoPrefab;
    public float velocidadRotacion = 0.3f;
    public float sensibilidadPinch = 1f;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject objeto;
    private GameObject panelInfo;

    // Variables para pinch
    private float distanciaInicialPinch;
    private float escalaInicialPinch;

    void Awake() => raycastManager = GetComponent<ARRaycastManager>();

    void Update()
    {
        if (Input.touchCount == 0) return;

        if (Input.touchCount == 2)
        {
            ManejarPinch();
        }
        else if (Input.touchCount == 1)
        {
            Touch toque = Input.GetTouch(0);

            if (toque.phase == TouchPhase.Began)
                ManejarToque(toque.position);
            else if (toque.phase == TouchPhase.Moved && objeto != null)
                ManejarRotacion(toque);
        }
    }

    void ManejarToque(Vector2 posicion)
    {
        // Primero: ¿tocó el objeto existente?
        if (objeto != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(posicion);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == objeto || hit.collider.transform.IsChildOf(objeto.transform))
                {
                    TogglePanel();
                    return;
                }
            }
        }

        // Si no: ARRaycast para colocar/mover
        hits.Clear();
        if (raycastManager.Raycast(posicion, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            if (objeto == null)
                objeto = Instantiate(prefabObjeto, pose.position, pose.rotation);
            else
                objeto.transform.SetPositionAndRotation(pose.position, pose.rotation);

            // Mover el panel con el objeto
            if (panelInfo != null)
                panelInfo.transform.position = objeto.transform.position + Vector3.up * 0.2f;
        }
    }

    void ManejarRotacion(Touch toque)
    {
        float rot = -toque.deltaPosition.x * velocidadRotacion;
        objeto.transform.Rotate(Vector3.up, rot, Space.World);
    }

    void ManejarPinch()
    {
        if (objeto == null) return;
        Touch t0 = Input.GetTouch(0), t1 = Input.GetTouch(1);

        if (t0.phase == TouchPhase.Began || t1.phase == TouchPhase.Began)
        {
            distanciaInicialPinch = Vector2.Distance(t0.position, t1.position);
            escalaInicialPinch = objeto.transform.localScale.x;
        }
        else
        {
            float factor  = Vector2.Distance(t0.position, t1.position) / distanciaInicialPinch;
            float nuevaEscala = Mathf.Clamp(escalaInicialPinch * factor * sensibilidadPinch, 0.05f, 5f);
            objeto.transform.localScale = Vector3.one * nuevaEscala;
        }
    }

    void TogglePanel()
    {
        if (panelInfo == null && panelInfoPrefab != null)
        {
            panelInfo = Instantiate(panelInfoPrefab);
            panelInfo.transform.position = objeto.transform.position + Vector3.up * 0.2f;
        }
        else if (panelInfo != null)
        {
            panelInfo.SetActive(!panelInfo.activeSelf);
        }
    }

    public void EliminarObjeto()
    {
        if (objeto != null) Destroy(objeto);
        if (panelInfo != null) Destroy(panelInfo);
        objeto = null;
        panelInfo = null;
    }

    void LateUpdate()
    {
        if (panelInfo != null && panelInfo.activeSelf)
        {
            panelInfo.transform.LookAt(Camera.main.transform);
            panelInfo.transform.Rotate(0, 180f, 0);
        }
    }
}
```

---

## PASO 2 — Crear Panel UI flotante (20 min)

1. Hierarchy → UI → Canvas
2. Canvas → Render Mode: **World Space**
3. Canvas Scale: 0.002 (para que sea pequeño en el espacio 3D)
4. Agregar hijos:
   - Image (panel fondo semitransparente, Alpha 0.7)
   - TextMeshPro (nombre del objeto)
   - TextMeshPro (descripción breve)
   - Button → Text: "Eliminar"
5. Al Button → On Click: arrastrar el GameObject XR Origin y seleccionar `GestosAR.EliminarObjeto`
6. Convertir en Prefab: `Assets/Prefabs/PanelInfoAR.prefab`
7. Arrastrar al campo "Panel Info Prefab" del script

---

## PASO 3 — Prueba y evidencias (15 min)

Probar en simulador o celular:
- Tap → colocar objeto
- Pinch → escalar
- Swipe horizontal → rotar
- Tap sobre objeto → mostrar/ocultar panel
- Botón Eliminar → borrar objeto

## Evidencias

```
□ 1. Captura del script GestosAR en Inspector (con prefabs asignados)
□ 2. Captura del Panel UI (modo World Space, con botón Eliminar)
□ 3. Video: colocar objeto + pinch + rotate (en 1 video)
□ 4. Video: tap sobre objeto → panel aparece → botón Eliminar
□ 5. Link al commit de GitHub
```

*PSISP08075 | Universidad Autónoma del Perú | 2026-1*
