# Guía de Trabajo 10 — Interacción Avanzada en AR
## ⚠️ VERSIÓN ESTUDIANTE

**Estudiante:** Gianfranco Eduardo Levano Villanueva  **Código:**  2221898772
**Fecha:** 13/06/2026 | **Puntuación total:** 20/20

---

## PARTE I — Opción Múltiple (4 puntos)

**1.** Para evitar conflicto entre pinch (2 dedos) y rotate (1 dedo), se debe:
- [ ] a) Deshabilitar uno de los dos gestos
- [X] b) Usar `if (touchCount == 2)` para pinch y `else if (touchCount == 1)` para rotate
- [ ] c) Usar callbacks en vez de Update()
- [ ] d) Cada gesto requiere un script separado

**2.** Un Canvas con Render Mode "World Space" en AR permite:
- [ ] a) Que la UI siempre esté en la misma posición de la pantalla
- [X] b) Que la UI exista como objeto 3D flotante en el espacio AR
- [ ] c) Que la UI sea transparente
- [ ] d) Optimizar automáticamente el número de draw calls

**3.** `Physics.Raycast` en este contexto (S10) detecta:
- [ ] a) Planos AR detectados por ARCore
- [X] b) Colliders de GameObjects de Unity
- [ ] c) Feature points del SLAM
- [ ] d) La posición de la luz en la escena

**4.** `LookAt(Camera.main.transform)` aplicado a un panel UI:
- [ ] a) Hace que el panel se mueva hacia la cámara
- [X] b) Rota el panel para que siempre enfrente a la cámara (billboard)
- [ ] c) Cambia el tamaño del panel según la distancia
- [ ] d) Desactiva el panel cuando la cámara se aleja

---

## PARTE II — Completar (4 puntos)

1. `t.deltaPosition.x` en un Touch de Unity indica el desplazamiento del dedo desde el frame anterior en el eje horizontal.

2. `Mathf.Clamp(valor, min, max)` en el pinch sirve para limitar los valores de escala extremos.

3. Para mostrar datos de una API REST en Unity, se usa una corrutina (Coroutine) (método que puede pausar sin bloquear el hilo principal).

4. Un panel UI que siempre mira a la cámara se llama Billboard en diseño 3D.

---

## PARTE III — Análisis y diseño (8 puntos)

**3.1** (3 pt) Analiza este fragmento de código e identifica qué hace cada sección:
```csharp
void Update()
{
    // SECCIÓN A
    if (Input.touchCount == 2)
    {
        Touch t0 = Input.GetTouch(0);
        Touch t1 = Input.GetTouch(1);
        float dist = Vector2.Distance(t0.position, t1.position);
        // ... escalar
    }
    
    // SECCIÓN B
    else if (Input.touchCount == 1)
    {
        Touch t = Input.GetTouch(0);
        if (t.phase == TouchPhase.Moved)
        {
            objeto.transform.Rotate(Vector3.up, -t.deltaPosition.x * 0.3f, Space.World);
        }
    }
}
```

| Sección | ¿Qué hace? | ¿Cuándo se activa? |
|---------|-----------|------------------|
| A | Obtiene la distancia entre dos dedos para calcular la escala (Pinch). | Cuando hay exactamente 2 dedos en pantalla. |
| B | Rota el objeto en el eje Y según el movimiento horizontal del dedo. | Cuando hay 1 solo dedo y este se encuentra en movimiento. |
| Else-if | Condiciona la rotación, dándole prioridad absoluta al escalado. | Evita que el objeto rote erráticamente mientras se usan 2 dedos. |

**3.2** (3 pt) Diseña en pseudo-código el sistema de interacción para una app AR de compras donde el usuario puede:

- Colocar un sofá en la sala (tap en plano)

- Escalarlo con pinch

- Rotarlo con dedo

- Ver precio al tocar el sofá

```csharp
// Pseudo-código del sistema de interacción:
void Update() {
    // 1. Colocar sofá (Tap en plano)
    if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) {
        Touch t = Input.GetTouch(0);
        if (ARRaycastManager.Raycast(t.position, hits, TrackableType.PlaneWithinPolygon)) {
            if (!objetoInstanciado) {
                Instanciar(sofaPrefab, hits[0].pose.position, hits[0].pose.rotation);
            } else {
                // 4. Ver precio al tocar el sofá
                if (Physics.Raycast(Camara.ScreenPointToRay(t.position), out hit)) {
                    if (hit.collider.CompareTag("Sofa")) MostrarUIPrecio();
                }
            }
        }
    }
    
    // 2. Escalar con Pinch
    if (Input.touchCount == 2) {
        Touch t0 = Input.GetTouch(0); Touch t1 = Input.GetTouch(1);
        float nuevaDistancia = Vector2.Distance(t0.position, t1.position);
        if (t0.phase == TouchPhase.Moved || t1.phase == TouchPhase.Moved) {
            float factor = nuevaDistancia / distanciaPrevia;
            sofá.transform.localScale *= factor;
        }
        distanciaPrevia = nuevaDistancia;
    }
    
    // 3. Rotar con 1 dedo
    else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved) {
        Touch t = Input.GetTouch(0);
        sofá.transform.Rotate(Vector3.up, -t.deltaPosition.x * velocidadRotacion);
    }
}
```
**3.3** (2 pt) ¿Cuál es la diferencia entre Physics.Raycast y ARRaycastManager.Raycast? ¿Cuándo se usa cada uno?

| | Physics.Raycast | ARRaycastManager.Raycast |
|--|----------------|------------------------|
| Detecta | Colliders de GameObjects virtuales en la escena 3D. | Planos físicos y superficies reales detectadas por la cámara (SLAM). |
| Cuándo usar | Para interactuar o seleccionar objetos virtuales ya creados. | Para buscar un lugar en el mundo real donde colocar un objeto. |

---

## PARTE IV — Reflexión (4 puntos)

**4.1** (2 pt) El principio de "affordance" en UX significa que el objeto debe parecer interactivo sin necesidad de instrucciones. Propón 2 formas de aplicar affordance visual en tu app AR de proyecto.

> 1. Mostrar un aro indicador luminoso o sombra digital en la base del objeto cuando el usuario lo selecciona para moverlo.
> 2. Agregar un ícono flotante sutil de una mano o flechas curvadas tridimensionales alrededor del objeto para sugerir rotación.

**4.2** (2 pt) Si tu app AR es para usuarios mayores de 60 años (adultos mayores), ¿qué cambios harías en la interacción? Menciona al menos 3 adaptaciones.

> 1. Reemplazar el gesto de pellizco (pinch) con dos botones de pantalla grandes (+ y -) para el escalado.
> 2. Disminuir la sensibilidad de rotación para mitigar movimientos involuntarios o ligeros temblores en las manos.
> 3. Utilizar textos en "World Space" con tipografía pesada, de alto contraste y un tamaño mínimo de 24pt para lectura clara.

*PSISP08075 | Universidad Autónoma del Perú | 2026-1*