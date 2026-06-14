# Guía de Trabajo 09 — Diseño de Escenarios 3D
## ⚠️ VERSIÓN ESTUDIANTE

**Estudiante:** Gianfranco Eduardo Levano Villanueva  **Código:**  2221898772
**Fecha:** 06/06/2026 | **Puntuación total:** ____/20

---

## PARTE I — Opción Múltiple (6 puntos)

**1.** ProBuilder en Unity permite:
- [ ] a) Importar modelos de Blender automáticamente
- [x] b) Crear geometría 3D directamente dentro del editor de Unity
- [ ] c) Generar texturas procedurales para cualquier objeto
- [ ] d) Compilar shaders personalizados para AR

**2.** En iluminación "Baked", la iluminación:
- [ ] a) Se calcula en tiempo real en cada frame
- [x] b) Se precalcula y se guarda en texturas (lightmaps) — cero costo en runtime
- [ ] c) Se descarga desde un servidor en la nube
- [ ] d) Solo funciona con luz ambiental, no con luces direccionales

**3.** "Static Batching" en Unity:
- [ ] a) Combina todos los objetos en una sola malla en tiempo real
- [x] b) Agrupa objetos estáticos con el mismo material en un solo draw call
- [ ] c) Reduce el número de polígonos de los objetos automáticamente
- [ ] d) Solo funciona con objetos instanciados desde Prefabs

**4.** LOD Group significa:
- [ ] a) Layer Of Darkness — control de sombras por capa
- [x] b) Level Of Detail — cambia la complejidad del modelo según distancia
- [ ] c) List Of Draw calls — optimización de renderizado
- [ ] d) Load On Demand — carga objetos cuando son necesarios
Justificación:
**5.** Para AR en celular Android de gama media, ¿cuántos draw calls máximo se recomienda?
- [ ] a) ≤500 draw calls
- [ ] b) ≤250 draw calls
- [x] c) ≤100 draw calls
- [ ] d) No hay límite, el driver los gestiona automáticamente

**6.** Occlusion Culling en Unity:
- [ ] a) Reduce la resolución de texturas en tiempo real
- [x] b) Evita renderizar objetos que están ocultos detrás de otros
- [ ] c) Elimina triángulos duplicados de la malla
- [ ] d) Combina materiales similares en uno solo

---

## PARTE II — Completar (6 puntos)

1. El número de **draw call** indica cuántas llamadas de renderizado hace el GPU por frame — debe mantenerse bajo en XR móvil.

2. Para que Static Batching funcione, los objetos deben estar marcados como __static__ en el Inspector de Unity.

3. El proceso de calcular la iluminación y guardarla en texturas se llama hacer __baking__ (lightmap baking/generate lighting)(o "baking de iluminación").

4. GPU Instancing es útil cuando hay muchos objetos __idénticos__ (mismo prefab, mismo material) en la escena.

5. Los **Lightmaps** son texturas que almacenan la __iluminación__ precalculada de la escena estática.

6. En ProBuilder, para crear un pasillo o sala a partir de un cubo, se usa la operación de __extrude (extrusion)__ de caras.

---

## PARTE III — Análisis de escena (5 puntos)

Un estudiante reporta estos valores en la ventana **Stats** de Unity:

```
Draw Calls: 347
Tris: 2.1M
Verts: 1.8M
FPS (Game View): 12
```

**3.1** (2 pt) Identifica los 3 problemas principales de rendimiento basándote en los valores.

| Valor | Problema | Impacto |
|-------|---------|---------|
| Draw Calls: 347 |Excede limite movil (=<100)materiales sin batching | GPU sobrecargado -->bajo FPS|
| Tris: 2.1M |Demasiada geometría para dispositivo móvil | Vértices saturan pipeline gráfico|
| FPS: 12 |No apto para  AR/VR (mínimo 30 para AR, 60 para VR)|Experiencia inutilizable, posible mareo |

**3.2** (3 pt) Propón 3 técnicas de optimización específicas para mejorar esta escena. Para cada una, indica cómo la aplicarías.

| Técnica | Cómo aplicarla | Mejora esperada |
|---------|---------------|----------------|
|Static batching| Marcar objetos estáticos como Static, asegurarse que compartan material|Draw call de 347 a ~50-80 |
|LOD Groups | Para objetos lejanos usar modelos con menos triangulos|tris de 2.1M a ~200-400K |
|Baked Lighting |Configurar luces como Baked, Generate lighting | Eliminación de calculo de sombras en runtime|

---

## PARTE IV — Diseño de escenario (3 puntos)

**4.1** (3 pt) Para el escenario de tu proyecto grupal, completa:

| Elemento | ¿Estático o dinámico? | Técnica de optimización | Material (descripción) |
|---------|----------------------|------------------------|----------------------|
|Mesas y mobiliario del laboratorio |Estático |Static Batching y Occlusion Culling |Material de madera y metal con texturas PBR de baja resolución optimizada. |
|Paredes, piso y techo del laboratorio |Estático |Light Baking y Occlusion Culling |Materiales de concreto, cerámica y pintura con iluminación precalculada |
|Frascos químicos interactivos |Dinámico |Prefabs reutilizables y Collider simplificado |Material de vidrio transparente con shader de reflexión y contenido químico coloreado. |
|Tabla periódica interactiva |Dinámico |UI Canvas optimizado y carga bajo demanda de información |Panel digital con materiales emisivos y elementos gráficos interactivos. |
|Personaje jugador |Dinámico |LOD y optimización de físicas |Modelo 3D controlado por teclado y mouse con componentes de movimiento y cámara. |

*PSISP08075 | Universidad Autónoma del Perú | 2026-1*
