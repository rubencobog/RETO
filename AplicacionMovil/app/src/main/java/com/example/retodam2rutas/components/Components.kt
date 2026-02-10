package com.example.retodam2rutas.components

import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.PaddingValues
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.foundation.verticalScroll
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Add
import androidx.compose.material.icons.filled.Clear
import androidx.compose.material.icons.filled.KeyboardArrowDown
import androidx.compose.material.icons.filled.KeyboardArrowUp
import androidx.compose.material.icons.filled.LocationOn
import androidx.compose.material3.AlertDialog
import androidx.compose.material3.Button
import androidx.compose.material3.CardColors
import androidx.compose.material3.CardDefaults
import androidx.compose.material3.Checkbox
import androidx.compose.material3.DropdownMenu
import androidx.compose.material3.DropdownMenuItem
import androidx.compose.material3.ElevatedCard
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.ExposedDropdownMenuBox
import androidx.compose.material3.ExposedDropdownMenuDefaults
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.OutlinedButton
import androidx.compose.material3.Text
import androidx.compose.material3.TextButton
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.runtime.DisposableEffect
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.viewinterop.AndroidView
import androidx.compose.ui.window.Dialog
import androidx.core.content.ContextCompat
import androidx.navigation.NavController
import com.bumptech.glide.integration.compose.ExperimentalGlideComposeApi
import com.bumptech.glide.integration.compose.GlideImage
import com.example.retodam2rutas.R
import com.example.retodam2rutas.entities.CLASIFICACION
import com.example.retodam2rutas.entities.PuntoRuta
import com.example.retodam2rutas.views.LoginViewModel
import com.example.retodam2rutas.entities.Ruta
import com.example.retodam2rutas.entities.maptemp.RutaTemporal
import com.example.retodam2rutas.entities.maptemp.TrackPoint
import com.example.retodam2rutas.model.UsuarioModel
import com.example.retodam2rutas.views.MapViewModel
import com.example.retodam2rutas.views.RutaViewModel
import org.osmdroid.events.MapEventsReceiver
import org.osmdroid.util.GeoPoint
import org.osmdroid.views.MapView
import org.osmdroid.views.overlay.MapEventsOverlay
import org.osmdroid.views.overlay.Marker
import org.osmdroid.views.overlay.Polyline
import java.io.File


//================ Contenido de la ventana home =================
@Composable
fun ContentHomeView(
    innerPadding: PaddingValues,
    navController: NavController,
    rutaViewModel: RutaViewModel) {
    LazyColumn (
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize()
            .background(Color(0xFFD2E6F6)),
        verticalArrangement = Arrangement.spacedBy(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        item {
            Text(
                text = "CATALOGO DE RUTAS",
                fontWeight = FontWeight.Bold,
                textAlign = TextAlign.Center,
                modifier = Modifier.fillMaxWidth(),
                color = Color.Black
            )
        }
        items(rutaViewModel.rutas){
            ruta ->
            RutaCard(ruta, navController)
        }
    }
}

//================ Contenido de la ventana detail =================
@Composable
fun ContentDetailView(
    innerPadding: PaddingValues,
    navController: NavController,
    id: Int,
    rutaViewModel: RutaViewModel) {

    rutaViewModel.cargarRuta(id)
    var ruta = rutaViewModel.rutaSeleccionada

    LazyColumn (
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize()
            .background(Color(0xFFD2E6F6)),
        verticalArrangement = Arrangement.spacedBy(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        item {
            Text(
                text = "Ruta",
                fontWeight = FontWeight.Bold,
                textAlign = TextAlign.Center,
                modifier = Modifier.fillMaxWidth(),
                color = Color.Black
            )
        }
        item {
            Button(
                onClick = { navController.navigate("Mapa/${ruta?.id}") }
            ) {
                Text("Iniciar ruta")
            }
        }
    }
}

//================ Contenido de la ventana GPS existente =================
@Composable
fun ContentDoView(
    innerPadding: PaddingValues,
    navController: NavController,
    id: Int,
    rutaViewModel: RutaViewModel,
    mapViewModel: MapViewModel
) {

    rutaViewModel.cargarRuta(id)
    val ruta = rutaViewModel.rutaSeleccionada
    val puntos = ruta?.let { mapViewModel.guardarPuntos(it) }

    val context = LocalContext.current
    val geoPoint = mapViewModel.lastGeoPoint

    val mapView = remember {
        MapView(context).apply {
            setMultiTouchControls(true)
            controller.setZoom(18.0)
        }
    }

    Column (
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize()
            .background(Color(0xFFD2E6F6)),
        verticalArrangement = Arrangement.spacedBy(26.dp),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {

        DisposableEffect(Unit) {
            mapView.onResume()
            onDispose {
                mapView.onPause()
            }
        }

        AndroidView(
            modifier = Modifier
                .fillMaxWidth()
                .height(300.dp),
            factory = { mapView },
            update = {
                geoPoint?.let {
                    val marker = Marker(mapView).apply {
                        position = it
                        setAnchor(Marker.ANCHOR_CENTER, Marker.ANCHOR_BOTTOM)
                        title = "Mi ubicación"
                    }
                    mostrarRuta(mapView,puntos)
                    mapView.overlays.clear()
                    mapView.overlays.add(marker)
                    mapView.controller.setCenter(it)

                    mapViewModel.puntosMapa.forEach { punto ->
                        val marker = mapViewModel.crearMarker(mapView, punto, context)
                        mapView.overlays.add(marker)
                    }

                    mapView.invalidate()
                }
            }
        )

        Row (
            modifier = Modifier
                .background(Color(0xFFD2E6F6))
                .fillMaxSize()
                .padding(innerPadding),
            verticalAlignment = Alignment.Bottom,
            horizontalArrangement = Arrangement.SpaceEvenly
        ){
            ButtonRuta(
                label = "Start",
                icon = R.drawable.play_circle,
                color = Color(0xCD4EC77D),
                onClick = {
                    if (geoPoint != null) {
                        mapViewModel.iniciarRuta("Ruta1",geoPoint)
                    }
                }
            )
            ButtonRuta(
                label = "Stop",
                icon = R.drawable.stop_circle,
                color = Color(0xCDC74E4E),
                onClick = {
                    if (geoPoint != null) {
                        mapViewModel.terminarRuta(geoPoint)
                    }
                }
            )
        }
    }
}

fun mostrarRuta(mapView: MapView, trackPoints: List<PuntoRuta?>?) {
    val polyline = Polyline().apply {
        width = 5f
        color = android.graphics.Color.BLUE
        if (trackPoints != null) {
            setPoints(trackPoints.map { it?.let { it1 -> GeoPoint(it1.latitud, it.longitud) } })
        }
    }
    mapView.overlays.clear()
    mapView.overlays.add(polyline)
    if (trackPoints != null) {
        if (trackPoints.isNotEmpty()) {
            mapView.controller.setCenter(trackPoints.first()
                        ?.let { GeoPoint(trackPoints.first()!!.latitud, it.longitud) })
        }
    }
    mapView.invalidate()
}


//================ Contenido de la ventana GPS añadir =================
@Composable
fun ContentAddView(
    innerPadding: PaddingValues,
    navController: NavController,
    id: Int,
    rutaViewModel: RutaViewModel,
    mapViewModel: MapViewModel
) {

    val ruta = mapViewModel.rutaEnCreacion

    val context = LocalContext.current
    val geoPoint = mapViewModel.lastGeoPoint

    var mostrarSelectorTipo by remember { mutableStateOf(false) }
    var mostrarDialogPI by remember { mutableStateOf(false) }
    var mostrarDialogPeligro by remember { mutableStateOf(false) }
    var puntoSeleccionado by remember { mutableStateOf<GeoPoint?>(null) }
    var mostrarDialogGuardar by remember { mutableStateOf(false) }

    val mapEventsOverlay = remember {
        MapEventsOverlay(object : MapEventsReceiver {
            override fun singleTapConfirmedHelper(p: GeoPoint?): Boolean {
                return false
            }
            override fun longPressHelper(p: GeoPoint?): Boolean {
                p?.let {
                    puntoSeleccionado = it
                    mostrarSelectorTipo = true
                }
                return true
            }
        })
    }
    val mapView = remember {
        MapView(context).apply {
            setMultiTouchControls(true)
            controller.setZoom(18.0)
        }
    }
    var userMarker by remember { mutableStateOf<Marker?>(null) }
    var grabar by remember { mutableStateOf(false) }

    //Cadena de if's para mostrar dialogos de puntos de interes y de peligro
    if (mostrarSelectorTipo) {
        AlertDialog(
            onDismissRequest = { mostrarSelectorTipo = false },
            title = { Text("¿Qué quieres marcar?") },
            confirmButton = {
                TextButton(onClick = {
                    mostrarSelectorTipo = false
                    mostrarDialogPI = true
                }) {
                    Text("Punto de interés")
                }
            },
            dismissButton = {
                TextButton(onClick = {
                    mostrarSelectorTipo = false
                    mostrarDialogPeligro = true
                }) {
                    Text("Punto de peligro")
                }
            }
        )
    }
    if (mostrarDialogPI && puntoSeleccionado != null) {
        var nombre by remember { mutableStateOf("") }
        var descripcion by remember { mutableStateOf("") }

        AlertDialog(
            onDismissRequest = { mostrarDialogPI = false },
            title = { Text("Nuevo punto de interés") },
            text = {
                Column {
                    TextField(nombre, { nombre = it }, label = { Text("Nombre") })
                    TextField(descripcion, { descripcion = it }, label = { Text("Descripción") })
                }
            },
            confirmButton = {
                TextButton(onClick = {
                    mapViewModel.guardarPuntoInteres(
                        geoPoint = puntoSeleccionado!!,
                        nombre = nombre,
                        descripcion = descripcion,
                        rutaid = 0
                    )
                    mostrarDialogPI = false
                }) {
                    Text("Guardar")
                }
            }
        )
    }

    if (mostrarDialogPeligro && puntoSeleccionado != null) {

        var kilometro by remember { mutableStateOf(0.0) }
        var gravedad by remember { mutableStateOf<Byte>(1) }
        var justificacion by remember { mutableStateOf("") }

        AlertDialog(
            onDismissRequest = { mostrarDialogPeligro = false },
            title = { Text("Nuevo punto de peligro") },
            text = {
                Column(verticalArrangement = Arrangement.spacedBy(12.dp)) {

                    SelectorKilometro(
                        kilometro = kilometro,
                        onKilometroChange = { kilometro = it }
                    )

                    SelectorGravedad(
                        gravedad = gravedad,
                        onGravedadChange = { gravedad = it }
                    )

                    TextField(
                        value = justificacion,
                        onValueChange = { justificacion = it },
                        label = { Text("Justificación") }
                    )
                }
            },
            confirmButton = {
                TextButton(onClick = {
                    mapViewModel.guardarPuntoPeligro(
                        geoPoint = puntoSeleccionado!!,
                        kilometro = kilometro,
                        gravedad = gravedad,
                        justificacion = justificacion,
                        rutaid = 0
                    )
                    mostrarDialogPeligro = false
                }) {
                    Text("Guardar")
                }
            }
        )
    }


    Column (
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize()
            .background(Color(0xFFD2E6F6)),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {

        DisposableEffect(Unit) {
            mapView.onResume()
            onDispose {
                mapView.onPause()
            }
        }

        AndroidView(
            modifier = Modifier
                .fillMaxWidth()
                .weight(2f),
            factory = { mapView },
            update = {
                geoPoint?.let {
                    if (userMarker == null) {
                        userMarker = Marker(mapView).apply {
                            setAnchor(Marker.ANCHOR_CENTER, Marker.ANCHOR_BOTTOM)
                            title = "Mi ubicación"
                        }
                        mapView.overlays.add(userMarker)
                    }
                    if (grabar) {
                        mapViewModel.actualizarRuta(it)
                    }
                    mapView.overlays.add(mapEventsOverlay)
                    userMarker!!.position = it
                    //mapView.overlays.clear() // Esto limpia el mapa de marcadores
                    mapView.controller.setCenter(it)

                    mapViewModel.puntosMapa.forEach { punto ->
                        if (!mapViewModel.markersMapa.containsKey(punto.id)) {
                            val marker = mapViewModel.crearMarker(mapView, punto, context)
                            mapViewModel.markersMapa[punto.id] = marker
                            mapView.overlays.add(marker)
                        }
                    }

                    mapView.invalidate()
                }
                ruta.let {
                    if (it != null) {
                        actualizarLineaMapa(mapView,it)
                    }
                }
            }
        )
        Row (
            modifier = Modifier
                .background(Color(0xFFD2E6F6))
                .fillMaxWidth()
                .weight(1f)
                .padding(innerPadding),
            verticalAlignment = Alignment.Bottom,
            horizontalArrangement = Arrangement.SpaceEvenly
        ){
            ButtonRuta(
                label = "Start",
                icon = R.drawable.play_circle,
                color = Color(0xCD4EC77D),
                onClick = {
                    if (geoPoint != null) {
                        mapViewModel.iniciarRuta("Ruta1",geoPoint)
                    }
                    grabar = true
                }
            )
            ButtonRuta(
                label = "Stop",
                icon = R.drawable.stop_circle,
                color = Color(0xCDC74E4E),
                onClick = {
                    if (geoPoint != null) {
                        mapViewModel.terminarRuta(geoPoint)
                        }
                    grabar = false
                }
            )
            Spacer(modifier = Modifier.width(10.dp))
            ButtonRuta(
                label = "Gpx",
                icon = R.drawable.outline_save,
                color = Color(0xCD4E6CC7),
                onClick = {
                    if(!grabar){
                        mostrarDialogGuardar = true
                    }
                }
            )
            if (mostrarDialogGuardar && ruta != null) {
                DialogGuardarRuta(
                    onDismiss = { mostrarDialogGuardar = false },
                    onGuardar = {
                            nombre,
                            clasificacion,
                            esfuerzo,
                            riesgo,
                            tipoTerreno,
                            indicaciones,
                            temporadas,
                            accesible,
                            familiar,
                            recomendaciones,
                            zona ->

                        mapViewModel.guardarRuta(
                            rutaTemporal = ruta,
                            usuarioId = id,
                            context = context,
                            nombre = nombre,
                            clasificacion = clasificacion,
                            nivelEsfuerzo = esfuerzo,
                            nivelRiesgo = riesgo,
                            tipoTerreno = tipoTerreno,
                            indicaciones = indicaciones,
                            temporadas = temporadas,
                            accesibilidad = accesible,
                            rutaFamiliar = familiar,
                            recomendaciones = recomendaciones,
                            zonaGeografica = zona
                        )

                        mostrarDialogGuardar = false
                    },
                    mapView = mapView
                )
            }

        }
    }
}

fun actualizarLineaMapa(mapView: MapView, ruta: RutaTemporal) {
    mapView.overlays.removeAll { it is Polyline }

    val polyline = Polyline().apply {
        width = 5f
        color = android.graphics.Color.RED
        setPoints(ruta.trackPoints.map { GeoPoint(it.latitude, it.longitude) })
    }

    mapView.overlays.add(polyline)
    mapView.invalidate()
}

//================ Card de Rutas =================
@OptIn(ExperimentalGlideComposeApi::class)
@Composable
fun RutaCard(ruta: Ruta, navController: NavController) {
    ElevatedCard(
        elevation = CardDefaults.cardElevation(
            defaultElevation = 6.dp
        ),
        modifier = Modifier
            .fillMaxWidth()
            .padding(8.dp)
            .clickable { navController.navigate("Detail/${ruta.id}") },
        colors = CardColors(
            containerColor = Color.Black,
            contentColor = Color.White,
            disabledContainerColor = Color.Gray,
            disabledContentColor = Color.White
        ),
        shape = CardDefaults.shape,
    ) {
        Row(
            modifier = Modifier
                .fillMaxWidth()
                .padding(12.dp),
            verticalAlignment = Alignment.CenterVertically
        ) {
            GlideImage(
                model = Icons.Default.LocationOn,
                contentDescription = "descripcion ruta",
                modifier = Modifier
                    .size(80.dp)
                    .clip(CircleShape)
                    .background(Color.LightGray)
            )

            Spacer(modifier = Modifier.width(16.dp))

            Column(
                modifier = Modifier.weight(1f)
            ) {
                Text(
                    text = ruta.nombre,
                    style = MaterialTheme.typography.titleMedium
                )
                Text(
                    text = "Distancia: ${ruta.distancia}m",
                    style = MaterialTheme.typography.bodyMedium
                )
                Text(
                    text = "Dificultad: ${ruta.nivelEsfuerzo}m",
                    style = MaterialTheme.typography.bodyMedium
                )
                Text(
                    text = "Valoracion: ${ruta.mediaEstrellas}m",
                    style = MaterialTheme.typography.bodyMedium
                )
            }
        }
    }
}

//================ Contenido de la ventana Login =================
@Composable
fun ContentLoginView(
    innerPadding: PaddingValues,
    navController: NavController,
    loginViewModel: LoginViewModel
) {
    val usuario: UsuarioModel? by loginViewModel.usuario.observeAsState()
    var email by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }
    var showDialog by remember { mutableStateOf(false) }
    Column(
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize(),
        horizontalAlignment = Alignment.CenterHorizontally,
        verticalArrangement = Arrangement.Center
    ) {
        Row(modifier = Modifier.padding(innerPadding)) {
          Column() {
              Text("Iniciar sesión")

              Spacer(modifier = Modifier.padding(10.dp))

              TextField(
                  value = email,
                  onValueChange = { email = it },
                  label = { Text("Usuario") },
                  singleLine = true
              )

              Spacer(modifier = Modifier.padding(10.dp))

              TextField(
                  value = password,
                  onValueChange = { password = it },
                  label = { Text("Contraseña") },
                  singleLine = true,
                  visualTransformation = PasswordVisualTransformation()
              )

              Spacer(modifier = Modifier.padding(4.dp))

              Button(onClick = {
                  loginViewModel.getLoginUsuario(email, password)

                  if(usuario != null){
                      navController.navigate("Home")
                  }else{
                      showDialog = true
                  }

              }) {
                  Text("Entrar")
              }
          }
        }

        if (showDialog) {
            AlertDialog(
                onDismissRequest = { showDialog = false },
                title = { Text("Error al Iniciar sesión") },
                text = { Text("No se ha encontrado al usuario. Inténtalo otra vez") },
                confirmButton = {
                    TextButton(onClick = { showDialog = false }) {
                        Text("OK")
                    }
                }
            )
        }

        Row(verticalAlignment = Alignment.Bottom, horizontalArrangement = Arrangement.End){
            Button(onClick = {
                loginViewModel.setUsuarioInvitado()
                navController.navigate("Home")
            }) {
                Text("Entrar como usuario invitado") }
        }



    }
}

//================ Dialog de informacion =================
@Composable
fun DialogoInformativo(
    titulo: String,
    mensaje: String,
    onCerrar: () -> Unit
) {
    AlertDialog(
        onDismissRequest = onCerrar,
        title = { Text(titulo) },
        text = { Text(mensaje) },
        confirmButton = {
            TextButton(onClick = onCerrar) {
                Text("Aceptar")
            }
        }
    )
}

//================ Funciones del selector de los puntos de peligro =================
@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun SelectorGravedad(
    gravedad: Byte,
    onGravedadChange: (Byte) -> Unit
) {
    var expanded by remember { mutableStateOf(false) }
    val opciones = (1..5).map { it.toByte() }

    ExposedDropdownMenuBox(
        expanded = expanded,
        onExpandedChange = { expanded = !expanded }
    ) {
        TextField(
            value = gravedad.toString(),
            onValueChange = {},
            readOnly = true,
            label = { Text("Gravedad") },
            trailingIcon = {
                ExposedDropdownMenuDefaults.TrailingIcon(expanded)
            },
            modifier = Modifier.menuAnchor()
        )

        ExposedDropdownMenu(
            expanded = expanded,
            onDismissRequest = { expanded = false }
        ) {
            opciones.forEach {
                DropdownMenuItem(
                    text = { Text(it.toString()) },
                    onClick = {
                        onGravedadChange(it)
                        expanded = false
                    }
                )
            }
        }
    }
}

@Composable
fun SelectorKilometro(
    kilometro: Double,
    onKilometroChange: (Double) -> Unit,
    step: Double = 1.0
) {
    Row(
        verticalAlignment = Alignment.CenterVertically
    ) {
        IconButton(
            onClick = {
                if (kilometro - step >= 0)
                    onKilometroChange(kilometro - step)
            }
        ) {
            Icon(Icons.Default.KeyboardArrowDown, contentDescription = "Restar")
        }

        Text(
            text = String.format("%.1f km", kilometro),
            modifier = Modifier.padding(horizontal = 12.dp)
        )

        IconButton(
            onClick = {
                onKilometroChange(kilometro + step)
            }
        ) {
            Icon(Icons.Default.KeyboardArrowUp, contentDescription = "Sumar")
        }
    }
}

//================ Dialogo de ruta =================
@Composable
fun DialogGuardarRuta(
    onDismiss: () -> Unit,
    onGuardar: (
        nombre: String,
        clasificacion: CLASIFICACION,
        nivelEsfuerzo: Byte,
        nivelRiesgo: Byte,
        tipoTerreno: Byte?,
        indicaciones: Byte?,
        temporadas: String?,
        accesibilidad: Boolean,
        rutaFamiliar: Boolean,
        recomendaciones: String?,
        zonaGeografica: String?
    ) -> Unit,
    mapView: MapView
) {
    var nombre by remember { mutableStateOf("") }
    var clasificacion by remember { mutableStateOf(CLASIFICACION.LINEAL) }
    var esfuerzo by remember { mutableStateOf(1) }
    var riesgo by remember { mutableStateOf(1) }
    var accesible by remember { mutableStateOf(false) }
    var familiar by remember { mutableStateOf(false) }
    var temporadas by remember { mutableStateOf("") }
    var recomendaciones by remember { mutableStateOf("") }
    var zona by remember { mutableStateOf("") }

    AlertDialog(
        onDismissRequest = onDismiss,
        title = { Text("Guardar ruta") },
        text = {
            Column(
                modifier = Modifier
                    .fillMaxWidth()
                    .verticalScroll(rememberScrollState()),
                verticalArrangement = Arrangement.spacedBy(14.dp)
            ) {

                TextField(
                    value = nombre,
                    onValueChange = { nombre = it },
                    label = { Text("Nombre de la ruta") }
                )

                SelectorClasificacion(clasificacion) {
                    clasificacion = it
                }

                NumericUpDown(
                    label = "Nivel de esfuerzo",
                    value = esfuerzo,
                    range = 1..5,
                    onChange = { esfuerzo = it }
                )

                NumericUpDown(
                    label = "Nivel de riesgo",
                    value = riesgo,
                    range = 1..5,
                    onChange = { riesgo = it }
                )

                TextField(
                    value = temporadas,
                    onValueChange = { temporadas = it },
                    label = { Text("Temporadas recomendadas") }
                )

                Row(verticalAlignment = Alignment.CenterVertically) {
                    Checkbox(accesible, { accesible = it })
                    Text("Accesible")
                }

                Row(verticalAlignment = Alignment.CenterVertically) {
                    Checkbox(familiar, { familiar = it })
                    Text("Ruta familiar")
                }

                TextField(
                    value = recomendaciones,
                    onValueChange = { recomendaciones = it },
                    label = { Text("Recomendaciones") }
                )

                TextField(
                    value = zona,
                    onValueChange = { zona = it },
                    label = { Text("Zona geográfica") }
                )
            }
        },
        confirmButton = {
            TextButton(onClick = {
                onGuardar(
                    nombre,
                    clasificacion,
                    esfuerzo.toByte(),
                    riesgo.toByte(),
                    null,
                    null,
                    temporadas.ifBlank { null },
                    accesible,
                    familiar,
                    recomendaciones.ifBlank { null },
                    zona.ifBlank { null }
                )
            }) {
                Text("Guardar")
            }
        }
    )
}

@Composable
fun SelectorClasificacion(
    clasificacion: CLASIFICACION,
    onChange: (CLASIFICACION) -> Unit
) {
    var expanded by remember { mutableStateOf(false) }

    Box {
        OutlinedButton(onClick = { expanded = true }) {
            Text("Clasificación: ${clasificacion.name}")
        }

        DropdownMenu(
            expanded = expanded,
            onDismissRequest = { expanded = false }
        ) {
            CLASIFICACION.values().forEach {
                DropdownMenuItem(
                    text = { Text(it.name) },
                    onClick = {
                        onChange(it)
                        expanded = false
                    }
                )
            }
        }
    }
}

@Composable
fun NumericUpDown(
    label: String,
    value: Int,
    range: IntRange,
    onChange: (Int) -> Unit
) {
    Column {
        Text(label)
        Row(verticalAlignment = Alignment.CenterVertically) {
            IconButton(
                onClick = { if (value > range.first) onChange(value - 1) }
            ) { Text("−") }

            Text(value.toString(), modifier = Modifier.padding(8.dp))

            IconButton(
                onClick = { if (value < range.last) onChange(value + 1) }
            ) { Text("+") }
        }
    }
}



