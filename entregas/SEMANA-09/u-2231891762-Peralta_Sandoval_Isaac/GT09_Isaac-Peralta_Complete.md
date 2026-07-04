# Guía de Trabajo 09 — Diseño de Escenarios 3D
## ⚠️ VERSIÓN ESTUDIANTE

**Estudiante:** _Isaac Josue Peralta Sandoval_  **Código:** _2231891762_
**Fecha:** _06/06/2026_ | **Puntuación total:** ____/20

---

## PARTE I — Opción Múltiple (6 puntos)

**1.** ProBuilder en Unity permite:
- [ ] a) Importar modelos de Blender automáticamente
- [X] b) Crear geometría 3D directamente dentro del editor de Unity
- [ ] c) Generar texturas procedurales para cualquier objeto
- [ ] d) Compilar shaders personalizados para AR

**2.** En iluminación "Baked", la iluminación:
- [ ] a) Se calcula en tiempo real en cada frame
- [X] b) Se precalcula y se guarda en texturas (lightmaps) — cero costo en runtime
- [ ] c) Se descarga desde un servidor en la nube
- [ ] d) Solo funciona con luz ambiental, no con luces direccionales

**3.** "Static Batching" en Unity:
- [ ] a) Combina todos los objetos en una sola malla en tiempo real
- [X] b) Agrupa objetos estáticos con el mismo material en un solo draw call
- [ ] c) Reduce el número de polígonos de los objetos automáticamente
- [ ] d) Solo funciona con objetos instanciados desde Prefabs

**4.** LOD Group significa:
- [ ] a) Layer Of Darkness — control de sombras por capa
- [X] b) Level Of Detail — cambia la complejidad del modelo según distancia
- [ ] c) List Of Draw calls — optimización de renderizado
- [ ] d) Load On Demand — carga objetos cuando son necesarios

**5.** Para AR en celular Android de gama media, ¿cuántos draw calls máximo se recomienda?
- [ ] a) ≤500 draw calls
- [ ] b) ≤250 draw calls
- [X] c) ≤100 draw calls
- [ ] d) No hay límite, el driver los gestiona automáticamente

**6.** Occlusion Culling en Unity:
- [ ] a) Reduce la resolución de texturas en tiempo real
- [X] b) Evita renderizar objetos que están ocultos detrás de otros
- [ ] c) Elimina triángulos duplicados de la malla
- [ ] d) Combina materiales similares en uno solo

---

## PARTE II — Completar (6 puntos)

1. El número de _draw calls_ indica cuántas llamadas de renderizado hace el GPU por frame — debe mantenerse bajo en XR móvil.

2. Para que Static Batching funcione, los objetos deben estar marcados como _Static_ en el Inspector de Unity.

3. El proceso de calcular la iluminación y guardarla en texturas se llama hacer _Bake_ (o "baking de iluminación").

4. GPU Instancing es útil cuando hay muchos objetos _idénticos_ (mismo prefab, mismo material) en la escena.

5. Los **Lightmaps** son texturas que almacenan la _iluminación_ precalculada de la escena estática.

6. En ProBuilder, para crear un pasillo o sala a partir de un cubo, se usa la operación de _Extrude_ de caras.

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
| Draw Calls: 347 |Supera el limite recomendado de 100 para XR o móviles, sobrecargando de calls a la cpu|El cpu pierde tiempo enviando individualemnte las intrucciones a la GPU|
| Tris: 2.1M |Es demasiada 'densidad poligonal' para el hardaware al que se le implementará|Al tener tantos vertices se sobrecarga la GPU, provocando baja tasa de refresco|
| FPS: 12 |Rendimiento inaceptable|Una experiencia mala o de plano injugable|

**3.2** (3 pt) Propón 3 técnicas de optimización específicas para mejorar esta escena. Para cada una, indica cómo la aplicarías.

| Técnica | Cómo aplicarla | Mejora esperada |
|---------|---------------|----------------|
|Static / Dynamic Batching y GPU Instancing|Marcar todos los objetos del entorno que no se mueven como Static. Para objetos repetidos (mismo prefab y material), activar el "Enable GPU Instancing" en su material respectivo.|Reducción masiva de Draw Calls|
|LOD Groups (Level of Detail)|Crear versiones simplificadas (con menos polígonos) de los modelos 3D y configurar el componente LOD Group en Unity para que el motor renderice mallas más livianas a medida que la cámara se aleja.|Disminución drástica de Tris (Triángulos)|
|Occlusion Culling|Hornear (bake) los datos de oclusión a través de la ventana de renderizado (Window > Rendering > Occlusion Culling). Esto desactiva el renderizado de cualquier objeto que se encuentre totalmente tapado por muros u otros elementos grandes.|Optimización de recursos globales|

---

## PARTE IV — Diseño de escenario (3 puntos)

**4.1** (3 pt) Para el escenario de tu proyecto grupal, completa:

| Elemento | ¿Estático o dinámico? | Técnica de optimización | Material (descripción) |
|---------|----------------------|------------------------|----------------------|
|Paredes y Suelo del Entorno (Mallas de ProBuilder)|Estático|Static Batching y Baked Lightmaps para precalcular sombras sin costo de procesamiento.|Material opaco estándar utilizando texturas optimizadas (máx. 1024x1024) y shaders de bajo costo (ej. URP Lit simplificado).|
|Columnas / Barriles de Decoración (Elementos repetidos)|Estático|GPU Instancing y Occlusion Culling para no renderizarlos si quedan detrás de los muros.|Un único material compartido entre todas las instancias para reducir drásticamente los draw calls.|
|Personaje Principal / Enemigos|Dinámico|LOD Group (Nivel de detalle) para simplificar sus polígonos cuando se alejan de la cámara.|Material dinámico optimizado con texturas empaquetadas (PBR simplificado) que responda a la luz ambiental en tiempo real.|
|Elementos Interactivos (Llaves, palancas o coleccionables)|Dinámico|Dynamic Batching (si son de pocos polígonos) y desactivación de scripts de lógica lejanos.|Material sencillo con shader sin físicas complejas, tal vez un canal emission bajo si requiere llamar la atención.|

*PSISP08075 | Universidad Autónoma del Perú | 2026-1*
