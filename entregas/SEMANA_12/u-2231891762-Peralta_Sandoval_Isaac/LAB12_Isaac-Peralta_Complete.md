# Laboratorio 12 — Dashboard AR con Datos de API
## ⚠️ VERSIÓN ESTUDIANTE

**Tiempo estimado:** 100 minutos

---

## Objetivo

Crear una app AR donde al detectar un marcador, aparece un dashboard con datos en tiempo real de una API REST.

---

## PASO 1 — Crear mock API local (15 min)

Instalar Node.js si no lo tienes: https://nodejs.org

```bash
# En la terminal:
npm install -g json-server

# Crear archivo db.json en el Desktop:
```

Crear archivo `db.json`:
```json
{
  "sensores": [
    {"id": 1, "nombre": "Motor Principal", "temperatura": 72.5, "humedad": 30, "estado": "normal"},
    {"id": 2, "nombre": "Compresor A", "temperatura": 88.1, "humedad": 25, "estado": "alerta"},
    {"id": 3, "nombre": "Enfriador B", "temperatura": 45.0, "humedad": 60, "estado": "normal"}
  ]
}
```

```bash
json-server --watch db.json --port 3000
# Verificar: http://localhost:3000/sensores debe retornar el JSON
```

---

## PASO 2 — Clases de datos en Unity (10 min)

`Assets/Scripts/Data/SensorData.cs`:

```csharp
using System;

[Serializable]
public class SensorData
{
    public int id;
    public string nombre;
    public float temperatura;
    public float humedad;
    public string estado;
}

[Serializable]
public class SensorResponse
{
    public SensorData[] items;
}
```

---

## PASO 3 — Script SensorARManager.cs (35 min)

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SensorARManager : MonoBehaviour
{
    [Header("UI Referencias")]
    public TextMeshPro textoNombre;
    public TextMeshPro textoTemp;
    public TextMeshPro textoHumedad;
    public TextMeshPro textoEstado;

    [Header("Configuración")]
    public int sensorId = 1;
    public float intervaloActualizacion = 10f;

    private string baseUrl = "http://localhost:3000/sensores/";

    void OnEnable()
    {
        StartCoroutine(ActualizarPeriodicamente());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator ActualizarPeriodicamente()
    {
        while (true)
        {
            yield return StartCoroutine(ObtenerSensor());
            yield return new WaitForSeconds(intervaloActualizacion);
        }
    }

    IEnumerator ObtenerSensor()
    {
        using (var req = UnityWebRequest.Get(baseUrl + sensorId))
        {
            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
                var sensor = JsonUtility.FromJson<SensorData>(req.downloadHandler.text);
                ActualizarUI(sensor);
            }
            else
            {
                textoEstado.text = "Sin conexión";
                textoEstado.color = Color.yellow;
            }
        }
    }

    void ActualizarUI(SensorData sensor)
    {
        textoNombre.text   = sensor.nombre;
        textoTemp.text     = $"Temp: {sensor.temperatura:F1}°C";
        textoHumedad.text  = $"Humedad: {sensor.humedad:F0}%";
        textoEstado.text   = sensor.estado.ToUpper();

        bool esAlerta = sensor.estado == "alerta" || sensor.temperatura > 85f;
        textoEstado.color = esAlerta ? Color.red : Color.green;
        textoTemp.color   = sensor.temperatura > 85f ? Color.red : Color.white;
    }
}
```

---

## PASO 4 — Crear panel AR (20 min)

1. Crear Canvas World Space con el dashboard:
   - Nombre del sensor (TextMeshPro grande)
   - Temperatura (con unidad °C)
   - Humedad (con unidad %)
   - Estado (verde/rojo)
2. Asignar campos al script SensorARManager
3. Colocar como hijo del ImageTarget con `sensorId` correspondiente

---

## Evidencias

```
□ 1. Captura de la terminal con json-server corriendo
□ 2. Captura del script SensorARManager en Inspector
□ 3. Captura del panel AR con datos (en Game View)
□ 4. Video: marcador detectado → dashboard aparece con datos reales → datos cambian al actualizar
□ 5. Captura mostrando temperatura en rojo cuando es >85°C
□ 6. Link al commit de GitHub
```

*PSISP08075 | Universidad Autónoma del Perú | 2026-1*
