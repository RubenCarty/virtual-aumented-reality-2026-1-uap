# Guía de Trabajo 10 — Interacción Avanzada en AR
## ⚠️ VERSIÓN ESTUDIANTE


**Estudiante:** Palacios Vergaray Jhener Erick **Código:** 2231890156

---

## PARTE I — Opción Múltiple (4 puntos)
**1.** Para evitar conflicto entre pinch (2 dedos) y rotate (1 dedo), se debe:
- [ ] a) Deshabilitar uno de los dos gestos
- [x] b) Usar `if (touchCount == 2)` para pinch y `else if (touchCount == 1)` para rotate
- [ ] c) Usar callbacks en vez de Update()
- [ ] d) Cada gesto requiere un script separado

**Explicación:**  
Esta estructura permite que cada gesto tenga una función específica, evitando que ambas acciones se ejecuten simultáneamente.

---

**2.** Un Canvas con Render Mode "World Space" en AR permite:
- [ ] a) Que la UI siempre esté en la misma posición de la pantalla
- [x] b) Que la UI exista como objeto 3D flotante en el espacio AR
- [ ] c) Que la UI sea transparente
- [ ] d) Optimizar automáticamente el número de draw calls

**Explicación:**  
Esta modalidad integra la interfaz dentro del entorno aumentado, permitiendo que forme parte de la experiencia tridimensional.

---

**3.** `Physics.Raycast` en este contexto (S10) detecta:
- [ ] a) Planos AR detectados por ARCore
- [x] b) Colliders de GameObjects de Unity
- [ ] c) Feature points del SLAM
- [ ] d) La posición de la luz en la escena

**Explicación:**  
Es una herramienta fundamental para reconocer cuándo el usuario interactúa con objetos virtuales presentes en la escena.

---

**4.** `LookAt(Camera.main.transform)` aplicado a un panel UI:
- [ ] a) Hace que el panel se mueva hacia la cámara
- [x] b) Rota el panel para que siempre enfrente a la cámara (billboard)
- [ ] c) Cambia el tamaño del panel según la distancia
- [ ] d) Desactiva el panel cuando la cámara se aleja

**Explicación:**  
Garantiza que la información mostrada permanezca visible y legible desde cualquier posición del usuario.

---

### 3.1 (3 pt) Analiza este fragmento de código e identifica qué hace cada sección:

| Sección | ¿Qué hace? | ¿Cuándo se activa? |
|---------|-----------|------------------|
| A | Calcula la distancia entre dos dedos para realizar escalado (pinch) | Cuando hay exactamente 2 dedos tocando la pantalla |
| B | Rota el objeto utilizando el movimiento horizontal del dedo | Cuando hay 1 dedo moviéndose sobre la pantalla |
| Else-if | Evita que rotación y escalado ocurran al mismo tiempo | Cuando no se cumple la condición de dos dedos |

**Explicación:**  
La lógica organiza las acciones según la cantidad de contactos detectados, permitiendo una interacción más controlada y precisa.

---

### 3.2 (3 pt) Diseña en pseudo-código el sistema de interacción para una app AR de compras donde el usuario puede:
- Colocar un sofá en la sala (tap en plano)
- Escalarlo con pinch
- Rotarlo con dedo
- Ver precio al tocar el sofá

**Explicación:**  
La propuesta integra colocación, manipulación y consulta de información dentro de una misma experiencia de realidad aumentada.

---

### 3.3 (2 pt) ¿Cuál es la diferencia entre Physics.Raycast y ARRaycastManager.Raycast? ¿Cuándo se usa cada uno?

| | Physics.Raycast | ARRaycastManager.Raycast |
|--|----------------|------------------------|
| Detecta | Colliders de objetos Unity | Planos y superficies detectadas por ARCore/ARKit |
| Cuándo usar | Seleccionar o interactuar con objetos existentes | Colocar objetos virtuales sobre superficies reales |

**Explicación:**  
Ambos métodos utilizan rayos, pero están orientados a tareas distintas dentro del flujo de interacción de una aplicación AR.

---

### 4.1 (2 pt) El principio de "affordance" en UX significa que el objeto debe parecer interactivo sin necesidad de instrucciones. Propón 2 formas de aplicar affordance visual en tu app AR de proyecto.

> Mostrar un efecto de resaltado o brillo cuando el usuario apunta a un componente de hardware.
>
> Utilizar iconos o botones visibles sobre los componentes para indicar que pueden tocarse y mostrar información adicional.

**Explicación:**  
Las señales visuales permiten anticipar las acciones disponibles, facilitando el aprendizaje y la exploración de la aplicación.

---

### 4.2 (2 pt) Si tu app AR es para usuarios mayores de 60 años (adultos mayores), ¿qué cambios harías en la interacción? Menciona al menos 3 adaptaciones.

> Utilizar botones más grandes y fáciles de presionar.
>
> Aumentar el tamaño de textos y etiquetas informativas.
>
> Reducir la cantidad de gestos complejos y reemplazarlos por botones simples para rotar o escalar objetos.

**Explicación:**  
El objetivo es simplificar la interacción para que la aplicación resulte cómoda, intuitiva y accesible para este grupo de usuarios.