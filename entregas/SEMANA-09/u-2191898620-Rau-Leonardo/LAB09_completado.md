# Laboratorio 09 — Escenario 3D Optimizado con ProBuilder
## ⚠️ VERSIÓN ESTUDIANTE

**Tiempo estimado:** 100 minutos

---

## Objetivo

Construir un aula universitaria 3D con ProBuilder, aplicar iluminación baked y optimizar para AR móvil.

---

## PASO 1 — Instalar ProBuilder (5 min)

`Window → Package Manager → Unity Registry → ProBuilder → Install`

Verificar: `Tools → ProBuilder → ProBuilder Window` debe abrirse.

---

## PASO 2 — Crear la estructura del aula (30 min)

### Suelo
1. `Tools → ProBuilder → New Shape` → Plane
2. Escala: 10x10 metros

### Paredes (4 paredes)
1. `New Shape → Cube` → dimensiones: 10 largo × 3 alto × 0.2 espesor
2. Copiar y rotar para las 4 paredes
3. Crear hueco para puerta: seleccionar cara → Extrude hacia adentro

### Techo
1. `New Shape → Plane` → posición en Y=3

### Mobiliario (ProBuilder)
- 6 mesas: Cube → 1.2 × 0.05 × 0.6m, posicionar en filas
- 12 sillas: Cube + extrude para respaldo

---

## PASO 3 — Aplicar materiales (15 min)

1. Crear materiales:
   - `MatSuelo`: textura de piso (Albedo: beige), Enable GPU Instancing ✅
   - `MatPared`: blanco liso, Enable GPU Instancing ✅
   - `MatMesa`: madera marrón, Enable GPU Instancing ✅
2. Aplicar usando ProBuilder Face Mode (seleccionar caras específicas)

---

## PASO 4 — Iluminación baked (15 min)

1. Seleccionar Directional Light → Mode: **Baked**
2. Agregar Point Light en el techo (para simular luz interior) → Mode: Baked
3. Marcar todos los objetos estáticos como **Static** ✅
4. `Window → Rendering → Lighting → Generate Lighting`
5. Esperar el baking (puede tomar 1-5 minutos)

---

## PASO 5 — Occlusion Culling (10 min)

1. Asegurarse que los objetos estáticos tienen Static ✅ → Occluder Static ✅
2. `Window → Rendering → Occlusion Culling → Bake`
3. Esperar el baking

---

## PASO 6 — Verificar rendimiento (10 min)

Game View → Stats button:
- Anotar Draw Calls: __41__
- Anotar Tris: __4.9k__
- Anotar FPS: __184.2__

Objetivo: Draw Calls < 50, Tris < 50,000, FPS > 30

Si Draw Calls > 50: revisar que los objetos con mismo material tengan Static ✅

---

## Evidencias

```
□ 1. Captura del Scene View con el aula completa (suelo, paredes, mobiliario)
□ 2. Captura del Lighting Window después del baking
□ 3. Captura de Stats: Draw Calls, Tris, FPS
□ 4. Captura de un material con Enable GPU Instancing activado
□ 5. Video de la escena en Game View moviéndose por el aula
□ 6. Link al commit de GitHub
```

---

## Reto extra (opcional +2 pts)

Agregar un LOD Group a las sillas: LOD 0 = modelo completo, LOD 1 = caja simple, LOD 2 = nada (culled). Captura mostrando el LOD Group funcionando (esferas de LOD en Scene View).

*PSISP08075 | Universidad Autónoma del Perú | 2026-1*
