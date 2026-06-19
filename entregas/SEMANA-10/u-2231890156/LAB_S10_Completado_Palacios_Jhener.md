# Laboratorio 10 — App AR con Interacción Avanzada y UI
**Estudiante:** Palacios Vergaray Jhener Erick **Código:** 2231890156

## Desarrollo del laboratorio en Unity

---

## Objetivo

En este laboratorio se extendió la aplicación AR de colocación de objetos, agregando interacción avanzada mediante gestos táctiles y una interfaz flotante en World Space.

Las funcionalidades implementadas fueron:

- Colocar un objeto en un plano AR mediante tap.
- Escalar el objeto usando gesto pinch con dos dedos.
- Rotar el objeto con movimiento horizontal de un dedo.
- Mostrar u ocultar un panel flotante con información del objeto.
- Eliminar el objeto mediante un botón de la interfaz.
- Simular la conexión a datos externos mostrando información del objeto en el panel.

---

## PASO 1 — Creación del script GestosAR.cs

Se creó el archivo:

`Assets/Scripts/GestosAR.cs`

Este script fue asignado al objeto principal de AR, donde también se encuentra el componente `ARRaycastManager`.

El script permite controlar la interacción principal de la aplicación AR:

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

        hits.Clear();
        if (raycastManager.Raycast(posicion, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            if (objeto == null)
                objeto = Instantiate(prefabObjeto, pose.position, pose.rotation);
            else
                objeto.transform.SetPositionAndRotation(pose.position, pose.rotation);

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

Este script controla la colocación del objeto, la rotación, el escalado, la aparición del panel informativo y la eliminación del objeto.

---

## PASO 2 — Creación del Panel UI flotante

Se creó un Canvas desde la jerarquía de Unity:

`Hierarchy → UI → Canvas`

Luego se configuró el Canvas con:

`Render Mode → World Space`

También se ajustó su escala a:

`Canvas Scale: 0.002`

Esto permitió que el panel se comporte como un objeto flotante dentro del espacio AR.

---

### Elementos agregados al Canvas

Dentro del Canvas se añadieron los siguientes elementos:

- `Image`: fondo semitransparente del panel.
- `TextMeshPro`: nombre del objeto.
- `TextMeshPro`: descripción breve del objeto.
- `Button`: botón con el texto "Eliminar".

El panel fue usado para simular información externa del objeto, como si los datos provinieran de una API REST.

Ejemplo de información mostrada:

```text
Nombre: Componente AR
Descripción: Objeto interactivo colocado en realidad aumentada.
Precio: S/ 120.00
```

---

## Configuración del botón Eliminar

Al botón `Eliminar` se le asignó la función pública del script:

`GestosAR.EliminarObjeto`

Para ello se realizó lo siguiente:

1. Seleccionar el botón.
2. Ir al componente `Button`.
3. En `On Click`, arrastrar el GameObject que contiene el script `GestosAR`.
4. Seleccionar la función:

`GestosAR → EliminarObjeto()`

Con esta configuración, al presionar el botón se elimina tanto el objeto AR como el panel informativo.

---

## Creación del Prefab del Panel

Después de configurar el Canvas, se convirtió en prefab arrastrándolo a la carpeta:

`Assets/Prefabs/PanelInfoAR.prefab`

Luego se asignó este prefab al campo:

`Panel Info Prefab`

dentro del script `GestosAR` en el Inspector.

También se asignó el modelo u objeto AR al campo:

`Prefab Objeto`

---

## PASO 3 — Pruebas realizadas

Se realizaron pruebas en la escena AR para verificar el funcionamiento de cada interacción.

| Acción | Resultado |
|-------|-----------|
| Tap sobre plano AR | El objeto se coloca en la superficie detectada |
| Pinch con dos dedos | El objeto aumenta o reduce su escala |
| Swipe horizontal con un dedo | El objeto rota sobre el eje Y |
| Tap sobre el objeto | Se muestra u oculta el panel informativo |
| Botón Eliminar | Se elimina el objeto y el panel de la escena |

---

## Evidencias realizadas

### Evidencia 1

Captura del script `GestosAR` en el Inspector, mostrando los campos `Prefab Objeto` y `Panel Info Prefab` correctamente asignados.

### Evidencia 2

Captura del Panel UI configurado en modo `World Space`, mostrando el nombre del objeto, la descripción y el botón `Eliminar`.

### Evidencia 3

Video de prueba donde se muestra el flujo:

`Colocar objeto → Pinch para escalar → Swipe para rotar`

### Evidencia 4

Video de prueba donde se muestra el flujo:

`Tap sobre objeto → Aparece panel informativo → Presionar botón Eliminar`

### Evidencia 5

Commit realizado en GitHub con los archivos del laboratorio, incluyendo el script, el prefab del panel y la escena actualizada.

---

## Conclusión

En este laboratorio se implementó una interacción AR más avanzada dentro de Unity. El uso de `ARRaycastManager` permitió colocar objetos sobre planos detectados, mientras que `Physics.Raycast` permitió reconocer toques sobre el objeto virtual.

Además, se incorporaron gestos táctiles como pinch para escalar y swipe para rotar, mejorando la manipulación del objeto en la escena. Finalmente, el panel en `World Space` permitió mostrar información flotante dentro del entorno AR y agregar una opción para eliminar el objeto de forma interactiva.

La práctica permitió reforzar el uso de interacción táctil, UI flotante y manipulación de objetos en aplicaciones de Realidad Aumentada.