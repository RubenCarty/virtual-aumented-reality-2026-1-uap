# Guía de Trabajo 09 — Diseño de Escenarios 3D
## ⚠️ VERSIÓN ESTUDIANTE

**Estudiante:** Leonardo Rau Bravo  **Código:** 2191898620
**Fecha:** 14/06/2026 | **Puntuación total:** 20/20

---

## PARTE I — Opción Múltiple (6 puntos)

**1.** ProBuilder en Unity permite:
- [ ] a) Importar modelos de Blender automáticamente
- [x] b) Crear geometría 3D directamente dentro del editor de Unity
- [ ] c) Generar texturas procedurales para cualquier objeto
- [ ] d) Compilar shaders personalizados para AR

**Justificación:**
- ProBuilder es una herramienta de Unity que permite crear y editar objetos 3D directamente dentro del editor, sin necesidad de modelarlos previamente en programas externos como Blender. Esto facilita la construcción rápida de escenarios, prototipos y elementos básicos durante el desarrollo del proyecto.

**2.** En iluminación "Baked", la iluminación:
- [ ] a) Se calcula en tiempo real en cada frame
- [x] b) Se precalcula y se guarda en texturas (lightmaps) — cero costo en runtime
- [ ] c) Se descarga desde un servidor en la nube
- [ ] d) Solo funciona con luz ambiental, no con luces direccionales

**Justificación:**
- Porque en la iluminación Baked los cálculos de luz se realizan previamente y el resultado se almacena en lightmaps. De esta manera, durante la ejecución de la aplicación no es necesario recalcular la iluminación, lo que mejora el rendimiento y reduce el consumo de recursos, algo especialmente útil en aplicaciones móviles y de realidad aumentada.

**3.** "Static Batching" en Unity:
- [ ] a) Combina todos los objetos en una sola malla en tiempo real
- [x] b) Agrupa objetos estáticos con el mismo material en un solo draw call
- [ ] c) Reduce el número de polígonos de los objetos automáticamente
- [ ] d) Solo funciona con objetos instanciados desde Prefabs

**Justificación:**
- Static Batching agrupa objetos marcados como estáticos que comparten el mismo material para que puedan renderizarse con menos draw calls. Esto ayuda a optimizar el rendimiento de la aplicación al reducir el trabajo que realiza la CPU durante el proceso de renderizado.

**4.** LOD Group significa:
- [ ] a) Layer Of Darkness — control de sombras por capa
- [x] b) Level Of Detail — cambia la complejidad del modelo según distancia
- [ ] c) List Of Draw calls — optimización de renderizado
- [ ] d) Load On Demand — carga objetos cuando son necesarios

**Justificación:**
- Level Of Detail permite utilizar diferentes versiones de un mismo modelo con distintos niveles de complejidad. A medida que el objeto se aleja de la cámara, Unity muestra modelos con menos polígonos, lo que ayuda a mejorar el rendimiento sin afectar significativamente la calidad visual de la escena.

**5.** Para AR en celular Android de gama media, ¿cuántos draw calls máximo se recomienda?
- [ ] a) ≤500 draw calls
- [ ] b) ≤250 draw calls
- [x] c) ≤100 draw calls
- [ ] d) No hay límite, el driver los gestiona automáticamente

**Justificación:**
- Porque en dispositivos Android de gama media, se recomienda mantener los draw calls por debajo de 100 para asegurar un rendimiento fluido. Reducir la cantidad de llamadas de renderizado disminuye la carga de trabajo de la CPU y ayuda a que las aplicaciones de realidad aumentada funcionen de manera más estable y con una mejor tasa de fotogramas.

**6.** Occlusion Culling en Unity:
- [ ] a) Reduce la resolución de texturas en tiempo real
- [x] b) Evita renderizar objetos que están ocultos detrás de otros
- [ ] c) Elimina triángulos duplicados de la malla
- [ ] d) Combina materiales similares en uno solo

**Justificación:**
- Occlusion Culling evita que Unity renderice objetos que no son visibles para la cámara debido a que están bloqueados por otros elementos de la escena. Esto permite ahorrar recursos de procesamiento y mejorar el rendimiento, especialmente en escenas complejas con muchos objetos.

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
|Modelos 3D del museo (objetos históricos)|Dinámico|Reducir polígonos y comprimir texturas|Material Standard/URP Lit con textura simple y pocos detalles para mejorar el rendimiento en móviles.|
|Paneles de título (UI)|Estático|Uso de un solo Canvas por ImageTarget y reutilización de sprites|Material UI por defecto con imágenes PNG optimizadas y fondo transparente.|
|Botones de audio descriptivo|Dinámico|Compresión de archivos de audio y desactivación cuando no se usan|Material UI por defecto, utilizando iconos ligeros en formato PNG.|
|Menú principal y panel "¿Deseas salir?"|Estático|Agrupar elementos UI y optimizar imágenes del menú|Material UI con sprites comprimidos para mantener bajo el consumo de memoria.|

*PSISP08075 | Universidad Autónoma del Perú | 2026-1*
